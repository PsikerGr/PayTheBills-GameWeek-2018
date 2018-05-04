using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {


    [SerializeField]
    private Button m_maleSelectionButton = null;

    [SerializeField]
    private Button m_femaleSelectionButton = null;

    [SerializeField]
    private AudioSource m_mainMenuAudio = null;

    [SerializeField]
    private AudioClip m_mainSound = null;

    [SerializeField]
    private List<AudioClip> m_mainMaleMenuSoundsList = new List<AudioClip>(3);

    

    [SerializeField]
    private List<AudioClip> m_mainFemaleMenuSoundsList = new List<AudioClip>(3);

    private List<AudioClip> m_currentMainMenuSoundsList = new List<AudioClip>(3);

    private Player m_player = null;

    void Start ()
    {
        m_maleSelectionButton.onClick.AddListener(delegate { SpritesManager.Instance.SetCurrentSpriteList(0); });
        m_femaleSelectionButton.onClick.AddListener(delegate { SpritesManager.Instance.SetCurrentSpriteList(1); });

        m_maleSelectionButton.onClick.AddListener(delegate { SetCurrentMainMenuSoundList(true); });
        m_femaleSelectionButton.onClick.AddListener(delegate { SetCurrentMainMenuSoundList(false); });

        m_maleSelectionButton.onClick.AddListener(PlaySound);
        m_femaleSelectionButton.onClick.AddListener(PlaySound);

        m_player = FindObjectOfType<Player>();
        m_maleSelectionButton.onClick.AddListener(m_player.InitCharacterTexture);
        m_femaleSelectionButton.onClick.AddListener(m_player.InitCharacterTexture);


        m_mainMenuAudio.PlayOneShot(m_mainSound);
        m_mainMenuAudio.loop = true;

    }
	
	void Update ()
    {
		
	}

    void PlaySound()
    {
        m_mainMenuAudio.PlayOneShot(m_currentMainMenuSoundsList[Random.Range(0, m_currentMainMenuSoundsList.Count)]);
    }

    void SetCurrentMainMenuSoundList(bool male)
    {
        if (male)
            m_currentMainMenuSoundsList = m_mainMaleMenuSoundsList;
        else
            m_currentMainMenuSoundsList = m_mainFemaleMenuSoundsList;
        m_mainMenuAudio.enabled = false;


    }
}
