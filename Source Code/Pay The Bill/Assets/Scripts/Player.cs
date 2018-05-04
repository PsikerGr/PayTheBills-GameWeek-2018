using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {

    public enum E_State
    {
        MORAL = 0,
        SOCIAL,
        ENERGY,
        COUNT
    }


    #region SerializedFields

    [SerializeField]
    private int m_MoralValue = 5;

    [SerializeField]
    private int m_SocialValue = 5;

    [SerializeField]
    private int m_EnergyValue = 5;

    [SerializeField]
    private int m_Money = 50000;


    [SerializeField]
    private Image m_hairTexture = null;

    [SerializeField]
    private Image m_eyesTexture = null;

    [SerializeField]
    private Image m_mouthTexture = null;

    [SerializeField]
    private Image m_bodyTexture = null;

    #endregion

    #region Properties

    public int MoralValue
    {
        get
        {
            return m_MoralValue;
        }

        set
        {
            m_MoralValue = value;
        }
    }

    public int SocialValue
    {
        get
        {
            return m_SocialValue;
        }

        set
        {
            m_SocialValue = value;
        }
    }

    public int EnergyValue
    {
        get
        {
            return m_EnergyValue;
        }

        set
        {
            m_EnergyValue = value;
        }
    }

    public int Money
    {
        get
        {
            return m_Money;
        }

        set
        {
            m_Money = value;
        }
    }


    #endregion


    private void Start()
    {
    }

    public void ChangeStatus(int state, int value)
    {

        Clamp(m_MoralValue, 0, 10);
        Clamp(m_EnergyValue, 0, 10);
        Clamp(m_SocialValue, 0, 10);

        switch ((E_State)state)
        {
            case E_State.MORAL:
                {
                    m_MoralValue = Clamp(m_MoralValue + value, 0, 10); ;
                    
                }
                break;
            case E_State.SOCIAL:
                {
                    m_SocialValue = Clamp(m_SocialValue + value, 0, 10);
                }
                break;
            case E_State.ENERGY:
                {
                    m_EnergyValue = Clamp(m_EnergyValue + value, 0, 10); 
                    
                }
                break;
            case E_State.COUNT:
                break;
            default:
                break;
        }

        CheckStates();
    }

    public void InitCharacterTexture()
    {
        m_bodyTexture.sprite = SpritesManager.Instance.SelectedSpritesDictionnay[0];
        m_eyesTexture.sprite = SpritesManager.Instance.SelectedSpritesDictionnay[2];
        m_hairTexture.sprite = SpritesManager.Instance.SelectedSpritesDictionnay[5];
        m_mouthTexture.sprite = SpritesManager.Instance.SelectedSpritesDictionnay[8];
    }

    public void CheckStates()
    {
        {
            if (m_EnergyValue >= 7)
                m_eyesTexture.sprite = SpritesManager.Instance.SelectedSpritesDictionnay[1]; //Change m_eyesTexture

            else if (m_EnergyValue > 3 && m_EnergyValue < 7)
                m_eyesTexture.sprite = SpritesManager.Instance.SelectedSpritesDictionnay[2];

            else if (m_EnergyValue <= 3)
                m_eyesTexture.sprite = SpritesManager.Instance.SelectedSpritesDictionnay[3];
        }

        {
            if (m_SocialValue >= 7)
                m_hairTexture.sprite = SpritesManager.Instance.SelectedSpritesDictionnay[4];

            else if (m_SocialValue > 3 && m_SocialValue < 7)
                m_hairTexture.sprite = SpritesManager.Instance.SelectedSpritesDictionnay[5];

            else if (m_SocialValue <= 3)
                m_hairTexture.sprite  = SpritesManager.Instance.SelectedSpritesDictionnay[6];
        }

        {
            if (m_MoralValue >= 7)
                m_mouthTexture.sprite = SpritesManager.Instance.SelectedSpritesDictionnay[7];

            else if (m_MoralValue > 3 && m_MoralValue < 7)
                m_mouthTexture.sprite = SpritesManager.Instance.SelectedSpritesDictionnay[8];

            else if (m_MoralValue <= 3)
                m_mouthTexture.sprite = SpritesManager.Instance.SelectedSpritesDictionnay[9];
        } 

      

        if (m_SocialValue < m_MoralValue)
        {
            if (m_SocialValue < m_EnergyValue)
                return; //Play sound
            else
                return; //Play sound
        }
        else if (m_MoralValue < m_EnergyValue)
            return;
        else
            return;

    }

    int Clamp(int value, int min, int max)
    {
        if (value < min)
            value = min;
        if (value > max)
            value = max;
        return value;
    }

}