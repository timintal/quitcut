using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Graphs;

namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_20B : ShaderGUIHelper_PUE
    {


        bool _ShapeState
        {
            get { return PlayerPrefs.GetInt("_ShapeState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_ShapeState", value ? 1 : 0); }
        }

        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            Material targetMat = materialEditor.target as Material;
            List<MaterialProperty> propertyList = new List<MaterialProperty>(properties);

            if (propertyList.Count > 0)
            {

                ImageSizeRatioA(materialEditor, properties);


                Header(30, "Shape Properties", 20, 120);

                MaterialProperty _NoOfShapes = ShaderGUI.FindProperty("_NoOfShapes", properties);
                MaterialProperty _Shape1 = ShaderGUI.FindProperty("_SelectShape_1", properties);
                MaterialProperty _Shape2 = ShaderGUI.FindProperty("_SelectShape_2", properties);
                MaterialProperty _Shape3 = ShaderGUI.FindProperty("_SelectShape_3", properties);
                MaterialProperty _Shape4 = ShaderGUI.FindProperty("_SelectShape_4", properties);
                MaterialProperty _Shape5 = ShaderGUI.FindProperty("_SelectShape_5", properties);
                MaterialProperty _Shape6 = ShaderGUI.FindProperty("_SelectShape_6", properties);
                int _One = 115;
                int _Two = 175;
                float _H = 55 + (_Shape1.floatValue == 0 ? +_One : _Two) * (_NoOfShapes.floatValue >= 0 ? 1 : 0);
                _H += (_Shape2.floatValue == 0 ? _One : _Two) * (_NoOfShapes.floatValue >= 0 ? 1 : 0);
                _H += (_Shape3.floatValue == 0 ? _One : _Two) * (_NoOfShapes.floatValue >= 1 ? 1 : 0);
                _H += (_Shape4.floatValue == 0 ? _One : _Two) * (_NoOfShapes.floatValue >= 2 ? 1 : 0);
                _H += (_Shape5.floatValue == 0 ? _One : _Two) * (_NoOfShapes.floatValue >= 3 ? 1 : 0);
                _H += (_Shape6.floatValue == 0 ? _One : _Two) * (_NoOfShapes.floatValue >= 4 ? 1 : 0);
                _H -= _NoOfShapes.floatValue*1.5f;
                GUILayout.Space(0);
                GUI.backgroundColor = m_BlackColorB;
                string _Text = _ShapeState ? "Minimize" : "Maximize";
                if (GUILayout.Button(_Text, GUILayout.Height(20), GUILayout.MaxWidth(80)))
                {
                    _ShapeState = !_ShapeState;
                }
                GUI.enabled = false;
                GUILayout.TextArea("", GUILayout.Height(_ShapeState ? _H : 40));
                GUI.enabled = true;
                GUI.backgroundColor = Color.white;
                GUILayout.Space(_ShapeState ? -_H - 10 : -50-0);
                materialEditor.ShaderProperty(_NoOfShapes, _NoOfShapes.displayName);
                MaterialPropertyState("_ShapeIdentifier", _ShapeState, materialEditor, properties);

                if (_ShapeState == true)
                {
                    if (_NoOfShapes.floatValue >= 0)
                    {
                        ShapeSliders(materialEditor, properties, 1,true, new Color(1,0,0,1));
                        ShapeSliders(materialEditor, properties, 2,true, new Color(0, 1, 0, 1));
                    }

                    ShapeSliders(materialEditor, properties, 3, _NoOfShapes.floatValue >= 1, new Color(0, 0, 1, 1));
                    ShapeSliders(materialEditor, properties, 4, _NoOfShapes.floatValue >= 2, new Color(1, 1, 0, 1));
                    ShapeSliders(materialEditor, properties, 5, _NoOfShapes.floatValue >= 3, new Color(1, 1, 1, 1));
                    ShapeSliders(materialEditor, properties, 6, _NoOfShapes.floatValue >= 4, new Color(0, 0, 0, 1));
                }


                BlockDesignA(10, -50, 40, m_BlackColorB);
                MaterialPropertyState("_SmoothBlend", true, materialEditor, properties);


                MaterialProperty _EnableRim = ShaderGUI.FindProperty("_EnableRim", properties);
                RimA(materialEditor, properties, false, 11, 10);


                Header(50, "Bloom Properties", 20, 120);
                int _H1 = 40 + (_EnableRim.floatValue == 0 ? 20 : 0);
                BlockDesignA(1, -_H1 - 10, _H1, m_BlackColorA);
                MaterialPropertyState("_Bloom", true, materialEditor, properties);
                MaterialPropertyState("_BloomGamma", _EnableRim.floatValue == 0, materialEditor, properties);


                ColorModeB(materialEditor, properties, "");


                GUILayout.Space(100);


            }
        }


        public void ShapeSliders(MaterialEditor materialEditor, MaterialProperty[] properties, int _Index, bool _State, Color _Color)
        {
            if (_State == false) return;

            GUI.backgroundColor = _Color;
            GUILayout.Space(15);
            if (GUILayout.Button("", GUILayout.Height(21), GUILayout.MaxWidth(60)))
            {

            }
            GUILayout.Space(-33);
            GUI.backgroundColor = Color.white;


            MaterialProperty _SelectShape = ShaderGUI.FindProperty("_SelectShape_" + _Index.ToString(), properties);
            MaterialPropertyState("_SelectShape_" + _Index.ToString(), _State, materialEditor, properties);

            if (_SelectShape.floatValue== 0)
            {
                MaterialPropertyState("_Radius_" + _Index.ToString(), _State, materialEditor, properties);
                MaterialPropertyState("_X_" + _Index.ToString(), _State, materialEditor, properties);
                MaterialPropertyState("_Y_" + _Index.ToString(), _State, materialEditor, properties);
            }
            else
            {
                MaterialPropertyState("_Width_" + _Index.ToString(), _State, materialEditor, properties);
                MaterialPropertyState("_Height_" + _Index.ToString(), _State, materialEditor, properties);
                MaterialPropertyState("_CornerRoundness_" + _Index.ToString(), _State, materialEditor, properties);
                MaterialPropertyState("_Rotation_" + _Index.ToString(), _State, materialEditor, properties);
                MaterialPropertyState("_X_" + _Index.ToString(), _State, materialEditor, properties);
                MaterialPropertyState("_Y_" + _Index.ToString(), _State, materialEditor, properties);
            }
        }


    }// Class


}// Namespace