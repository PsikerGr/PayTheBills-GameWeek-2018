using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour {


    static private BackgroundManager instance;
    static public BackgroundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BackgroundManager>();
                if (instance == null)
                    Debug.LogWarning("BackgroundManager.Instance - failed to find object of type BackgroundManager");
            }
            return instance;
        }
    }


    enum E_Background
    {
        BG_1 = 0,
        BG_2,
        BG_3,
        BG_4,
        BG_5,
        COUNT
    }

    [SerializeField]
    private List<Sprite> m_BackgroundList = new List<Sprite>();

    [SerializeField]
    private Image m_background = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetBackground(string name)
    {
        string[] splitted = name.Split(new char[] { '.' });
        int stringToInt;

        int.TryParse(splitted[0], out stringToInt);

      if (name == "BG_01")
          m_background.sprite = m_BackgroundList[0];
      else if (name == "BG_02")
            m_background.sprite = m_BackgroundList[1];
      else if (name == "BG_03")
            m_background.sprite = m_BackgroundList[2];
      else if (name == "BG_04")
            m_background.sprite = m_BackgroundList[3];
      else if (name == "BG_05")
             m_background.sprite = m_BackgroundList[4];


    }

}
