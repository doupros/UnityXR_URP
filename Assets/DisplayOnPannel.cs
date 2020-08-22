using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayOnPannel : MonoBehaviour
{
    public Node node;

    private GameObject pannalLeft;
    private Text nodeName;
    private Text nodeID;
    private Text nodeDisplayName;
    private Text nodeType;

    private Text[] nodeElements;

    // Start is called before the first frame update
    void Start()
    {
        //pannalLeft = GameObject.FindGameObjectWithTag("LeftHandPannal");
       // Debug.Log(pannalLeft);
        //nodeName = pannalLeft.GetComponentInChildren<Text>();
       // nodeElements = pannalLeft.GetComponents<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (nodeElements[0])
        //{
        //Debug.Log(nodeElements[0].text);

        //}
        
       // nodeElements[0].text = node.Name.text;
        //nodeElements[1].text = node.displayName;
    }
}
