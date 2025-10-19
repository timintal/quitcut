using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_16F : ShaderGUIHelper_PUE
    {
        

        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            Material targetMat = materialEditor.target as Material;
            List<MaterialProperty> propertyList = new List<MaterialProperty>(properties);

            if (propertyList.Count > 0)
            {

                ImageSizeRatioA(materialEditor, properties);

                
                Header(30, "Shape Properties (Container)", 20, 185);


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
                    BlockDesignA(11, -_H0 +10, _H0, m_BlackColorB);
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

                    if (_MaskContainer.floatValue != 4)
                    {
                        BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                        MaterialPropertyState("_ContainerEdgeBlur", true, materialEditor, properties);
                    }
                }


                if (_MaskContainer.floatValue == 4)
                {
                    BlockDesignA(11, -90 + 10, 90, m_BlackColorB);
                    MaterialPropertyState("_MainTex", true, materialEditor, properties);
                }


                Header(45, "Shape Background", 20, 140);


                MaterialProperty _EnableBG = ShaderGUI.FindProperty("_EnableBG", properties);
                int _H1 = _EnableBG.floatValue == 1 ? 65 : 40;
                BlockDesignA(0, -_H1 - 10, _H1, m_BlackColorA);
                materialEditor.ShaderProperty(_EnableBG, _EnableBG.displayName);
                MaterialPropertyState("_BGColor", _EnableBG.floatValue == 1, materialEditor, properties);
                
                
                Header(45, "General Properties", 20, 120);


                BlockDesignA(0, -190 - 10, 190, m_BlackColorA);
                MaterialPropertyState("_NoiseTex", true, materialEditor, properties);
                GUILayout.Space(5);
                MaterialPropertyState("_NoiseTexScale", true, materialEditor, properties);
                GUILayout.Space(10);
                MaterialPropertyState("_FireXOffset", true, materialEditor, properties);
                MaterialPropertyState("_FireYOffset", true, materialEditor, properties);
                MaterialPropertyState("_AnimationSpeed", true, materialEditor, properties);


                GUILayout.Space(45);
                GUI.backgroundColor = m_BlackColorA;
                string _Text = _FireLayerAState ? "Minimize - Fire Layer A" : "Maximize - Fire Layer A";
                if (GUILayout.Button(_Text, GUILayout.Height(20), GUILayout.MaxWidth(150)))
                {
                    _FireLayerAState = !_FireLayerAState;
                }
                GUI.backgroundColor = Color.white;
                if (_FireLayerAState == false)
                {
                    BlockDesignA(0, -40 - 10, 40, m_BlackColorA);
                    MaterialPropertyState("_EnableFireLayerA", true, materialEditor, properties);
                }
                else
                {
                    MaterialProperty _EnableFireLayerA = ShaderGUI.FindProperty("_EnableFireLayerA", properties);
                    MaterialProperty _ColorModeLayerA = ShaderGUI.FindProperty("_ColorModeFireA", properties);
                    int _H = 260;
                    _H -= _ColorModeLayerA.floatValue == 0 ? 15 : 0;
                    _H += _ColorModeLayerA.floatValue == 1 ? 38 : 0;
                    BlockDesignA(0, -_H-10, _H, m_BlackColorA);
                    MaterialPropertyState("_EnableFireLayerA", true, materialEditor, properties);
                    GUI.enabled = _EnableFireLayerA.floatValue == 1;
                    GUILayout.Space(5);
                    MaterialPropertyState("_FireAHeight", true, materialEditor, properties);
                    MaterialPropertyState("_FireAXOffset", true, materialEditor, properties);
                    MaterialPropertyState("_FireAYOffset", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_ColorModeFireA", true, materialEditor, properties);
                    MaterialPropertyState("_ColorAFireA", true, materialEditor, properties);
                    MaterialPropertyState("_ColorBFireA", true, materialEditor, properties);
                    MaterialPropertyState("_GradientAngleFireA", true, materialEditor, properties);
                    MaterialPropertyState("_GradientScaleFireA", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_BloomFireA", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_BloomColorFireA", _ColorModeLayerA.floatValue == 1, materialEditor, properties);
                    MaterialPropertyState("_BloomEdgeWidthFireA", _ColorModeLayerA.floatValue==1, materialEditor, properties);
                    GUI.enabled = true;

                }


                GUILayout.Space(45);
                GUI.backgroundColor = m_BlackColorA;
                string _Text1 = _FireLayerAState ? "Minimize - Fire Layer B" : "Maximize - Fire Layer B";
                if (GUILayout.Button(_Text1, GUILayout.Height(20), GUILayout.MaxWidth(150)))
                {
                    _FireLayerBState = !_FireLayerBState;
                }
                GUI.backgroundColor = Color.white;
                if (_FireLayerBState == false)
                {
                    BlockDesignA(0, -40 - 10, 40, m_BlackColorA);
                    MaterialPropertyState("_EnableFireLayerB", true, materialEditor, properties);
                }
                else
                {
                    MaterialProperty _EnableFireLayerB = ShaderGUI.FindProperty("_EnableFireLayerB", properties);
                    MaterialProperty _ColorModeLayerB = ShaderGUI.FindProperty("_ColorModeFireB", properties);
                    int _H = 260;
                    _H -= _ColorModeLayerB.floatValue == 0 ? 15 : 0;
                    _H += _ColorModeLayerB.floatValue == 1 ? 38 : 0;
                    BlockDesignA(0, -_H - 10, _H, m_BlackColorA);
                    MaterialPropertyState("_EnableFireLayerB", true, materialEditor, properties);
                    GUI.enabled = _EnableFireLayerB.floatValue == 1;
                    GUILayout.Space(5);
                    MaterialPropertyState("_FireBHeight", true, materialEditor, properties);
                    MaterialPropertyState("_FireBXOffset", true, materialEditor, properties);
                    MaterialPropertyState("_FireBYOffset", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_ColorModeFireB", true, materialEditor, properties);
                    MaterialPropertyState("_ColorAFireB", true, materialEditor, properties);
                    MaterialPropertyState("_ColorBFireB", true, materialEditor, properties);
                    MaterialPropertyState("_GradientAngleFireB", true, materialEditor, properties);
                    MaterialPropertyState("_GradientScaleFireB", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_BloomFireB", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_BloomColorFireB", _ColorModeLayerB.floatValue == 1, materialEditor, properties);
                    MaterialPropertyState("_BloomEdgeWidthFireB", _ColorModeLayerB.floatValue == 1, materialEditor, properties);
                    GUI.enabled = true;

                }


                GUILayout.Space(45);
                GUI.backgroundColor = m_BlackColorA;
                string _Text2 = _FireLayerCState ? "Minimize - Fire Layer C" : "Maximize - Fire Layer C";
                if (GUILayout.Button(_Text2, GUILayout.Height(20), GUILayout.MaxWidth(150)))
                {
                    _FireLayerCState = !_FireLayerCState;
                }
                GUI.backgroundColor = Color.white;
                if (_FireLayerCState == false)
                {
                    BlockDesignA(0, -40 - 10, 40, m_BlackColorA);
                    MaterialPropertyState("_EnableFireLayerC", true, materialEditor, properties);
                }
                else
                {
                    MaterialProperty _EnableFireLayerC = ShaderGUI.FindProperty("_EnableFireLayerC", properties);
                    MaterialProperty _ColorModeLayerC = ShaderGUI.FindProperty("_ColorModeFireC", properties);
                    int _H = 260;
                    _H -= _ColorModeLayerC.floatValue == 0 ? 15 : 0;
                    _H += _ColorModeLayerC.floatValue == 1 ? 38 : 0;
                    BlockDesignA(0, -_H - 10, _H, m_BlackColorA);
                    MaterialPropertyState("_EnableFireLayerC", true, materialEditor, properties);
                    GUI.enabled = _EnableFireLayerC.floatValue == 1;
                    GUILayout.Space(5);
                    MaterialPropertyState("_FireCHeight", true, materialEditor, properties);
                    MaterialPropertyState("_FireCXOffset", true, materialEditor, properties);
                    MaterialPropertyState("_FireCYOffset", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_ColorModeFireC", true, materialEditor, properties);
                    MaterialPropertyState("_ColorAFireC", true, materialEditor, properties);
                    MaterialPropertyState("_ColorBFireC", true, materialEditor, properties);
                    MaterialPropertyState("_GradientAngleFireC", true, materialEditor, properties);
                    MaterialPropertyState("_GradientScaleFireC", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_BloomFireC", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_BloomColorFireC", _ColorModeLayerC.floatValue == 1, materialEditor, properties);
                    MaterialPropertyState("_BloomEdgeWidthFireC", _ColorModeLayerC.floatValue == 1, materialEditor, properties);
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


    }// Class


}// NameSpace