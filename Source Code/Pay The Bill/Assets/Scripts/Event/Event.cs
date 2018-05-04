using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{

    private string m_name, m_nameBackground, m_answerName1, m_answerName2, m_eventDescription, m_eventTitle;
    private int m_timeLine;

    private List<ChoiceEvent> m_Childs = new List<ChoiceEvent>();


    #region Properties

    public string Name
    {
        get
        {
            return m_name;
        }

        set
        {
            m_name = value;
        }
    }

    public string NameBackground
    {
        get
        {
            return m_nameBackground;
        }

        set
        {
            m_nameBackground = value;
        }
    }

    public string AnswerName1
    {
        get
        {
            return m_answerName1;
        }

        set
        {
            m_answerName1 = value;
        }
    }

    public string AnswerName2
    {
        get
        {
            return m_answerName2;
        }

        set
        {
            m_answerName2 = value;
        }
    }

    public string EventDescription
    {
        get
        {
            return m_eventDescription;
        }

        set
        {
            m_eventDescription = value;
        }
    }

    public string EventTitle
    {
        get
        {
            return m_eventTitle;
        }

        set
        {
            m_eventTitle = value;
        }
    }

    public int TimeLine
    {
        get
        {
            return m_timeLine;
        }

        set
        {
            m_timeLine = value;
        }
    }

    public List<ChoiceEvent> Childs
    {
        get
        {
            return m_Childs;
        }

        set
        {
            m_Childs = value;
        }
    }

    #endregion
   

    public void CreateEvent(string[] row)
    {

        string[] correctName = row[0].Split(new char[] { '\n' });
        if (correctName.Length > 1)
            m_name = correctName[1];
        else
            m_name = correctName[0];
        m_nameBackground = row[1]; 
        m_answerName1 = row[4];
        m_answerName2 = row[5];
        m_eventDescription = row[7];
        m_eventTitle = row[8];
        int.TryParse(row[9], out m_timeLine);
    }

}
