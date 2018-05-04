using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesManager : MonoBehaviour {

    static private SpritesManager instance;
    static public SpritesManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SpritesManager>();
                if (instance == null)
                    Debug.LogWarning("SpritesManager.Instance - failed to find object of type SpritesManager");
            }
            return instance;
        }
    }

    public Dictionary<int, Sprite> SelectedSpritesDictionnay
    {
        get
        {
            return m_selectedSpritesDictionnay;
        }

        set
        {
            m_selectedSpritesDictionnay = value;
        }
    }

    [SerializeField]
    private List<Sprite> m_maleCharacterSprites = new List<Sprite>(10);

    [SerializeField]
    private List<Sprite> m_femaleCharacterSprites = new List<Sprite>(10);

    public List<Sprite> CurrentSpriteList = null;

    private Dictionary<int, List<Sprite>> m_spriteListDictionnary = new Dictionary<int, List<Sprite>>();
    private Dictionary<int, Sprite> m_selectedSpritesDictionnay = new Dictionary<int, Sprite>();


    void Start ()
    {
        m_spriteListDictionnary.Add(0, m_maleCharacterSprites);
        m_spriteListDictionnary.Add(1, m_femaleCharacterSprites);

        
    }
	
	void Update ()
    {
		
	}

    public void SetCurrentSpriteList(int index)
    {
        CurrentSpriteList = m_spriteListDictionnary[index];
        for (int i = 0; i < CurrentSpriteList.Count; i++)
            m_selectedSpritesDictionnay.Add(i, CurrentSpriteList[i]);
    }
}
