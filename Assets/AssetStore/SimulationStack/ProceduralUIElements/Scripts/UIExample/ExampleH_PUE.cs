using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ProceduralUIElements
{


    public class ExampleH_PUE : MonoBehaviour, IProcessInterface
    {
        public GameObject[] m_UIObjects;


        void Start()
        {
        }

        public void CustomUpdate()
        {
            float _X = 1100 - Mathf.Abs(Mathf.Sin(Time.time)) * 800;
            float _Y = 500;// - Mathf.Abs(Mathf.Sin(Time.time)) * 200;

            m_UIObjects[0].GetComponent<RectTransform>().sizeDelta = new Vector2(_X, _Y);
            m_UIObjects[0].GetComponent<Image>().material.SetVector("_ImageSizeRatio", new Vector4(_X, _Y, 0, 0));
          
        }
    }


}
