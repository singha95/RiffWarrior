using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    public UnityEngine.UI.Button[] buttons;
    public PlayerController.Controller controller;
    int currentBtn;

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void Start()
    {
        currentBtn = 1;

        highlightNextBtn(-1);
    }

    private void highlightNextBtn(int direction)
    {
        buttons[currentBtn].OnPointerExit(null);

        currentBtn += direction;
        if (currentBtn == buttons.Length)
        {
            currentBtn = 0;
        }
        else if (currentBtn == -1)
        {
            currentBtn = buttons.Length - 1;
        }

        buttons[currentBtn].OnPointerEnter(null);
    }

    private void Update()
    {
        switch (controller)
        {
            case PlayerController.Controller.GUITARHERO:
                GuitarControls("GH");
                break;
            case PlayerController.Controller.ROCKBAND:
                GuitarControls("RB");
                break;
            case PlayerController.Controller.KEYBOARD:
                KeyboardControlls();
                break;
        }
    }

    private void GuitarControls(string prefix)
    {
        if (Input.GetButtonDown(prefix + "Green"))
        {
            highlightNextBtn(-1);
        }
        else if (Input.GetButtonDown(prefix + "Red"))
        {
            highlightNextBtn(1);
        }

        float strum = Input.GetAxis(prefix + "Strum");
        if (strum != 0)
        {
            buttons[currentBtn].onClick.Invoke();
        }
    }

    private void KeyboardControlls()
    {
        if (Input.GetButtonDown("Left"))
        {
            highlightNextBtn(-1);
        }
        else if (Input.GetButtonDown("Right"))
        {
            highlightNextBtn(1);
        }

        float strum = Input.GetAxis("Submit");
        if (strum != 0)
        {
            buttons[currentBtn].onClick.Invoke();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
