using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




namespace ProceduralUIElements
{



    public class UIElement_PUE : MonoBehaviour, IProcessInterface
    {
        public UIElementAnimation[] m_UIElementAnimations;

        float _TimeCounter = 0;



        public void CustomUpdate()
        {

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
                    m_UIElementAnimations[i].m_UIElement[j].GetComponent<Image>().material.SetFloat(_ShaderPropertyName, _ShaderPropertyValue);
                }
            }
        }
    }



}/// namespace