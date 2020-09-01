using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Node : MonoBehaviour
{
    public Graph graph;

    public TextMeshPro Name;
    public string id;
    public long intiID;
    public string displayName;
    public string type;

    public Material[] material;
    //public string SUID;
    //public string shared_name;
    //public string primaryDataset;

    //public string domainID;

    //public string uid;
    //public string refSeqId;
    //public string unitprotEntryName; 

    public List<Node> Neighbours;
    public List<Edge> Connections;

    public bool isVisited = false;

    //public bool isActive = true;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        Name.text = displayName;
        rend = GetComponent<Renderer>();

        rend.enabled = true;
        switch (type)
        {
            case "RProtein":
            case "Protein":
                rend.sharedMaterial = material[0];
                break;
            case "RPathway":
            case "Pathway":
                rend.sharedMaterial = material[1];
                break;
            case "RGene":
            case "Gene":
                rend.sharedMaterial = material[2];
                break;
            case "Disorder":
                rend.sharedMaterial = material[3];
                break;
        }
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    //private void setID(string omg)
    //{
    //    intiID = System.Int64.Parse(omg);
    //}
    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        //foreach(Node node in Neighbours)
        //{
        //    Vector3 currentPosition = node.GetPosition();
        //    Vector3 direction = currentPosition - GetPosition();

        //    node.transform.position = currentPosition-direction/2;
        //}
        foreach (Edge edge in Connections)
        {
            edge.edge.material.color = Color.red;
            edge.edge.startWidth = 0.2f;
            edge.edge.endWidth = 0.2f;
            edge.isActive = true;
        }
    }
    private void OnMouseUpAsButton()
    {
        //foreach (Node node in Neighbours)
        //{
        //    Vector3 currentPosition = node.GetPosition();
        //    Vector3 direction = currentPosition - GetPosition();

        //    node.transform.position = currentPosition + direction * 2;
        //}
        foreach (Edge edge in Connections)
        {
            edge.isActive = false;
        }
    }
}
