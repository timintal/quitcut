using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;



namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_7H : ShaderGUIHelper_PUE
    {


        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            Material targetMat = materialEditor.target as Material;
            List<MaterialProperty> propertyList = new List<MaterialProperty>(properties);

            if (propertyList.Count > 0)
            {
                ImageSizeRatioA(materialEditor, properties);


                Header(30, "Shape Properties", 20, 120);

                BlockDesignA(1, -40 - 10, 40, m_BlackColorB);
                MaterialPropertyState("_RadiusCenterPoint", true, materialEditor, properties);


                BlockDesignA(11, -80 + 10, 80, m_BlackColorB);
                MaterialPropertyState("_Arc", true, materialEditor, properties);
                MaterialPropertyState("_Separation", true, materialEditor, properties);
                MaterialPropertyState("_Thickness", true, materialEditor, properties);


                BlockDesignA(11, -80 + 10, 80, m_BlackColorB);
                MaterialPropertyState("_XOffset", true, materialEditor, properties);
                MaterialPropertyState("_YOffset", true, materialEditor, properties);
                MaterialPropertyState("_Rotation", true, materialEditor, properties);


                RimA(materialEditor, properties, false, 11, 10);

                //MaterialProperty _EnableRim = ShaderGUI.FindProperty("_EnableRim", properties);
                //int _Temp = _EnableRim.floatValue == 1 ? 60 : 40;
                //BlockDesignA(11, -_Temp + 10, _Temp, m_BlackColorB);
                //materialEditor.ShaderProperty(_EnableRim, _EnableRim.displayName);
                //MaterialPropertyState("_RimWidth", _EnableRim.floatValue == 1, materialEditor, properties);

                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_EdgeBlur", true, materialEditor, properties);

                BlockDesignA(50, -40 - 10, 40, m_YellowColorA);
                MaterialPropertyState("_FillAmount", true, materialEditor, properties);


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

