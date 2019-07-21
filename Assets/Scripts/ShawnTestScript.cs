using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShawnTestScript : MonoBehaviour
{
    public Controller controller;
    public Variation variation;
    private Animator animator;

    // Free Walk Variables
    public float speed;
    public float rotationSpeed;

    // Grid Walk Variables
    public int stepTime;
    public int movementDistance;
    public int gridRotationSpeed;
    private float turnAmount;
    private float moveAmount;


    public enum Controller
    {
        GUITARHERO,
        ROCKBAND,
        KEYBOARD
    }

    public enum Variation
    {
        ARROW_KEYS,
        PEDAL_STEP,
        STRUM_TURN,
        AXIS_WALK,
    }

    void Start()
    {
        //rigidbody = gameObject.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (variation)
        {
            case Variation.ARROW_KEYS:
                ArrowKeyWalk();
                break;
            case Variation.AXIS_WALK:
                AxisWalk();
                break;
            case Variation.PEDAL_STEP:
                PedalStep();
                break;
            case Variation.STRUM_TURN:
                StrumTurn();
                break;
        }
        if (variation == Variation.ARROW_KEYS)
        {
            ArrowKeyWalk();
        }
    }

    /*****************   Basic Keyboard Arrow  ***************************/

    private void ArrowKeyWalk()
    {
        if (Input.GetButton("Up"))
        {
            FreeWalk(1);
        }
        else if (Input.GetButton("Down"))
        {
            FreeWalk(-1);
        }
        else
        {
            FreeWalk(0);
        }

        if (Input.GetButton("Right"))
        {
            FreeRotate(1);
        }
        else if (Input.GetButton("Left"))
        {
            FreeRotate(-1);
        }
    }

    public void FreeRotate(float direction)
    {
        transform.Rotate(Vector3.up * direction * Time.deltaTime * rotationSpeed);
    }

    public void FreeWalk(float direction)
    {
        if (direction != 0)
        {
            if (!animator.GetBool("IsWalking"))
            {
                animator.SetBool("IsWalking", true);
            }

            transform.Translate(Vector3.forward * direction * speed * Time.deltaTime);
        }
        else if (animator.GetBool("IsWalking"))
        {
            animator.SetBool("IsWalking", false);
        }
    }

    /*****************   Raising Lowering Guitar w/ Green/Red, Left/Right turning   ***************************/

    private void AxisWalk()
    {
        switch (controller)
        {
            case Controller.KEYBOARD:
                ArrowKeyWalk();
                break;

        }
    }

    /*****************   Pedal Grid Movement   ***************************/

    private void PedalStep()
    {
        switch (controller)
        {
            case Controller.KEYBOARD:
                GridWalkKeyboard();
                break;
            case Controller.GUITARHERO:
                GridWalkGH();
                break;
            case Controller.ROCKBAND:
                GridWalkRB();
                break;
        }
    }

    private void GridWalkKeyboard()
    {
        if (moveAmount + turnAmount == 0)
        {
            if (animator.GetBool("IsWalking"))
            {
                animator.SetBool("IsWalking", false);
            }

            if (Input.GetButtonDown("Up"))
            {
                moveAmount += movementDistance;

                if (!animator.GetBool("IsWalking"))
                {
                    animator.SetBool("IsWalking", true);
                }

            }
            else if (Input.GetButtonDown("Down"))
            {
                moveAmount -= movementDistance;

                if (!animator.GetBool("IsWalking"))
                {
                    animator.SetBool("IsWalking", true);
                }
            }
            else if (Input.GetButtonDown("Left"))
            {
                turnAmount -= 90;
            }
            else if (Input.GetButtonDown("Right"))
            {
                turnAmount += 90;
            }
        }

        GridMove();
    }

    private void GridWalkGH()
    {
        if (moveAmount + turnAmount == 0)
        {
            if (animator.GetBool("IsWalking"))
            {
                animator.SetBool("IsWalking", false);
            }

            float strum = Input.GetAxis("GHStrum");

            if (Input.GetButtonDown("GHPedal"))
            {
                moveAmount += movementDistance;
                if (!animator.GetBool("IsWalking"))
                {
                    animator.SetBool("IsWalking", true);
                }

            }
            // Left
            else if (strum > 0.2)
            {
                turnAmount -= 90;
            }
            // RIght
            else if (strum < -0.2)
            {
                turnAmount += 90;
            }
        }

        GridMove();
    }

    private void GridWalkRB()
    {
        if (moveAmount + turnAmount == 0)
        {
            if (animator.GetBool("IsWalking"))
            {
                animator.SetBool("IsWalking", false);
            }

            float strum = Input.GetAxis("RBStrum");

            if (Input.GetButtonDown("RBPedal"))
            {
                moveAmount += movementDistance;
                if (!animator.GetBool("IsWalking"))
                {
                    animator.SetBool("IsWalking", true);
                }

            }
            // Left
            else if (strum > 0.2)
            {
                turnAmount -= 90;
            }
            // RIght
            else if (strum < -0.2)
            {
                turnAmount += 90;
            }
        }

        GridMove();
    }

    private void GridMove()
    {
        // Spin Player
        if (turnAmount != 0)
        {
            // Use up leftover rotation at once
            if (turnAmount < 1 && turnAmount > -1)
            {
                transform.Rotate(Vector3.up * turnAmount);
                turnAmount = 0;
            }

            transform.Rotate(Vector3.up * turnAmount * Time.deltaTime * gridRotationSpeed);
            turnAmount -= (turnAmount * Time.deltaTime * gridRotationSpeed);
        }

        // Move Player
        if (moveAmount != 0)
        {
            float moveDiff = movementDistance * Time.deltaTime / stepTime * (moveAmount / Mathf.Abs(moveAmount));

            // Use up leftover movement at once
            if ((moveDiff > 0 && moveAmount < moveDiff) || (moveDiff < 0 && moveAmount > moveDiff))
            {
                transform.Translate(Vector3.forward * moveAmount);
                moveAmount = 0;
            }
            else
            {
                transform.Translate(Vector3.forward * moveDiff);
                moveAmount -= moveDiff;
            }
        }
    }

    /*****************   Strum free movement   ***************************/

    private void StrumTurn()
    {
        switch (controller)
        {
            case Controller.KEYBOARD:
                StrumWalkKeyboard();
                break;
            case Controller.GUITARHERO:
                StrumWalkGH();
                break;
            case Controller.ROCKBAND:
                StrumWalkRB();
                break;
        }
    }

    private void StrumWalkKeyboard()
    {

    }

    private void StrumWalkGH()
    {
        if (Input.GetButton("GHGreen"))
        {
            FreeWalk(1);
        }
        else if (Input.GetButton("GHRed"))
        {
            FreeWalk(-1);
        }
        else
        {
            FreeWalk(0);
        }
        
        FreeRotate(Input.GetAxis("GHStrum"));
    }

    private void StrumWalkRB()
    {

    }
}
