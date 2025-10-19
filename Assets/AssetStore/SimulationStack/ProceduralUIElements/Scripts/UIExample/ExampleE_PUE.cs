using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProceduralUIElements
{

    public class ExampleE_PUE : MonoBehaviour, IProcessInterface
    {
        public float m_Threshold;
        float t = 0;
        int m_Alignment = 0;

        // Update is called once per frame
        public void CustomUpdate()
        {
            t += Time.deltaTime;

            if (t > m_Threshold)
            {
                t = 0;
                m_Alignment++;

                if (m_Alignment == 4)
                {
                    m_Alignment = 0;
                }
            }

            GetComponent<Image>().material.SetFloat("_Alignment", m_Alignment);
        }
    }

}
