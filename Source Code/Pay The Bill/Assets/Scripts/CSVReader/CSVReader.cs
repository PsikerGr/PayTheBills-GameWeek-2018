using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class CSVReader
{
    public List<Event> events = new List<Event>();
    public List<ChoiceEvent> choiceEvents = new List<ChoiceEvent>();
    private string m_DecisionTreePath;
    private Event m_currentEvent = null;

    public Event CurrentEvent
    {
        get
        {
            return m_currentEvent;
        }

        set
        {
            m_currentEvent = value;
        }
    }

    public CSVReader(string path)
    {
        m_DecisionTreePath = path;
    }

    public void Init () {

        TextAsset m_DecisionTree = Resources.Load<TextAsset>(m_DecisionTreePath);

        if (m_DecisionTree)
        {
            string[] data = m_DecisionTree.text.Split(new char[] { '\r' });
            
            for(int i = 0; i < data.Length - 1; i++)
            {
                if (i % 3 == 0)
                {
                    string[] eventRow = data[i].Split(new char[] { ',' });
                    Event newEvent = new Event();
                    newEvent.CreateEvent(eventRow);
                    events.Add(newEvent);
                }
                else
                {
                    string[] choiceEventRow = data[i].Split(new char[] { ',' });
                    ChoiceEvent choiceEvent = new ChoiceEvent();
                    choiceEvent.CreateChoiceEvent(choiceEventRow);
                    choiceEvents.Add(choiceEvent);
                }
            }
            SetChoiceEventNextEvent();
            SetEventsChoiceEvents();
        }

        m_currentEvent = events[0];
	}

    private void SetEventsChoiceEvents()
    {
        foreach(Event mEvent in events.ToArray())
        {
            foreach(ChoiceEvent choiceEvent in choiceEvents.ToArray())
            {
                if(choiceEvent.EventName == mEvent.AnswerName1 || choiceEvent.EventName == mEvent.AnswerName2)
                {
                    mEvent.Childs.Add(choiceEvent);
                    choiceEvents.Remove(choiceEvent);
                }
            }
        }
    }

    private void SetChoiceEventNextEvent()
    {
        List<Event> tempEventList = events;

        foreach (ChoiceEvent choiceEvent in choiceEvents.ToArray())
        {
            foreach (Event mEvent in tempEventList.ToArray())
            {
                if (choiceEvent.NextEventName == mEvent.Name)
                {
                    choiceEvent.NextEvent = mEvent;
                   // tempEventList.Remove(mEvent);
                }
            }
        }
    }

    public string[] SplitCsvLine(string line)
    {
        return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
        @"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)",
        System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
                select m.Groups[1].Value).ToArray();
    }

    public void SetNextEvent(string eventName)
    {
        events.Remove(m_currentEvent);
        m_currentEvent = events.Find(mEvent => mEvent.Name.Contains(eventName));
    }

}

