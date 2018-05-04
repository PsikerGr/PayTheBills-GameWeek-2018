using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SettingMenuReturnButton : MonoBehaviour
{
    Button playButton;

    [SerializeField] private Camera mainCamera;
    // Use this for initialization
    void Awake()
    {
        playButton = GetComponent<Button>();
        if (!mainCamera)
        {
            Debug.Log("missing Camera mainCamera", this);
            return;
        }
    }

    private void OnEnable()
    {
        //playButton.interactable = true;

    }

    public void OnClick()
    {
        mainCamera.GetComponent<Animator>().SetTrigger("SettingsMenuToMainMenu");
        // playButton.interactable = false;
    }
}