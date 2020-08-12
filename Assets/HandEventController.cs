using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandEventController : MonoBehaviour
{

    public XRController leftHandPannal;
    public XRController rightHandInteractLine;
    public InputHelpers.Button PannalEnableButton;
    

    public bool EnableLeftHandPannal { get; set; } = true;
    public bool EnableRightHandInteractLine { get; set; } = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnableLeftHandPannal)
        {
            leftHandPannal.gameObject.SetActive(EnableLeftHandPannal && CheckIfActivated(leftHandPannal));
        }
        if (EnableRightHandInteractLine)
        {
            rightHandInteractLine.gameObject.SetActive(EnableRightHandInteractLine && CheckIfActivated(rightHandInteractLine));
        }
      
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, PannalEnableButton, out bool isActived);

        return isActived;
    }
}
