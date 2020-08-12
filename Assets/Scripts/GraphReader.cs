using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class GraphReader : MonoBehaviour
{
    public ForceBasedGraph Graph;
    public Node nodePrefab;
    public Edge edgePrefab;
    public Hashtable NodesHash;
    public List<Node> Nodes;
    public List<Edge> Edges;
    public bool again;

    
    // Start is called before the first frame update
    public void Start()
    {
 
        NodesHash = new Hashtable();
        Graph = new ForceBasedGraph();
        ///---------------- LOAD SOURCE FILE------------
        //string sourceFile = Application.dataPath + "/Data/random100_300Graph.graphml";
        string sourceFile = Application.dataPath + "/Data/proteins.graphml";

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

        for(int i = 0; i<root.ChildNodes.Count; ++i)
        {
            XmlElement xmlGraph = root.ChildNodes[i] as XmlElement;
            for(int j=0; j<xmlGraph.ChildNodes.Count; ++j)
            {
                XmlElement xmlNode = xmlGraph.ChildNodes[j] as XmlElement;

                if (xmlNode.Name == "node")
                {
                    Vector3 random_starting_position = Random.onUnitSphere * 7;
                    Node node = Instantiate(nodePrefab, random_starting_position, Quaternion.identity) as Node;

                    //Node nodetest = new Node();               
                    node.id = xmlNode.Attributes["id"].Value;
                    //nodetest.id = xmlNode.Attributes["id"].Value;
                    //Nodes.Add(nodetest);
                    NodesHash.Add(node.id, node);
                    Nodes.Add(node);

                    for (int k = 0; k < xmlNode.ChildNodes.Count; k++)
                    {

                        XmlElement nodeData = xmlNode.ChildNodes[k] as XmlElement;
                        if (nodeData.Name == "data")
                        {
                            string dataValue = nodeData.Attributes["key"].Value;

                           // Renderer rend = nodeObject.GetComponent<Renderer>();
                           // rend.enabled = true;
                            switch (dataValue)
                            {
                                case "type":
                                    node.type = nodeData.InnerText;
                                    break;
                                case "displayName":

                                    break;
                                    
                            }
                        }
                    }
                }
                if (xmlNode.Name == "edge")
                {

                    Edge edge = Instantiate(edgePrefab, new Vector3(0, 0, 0), Quaternion.identity) as Edge;

                    //Edge edgeobj = new Edge();
                    //edgeobj.sourceID = xmlNode.Attributes["source"].Value;
                    //edgeobj.targetID = xmlNode.Attributes["target"].Value;

                    edge.sourceID = xmlNode.Attributes["source"].Value;
                    edge.targetID = xmlNode.Attributes["target"].Value;

                    Edges.Add(edge);
                   // Edges.Add(edge);
                    //  string source = xmlNode.Attributes["source"].Value;
                    //  edge.source = nodes[source];


                    Debug.Log("i=" + i);
                    Debug.Log("j=" + j);
                }

            }
        }
        Debug.Log(Time.realtimeSinceStartup);
        MapEdges();
        again = true;
    }


   private void MapEdges()
    {
        foreach(Edge edge in Edges)
        {
            edge.source = NodesHash[edge.sourceID]as Node;
            edge.target = NodesHash[edge.targetID] as Node;

            edge.source.Neighbours.Add(edge.target);
            edge.target.Neighbours.Add(edge.source);

            edge.source.Connections.Add(edge);
            edge.target.Connections.Add(edge);
        }
    }


    public Hashtable GetNodesHash()
    {
        return NodesHash;
    }

    public List<Node> GetNodes()
    {
        return Nodes;
    }

    public List<Edge> GetEdges()
    {
        return Edges;
    }


    //public void UpdatePositions()
    //{
    //    //repulsion between nodes

    //    float totalEnergy = 0;
    //    foreach (Node a in NodesHash.Values)
    //    {
    //        foreach (Node b in NodesHash.Values)
    //        {
    //            if (a == b) continue;
    //            Vector3 posA = a.transform.position;
    //            Vector3 posB = b.transform.position;
    //            Vector3 dir = posA - posB;
    //            float dis = dir.magnitude;
    //            if (dis > 0)
    //            {
    //                float c = 3;
    //                float f = 0.001f * c / dis;
    //                posA += dir / dis * f;
    //                posB -= dir / dis * f;
    //                a.transform.position = posA;
    //                b.transform.position = posB;
    //            }
    //        }
    //    }

    //    foreach (Edge edge in Edges)
    //    {

    //        Vector3 targetpos = edge.target.transform.position;
    //        Vector3 sourcepos = edge.source.transform.position;
    //        Vector3 dir = targetpos - sourcepos;
    //        float dis = dir.magnitude;
    //        totalEnergy += dis;
    //        if (dis > 0)
    //        {
    //            float c = 3;
    //            // if (edge.target == root || edge.source == root) c *= 5000;
    //            float f = -0.001f * c * dis;
    //            targetpos += dir / dis * f;
    //            sourcepos -= dir / dis * f;
    //            edge.target.transform.position = targetpos;
    //            edge.source.transform.position = sourcepos;
    //        }
    //    }
    //    if (totalEnergy > Edges.Count * 6)
    //    {
    //        again = true;
    //    }
    //    else
    //    {
    //        again = false;
    //    }
    //}
    // Update is called once per frame
    void Update()
    {
        //if (again)
        //{
        //    UpdatePositions();

        //}
        //Graph.UpdatePositions(Nodes, Edges);
    }
}