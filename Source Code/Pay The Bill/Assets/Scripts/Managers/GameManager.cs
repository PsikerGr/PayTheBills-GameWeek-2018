using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    private Player m_player = null;

    static private GameManager instance;
    static public GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                    Debug.LogWarning("GameManager.Instance - failed to find object of type GameManager");
            }
            return instance;
        }
    }

    public bool Lose = false;

    private void Start()
    {
        m_player = FindObjectOfType<Player>();
    }

    public void CheckLoseCondition()
    {
        if (new[] { m_player.SocialValue, m_player.MoralValue, m_player.EnergyValue}.All(x => x <= 0))
        {
            Lose = true;
        }
    }

}
