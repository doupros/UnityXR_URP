using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class GraphReader : MonoBehaviour
{
    public Graph Graph;
    public Node nodePrefab;
    public Edge edgePrefab;
    public Hashtable NodesHash;
    public Hashtable NodeNameHash { get; set; }

    //public List<Node> Nodes;
    //public List<Edge> Edges;
    public bool again;

    // Start is called before the first frame update
    public void Start()
    {
        NodesHash = new Hashtable();
        NodeNameHash = new Hashtable();


        ///---------------- LOAD SOURCE FILE------------
        //string sourceFile = Application.dataPath + "/Data/random10_15Graph.graphml";
        //string sourceFile = Application.dataPath + "/Data/random100_300Graph.graphml";
        string sourceFile = Application.dataPath + "/Data/proteins.graphml";
        //string sourceFile = Application.dataPath + "/Data/subset.graphml";

        XmlDocument graphmlDoc = new XmlDocument();
        Debug.Log(Time.time);
        graphmlDoc.Load(sourceFile);

        XmlElement root = graphmlDoc.GetElementsByTagName("graphml")[0] as XmlElement;

        // -------close document
        //---- option monad
        if (root == null)
        {
            root = graphmlDoc.FirstChild as XmlElement;
        }

        for (int i = 0; i < root.ChildNodes.Count; ++i)
        {
            XmlElement xmlGraph = root.ChildNodes[i] as XmlElement;
            for (int j = 0; j < xmlGraph.ChildNodes.Count; ++j)
            {
                XmlElement xmlNode = xmlGraph.ChildNodes[j] as XmlElement;

                if (xmlNode.Name == "node")
                {

                    Vector3 random_starting_position = Random.onUnitSphere * 7;

                    //random_starting_position.y = 0;
                    Node node = Instantiate(nodePrefab, random_starting_position, Quaternion.identity, Graph.transform) as Node;

                    node.id = xmlNode.Attributes["id"].Value;

                    NodesHash.Add(node.id, node);

                    //node.displayName = node.id;

                    NodeNameHash.Add(node.Name, node);  
                    Graph.Nodes.Add(node);


                    for (int k = 0; k < xmlNode.ChildNodes.Count; k++)
                    {
                        XmlElement nodeData = xmlNode.ChildNodes[k] as XmlElement;
                        if (nodeData.Name == "data")
                        {
                            string dataValue = nodeData.Attributes["key"].Value;

                            switch (dataValue)
                            {
                                case "type":
                                case "d2":
                                    node.type = nodeData.InnerText;
                                    break;
                                case "displayName":

                                case "d1":
                                    node.displayName = nodeData.InnerText;
                                    break;
                            }
                        }
                    }
                }
                if (xmlNode.Name == "edge")
                {
                    Edge edge = Instantiate(edgePrefab, new Vector3(0, 0, 0), Quaternion.identity, Graph.transform) as Edge;
                    edge.sourceID = xmlNode.Attributes["source"].Value;
                    edge.targetID = xmlNode.Attributes["target"].Value;

                    Graph.Edges.Add(edge);
                }
            }
        }
        Debug.Log(Time.realtimeSinceStartup);
        MapEdges();
       // again = true;
    }

    private void MapEdges()
    {
        foreach (Edge edge in Graph.Edges)
        {
            edge.source = NodesHash[edge.sourceID] as Node;
            edge.target = NodesHash[edge.targetID] as Node;

            edge.source.Neighbours.Add(edge.target);
            edge.target.Neighbours.Add(edge.source);

            edge.source.Connections.Add(edge);
            edge.target.Connections.Add(edge);
        }
    }


    // Update is called once per frame
    void Update()
    {


    }
}