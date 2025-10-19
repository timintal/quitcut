using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace ProceduralUIElements
{


    [System.Serializable]
    public struct UIElementAnimation
    {
        public string m_ShaderPropertyName;
        public GameObject[] m_UIElement;

        [Space(10)]
        public AnimationCurve m_AnimationCurve;
        public float m_InitialValue;
        public float m_FinalValue;

        [Space(10)]
        public float m_AnimationSpeed;
    }


    public class PanelUIElements_PUE : MonoBehaviour, IProcessInterface
    {
        public UIElementAnimation[] m_UIElementAnimations;
        float _TimeCounter = 0;
        public bool m_IsTriggered;

        [Space(30)]
        public GameObject[] m_Processes;



        private void OnTriggerEnter2D(Collider2D collision)
        {
            m_IsTriggered = true;
            //transform.GetChild(0).gameObject.SetActive(true);
            //transform.GetChild(1).gameObject.SetActive(true);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            m_IsTriggered = false;
            //transform.GetChild(0).gameObject.SetActive(false);
            //transform.GetChild(1).gameObject.SetActive(false);
        }

        public void CustomUpdate()
        {
            if (m_IsTriggered == false) return;

            _TimeCounter += Time.deltaTime;

            for (int i = 0; i < m_UIElementAnimations.Length; i++)
            {
                string _ShaderPropertyName = m_UIElementAnimations[i].m_ShaderPropertyName;
                float _InitialValue = m_UIElementAnimations[i].m_InitialValue;
                AnimationCurve _AnimationCurve = m_UIElementAnimations[i].m_AnimationCurve;
                float _AnimationSpeed = m_UIElementAnimations[i].m_AnimationSpeed;
                float _FinalValue = m_UIElementAnimations[i].m_FinalValue;
                float _Difference = _FinalValue - _InitialValue;
                float _ShaderPropertyValue = _InitialValue + _AnimationCurve.Evaluate(_TimeCounter * _AnimationSpeed) * _Difference;

                for (int j = 0; j < m_UIElementAnimations[i].m_UIElement.Length; j++)
                {
                    if (m_UIElementAnimations[i].m_UIElement[j] != null)
                    {
                        m_UIElementAnimations[i].m_UIElement[j].GetComponent<Image>().material.SetFloat(_ShaderPropertyName, _ShaderPropertyValue);
                    }
                }
            }
        }
    }


}
