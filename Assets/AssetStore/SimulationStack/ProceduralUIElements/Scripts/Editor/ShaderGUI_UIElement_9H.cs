using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;



namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_9H : ShaderGUIHelper_PUE
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

                RimA(materialEditor, properties, false, 11, 10);

                //MaterialProperty _EnableRim = ShaderGUI.FindProperty("_EnableRim", properties);
                //int _Temp = _EnableRim.floatValue == 1 ? 60 : 40;
                //BlockDesignA(11, -_Temp + 10, _Temp, m_BlackColorB);
                //materialEditor.ShaderProperty(_EnableRim, _EnableRim.displayName);
                //MaterialPropertyState("_RimWidth", _EnableRim.floatValue == 1, materialEditor, properties);

                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_EdgeBlur", true, materialEditor, properties);


                Header(50, "Blur", 20, 70);
                BlockDesignA(1, -60 - 10, 60, new Color(0.7f, 0.0f, 0.4f, 0.8f));
                MaterialProperty _EnableBlur = ShaderGUI.FindProperty("_EnableBlur", properties);
                MaterialPropertyState("_EnableBlur", true, materialEditor, properties);
                GUI.enabled = _EnableBlur.floatValue == 1;
                MaterialPropertyState("_BlurMagnitude", true, materialEditor, properties);
                GUI.enabled = true;


                Header(50, "Glass Properties", 20, 120);
                BlockDesignA(1, -80 - 10, 80, new Color(0.7f, 0.0f, 0.4f, 0.8f));
                MaterialPropertyState("_DistortionType", true, materialEditor, properties);
                MaterialPropertyState("_Distortion", true, materialEditor, properties);
                MaterialPropertyState("_DistortionArea", true, materialEditor, properties);


                ColorModeC(materialEditor, properties, "_Opacity");


                BorderA(materialEditor, properties);


                InnerShadowA(materialEditor, properties);


                DropShadowA(materialEditor, properties);


                GUILayout.Space(100);


            }
        }


    }// Class


}// NameSpace

