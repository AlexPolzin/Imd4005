using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class Test : MonoBehaviour, IPointerUpHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(TDrag.gethis.transform.position.x);
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetMouseButtonUp(0))
        {
            GraphicRaycaster gr = this.GetComponent<GraphicRaycaster>();
            //Create the PointerEventData with null for the EventSystem
            PointerEventData ped = new PointerEventData(null);
            //Set required parameters, in this case, mouse position
            ped.position = Input.mousePosition;
            //Create list to receive all results
            List<RaycastResult> results = new List<RaycastResult>();
            //Raycast it
            gr.Raycast(ped, results);
            Debug.Log(results.Count);
            for (int i = 0; i < results.Count; i++)
            {
                Debug.Log(results[i].gameObject.tag);
            }

        }*/
    }
    
}

