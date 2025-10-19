using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ProceduralUIElements
{


    public class ExampleD_PUE : MonoBehaviour, IProcessInterface
    {
        public GameObject m_Plane;
        public GameObject m_Circle;

        public AnimationCurve m_AnimCurve1;
        public AnimationCurve m_AnimCurve2;

        float t = 0;


        void Start()
        {

        }

        public void CustomUpdate()
        {
            t += Time.deltaTime;

            m_Circle.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(Vector3.up * 50, Vector3.up * -50, m_AnimCurve1.Evaluate(t));

            float Value = Mathf.Lerp(0, -0.13f, m_AnimCurve2.Evaluate(t));

            m_Plane.GetComponent<Image>().material.SetFloat("_YOffsetB", Value);
        }


    }


}