using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandEventController : MonoBehaviour
{

    public XRController leftHandPannal;
    public XRController rightHandInteractLine;
    public XRController leftHandInteractLine;
    public InputHelpers.Button PannalEnableButton;//primaryButton
    public InputHelpers.Button InteractRayEnableButton;
    

    public bool EnableLeftHandPannal { get; set; } = true;
    public bool EnableLeftHandInteractLine { get; set; } = true;
    public bool EnableRightHandInteractLine { get; set; } = true;


    private bool switchingPrimaryButton = false;
    //private bool LeftHandIsActive = false;
    // Start is called before the first frame update

    private bool originValue;
    private bool newValue;
    void Start()
    {
        //LeftHandIsActive = leftHandInteractLine.isActiveAndEnabled; 
    }
    void Update()
    {

        //InputHelpers.IsPressed(leftHandInteractLine.inputDevice, PannalEnableButton, out bool isActived);
        //if (isActived)
        //{
        //    Trigger();

        //}
        InputHelpers.IsPressed(leftHandInteractLine.inputDevice, InteractRayEnableButton, out bool isActived);
        newValue = isActived;
        if (originValue!=newValue)
        {
            bool temp1 = originValue;
            bool temp2 = newValue;
            originValue=newValue;
            Debug.Log("Changed");
            if (temp1 == false && temp2 == true)
            {
                Debug.Log("Button Down Once");
            }
        }
        else
        {
            Debug.Log("Not Changed");
        }

    }
    public void Trigger()
    {
        if (leftHandInteractLine.gameObject.activeSelf)
        {
            leftHandInteractLine.gameObject.SetActive(false);
        }
        else if (!leftHandInteractLine.gameObject.activeSelf)
        {
            leftHandInteractLine.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (EnableLeftHandPannal)
    //    {
    //        leftHandPannal.gameObject.SetActive(EnableLeftHandPannal && CheckIfActivated(leftHandPannal));
    //        //if (CheckIfActivated(leftHandPannal))
    //        //{
    //        //    SwithBool(EnableLeftHandPannal);
    //        //    leftHandPannal.gameObject.SetActive(EnableLeftHandPannal);
    //        //}
    //    }
    //    if (true) 
    //    {
    //        CheckIfPBPressed(leftHandInteractLine);
    //        leftHandInteractLine.gameObject.SetActive(EnableLeftHandInteractLine && switchingPrimaryButton);
    //        leftHandInteractLine.gameObject.SetActive(true);

    //    }

    //    if (EnableRightHandInteractLine)
    //    {
    //        rightHandInteractLine.gameObject.SetActive(EnableRightHandInteractLine && CheckIfActivated(rightHandInteractLine));
    //        //if (CheckIfActivated(rightHandInteractLine))
    //        //{
    //        //    SwithBool(EnableRightHandInteractLine);
    //        //    rightHandInteractLine.gameObject.SetActive(EnableRightHandInteractLine);
    //        //}
    //    }
    //}

    public bool CheckIfPannalActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, PannalEnableButton, out bool isActived);
        

        return isActived;
    }
    public void Func()
    {
        

    }
    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, PannalEnableButton, out bool isActived);

        return isActived;
    }

    public bool CheckIfPBPressed(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, InteractRayEnableButton, out bool isPressed);
        if (isPressed)
        {
           return SwithPrimaryButtonBool();
        }
        else
        {
            return false;
        }
    }

    public bool SwithPrimaryButtonBool()
    {
        switchingPrimaryButton = !switchingPrimaryButton; 
        Debug.Log("SwitchTriggered");
        return switchingPrimaryButton;
    }


    public void EnableInteractRay(XRController controller , bool bool1)
    {
        controller.gameObject.SetActive(EnableLeftHandPannal && bool1);
       // LeftHandIsActive = true;
    }
}
