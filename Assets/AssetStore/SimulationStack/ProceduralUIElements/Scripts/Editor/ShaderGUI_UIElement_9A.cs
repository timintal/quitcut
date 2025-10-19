using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;



namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_9A : ShaderGUIHelper_PUE
    {
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

                if (_MaskContainer.floatValue == 0)
                {
                    _H0 = 40;
                }
                else if (_MaskContainer.floatValue == 1)
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

                    if (_MaskContainer.floatValue == 1)
                    {
                        MaterialProperty _ChooseDimensionParameters = ShaderGUI.FindProperty("_ChooseDimensionParameters", properties);
                        MaterialPropertyState("_ChooseDimensionParameters", true, materialEditor, properties);
                        MaterialPropertyState("_Width", _ChooseDimensionParameters.floatValue == 0, materialEditor, properties);
                        MaterialPropertyState("_Height", _ChooseDimensionParameters.floatValue == 0, materialEditor, properties);
                        MaterialPropertyState("_WidthMargin", _ChooseDimensionParameters.floatValue == 1, materialEditor, properties);
                        MaterialPropertyState("_HeightMargin", _ChooseDimensionParameters.floatValue == 1, materialEditor, properties);
                    }

                    MaterialPropertyState("_PolygonSize", _MaskContainer.floatValue == 2, materialEditor, properties);
                    MaterialPropertyState("_PolygonTurns", _MaskContainer.floatValue == 2, materialEditor, properties);
                    MaterialPropertyState("_PolygonEdgeAngle", _MaskContainer.floatValue == 2, materialEditor, properties);

                    MaterialPropertyState("_HeartSize", _MaskContainer.floatValue == 3, materialEditor, properties);

                    if (_MaskContainer.floatValue == 1 || _MaskContainer.floatValue == 2)
                    {
                        BlockDesignA(11 + (_MaskContainer.floatValue == 1 ? 3 : 0), -40 + 10, 40, m_BlackColorB);
                        MaterialPropertyState("_CornerRoundness", true, materialEditor, properties);
                    }

                    MaterialProperty _EnableRim = ShaderGUI.FindProperty("_EnableRim", properties);
                    int _Temp = _EnableRim.floatValue == 1 ? 60 : 40;
                    BlockDesignA(11, -_Temp + 10, _Temp, m_BlackColorB);
                    materialEditor.ShaderProperty(_EnableRim, _EnableRim.displayName);
                    MaterialPropertyState("_RimWidth", _EnableRim.floatValue == 1, materialEditor, properties);

                    BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                    MaterialPropertyState("_EdgeBlur", true, materialEditor, properties);
                }

                if (_MaskContainer.floatValue == 4)
                {
                    BlockDesignA(11, -90 + 10, 90, m_BlackColorB);
                    MaterialPropertyState("_ShapeTexture", true, materialEditor, properties);
                }


                BlockDesignA(50, -55, 50, new Color(0.7f, 0.0f, 0.4f, 0.8f));
                MaterialPropertyState("_BlurMagnitude", true, materialEditor, properties);


                Header(50, "Texture Noise (Multiply)", 20, 150);

                MaterialProperty _EnableNoise = ShaderGUI.FindProperty("_EnableNoise", properties);
                int _H1 = _EnableNoise.floatValue == 1 ? 195 : 40;
                BlockDesignA(1, -_H1 - 10, _H1, m_BlackColorA);
                MaterialPropertyState("_EnableNoise", true, materialEditor, properties);
                if (_EnableNoise.floatValue == 1)
                {
                    GUILayout.Space(10);
                    MaterialPropertyState("_MainTex", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_TextureScale", true, materialEditor, properties);
                    MaterialPropertyState("_NoiseIntensity", true, materialEditor, properties);
                    MaterialPropertyState("_NoiseAnimate", true, materialEditor, properties);
                }


                ColorModeC(materialEditor, properties, "_Opacity");


                if (_MaskContainer.floatValue != 4 && _MaskContainer.floatValue != 5)
                {
                    BorderA(materialEditor, properties);

                    DropShadowA(materialEditor, properties);
                }


                GUILayout.Space(100);


            }
        }


    }// Class


}// NameSpace

