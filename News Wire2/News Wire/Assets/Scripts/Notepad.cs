using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Notepad : MonoBehaviour,IDropHandler {

    //public List<EventDev.Events> timeline;
    public List<GameObject> notesN;
    public List<GameObject> notesE;
    public GameObject prefab;
    public GameObject names;
    public GameObject things;
    private Vector3 nStart;
    private Vector3 TStart;

    // Use this for initialization
    void Start () {
        nStart = names.GetComponent<RectTransform>().localPosition;
        TStart = things.GetComponent<RectTransform>().localPosition;
        //names.GetComponent<RectTransform>().localPosition = new Vector3(-77, 186);

        //things.GetComponent<RectTransform>().localPosition = new Vector3(TStart.x, TStart.y - (notesN.Count - 1) * 13);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //names.GetComponent<RectTransform>().localPosition = new Vector3(-77, 186);
        for (int i = 0; i < notesN.Count; i++)
        {
            notesN[i].GetComponent<RectTransform>().localPosition = new Vector3(nStart.x, nStart.y - i * 13);
        }
        //things.GetComponent<RectTransform>().localPosition = new Vector3(TStart.x, TStart.y - (notesN.Count - 1) * 13);
        for (int i = 0; i < notesE.Count; i++)
        {
            notesE[i].GetComponent<RectTransform>().localPosition = new Vector3(TStart.x, TStart.y - i * 13);
        }
    }
    public void AddNote(EventDev.Events c)
    {
        //timeline.Add(c);
        notesN.Add(place(c.name,c));
        notesE.Add(place(c.words,c));
        
    }
    GameObject place(string txt, EventDev.Events c)
    {
        GameObject s = Instantiate(prefab);
        s.transform.SetParent(transform);
        s.GetComponent<Text>().supportRichText = true;
        s.GetComponent<Text>().text = txt;
        s.name = txt;
        s.GetComponent<TextRe>().AddNote(c);
        return s;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(TextRe.Drager.name);
    }
}
