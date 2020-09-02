using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class SearchSubString : MonoBehaviour
{

    public GraphReader reader;

    private TextMeshPro thisText;
    private Hashtable nodeHashtable;
    private GameObject resultObject;
    private TextMeshPro searchResult;

    // Start is called before the first frame update
    void Start()
    {
        thisText = gameObject.GetComponent<TextMeshPro>();
        resultObject = GameObject.FindGameObjectWithTag("SearchingResult");
        searchResult = resultObject.GetComponentInChildren<TextMeshPro>();
        nodeHashtable = new Hashtable (reader.NodeNameHash);

        foreach (Node item in reader.NodeNameHash)
        {
           // reader.NodeNameHash[item.name] as Node;
           
        }
        //nodeHashtable;
    }

    // Update is called once per frame
    void Update()
    {
        //string textInputed = thisText.text;
        //List<string> list = new List<string>();
        //string s = "{1}{2}{3}";
        //MatchCollection mc = Regex.Matches(textInputed, @"{(.*?)}");
        //foreach (Match m in mc)
        //    list.Add(m.Groups[1].Value);
        //foreach (string str in list)
        //    Debug.Log("2 " + str);
        /*  
        if (nodeHashtable.ContainsKey(thisText.text))
        {
            Debug.Log("contains");
        }*/

        //Debug.Log(reader.NodeNameHash.Count);

        //if (nodeHashtable.ContainsKey(thisText.text) && thisText.text.Length > 1)
        //{
        //    resultObject.SetActive(true);
        //    Debug.Log(thisText.text);
        //}

    }
}
