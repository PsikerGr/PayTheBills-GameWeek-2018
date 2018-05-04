using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameHomeButton : MonoBehaviour {

    [SerializeField] private Camera mainCamera;
    [SerializeField] private InGame inGame;
    [SerializeField] private BillCanvas billCanvas;
    // Use this for initialization
    void Awake()
    {
        if (!mainCamera)
        {
            Debug.Log("missing Camera mainCamera", this);
            return;
        }
        if (!inGame)
        {
            Debug.Log("missing InGame inGame", this);
            return;
        }
    }

    private void OnEnable()
    {
        //playButton.interactable = true;
    }

    public void OnClick()
    {
        if (billCanvas.showed)
        {
            inGame.ToggleBill();
        }
        else
        {
            mainCamera.GetComponent<Animator>().SetTrigger("InGameToMainMenu");
        }
        // playButton.interactable = false;
    }
}
