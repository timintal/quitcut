using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_14F : ShaderGUIHelper_PUE
    {


        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            Material targetMat = materialEditor.target as Material;
            List<MaterialProperty> propertyList = new List<MaterialProperty>(properties);

            if (propertyList.Count > 0)
            {
                ImageSizeRatioA(materialEditor, properties);


                Header(30, "Shape Properties", 20, 120);


                MaterialProperty _EnableBorder = ShaderGUI.FindProperty("_EnableBorder", properties);
                MaterialProperty _MaskContainer = ShaderGUI.FindProperty("_MaskContainer", properties);

                int _H0 = 40;
                int _Sub = _EnableBorder.floatValue == 1 ? 20 : 0;

                if (_MaskContainer.floatValue == 0)
                {
                    _H0 = 40;
                }
                else if (_MaskContainer.floatValue == 1)
                {
                    _H0 = 83;
                }

                BlockDesignA(1, -40 - 15, 40, m_BlackColorB);
                materialEditor.ShaderProperty(_MaskContainer, _MaskContainer.displayName);

                if (_MaskContainer.floatValue < 2)
                {
                    BlockDesignA(16, -_H0 + 10, _H0, m_BlackColorB);
                    MaterialPropertyState("_CircleRadius", _MaskContainer.floatValue == 0, materialEditor, properties);

                    if(_MaskContainer.floatValue==1)
                    {
                        MaterialProperty _ChooseDimensionParameters = ShaderGUI.FindProperty("_ChooseDimensionParameters", properties);
                        MaterialPropertyState("_ChooseDimensionParameters", true, materialEditor, properties);
                        MaterialPropertyState("_Width", _ChooseDimensionParameters.floatValue==0, materialEditor, properties);
                        MaterialPropertyState("_Height", _ChooseDimensionParameters.floatValue==0, materialEditor, properties);
                        MaterialPropertyState("_WidthMargin", _ChooseDimensionParameters.floatValue==1, materialEditor, properties);
                        MaterialPropertyState("_HeightMargin", _ChooseDimensionParameters.floatValue==1, materialEditor, properties);
                    }

                    if (_MaskContainer.floatValue == 1)
                    {
                        BlockDesignA(11+(_MaskContainer.floatValue==1?3:0), -40 + 10, 40, m_BlackColorB);
                        MaterialPropertyState("_CornerRoundness", true, materialEditor, properties);
                    }

                    BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                    MaterialPropertyState("_ContainerEdgeBlur", true, materialEditor, properties);
                }

                if(_MaskContainer.floatValue==2)
                {
                    BlockDesignA(16, -90 + 10, 90, m_BlackColorB);
                    MaterialPropertyState("_MainTex", true, materialEditor, properties);
                }


                Header(45, "Grid Properties", 20, 110);


                BlockDesignA(1, -50, 40, m_BlackColorB);
                MaterialPropertyState("_GridSize", true, materialEditor, properties);


                BlockDesignA(11, -65, 70, m_BlackColorB);
                MaterialPropertyState("_LineWidth", true, materialEditor, properties);
                MaterialPropertyState("_Blur", true, materialEditor, properties);
                MaterialPropertyState("_Gamma", true, materialEditor, properties);


                BlockDesignA(6, -50, 60, m_BlackColorB);
                MaterialPropertyState("_Rotate", true, materialEditor, properties);
                MaterialPropertyState("_Twist", true, materialEditor, properties);


                BlockDesignA(11, -30, 40, m_BlackColorB);
                MaterialPropertyState("_Opacity", true, materialEditor, properties);


                Header(45, "Distortion", 20, 80);

                MaterialProperty _EnableDistortion = ShaderGUI.FindProperty("_EnableDistortion", properties);
                int _H2 = _EnableDistortion.floatValue == 1 ? 195 : 40;
                BlockDesignA(1, -_H2 - 20, _H2, m_BlackColorA);
                MaterialPropertyState("_EnableDistortion", true, materialEditor, properties);
                if (_EnableDistortion.floatValue == 1)
                {
                    GUILayout.Space(10);
                    MaterialPropertyState("_DistortionTexture", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_DistortionTextureScale", true, materialEditor, properties);
                    MaterialPropertyState("_DistortionIntensity", true, materialEditor, properties);
                    MaterialPropertyState("_AnimateDistortion", true, materialEditor, properties);
                }


                ColorModeC(materialEditor, properties, "");


                if (_MaskContainer.floatValue < 2)
                {
                    BorderA(materialEditor, properties);
                    InnerShadowA(materialEditor, properties);
                }

                GUILayout.Space(100);

            }
        }


    }// Class


}// NameSpace