using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ProceduralUIElements
{


    public class ExampleG_PUE : MonoBehaviour, IProcessInterface
    {
        public float m_Threshold;
        public float t = 0;

        float m_Counter = 0;

        void Start()
        {
            m_Counter = 10;
        }

        public void CustomUpdate()
        {
            t += Time.deltaTime;

            if (t > m_Threshold)
            {
                t = 0;
                m_Counter++;

                if (m_Counter == 20)
                {
                    m_Counter = 10;
                }
            }
            GetComponent<Image>().material.SetFloat("_NumberOfSpikes", m_Counter);
        }
    }


}
