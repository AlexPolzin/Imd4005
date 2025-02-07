﻿using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour {

    public float speed = 2f;
    public float xMax = 4.2f;
    public float yMax = 7.65f;
    public float xMin = -5.7f;
    public float yMin = -7.7f;
    public Notepad noteP;

    [HideInInspector]
    public TriggerObj trigger;

   
    private SpriteRenderer sprite;
    private Animator animator;

    void Start () {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update() {


        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("space"))
        {
            animator.SetTrigger("Interact");
                        
            if (trigger)
            {
                
                if (trigger.currentEvent != null)
                {
                    for (int i = 0; i < trigger.currentEvent.Count; i++)
                    {
                        //Debug.Log(trigger.currentEvent[i].words);
                        
                        if (this.GetComponent<DataHolder>())
                            this.GetComponent<DataHolder>().NewEvent(trigger.currentEvent[i]);

                        if (!trigger.multi)
                        {
                            if (trigger.currentEvent[i] != null)
                                noteP.AddNote(trigger.currentEvent[i]);
                            trigger.currentEvent[i] = null;
                        }
                    }
                }
            }
        }
        else if (horizontal > 0) { 
            if (transform.localScale.x > 0)
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
        } else if (horizontal < 0) { 
            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
        }
        else if (vertical > 0){
        }else if (vertical < 0){
        }else {
            //animator.SetTrigger("Idle");
        }

        transform.position += new Vector3(horizontal * speed, vertical * speed, 0);

        if (transform.position.x <= xMin)
        {
            transform.position = new Vector2(xMin, transform.position.y);
        }
        else if (transform.position.x >= xMax)
        {
            transform.position = new Vector2(xMax, transform.position.y);
        }

        if (transform.position.y <= yMin)
        {
            transform.position = new Vector2(transform.position.x, yMin);
        }
        else if (transform.position.y >= yMax)
        {
            transform.position = new Vector2(transform.position.x, yMax);
        }

    }
    public void Touch(TriggerObj c)
    {
        trigger = c;
    }
    public void Leave()
    {
       trigger = null;
    }

}
