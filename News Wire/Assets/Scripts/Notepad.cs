using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Notepad : MonoBehaviour {

    public List<EventDev.Events> timeline;
    public List<GameObject> notesN;
    public List<GameObject> notesE;
    public GameObject prefab;
    public GameObject names;
    public GameObject things;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        names.GetComponent<RectTransform>().localPosition = new Vector3(-598, 115);
        for (int i = 0; i < timeline.Count; i++)
        {
            notesN[i].GetComponent<RectTransform>().localPosition = new Vector3(-579, 102 - i * 13);
        }
        things.GetComponent<RectTransform>().localPosition = new Vector3(-598, 85 - timeline.Count * 13);
        for (int i = 0; i < timeline.Count; i++)
        {
            notesE[i].GetComponent<RectTransform>().localPosition = new Vector3(-579, 72 - timeline.Count * 13 - i * 13);
        }
    }
    public void AddNote(EventDev.Events c)
    {
        timeline.Add(c);
        notesN.Add(place(c.name));
        notesE.Add(place(c.words));
    }
    GameObject place(string txt)
    {
        GameObject s = Instantiate(prefab);
        s.transform.SetParent(transform);
        s.GetComponent<Text>().supportRichText = true;
        s.GetComponent<Text>().text = txt;
        return s;
    }
}
