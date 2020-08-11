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
        edge.startWidth = 0.02f;
        edge.endWidth = 0.02f;
        // Init();
        edge.SetPosition(0, source.GetPosition());
        edge.SetPosition(1, target.GetPosition());

    }
    //void Init() {
    //    edge.material = new Material(Shader.Find("Sprites/Default"));
    //    edge.SetColors(Color.blue, Color.blue);
    //}

    // Update is called once per frame
    void Update()
    {
        if (source && target)
        {

            setStart();
            setEnd();

            //Vector3 start = source.GetPosition();
            //Vector3 end = target.GetPosition() ;
            //edge.SetPosition(0, start);
            //edge.SetPosition(1, end);
        }
        //edge.enabled = true;




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
