using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    public Node nude;
    public GameObject nodePrefab;
    public string name;
    public float number;
    private void Start()
    {
        GameObject spawnedNode = Instantiate(nodePrefab, transform);
        number = spawnedNode.GetComponent<Node>().number;
        name = spawnedNode.GetComponent<Node>().name;
    }

    public void test1()
    {
        Debug.Log("testing interact");
        Debug.Log(name);
        Debug.Log(number);
    }

    public void testActive() 
    {
        Debug.Log("testing active");
    }
}
