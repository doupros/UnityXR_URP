using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TestActive()
    {
        Debug.Log("Avtive triggered");
    }

    public void TestDeactive() 
    {
        Debug.Log("Deavtive triggered");
    }
    public void TestSelectIn()
    {
        Debug.Log("Select triggered");
    }
    public void TestSelectOut()
    {
        Debug.Log("Deselect triggered");
    }


}
