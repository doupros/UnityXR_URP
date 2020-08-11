using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public string id;
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

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {

        Renderer rend = GetComponent<Renderer>();

        rend.enabled = true;
        //GetComponent<Renderer>().material.color = Color.red;
        switch (type)
        {
            case "RProtein":
                //Vector3 pos = new Vector3(Random.Range(1, 40), 1, Random.Range(1, 40));
                //transform.position = pos;
                //  GetComponent<Renderer>().material.color = Color.red;
                rend.sharedMaterial = material[0];
                break;
            case "RPathway":
                //Vector3 pos1 = new Vector3(Random.Range(1, 40), 10, Random.Range(1, 40));
                //transform.position = pos1;
                rend.sharedMaterial = material[1];

                //GetComponent<Renderer>().material.color = Color.green;
                break;
            case "RGene":
                //Vector3 pos2 = new Vector3(Random.Range(1, 40), 20, Random.Range(1, 40));
                //transform.position = pos2;
                rend.sharedMaterial = material[2];

                // GetComponent<Renderer>().material.color = Color.blue;
                break;
        }
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    // Update is called once per frame
    void Update()
    {
       // GetComponent<Renderer>().material.color = new Color(transform.position.normalized.x, transform.position.normalized.y, transform.position.normalized.z, 1);

    }

    private void OnMouseEnter()
    {
        //GetComponent<Renderer>().material.color = Color.red;

        foreach (Edge edge in Connections)
        {

            edge.edge.material.color = Color.green;
            edge.edge.SetWidth(0.5f, 0.5f);
            edge.edge.SetPosition(0, transform.position);
            edge.edge.SetPosition(1, edge.target.transform.position);
        }
    }
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = new Color(transform.position.normalized.x, transform.position.normalized.y, transform.position.normalized.z, 1);
        foreach (Edge edge in Connections)
        {

            edge.edge.material.color = Color.gray;
            edge.edge.SetWidth(0.02f, 0.02f);
        }
    }
}
