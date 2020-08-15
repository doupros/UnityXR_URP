using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public string sourceID;
    public string targetID;
    public Node source;
    public Node target;
    public LineRenderer edge;

    // Start is called before the first frame update
    void Start()
    {

        edge = gameObject.GetComponent<LineRenderer>();

        edge.startWidth = 0.01f;
        edge.endWidth = 0.01f;

        edge.SetPosition(0, source.GetPosition());
        edge.SetPosition(1, target.GetPosition());

    }

    // Update is called once per frame
    void Update()
    {
        if (source && target)
        {
            setStart();
            setEnd();
        }
    }

    private void setStart()
    {
        edge.SetPosition(0, source.GetPosition());
    }

    private void setEnd()
    {
        edge.SetPosition(1, target.GetPosition());
    }
}
