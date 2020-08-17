using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandEventController : MonoBehaviour
{

    public XRController leftHandPannal;
    public XRController rightHandInteractLine;
    public XRController leftHandInteractLine;
    public InputHelpers.Button PannalEnableButton; //primaryButton
    public InputHelpers.Button InteractRayEnableButton; //sconderyButton


    //public bool EnableLeftHandPannal { get; set; } = true;
    //public bool EnableLeftHandInteractLine { get; set; } = true;
    //public bool EnableRightHandInteractLine { get; set; } = true;


    // private bool switchingPrimaryButton = false;
    //private bool LeftHandIsActive = false;
    // Start is called before the first frame update

    private bool originValueLeft;
    private bool newValueLeft;
    private bool originValueLeftP;
    private bool newValueLeftP;
    private bool originValueRight;
    private bool newValueRight;
    private int countLeft = 0;
    private int countLeftP = 0;
    private int countRight = 0;

    void Start()
    {
        leftHandInteractLine.gameObject.SetActive(false);
        rightHandInteractLine.gameObject.SetActive(false);
        leftHandPannal.gameObject.SetActive(false);
    }
    void Update()
    {
        LeftHandLineTrigger();
        RightHandLineTrigger();
        LeftPannalTrigger();
    }
    private void LeftHandLineTrigger()
    {
        InputHelpers.IsPressed(leftHandInteractLine.inputDevice, InteractRayEnableButton, out bool isActived);
        newValueLeft = isActived;
        if (originValueLeft != newValueLeft)
        {
            originValueLeft = newValueLeft;
            //Debug.Log("Changed");
            countLeft++;
            leftHandInteractLine.gameObject.SetActive(countLeft % 4 == 0);
        }
    }
    private void RightHandLineTrigger()
    {
        InputHelpers.IsPressed(rightHandInteractLine.inputDevice, InteractRayEnableButton, out bool isActived);
        newValueRight = isActived;
        if (originValueRight != newValueRight)
        {
            originValueRight = newValueRight;
            //Debug.Log("Changed");
            countRight++;
            rightHandInteractLine.gameObject.SetActive(countRight % 4 == 0);
        }
    }

    private void LeftPannalTrigger()
    {
        InputHelpers.IsPressed(leftHandPannal.inputDevice, PannalEnableButton, out bool isActived);
        newValueLeftP = isActived;
        if (originValueLeftP != newValueLeftP)
        {
            originValueLeftP = newValueLeftP;
            // Debug.Log("Changed");
            countLeftP++;
            leftHandPannal.gameObject.SetActive(countLeftP % 4 == 0);
        }
    }

}

        
    

    //public void Trigger()
    //{
    //    if (leftHandInteractLine.gameObject.activeSelf)
    //    {
    //        leftHandInteractLine.gameObject.SetActive(false);
    //    }
    //    else if (!leftHandInteractLine.gameObject.activeSelf)
    //    {
    //        leftHandInteractLine.gameObject.SetActive(true);
    //    }
    //}

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
//    public bool CheckIfPannalActivated(XRController controller)
//    {
//        InputHelpers.IsPressed(controller.inputDevice, PannalEnableButton, out bool isActived);

//        return isActived;
//    }

//    public bool CheckIfActivated(XRController controller)
//    {
//        InputHelpers.IsPressed(controller.inputDevice, PannalEnableButton, out bool isActived);
//        return isActived;
//    }

//    public bool CheckIfPBPressed(XRController controller)
//    {
//        InputHelpers.IsPressed(controller.inputDevice, InteractRayEnableButton, out bool isPressed);
//        if (isPressed)
//        {
//           return SwithPrimaryButtonBool();
//        }
//        else
//        {
//            return false;
//        }
//    }

//    public bool SwithPrimaryButtonBool()
//    {
//        switchingPrimaryButton = !switchingPrimaryButton; 
//        Debug.Log("SwitchTriggered");
//        return switchingPrimaryButton;
//    }


//    public void EnableInteractRay(XRController controller , bool bool1)
//    {
//        controller.gameObject.SetActive(EnableLeftHandPannal && bool1);
//       // LeftHandIsActive = true;
//    }
//}
