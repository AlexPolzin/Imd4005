using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Notepad : MonoBehaviour,IDropHandler {

    public List<EventDev.Events> timeline;
    public List<GameObject> notesN;
    public List<GameObject> notesE;
    public GameObject prefab;
    public GameObject names;
    public GameObject things;

    // Use this for initialization
    void Start () {
        names.GetComponent<RectTransform>().localPosition = new Vector3(-77, 186);
        things.GetComponent<RectTransform>().localPosition = new Vector3(-77, 156 - timeline.Count * 13);
    }
	
	// Update is called once per frame
	void Update () {
    }
    public void AddNote(EventDev.Events c)
    {
        timeline.Add(c);
        notesN.Add(place(c.name));
        notesE.Add(place(c.words));
        names.GetComponent<RectTransform>().localPosition = new Vector3(-77, 186);
        for (int i = 0; i < timeline.Count; i++)
        {
            notesN[i].GetComponent<RectTransform>().localPosition = new Vector3(-57, 173 - i * 13);
        }
        things.GetComponent<RectTransform>().localPosition = new Vector3(-77, 156 - timeline.Count * 13);
        for (int i = 0; i < timeline.Count; i++)
        {
            notesE[i].GetComponent<RectTransform>().localPosition = new Vector3(-57, 143 - timeline.Count * 13 - i * 13);
        }
    }
    GameObject place(string txt)
    {
        GameObject s = Instantiate(prefab);
        s.transform.SetParent(transform);
        s.GetComponent<Text>().supportRichText = true;
        s.GetComponent<Text>().text = txt;
        s.name = txt;
        return s;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(TextRe.Drager.name);
    }
}
