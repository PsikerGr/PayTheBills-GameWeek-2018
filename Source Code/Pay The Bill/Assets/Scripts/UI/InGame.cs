using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour {

    [SerializeField] private BillCanvas billCanvas;
    [SerializeField] private BackGroundCanvas backGroundCanvas;
    // Use this for initialization
    void Awake()
    {
        if (!billCanvas)
        {
            Debug.Log("missing BillCanvas billCanvas", this);
            return;
        }
        if (!backGroundCanvas)
        {
            Debug.Log("missing GameObject backGroundCanvas", this);
            return;
        }
    }

    
    public void ToggleBill()
    {
        billCanvas.Toggle();
        backGroundCanvas.Toggle();
    }
}
