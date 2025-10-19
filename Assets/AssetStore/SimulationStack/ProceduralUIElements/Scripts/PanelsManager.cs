using ProceduralUIElements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsManager : MonoBehaviour
{
    public GameObject[] m_Panels;

    [Space(40)]
    public GameObject[] m_Processes;






    [ContextMenu("Change State")]
    public void ChangeState()
    {
        for (int i = 0; i < m_Panels.Length; i++)
        {
            if (m_Panels[i].transform.GetChild(0).gameObject.activeInHierarchy)
            {
                m_Panels[i].transform.GetChild(0).gameObject.SetActive(false);
                m_Panels[i].transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                m_Panels[i].transform.GetChild(0).gameObject.SetActive(true);
                m_Panels[i].transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }



    void Start()
    {
        
    }

    void Update()
    {
        for(int i=0;i<m_Panels.Length;i++)
        {
            if (m_Panels[i] != null && m_Panels[i].activeInHierarchy) 
            {
                if (m_Panels[i].GetComponent<IProcessInterface>()!=null) 
                {
                    m_Panels[i].GetComponent<IProcessInterface>().CustomUpdate();

                }
            }
        }

        for (int i = 0; i < m_Processes.Length; i++)
        {
            if (m_Processes[i] != null && m_Processes[i].activeInHierarchy)
            {
                if (m_Processes[i].GetComponent<IProcessInterface>() != null)
                {
                    m_Processes[i].GetComponent<IProcessInterface>().CustomUpdate();
                }
            }
        }
    }
}
