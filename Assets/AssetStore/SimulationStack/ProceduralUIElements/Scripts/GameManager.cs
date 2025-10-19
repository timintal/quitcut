using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralUIElements
{


    public class GameManager : MonoBehaviour
    {
        public GameObject m_UIPanel;
        public float m_ZoomSpeed;
        public float m_PanSpeed;

        void Start()
        {

        }

        void Update()
        {
            //if(Input.GetMouseButton(0))
            //{
            //    float _X = m_UIPanel.GetComponent<RectTransform>().anchoredPosition.x;
            //    float _Y = m_UIPanel.GetComponent<RectTransform>().anchoredPosition.y;

            //    _X = Input.GetAxis("Mouse X") * m_PanSpeed * Time.deltaTime;
            //    _Y = Input.GetAxis("Mouse Y") * m_PanSpeed * Time.deltaTime;

            //    _X = Mathf.Clamp(_X, -14170, 0);

            //    m_UIPanel.GetComponent<RectTransform>().anchoredPosition += new Vector2(_X, 0);
            //}

            //if(Input.mouseScrollDelta.magnitude>0)
            //{
            //    float _Scale = m_UIPanel.GetComponent<RectTransform>().transform.localScale.x;
            //    _Scale += Input.mouseScrollDelta.y * m_ZoomSpeed * Time.deltaTime;
            //    _Scale = Mathf.Clamp(_Scale, 0.1f, 6.0f);
            //    m_UIPanel.GetComponent<RectTransform>().transform.localScale = Vector3.one * _Scale;
            //    Vector2 _Direction = m_UIPanel.GetComponent<RectTransform>().anchoredPosition - Vector2.zero;
            //}


            //if(Input.GetKey(KeyCode.Z)||Input.GetKey(KeyCode.X))
            //{
            //    float _Dir = Input.GetKey(KeyCode.Z) ? 1 : -1;

            //    float _Scale = m_UIPanel.GetComponent<RectTransform>().transform.localScale.x;
            //    _Scale += _Dir * (m_ZoomSpeed/10.0f) * Time.deltaTime;
            //    _Scale = Mathf.Clamp(_Scale, 0.1f, 6.0f);
            //    m_UIPanel.GetComponent<RectTransform>().transform.localScale = Vector3.one * _Scale;
            // }

        }
    }

}
