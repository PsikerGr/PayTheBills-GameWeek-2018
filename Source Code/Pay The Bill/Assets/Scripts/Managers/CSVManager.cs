using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVManager : MonoBehaviour
{

    static private CSVManager instance;
    static public CSVManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CSVManager>();
                if (instance == null)
                    Debug.LogWarning("CSVManager.Instance - failed to find object of type CSVManager");
            }
            return instance;
        }
    }

    public CSVReader CurrentDecisionTree
    {
        get
        {
            return m_currentDecisionTree;
        }

        set
        {
            m_currentDecisionTree = value;
        }
    }

    public List<string> DepenseList = new List<string>();
    public List<string> CreditList = new List<string>();

    public CSVReader MoralDecisionTree = new CSVReader("Evenements - MORAL TREE");
    public CSVReader EnergyDecisitionTree = new CSVReader("Evenements - ENERGY TREE");
    public CSVReader SocialDecisitionTree = new CSVReader("Evenements - SOCIAL TREE");
     

    private List<CSVReader> m_CSVReaderList = new List<CSVReader>();

    private CSVReader m_currentDecisionTree = null;
    private int m_currentDecisionTreeID = 0;

    void Start ()
    {
        MoralDecisionTree.Init();
        EnergyDecisitionTree.Init();
        SocialDecisitionTree.Init();
        m_CSVReaderList.Add(MoralDecisionTree);
        m_CSVReaderList.Add(EnergyDecisitionTree);
        m_CSVReaderList.Add(SocialDecisitionTree);

        DecisionTreeSwap();
	}
	
	void Update ()
    {
        if (m_currentDecisionTreeID == m_CSVReaderList.Count)
            m_currentDecisionTreeID = 0;
	}


    public void DecisionTreeSwap()
    {
        m_currentDecisionTree = m_CSVReaderList[m_currentDecisionTreeID];
        m_currentDecisionTreeID++;
    }
}
