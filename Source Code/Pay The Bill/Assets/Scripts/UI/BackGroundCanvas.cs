using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCanvas : MonoBehaviour {

    private bool showed = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Toggle()
    {
        if (showed)
        {
            GetComponent<Animator>().SetTrigger("HideBackGround");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("ShowBackGround");
        }
        showed = !showed;
    }
}
