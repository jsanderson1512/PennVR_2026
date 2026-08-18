using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Custom_OculusInput_ToggleObjectVisibility : MonoBehaviour
{
    private bool triggerDown = false;
    private float triggerDownTolerance = 0.6f;
    private float triggerUpTolerance = 0.4f;
    private bool gripDown = false;
    private float gripDownTolerance = 0.6f;
    private float gripUpTolerance = 0.4f;

    private bool joystickDown = false;
    private float joystickDownTolerance = 0.6f;
    private float joystickUpTolerance = 0.4f;
    public bool isLeftHand = false;


    public UnityEvent TriggerClickFunction;
    public UnityEvent TriggerUnClickFunction;

    public UnityEvent GripClickFunction;
    public UnityEvent GripUnClickFunction;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkForOculusInput();




        if(Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("fake trigger click button");
            TriggerClick();
        }
        if(Input.GetKeyUp(KeyCode.U))
        {
            Debug.Log("fake trigger un click button");
            TriggerUnClick();
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("fake grip click button");
            GripClick();
        }
        if(Input.GetKeyUp(KeyCode.I))
        {
            Debug.Log("fake grip un click button");
            GripUnClick();
        }

    }




    void checkForOculusInput()
    {
        //OCULUS TOUCH TRIGGERS
        if (isLeftHand)
        {
            float LTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);//(range of 0.0f to 1.0f)
            if (!triggerDown)
            {
                if (LTrigger > triggerDownTolerance)
                {
                    Debug.Log("Trigger clicked.");
                    triggerDown = true;
                    TriggerClick();
                }
            }
            else
            {
                if (LTrigger < triggerUpTolerance)
                {
                    Debug.Log("Trigger unclicked.");
                    triggerDown = false;
                    TriggerUnClick();
                }
            }
        }
        else
        {
            float RTrigger = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);//(range of 0.0f to 1.0f)
            if (!triggerDown)
            {
                if (RTrigger > triggerDownTolerance)
                {
                    Debug.Log("Trigger clicked.");
                    triggerDown = true;
                    TriggerClick();
                }
            }
            else
            {
                if (RTrigger < triggerUpTolerance)
                {
                    Debug.Log("Trigger unclicked.");
                    triggerDown = false;
                    TriggerUnClick();
                }
            }
        }






        //OCULUS TOUCH GRIPS
        if (isLeftHand)
        {
            float LGrip = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);//(range of 0.0f to 1.0f)
            if (!gripDown)
            {
                if (LGrip > gripDownTolerance)
                {
                    Debug.Log("Grip clicked.");
                    gripDown = true;
                    GripClick();
                }
            }
            else
            {
                if (LGrip < gripUpTolerance)
                {
                    Debug.Log("Grip unclicked.");
                    gripDown = false;
                    GripUnClick();
                }
            }
        }
        else
        {
            float RGrip = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);//(range of 0.0f to 1.0f)
            if (!gripDown)
            {
                if (RGrip > gripDownTolerance)
                {
                    Debug.Log("Grip clicked.");
                    gripDown = true;
                    GripClick();
                }
            }
            else
            {
                if (RGrip < gripUpTolerance)
                {
                    Debug.Log("Grip unclicked.");
                    gripDown = false;
                    GripUnClick();
                }
            }
        }










        //OCULUS TOUCH JOYSTICKS
        if (isLeftHand)
        {
            //OCULUS TOUCH JOYSTICKS
            Vector2 LJoystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);//(X/Y range of -1.0f to 1.0f)
            if (!joystickDown)
            {
                if (LJoystick.x > joystickDownTolerance)
                {
                    Debug.Log("Joystick clicked right.");
                    joystickDown = true;
                    JoyRightClick();
                }
                else if (LJoystick.x < -joystickDownTolerance)
                {
                    Debug.Log("Joystick clicked left.");
                    joystickDown = true;
                    JoyLeftClick();
                }
            }
            else
            {
                //if the absolute value of both joysticks is less than the tolerance, we have unclicked
                if (Math.Abs(LJoystick.x) < joystickUpTolerance)
                {
                    Debug.Log("Joystick unclicked.");
                    joystickDown = false;
                }
            }
        }
        else
        {
            //OCULUS TOUCH JOYSTICKS
            Vector2 RJoystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);//(X/Y range of -1.0f to 1.0f)
            if (!joystickDown)
            {
                if (RJoystick.x > joystickDownTolerance)
                {
                    Debug.Log("Joystick clicked right.");
                    joystickDown = true;
                    JoyRightClick();
                }
                else if (RJoystick.x < -joystickDownTolerance)
                {
                    Debug.Log("Joystick clicked left.");
                    joystickDown = true;
                    JoyLeftClick();
                }
            }
            else
            {
                //if the absolute value of both joysticks is less than the tolerance, we have unclicked
                if (Math.Abs(RJoystick.x) < joystickUpTolerance)
                {
                    Debug.Log("Joystick unclicked.");
                    joystickDown = false;
                }
            }
        }
    }

    void JoyRightClick()
    {

    }
    void JoyLeftClick()
    {

    }
    void TriggerClick()
    {

        TriggerClickFunction.Invoke();


    }

    void TriggerUnClick()
    {
        TriggerUnClickFunction.Invoke();

    }

    void GripClick()
    {

        GripClickFunction.Invoke();


    }


    void GripUnClick()
    {
        GripUnClickFunction.Invoke();

    }
}
