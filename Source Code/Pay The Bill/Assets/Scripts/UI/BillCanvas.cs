using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BillCanvas : MonoBehaviour {
    [SerializeField] private Button HomeButton;
    //[SerializeField] private String textHomeButtonEnabled = "Suivant";
    //[SerializeField] private String textHomeButtonDisabled = "Accueil";
    [SerializeField] private Sprite spriteHomeButtonEnabled;
    [SerializeField] private Sprite spriteHomeButtonDisabled;

    [HideInInspector] public bool showed = false;
    //[SerializeField] private GameObject toDisable;
    // Use this for initialization
    void Start () {
        /*if (!textHomeButton)
        {
            Debug.Log("missing Text textHomeButton", this);
        }*/
        if (!spriteHomeButtonEnabled)
        {
            Debug.Log("missing Sprite spriteHomeButtonEnabled", this);
        }
        if (!spriteHomeButtonDisabled)
        {
            Debug.Log("missing Sprite spriteHomeButtonDisabled", this);
        }
        /*if (!toDisable)
        {
            Debug.Log("missing GameObject toDisable", this);
        }*/
    }

    public void Toggle()
    {
        if (showed)
        {
            GetComponent<Animator>().SetTrigger("HideBill");
            HomeButton.image.sprite = spriteHomeButtonDisabled;
            //textHomeButton.text = textHomeButtonDisabled;
        }
        else
        {
            GetComponent<Animator>().SetTrigger("ShowBill");
            HomeButton.image.sprite = spriteHomeButtonEnabled;
            //textHomeButton.text = textHomeButtonEnabled;
        }
        showed = !showed;
    }
}
