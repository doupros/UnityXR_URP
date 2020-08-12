using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBasedGraph : MonoBehaviour
{

    public bool again;
    public Hashtable NodesHash;
    public List<Node> Nodes;
    public List<Edge> Edges;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdatePositions(List<Node> Nodes, List<Edge> Edges)
    {
        //repulsion between nodes

        float totalEnergy = 0;
        foreach (Node a in Nodes)
        {
            foreach (Node b in Nodes)
            {
                if (a == b) continue;
                Vector3 posA = a.transform.position;
                Vector3 posB = b.transform.position;
                Vector3 dir = posA - posB;
                float dis = dir.magnitude;
                if (dis > 0)
                {
                    float c = 3;
                    float f = 0.001f * c / dis;
                    posA += dir / dis * f;
                    posB -= dir / dis * f;
                    a.transform.position = posA;
                    b.transform.position = posB;
                }
            }
        }

        foreach (Edge edge in Edges)
        {

            Vector3 targetpos = edge.target.transform.position;
            Vector3 sourcepos = edge.source.transform.position;
            Vector3 dir = targetpos - sourcepos;
            float dis = dir.magnitude;
            totalEnergy += dis;
            if (dis > 0)
            {
                float c = 3;
                // if (edge.target == root || edge.source == root) c *= 5000;
                float f = -0.001f * c * dis;
                targetpos += dir / dis * f;
                sourcepos -= dir / dis * f;
                edge.target.transform.position = targetpos;
                edge.source.transform.position = sourcepos;
            }
        }
        if (totalEnergy > Edges.Count * 6)
        {
            again = true;
        }
        else
        {
            again = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (again)
        {
        }
    }
}
