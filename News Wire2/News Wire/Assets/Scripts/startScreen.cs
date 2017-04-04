using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScreen : MonoBehaviour {

    private GameObject start;

    private Color startCol;

    private float alp;

    public float alphaChangeRate;

	// Use this for initialization
	void Start () {
        start = GameObject.FindGameObjectWithTag("startGO");
        alp = 1.0f;

        startCol = start.GetComponent<SpriteRenderer>().color;

        startCol.a = alp;
    }
	
	// Update is called once per frame
	void Update () {

        alp -= alphaChangeRate;

        if (alp < 0.0f)
            alp = 1.0f;

        startCol.a = alp;

        start.GetComponent<SpriteRenderer>().color = startCol;
        
    }
}
