using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace ProceduralUIElements
{


    public class ExampleC_PUE : MonoBehaviour, IProcessInterface
    {
        public GameObject m_Plane;
        public GameObject m_Circle;

        float t = 0;



        void Start()
        {

        }

        public void CustomUpdate()
        {
            t += Time.deltaTime;

            Vector2 _CirclePosition = m_Circle.GetComponent<RectTransform>().anchoredPosition;
            m_Circle.GetComponent<RectTransform>().anchoredPosition = Vector2.up * _CirclePosition.y + Vector2.right * Mathf.Sin(t) * 70.0f;

            float _X = Mathf.Sin(t) * 0.175f;
            m_Plane.GetComponent<Image>().material.SetFloat("_XOffsetB", _X);

            float _Blend = (Mathf.Sin(t) * 0.5f + 0.5f) * 0.2f;
            m_Plane.GetComponent<Image>().material.SetFloat("_Blend", _Blend);

        }

    }


}/// namespace
