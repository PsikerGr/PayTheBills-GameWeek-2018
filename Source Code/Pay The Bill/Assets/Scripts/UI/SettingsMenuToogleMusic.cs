using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuToogleMusic : MonoBehaviour {
    [SerializeField] private GameObject sliderOn, sliderOff;

	// Use this for initialization
	void Start () {
		
	}
	
    public void OnValueChanged(bool val)
    {
        if ( val)
        {
            sliderOn.SetActive(true);
            sliderOff.SetActive(false);
        }
        else
        {
            sliderOff.SetActive(true);
            sliderOn.SetActive(false);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
