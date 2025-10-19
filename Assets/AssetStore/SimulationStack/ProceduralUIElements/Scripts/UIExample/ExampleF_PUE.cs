using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ProceduralUIElements
{


    public class ExampleF_PUE : MonoBehaviour, IProcessInterface
    {

        public GameObject[] m_UIElements;


        public void CustomUpdate()
        {
            Vector4 _Po1 = m_UIElements[0].GetComponent<Image>().material.GetVector("_P1");
            float _X1 = -0.0370f + Mathf.Sin(Time.time) * 0.1f;
            m_UIElements[0].GetComponent<Image>().material.SetVector("_P1", new Vector4(_X1, _Po1.y, 0, 0));

            Vector4 _Po2 = m_UIElements[1].GetComponent<Image>().material.GetVector("_P3");
            float _X2 = 0.2f + Mathf.Sin(Time.time) * 0.1f;
            m_UIElements[1].GetComponent<Image>().material.SetVector("_P3", new Vector4(_X2, _Po2.y, 0, 0));

            Vector4 _Po3 = m_UIElements[2].GetComponent<Image>().material.GetVector("_P4");
            float _X3 = 0.1722f + Mathf.Sin(Time.time) * 0.1f;
            m_UIElements[2].GetComponent<Image>().material.SetVector("_P4", new Vector4(_X3, _Po3.y, 0, 0));
        }
    }

}
