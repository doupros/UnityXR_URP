using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainSystem : MonoBehaviour
{
    const int FORCE_BASED = 1;
    const int RANDOM_CIRCULAR = 2;
    const int SORT_AND_DRAW = 3;
    const int BINARY_DISTANCE = 4;
    const int COMPARE = 5;

    private int MODE;
    private int LAST_MODE;

    public GameObject resultObject;
    public TextMeshPro[] searchResult;

    public Graph Graph;
    public ForceBasedGraph Force_Based_Graph;
    public NodeComparer nodeComparer;

    public string a;
    public string b;

    //public GraphReader Reader;

    // Start is called before the first frame update
    void Start()
    {

        // Reader = new GraphReader();
        MODE = 0;
        LAST_MODE = 0;
        resultObject = GameObject.FindGameObjectWithTag("SearchingResult");
        searchResult = resultObject.GetComponentsInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (MODE)
        {
            case FORCE_BASED:
                LAST_MODE = FORCE_BASED;
                Graph.UpdatePositions_FBG();
                break;
            case RANDOM_CIRCULAR:
                if (MODE != LAST_MODE)
                {
                    LAST_MODE = RANDOM_CIRCULAR;
                    Graph.Draw_Circular();
                }
                break;
            case SORT_AND_DRAW:
                if (MODE != LAST_MODE)
                {
                    LAST_MODE = SORT_AND_DRAW;
                    Graph.SortAndDraw();
                }
                break;
            case BINARY_DISTANCE:
                if (MODE != LAST_MODE)
                {
                    LAST_MODE = BINARY_DISTANCE;
                    Graph.FindDistances();
                }
                break;
            case COMPARE:
                //nodeComparer.

                if (MODE != LAST_MODE)
                {
                    LAST_MODE = COMPARE;

                    Node tempNodeA = null, tempNodeB = null;
                    if (searchResult[0] != null && searchResult[1] != null)
                    {
                         tempNodeA = Graph.Nodes.Find(node => node.displayName.Contains(searchResult[0].text));
                         tempNodeB = Graph.Nodes.Find(node => node.displayName.Contains(searchResult[1].text));
                    }
                    if (tempNodeA == null || tempNodeB == null)
                    {
                        Debug.Log("Node not found");
                        break;
                    }
                   // Debug.Log(Graph.Nodes.Find(node => node.displayName.Equals(a)));
                    //nodeComparer.CompareNodes(Graph.Nodes.Find(node => node.displayName.Equals(a)), Graph.Nodes.Find(node => node.displayName.Equals(b)));
                    nodeComparer.CompareNodes(tempNodeA, tempNodeB);
                }

                break;
            //case PAUSE:
            //    if (MODE != LAST_MODE)
            //    {

            //    }
            default:
                break;
        }

    }
    //void OnGUI()
    //{
    //    if (GUILayout.Button("Press Me"))
    //        Debug.Log("Hello!");
    //}
    public void SetMode(int newMode)
    {
        MODE = newMode;
    }
    public void setStringA(string nodeA)
    {
        a = nodeA;
    }

    public void setStringB(string nodeB)
    {
        b = nodeB;
    }
}
