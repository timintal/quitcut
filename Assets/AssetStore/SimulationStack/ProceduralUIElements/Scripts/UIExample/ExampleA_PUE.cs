using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ProceduralUIElements
{


    public class ExampleA_PUE : MonoBehaviour,IProcessInterface
    {
        public GameObject m_Plane;
        public GameObject m_Circle;

        public GameObject m_Reflection;


        public float m_Threshold;
        float t = 0;
        float t2;



        void Start()
        {

        }


        public void CustomUpdate()
        {
            t += Time.deltaTime;

            m_Circle.GetComponent<RectTransform>().anchoredPosition = Vector2.up * 26.1f + Vector2.right * Mathf.Sin(t) * 100.0f;

            float Value = Mathf.Sin(t) * 0.25f;
            m_Plane.GetComponent<Image>().material.SetFloat("_XOffsetB", Value);
            m_Reflection.GetComponent<Image>().material.SetFloat("_XOffsetB", Value);

            t2 += Time.deltaTime;

            if (t2 > m_Threshold)
            {
                t2 = 0;
                float _Operation = m_Plane.GetComponent<Image>().material.GetFloat("_ShapeBlendMode");
                m_Plane.GetComponent<Image>().material.SetFloat("_ShapeBlendMode", _Operation == 0 ? 1 : 0);
                m_Reflection.GetComponent<Image>().material.SetFloat("_ShapeBlendMode", _Operation == 0 ? 1 : 0);
            }
        }
    }

}/// name space