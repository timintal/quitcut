using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ProceduralUIElements
{


    public class ExampleB_PUE : MonoBehaviour, IProcessInterface
    {
        public GameObject m_Plane;
        public GameObject m_Circle;
        float t = 0;
        public float m_Threshold1;
        public float t2;


        void Start()
        {

        }


        public void CustomUpdate()
        {
            t += Time.deltaTime;
            t2 += Time.deltaTime;
            float Value2 = Mathf.Sin(t * 5) * 0.15f;
            float _X = 0.14f * Mathf.Cos(Time.time);
            float _Y = 0.25f * Mathf.Sin(Time.time);
            m_Plane.GetComponent<Image>().material.SetFloat("_OffsetXRectangleB", _X);
            m_Plane.GetComponent<Image>().material.SetFloat("_OffsetYRectangleB", _Y);
            m_Plane.GetComponent<Image>().material.SetFloat("_OffsetXCircleB", _X);
            m_Plane.GetComponent<Image>().material.SetFloat("_OffsetYCircleB", _Y);

            if (t2 > m_Threshold1)
            {
                t2 = 0;
                float _Operation = m_Plane.GetComponent<Image>().material.GetFloat("_ChooseShapeB");
                m_Plane.GetComponent<Image>().material.SetFloat("_ChooseShapeB", _Operation == 0 ? 1 : 0);
            }
        }
    }


}
