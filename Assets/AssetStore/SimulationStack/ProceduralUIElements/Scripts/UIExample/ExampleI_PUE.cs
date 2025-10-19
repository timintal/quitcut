using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ProceduralUIElements
{


    public class ExampleI_PUE : MonoBehaviour, IProcessInterface
    {
        public GameObject[] m_UIObjects;

        public float m_SpeedA;


        void Start()
        {
        }

        public void CustomUpdate()
        {
            float _Y = 250 + Mathf.Abs(Mathf.Sin(Time.time * m_SpeedA)) * 250;

            m_UIObjects[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, _Y);
            //m_UIObjects[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, _Y);

            //float _Y1 = -100 + Mathf.Sin(Time.time) * 70;
            //m_UIObjects[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, _Y1);

            //m_UIObjects[1].GetComponent<RectTransform>().sizeDelta = new Vector2(_X, _Y);
            //m_UIObjects[2].GetComponent<Image>().material.SetFloat("_CornerRoundness", 0.1f + Mathf.Sin(Time.time) * 0.1f);

        }
    }


}
