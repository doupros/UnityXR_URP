using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyDetactor : MonoBehaviour
{
    private TextMeshPro playerTextOutput;

    // Start is called before the first frame update
    void Start()
    {
        playerTextOutput = GameObject.FindGameObjectWithTag("PlayerTextOutput").GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhenTriggered()
    {
        //var key = gameObject.GetComponentInChildren<GameObject>().GetComponentInChildren<TextMeshPro>();
        var key = gameObject.GetComponentInChildren<TextMeshPro>();
        if (key != null)
        {
            if (gameObject.GetComponent<KeyFeedBack>().KeyCanBeHitAgain)
            {
                if (key.text == "SPACE")
                {
                    playerTextOutput.text += " ";
                }
                else if (key.text == "<-")
                {
                    if (playerTextOutput.text.Length > 0)
                    {
                        playerTextOutput.text = playerTextOutput.text.Substring(0, playerTextOutput.text.Length - 1);
                    }
                }
                else
                {
                    playerTextOutput.text += key.text;
                }
            }
        }
    }
    
}
