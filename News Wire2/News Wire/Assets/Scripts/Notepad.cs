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
    public GameObject Bonus;
    public GameObject things;
    public bool dropable = false;
    private Vector3 nStart;
    private Vector3 TStart;
    
    // Use this for initialization
    void Awake () {
        nStart = names.GetComponent<RectTransform>().localPosition;
        TStart = things.GetComponent<RectTransform>().localPosition - names.GetComponent<RectTransform>().localPosition;
        NoteUpdate();
        //names.GetComponent<RectTransform>().localPosition = new Vector3(-77, 186);

        //things.GetComponent<RectTransform>().localPosition = new Vector3(TStart.x, TStart.y - (notesN.Count - 1) * 13);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
    }
    public void NoteUpdate()
    {
        for (int i = 0; i < notesN.Count; i++)
        {
            notesN[i].GetComponent<Text>().fontSize = names.GetComponent<Text>().fontSize;
            notesN[i].GetComponent<RectTransform>().localPosition = new Vector3(nStart.x, nStart.y - i * 13);
        }

        Vector3 newT = (nStart + new Vector3(TStart.x, TStart.y - (notesN.Count - 1) * 13));
        //TStart = new Vector3(TStart.x, TStart.y - (notesN.Count - 1) * 13);
        things.GetComponent<RectTransform>().localPosition = newT;
        if(Bonus)
            Bonus.GetComponent<RectTransform>().localPosition = new Vector3(Bonus.GetComponent<RectTransform>().localPosition.x,things.GetComponent<RectTransform>().localPosition.y + 10);
        for (int i = 0; i < notesE.Count; i++)
        {
            notesE[i].GetComponent<Text>().fontSize = things.GetComponent<Text>().fontSize;
            notesE[i].GetComponent<RectTransform>().localPosition = new Vector3(newT.x, newT.y - i * 13);
        }
    }

    public void AddNote(EventDev.Events c)
    {
        //timeline.Add(c);

        notesN.Add(place(c.name,c, "name"));
        notesE.Add(place(c.words,c, "words"));
        //names.GetComponent<RectTransform>().localPosition = new Vector3(-77, 186);
        //nStart = names.GetComponent<RectTransform>().localPosition;
        //TStart = things.GetComponent<RectTransform>().localPosition - names.GetComponent<RectTransform>().localPosition;
        NoteUpdate();
    }
    public void AddName(EventDev.Events c)
    {
        for (int i = 0; i < notesN.Count; i++)
        {
            if (notesN[i].GetComponent<TextRe>().e.id == c.id)
                return;
        }
        notesN.Add(place(c.name, c, "name"));
        NoteUpdate();
    }
    public void AddThing(EventDev.Events c)
    {
        for (int i = 0; i < notesE.Count; i++)
        {
            if (notesE[i].GetComponent<TextRe>().e.id == c.id)
                return;
        }
        notesE.Add(place(c.words, c,"words"));
        NoteUpdate();
    }

    GameObject place(string txt, EventDev.Events c,string n)
    {
        GameObject s = Instantiate(prefab);
        s.transform.SetParent(transform);
        s.GetComponent<Text>().supportRichText = true;
        s.GetComponent<Text>().text = txt;
        s.name = txt;
        s.GetComponent<TextRe>().AddNote(c);
        s.GetComponent<TextRe>().SetType(n);
        return s;
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.GetComponent< TextRe>().holding);
        if (dropable)
        {
            if (eventData.pointerDrag.GetComponent<TextRe>().holding == "words")
            {
                AddThing(eventData.pointerDrag.GetComponent<TextRe>().e);
            }
            else if (eventData.pointerDrag.GetComponent<TextRe>().holding == "name")
            {
                AddName(eventData.pointerDrag.GetComponent<TextRe>().e);
            }
            else
            {
                AddNote(eventData.pointerDrag.GetComponent<TextRe>().e);
            }
        }
    }
}
