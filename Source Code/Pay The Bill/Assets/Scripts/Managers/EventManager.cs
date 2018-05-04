using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class EventManager : MonoBehaviour
{
    private Player m_player = null;

    [SerializeField]
    private Button m_leftButton = null;

    [SerializeField]
    private Button m_rightButton = null;

    [SerializeField]
    private Text m_eventDescription = null;

    [SerializeField]
    private Text m_date = null;

    [SerializeField]
    private Text m_eventTitle = null;

    [SerializeField]
    private Image m_background = null;

    static private EventManager instance;
    static public EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventManager>();
                if (instance == null)
                    Debug.LogWarning("EventManager.Instance - failed to find object of type EventManager");
            }
            return instance;
        }
    }

    public int day = 20, month = 09;
    public delegate void StatusChangement(int status, int value);
    public static event StatusChangement StatusChange;

    public delegate void UIChangement();
    public static event UIChangement UpdateUI;

    void Start ()
    {
        m_player = FindObjectOfType<Player>();

        if(m_player)
            StatusChange += m_player.ChangeStatus;

        UpdateUI += UpdateGUI;

        UpdateUI.Invoke();
        m_rightButton.onClick.AddListener(UpdateGUI);
        m_rightButton.onClick.AddListener(delegate { GoToNextEvent(1); });
        m_rightButton.onClick.AddListener(delegate { ApplyPlayerStatusChangement(1); });

        m_leftButton.onClick.AddListener(UpdateGUI);
        m_leftButton.onClick.AddListener(delegate { GoToNextEvent(0); });
        m_leftButton.onClick.AddListener(delegate { ApplyPlayerStatusChangement(0); });

        m_date.text = day.ToString() + "/" + month.ToString();

    }
	
	void Update ()
    {
		
	}
    
    void UpdateGUI()
    {
        Event mEvent = CSVManager.Instance.CurrentDecisionTree.CurrentEvent;

        m_eventDescription.text = mEvent.EventDescription;
        m_eventTitle.text = mEvent.EventTitle;
        m_leftButton.GetComponentInChildren<Text>().text = mEvent.Childs[0].Description;
        m_rightButton.GetComponentInChildren<Text>().text = mEvent.Childs[1].Description;
        BackgroundManager.Instance.SetBackground(mEvent.NameBackground);
    }

    void GoToNextEvent(int choice)
    {
        Event mEvent = CSVManager.Instance.CurrentDecisionTree.CurrentEvent;

        CSVManager.Instance.CurrentDecisionTree.SetNextEvent(mEvent.Childs[choice].NextEventName);
        CSVManager.Instance.DecisionTreeSwap();
        UpdateDate(mEvent.TimeLine);

       // GameManager.Instance.CheckLoseCondition();

    }

    void ApplyPlayerStatusChangement(int choice)
    {
        Event mEvent = CSVManager.Instance.CurrentDecisionTree.CurrentEvent;

        if (mEvent.Childs[choice].States != null && mEvent.Childs[choice].StatesImpactValues != null)
            for (int i = 0; i < mEvent.Childs[choice].States.Length; i++)
                StatusChange.Invoke(mEvent.Childs[choice].States[i], mEvent.Childs[choice].StatesImpactValues[i]);
        else
            StatusChange.Invoke(mEvent.Childs[choice].State, mEvent.Childs[choice].StateImpactValue);

    }

    void UpdateDate(int value)
    {
        day += value;

        if(day >= 30)
        {
            int dayToRestore = (day + value) - 30;
            day = 1;
            month += 1;
        }

        if (month > 12)
            month = 1;

        m_date.text = day.ToString() + "/" + month.ToString();
    }
}
