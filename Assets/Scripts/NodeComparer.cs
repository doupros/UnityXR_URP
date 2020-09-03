using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeComparer : MonoBehaviour
{
    public Node node1;
    public Node node2;

    public List<Node> node1Neihbours;
    public List<Node> node2Neihbours;


    // Start is called before the first frame update
    void Start()
    {

    }
    public void CompareNodes(Node a, Node b)
    {
        node1 = a;
        node2 = b;

        node1 = Instantiate(a, transform.Find("Node1Holder").position, Quaternion.identity, transform.Find("Node1Holder"));
        node2 = Instantiate(b, transform.Find("Node2Holder").position, Quaternion.identity, transform.Find("Node2Holder"));

        foreach (Node neighbour in node1.Neighbours)
        {
            if (node1 == neighbour)
            {
                break;
            }
            node1Neihbours.Add(neighbour);
            //Instantiate(neighbour, node1.transform.position + Random.onUnitSphere, Quaternion.identity, node1.transform);
        }
        foreach (Node neighbour in node2.Neighbours)
        {
            if (node2 == neighbour)
            {
                break;
            }
            node2Neihbours.Add(neighbour);
           // Instantiate(neighbour, node2.transform.position + Random.onUnitSphere, Quaternion.identity, node2.transform);
        }

        foreach(Node node in node1Neihbours)
        {
            Instantiate(node, node1.transform.position + Random.onUnitSphere, Quaternion.identity, node1.transform);
        }
        foreach (Node node in node2Neihbours)
        {
            Instantiate(node, node2.transform.position + Random.onUnitSphere, Quaternion.identity, node2.transform);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
