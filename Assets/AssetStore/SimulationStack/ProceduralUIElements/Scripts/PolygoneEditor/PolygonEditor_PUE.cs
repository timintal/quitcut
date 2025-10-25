using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;


namespace ProceduralUIElements
{


    public class PolygonEditor_PUE : MonoBehaviour
    {
        public GameObject[] m_Points;

        [Space(20)]
        public int m_PointScale;
        public int m_PointMoveSpeed;

        [HideInInspector]
        public bool m_IsAnyPointClicked;

        [HideInInspector]
        public float m_ImageWidth;
        [HideInInspector]
        public float m_ImageHeight;




        void Awake()
        {

        }


        private void Start()
        {
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged += OnChangePlayModeState;
#endif
        }


        void OnChangePlayModeState(PlayModeStateChange playModeStateChange)
        {
#if UNITY_EDITOR
        if (EditorApplication.isPlayingOrWillChangePlaymode == false)
        {
            for (int i = 0; i < 10; i++)
            {
                float _X = PlayerPrefs.GetFloat("_P" + (i + 1).ToString() + "X");
                float _Y = PlayerPrefs.GetFloat("_P" + (i + 1).ToString() + "Y");
                m_Points[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(_X * m_ImageWidth, _Y * m_ImageHeight);
            }
        }
#endif

        }


        [ContextMenu("Set Points In Circle Positions")]
        public void SetPointsInCirclePositions()
        {
            for (int i = 0; i < 10; i++)
            {
                m_Points[i].SetActive(false);
            }

            float _NoOfPoints = GetComponent<Image>().material.GetFloat("_NoOfPoints") + 3;
            m_ImageWidth = GetComponent<RectTransform>().sizeDelta.x;
            m_ImageHeight = GetComponent<RectTransform>().sizeDelta.y;
            for (int i = 0; i < _NoOfPoints; i++)
            {
                float _Angle = (i / _NoOfPoints) * 360;
                float _X = m_ImageWidth / 2.0f * Mathf.Cos(_Angle * Mathf.Deg2Rad);
                float _Y = m_ImageHeight / 2.0f * Mathf.Sin(_Angle * Mathf.Deg2Rad);

                m_Points[i].SetActive(true);
                m_Points[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(_X, _Y);
                m_Points[i].transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
                UpdatePointPosition(i);
            }
        }


        [ContextMenu("Adjust Points Positions")]
        public void AdjustPointsPositions()
        {
            float _NoOfPoints = GetComponent<Image>().material.GetFloat("_NoOfPoints");
            Vector4[] _PointsPositions = new Vector4[10];

            m_ImageWidth = GetComponent<RectTransform>().sizeDelta.x;
            m_ImageHeight = GetComponent<RectTransform>().sizeDelta.y;

            for (int i = 0; i < 10; i++)
            {
                float _X = GetComponent<Image>().material.GetFloat("_X_" + (i + 1).ToString());
                float _Y = GetComponent<Image>().material.GetFloat("_Y_" + (i + 1).ToString());
                _PointsPositions[i] = new Vector4(_X, _Y, 0, 0);

                if (i < _NoOfPoints + 3)
                {
                    m_Points[i].SetActive(true);
                    m_Points[i].transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
                    m_Points[i].GetComponent<RectTransform>().sizeDelta = new Vector2(m_PointScale, m_PointScale);
                    m_Points[i].GetComponent<Point_PolygonEditor_PUE>().m_Index = i;
                    Vector2 _Direction = m_Points[i].GetComponent<RectTransform>().anchoredPosition - Vector2.zero;
                    m_Points[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(_PointsPositions[i].x * m_ImageWidth, _PointsPositions[i].y * m_ImageHeight);
                }
                else
                {
                    m_Points[i].SetActive(false);
                }
            }
        }




        public void UpdatePointPosition(int _Index)
        {
            float _XPos = m_Points[_Index].GetComponent<RectTransform>().anchoredPosition.x / m_ImageWidth;
            float _YPos = m_Points[_Index].GetComponent<RectTransform>().anchoredPosition.y / m_ImageHeight;
            GetComponent<Image>().material.SetFloat("_X_" + (_Index + 1).ToString(), _XPos);
            GetComponent<Image>().material.SetFloat("_Y_" + (_Index + 1).ToString(), _YPos);

            PlayerPrefs.SetFloat("_P" + (_Index + 1).ToString() + "X", _XPos);
            PlayerPrefs.SetFloat("_P" + (_Index + 1).ToString() + "Y", _YPos);
        }

    }


}/// namespace
