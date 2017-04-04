using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TextRe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //public Text text;
    //public string key;
    public static GameObject Drager;
    public GameObject prefab;
    private GameObject holder;
    public EventDev.Events e;
    public string holding;
    // Use this for initialization
    void Start () {
        //text.supportRichText = true;
        //text.text = text.text.Replace(key, "<color=blue>"+ key+ "</color>");
        //transform.position = new Vector3(transform.position.x + GetComponent<RectTransform>().rect.width / 2, transform.position.y);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetType(string s)
    {
        holding = s;
    }
    public void AddNote(EventDev.Events c)
    {
        e = c;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag start");
        Drager = gameObject;
        holder = Instantiate(prefab);
        holder.GetComponent<Text>().supportRichText = GetComponent<Text>().supportRichText;
        holder.GetComponent<Text>().text = GetComponent<Text>().text;
        holder.GetComponent<Text>().fontSize = GetComponent<Text>().fontSize;
        holder.GetComponent<Text>().color = new Color(holder.GetComponent<Text>().color.r, holder.GetComponent<Text>().color.g, holder.GetComponent<Text>().color.b, holder.GetComponent<Text>().color.a * 0.5f);
        holder.transform.SetParent(transform.parent);
        holder.transform.position = transform.position;
        GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        GetComponent<Text>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        //Debug.Log(transform.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(transform.parent.GetComponent<Notepad>().dropable)
        {
            Destroy(holder);
            transform.parent.GetComponent<Notepad>().remove(gameObject, holding);
            Destroy(gameObject);
        }
        Drager = null;
        transform.position = holder.transform.position;
        GetComponent<Text>().alignment = TextAnchor.UpperLeft;
        GetComponent<Text>().raycastTarget = true;
        Destroy(holder);
    }
}
