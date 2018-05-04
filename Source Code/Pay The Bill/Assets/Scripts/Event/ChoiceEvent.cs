using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceEvent
{

    private string m_eventName, m_description, m_nextEventName;
    private int m_stateImpactValue, m_money, m_state;
    private int[] m_states, m_statesImpactValues;
    private Event m_nextEvent;

    #region Properties

    public string EventName
    {
        get
        {
            return m_eventName;
        }

        set
        {
            m_eventName = value;
        }
    }

    public string Description
    {
        get
        {
            return m_description;
        }

        set
        {
            m_description = value;
        }
    }

    public int Money
    {
        get
        {
            return m_money;
        }

        set
        {
            m_money = value;
        }
    }

    public int State
    {
        get
        {
            return m_state;
        }

        set
        {
            m_state = value;
        }
    }

    public int[] States
    {
        get
        {
            return m_states;
        }

        set
        {
            m_states = value;
        }
    }

    public int[] StatesImpactValues
    {
        get
        {
            return m_statesImpactValues;
        }

        set
        {
            m_statesImpactValues = value;
        }
    }

    public int StateImpactValue
    {
        get
        {
            return m_stateImpactValue;
        }

        set
        {
            m_stateImpactValue = value;
        }
    }

    public string NextEventName
    {
        get
        {
            return m_nextEventName;
        }

        set
        {
            m_nextEventName = value;
        }
    }

    public Event NextEvent
    {
        get
        {
            return m_nextEvent;
        }

        set
        {
            m_nextEvent = value;
        }
    }

    #endregion


    public void CreateChoiceEvent(string[] row)
    {
        string[] correctName = row[0].Split(new char[] { '\n' });
        if (correctName.Length > 1)
            m_eventName = correctName[1];
        else
            m_eventName = correctName[0];

        if (row[2].Contains("_"))
        {
            string[] states = row[2].Split(new char[] { '_' });
            m_states = new int[states.Length];
            for (int i = 0; i < states.Length; i++)
            {
                int.TryParse(states[i], out m_states[i]);
            }
        }
        else
            int.TryParse(row[2], out m_state);

        if (row[3].Contains("_"))
        {
            string[] statesValues = row[3].Split(new char[] { '_' });
            m_statesImpactValues = new int[statesValues.Length];
            for (int i = 0; i < statesValues.Length; i++)
                int.TryParse(statesValues[i], out m_statesImpactValues[i]);
        }
        else
            int.TryParse(row[3], out m_stateImpactValue);

        m_nextEventName = row[4];

        if (row[6] != "")
            int.TryParse(row[6], out m_money);

        m_description = row[7];
    }
}
