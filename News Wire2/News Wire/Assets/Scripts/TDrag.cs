using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class TDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject gethis;
	// Use this for initialization
	void Start () {
        gethis = gameObject;

    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            /*GraphicRaycaster gr = this.GetComponent<GraphicRaycaster>();
            //Create the PointerEventData with null for the EventSystem
            PointerEventData ped = new PointerEventData(null);
            //Set required parameters, in this case, mouse position
            ped.position = Input.mousePosition;
            //Create list to receive all results
            List<RaycastResult> results = new List<RaycastResult>();
            //Raycast it
            Debug.Log("here");
            Debug.Log(ped.pointerCurrentRaycast.gameObject.tag);
            gr.Raycast(ped, results);
            Debug.Log(results.Count);
            for (int i = 0; i < results.Count; i++)
            {
                Debug.Log(results[i].gameObject.tag);
            }
                Destroy(gameObject);
    transform.position = Input.mousePosition;
    }*/

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
      
