using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    private GameObject leftHandPannal;
    private TextMeshPro[] textList;

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

        //Instantiate(Node);

        leftHandPannal = GameObject.FindGameObjectWithTag("LeftHandPannal");
       
        //textList = leftHandPannal.GetComponentsInChildren<TextMeshPro>();
        //var temp = GameObject.FindGameObjectWithTag("LeftHandPannal").GetComponentInChildren<Canvas>();
       // Debug.Log(temp);

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

    //private void OnMouseDown()

    // GetComponent<Renderer>().material.color = new Color(transform.position.normalized.x, transform.position.normalized.y, transform.position.normalized.z, 1);

   

    public void OnSelectEnter()

    {
        //foreach(Node node in Neighbours)
        //{
        //    Vector3 currentPosition = node.GetPosition();
        //    Vector3 direction = currentPosition - GetPosition();

        //    node.transform.position = currentPosition-direction/2;
        //}
        foreach (Edge edge in Connections)
        {
            //edge.edge.material.color = Color.red;
            //edge.edge.startWidth = 0.2f;
            //edge.edge.endWidth = 0.2f;
            edge.isActive = true;
        }
    }

    //private void OnMouseUpAsButton()

    public void OnSelectOut()

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

    public void OnDisplaySelectIn()
    {
        leftHandPannal = GameObject.FindGameObjectWithTag("LeftHandPannal");
        if (leftHandPannal != null)
        {
            textList = leftHandPannal.GetComponentsInChildren<TextMeshPro>();
            textList[0].text = "Name: " + Name.text;
            textList[1].text = "DisplayName: " + displayName;
            textList[2].text = "ID: " + id;
            textList[3].text = "Type: " + type;
        }
    }
}
