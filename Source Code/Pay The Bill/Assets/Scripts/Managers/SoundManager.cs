using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


    [SerializeField]
    private AudioSource m_InGameAudioSource = null;

    [SerializeField]
    private List<AudioClip> m_audioClipList = new List<AudioClip>();

	void Start ()
    {
        m_InGameAudioSource.PlayDelayed(10f);
        
	}
	
	void Update ()
    {
		
	}
}
