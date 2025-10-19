using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;



namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_10A : ShaderGUIHelper_PUE
    {

        public bool _WaveAState
        {
            get { return PlayerPrefs.GetInt("_WaveAState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_WaveAState", value ? 1 : 0); }
        }

        public bool _WaveBState
        {
            get { return PlayerPrefs.GetInt("_WaveBState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_WaveBState", value ? 1 : 0); }
        }

        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            Material targetMat = materialEditor.target as Material;
            List<MaterialProperty> propertyList = new List<MaterialProperty>(properties);

            if (propertyList.Count > 0)
            {

                ImageSizeRatioA(materialEditor, properties);


                Header(30, "Shape Properties (Container)", 20, 180);


                MaterialProperty _MaskContainer = ShaderGUI.FindProperty("_MaskContainer", properties);
                int _H0 = 40;

                if (_MaskContainer.floatValue == 1)
                {
                    _H0 = 83;
                }
                else if (_MaskContainer.floatValue == 2)
                {
                    _H0 = 80;
                }

                BlockDesignA(0, -40 - 10, 40, m_BlackColorB);
                materialEditor.ShaderProperty(_MaskContainer, _MaskContainer.displayName);

                if (_MaskContainer.floatValue < 4)
                {
                    BlockDesignA(11, -_H0 + 10, _H0, m_BlackColorB);
                    MaterialPropertyState("_Radius", _MaskContainer.floatValue == 0, materialEditor, properties);

                    if(_MaskContainer.floatValue==1)
                    {
                        MaterialProperty _ChooseDimensionParameters = ShaderGUI.FindProperty("_ChooseDimensionParameters", properties);
                        MaterialPropertyState("_ChooseDimensionParameters", true, materialEditor, properties);
                        MaterialPropertyState("_Width", _ChooseDimensionParameters.floatValue==0, materialEditor, properties);
                        MaterialPropertyState("_Height", _ChooseDimensionParameters.floatValue==0, materialEditor, properties);
                        MaterialPropertyState("_WidthMargin", _ChooseDimensionParameters.floatValue==1, materialEditor, properties);
                        MaterialPropertyState("_HeightMargin", _ChooseDimensionParameters.floatValue==1, materialEditor, properties);
                    }

                    MaterialPropertyState("_PolygonSize", _MaskContainer.floatValue == 2, materialEditor, properties);
                    MaterialPropertyState("_PolygonTurns", _MaskContainer.floatValue == 2, materialEditor, properties);
                    MaterialPropertyState("_PolygonEdgeAngle", _MaskContainer.floatValue == 2, materialEditor, properties);

                    MaterialPropertyState("_HeartSize", _MaskContainer.floatValue == 3, materialEditor, properties);

                    if (_MaskContainer.floatValue > 0)
                    {
                        if (_MaskContainer.floatValue < 3)
                        {
                            BlockDesignA(11+(_MaskContainer.floatValue==1?3:0), -40 + 10, 40, m_BlackColorB);
                            MaterialPropertyState("_CornerRoundness", _MaskContainer.floatValue > 0, materialEditor, properties);
                        }
                    }

                    BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                    MaterialPropertyState("_ContainerEdgeBlur", true, materialEditor, properties);
                }


                if (_MaskContainer.floatValue ==4 )
                {
                    BlockDesignA(11, -90 + 10, 90, m_BlackColorB);
                    MaterialPropertyState("_MainTex", true, materialEditor, properties);
                }
               

                Header(50, "Container Background", 20, 150);


                MaterialProperty _EnableBG = ShaderGUI.FindProperty("_EnableBG", properties);
                int _H1 = _EnableBG.floatValue == 1 ? 60 : 40;
                BlockDesignA(1, -_H1 - 12, _H1, m_BlackColorA);
                materialEditor.ShaderProperty(_EnableBG, _EnableBG.displayName);
                MaterialPropertyState("_BGColor", _EnableBG.floatValue == 1, materialEditor, properties);


                MaterialProperty _EnableWaveA = ShaderGUI.FindProperty("_EnableWaveA", properties);
                MaterialProperty _EnableWaveB = ShaderGUI.FindProperty("_EnableWaveB", properties);

                int _H2 = 60;
                BlockDesignA(50, -_H2 - 8, _H2, new Color(0.8f, 0.8f, 0.2f, 0.8f));
                GUI.enabled = _EnableWaveA.floatValue == 1;
                MaterialPropertyState("_WaveA_FillAmount", true, materialEditor, properties);
                GUI.enabled = true;
                GUI.enabled = _EnableWaveB.floatValue == 1;
                MaterialPropertyState("_WaveB_FillAmount", true, materialEditor, properties);
                GUI.enabled = true;


                GUILayout.Space(45);
                GUI.backgroundColor = m_BlackColorA;
                string _Text = _WaveAState ? "Minimize - Wave A" : "Maximize - Wave A";
                if (GUILayout.Button(_Text, GUILayout.Height(20), GUILayout.MaxWidth(120)))
                {
                    _WaveAState = !_WaveAState;
                }
                GUI.backgroundColor = Color.white;
                if (_WaveAState == false)
                {
                    BlockDesignA(0, -40 - 10, 40, m_BlackColorA);
                    MaterialPropertyState("_EnableWaveA", true, materialEditor, properties);
                }
                else
                {
                    MaterialProperty _WaveAColorMode = ShaderGUI.FindProperty("_WaveAColorMode", properties);
                    int _H5 = _WaveAColorMode.floatValue == 0 ? 233 : 323;
                    BlockDesignA(1, -_H5 - 10, _H5, m_BlackColorA);
                    MaterialPropertyState("_EnableWaveA", true, materialEditor, properties);
                    GUILayout.Space(10);
                    GUI.enabled = _EnableWaveA.floatValue == 1;
                    MaterialPropertyState("_WaveAAmplitude", true, materialEditor, properties);
                    MaterialPropertyState("_WaveACycles", true, materialEditor, properties);
                    MaterialPropertyState("_WaveASpeed", true, materialEditor, properties);
                    MaterialPropertyState("_WaveAPhase", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_WaveAEdgeBlur", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_WaveAOpacity", true, materialEditor, properties);
                    materialEditor.ShaderProperty(_WaveAColorMode, _WaveAColorMode.displayName);
                    MaterialPropertyState("_WaveAColor", _WaveAColorMode.floatValue == 0, materialEditor, properties);
                    if (_WaveAColorMode.floatValue == 1)
                    {
                        MaterialPropertyState("_WaveAColorA", true, materialEditor, properties);
                        MaterialPropertyState("_WaveAColorB", true, materialEditor, properties);
                        GUILayout.Space(10);
                        MaterialPropertyState("_WaveAGradientAngle", true, materialEditor, properties);
                        MaterialPropertyState("_WaveAGradientScale", true, materialEditor, properties);
                        MaterialPropertyState("_WaveAGradientOffset", true, materialEditor, properties);
                    }
                    GUI.enabled = true;
                }



                GUILayout.Space(45);
                GUI.backgroundColor = m_BlackColorA;
                string _Text1 = _WaveBState ? "Minimize - Wave B" : "Maximize - Wave B";
                if (GUILayout.Button(_Text1, GUILayout.Height(20), GUILayout.MaxWidth(120)))
                {
                    _WaveBState = !_WaveBState;
                }
                GUI.backgroundColor = Color.white;
                if (_WaveBState == false)
                {
                    BlockDesignA(0, -40 - 10, 40, m_BlackColorA);
                    MaterialPropertyState("_EnableWaveB", true, materialEditor, properties);
                }
                else
                {
                    MaterialProperty _WaveBColorMode = ShaderGUI.FindProperty("_WaveBColorMode", properties);
                    int _H5 = _WaveBColorMode.floatValue == 0 ? 233 : 323;
                    BlockDesignA(1, -_H5 - 10, _H5, m_BlackColorA);
                    MaterialPropertyState("_EnableWaveB", true, materialEditor, properties);
                    GUILayout.Space(10);
                    GUI.enabled = _EnableWaveB.floatValue == 1;
                    MaterialPropertyState("_WaveBAmplitude", true, materialEditor, properties);
                    MaterialPropertyState("_WaveBCycles", true, materialEditor, properties);
                    MaterialPropertyState("_WaveBSpeed", true, materialEditor, properties);
                    MaterialPropertyState("_WaveBPhase", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_WaveBEdgeBlur", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_WaveBOpacity", true, materialEditor, properties);
                    materialEditor.ShaderProperty(_WaveBColorMode, _WaveBColorMode.displayName);
                    MaterialPropertyState("_WaveBColor", _WaveBColorMode.floatValue == 0, materialEditor, properties);
                    if (_WaveBColorMode.floatValue == 1)
                    {
                        MaterialPropertyState("_WaveBColorA", true, materialEditor, properties);
                        MaterialPropertyState("_WaveBColorB", true, materialEditor, properties);
                        GUILayout.Space(10);
                        MaterialPropertyState("_WaveBGradientAngle", true, materialEditor, properties);
                        MaterialPropertyState("_WaveBGradientScale", true, materialEditor, properties);
                        MaterialPropertyState("_WaveBGradientOffset", true, materialEditor, properties);
                    }
                    GUI.enabled = true;
                }


                if (_MaskContainer.floatValue < 4)
                {
                    BorderA(materialEditor, properties);
                    InnerShadowA(materialEditor, properties);
                }


                GUILayout.Space(100);


            }
        }


    }


}