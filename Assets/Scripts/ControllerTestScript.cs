using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTestScript : MonoBehaviour
{
    public bool rockband;
    public bool testInput;

    private void FixedUpdate()
    {
        if (testInput)
        {
            ShowInput();
        }
        else
        {
            GetInput();
        }
    }


    private void GetInput()
    {
        //Code to figure which button being pressed by controller
        if (rockband)
        {
            float whammy = Input.GetAxis("RBWhammy");
            float strum = Input.GetAxis("RBStrum");

            if (Input.GetButtonDown("RBGreen"))
            {
                if (Input.GetButtonDown("High Fret"))
                {
                    print("high green");
                }
                else
                {
                    print("low green");
                }
            }

            if (Input.GetButtonDown("RBRed"))
            {

                if (Input.GetButtonDown("High Fret"))
                {

                    print("high red");

                }
                else
                {

                    print("low red");

                }

            }

            if (Input.GetButtonDown("RBYellow"))
            {

                if (Input.GetButtonDown("High Fret"))
                {

                    print("high yellow");
                }
                else
                {
                    print("low yellow");
                }
            }

            if (Input.GetButtonDown("RBBlue"))
            {
                if (Input.GetButtonDown("High Fret"))
                {
                    print("high blue");
                }
                else
                {
                    print("low blue");
                }
            }

            if (Input.GetButtonDown("RBOrange"))
            {
                if (Input.GetButtonDown("High Fret"))
                {
                    print("high orange");
                }
                else
                {
                    print("low orange");
                }
            }

            if (Input.GetButtonDown("RBStart"))
            {
                print("start");
            }

            if (Input.GetButtonDown("RBSelect"))
            {
                print("select");
            }

            if (whammy > 0.2f || whammy < -0.2f)
            {
                print("whammy bar");
            }

            if (strum > 0.2f || strum < -0.2f)
            {
                print("strum");
            }
        }
        else
        {
            float strum = Input.GetAxis("GHStrum");

            if (Input.GetButtonDown("GHGreen"))
            {
                print("green");
            }

            if (Input.GetButtonDown("GHRed"))
            {
                print("red");
            }

            if (Input.GetButtonDown("GHYellow"))
            {
                print("yellow");
            }

            if (Input.GetButtonDown("GHBlue"))
            {
                print("blue");
            }

            if (Input.GetButtonDown("GHOrange"))
            {
                print("orange");
            }

            if (Input.GetButtonDown("GHStart"))
            {
                print("start");
            }

            if (Input.GetButtonDown("GHSelect"))
            {
                print("select");
            }

            if (Input.GetAxis("GHWhammy") > -1f)
            {
                print("whammy bar");
            }

            if (strum > 0.2f || strum < -0.2f)
            {
                print("Strumming: " + strum);
            }
            float StarPower = Input.GetAxis("GHStarPower");
            print("Starpower: " + StarPower);
        }
    }


    private void ShowInput()
    {
        System.Array values = System.Enum.GetValues(typeof(KeyCode));
        foreach (KeyCode code in values)
        {
            if (Input.GetKeyDown(code)) { print(System.Enum.GetName(typeof(KeyCode), code)); }
        }
    }
}

