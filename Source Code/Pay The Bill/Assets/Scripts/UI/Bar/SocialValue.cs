using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SocialValue : MonoBehaviour {

    private Player player = null;

    [SerializeField]
    private Text text = null;

    void Start()
    {
        player = FindObjectOfType<Player>();
        UpdateValue(); // Init Value
    }

    void Update()
    {
        UpdateValue();
    }

    private void UpdateValue()
    {
        if (text)
        {
            text.text = player.SocialValue.ToString();
        }
    }
}
