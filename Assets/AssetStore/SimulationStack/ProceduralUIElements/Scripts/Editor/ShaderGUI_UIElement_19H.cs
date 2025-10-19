using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;



namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_19H : ShaderGUIHelper_PUE
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
                MaterialPropertyState("_GearSize", true, materialEditor, properties);


                BlockDesignA(11, -30, 40, m_BlackColorB);
                MaterialPropertyState("_GearRingWidth", true, materialEditor, properties);


                BlockDesignA(11, -149, 155, m_BlackColorB);
                GUILayout.Label("Gear Teeth Properties");
                MaterialPropertyState("_NoOfGearTeeths", true, materialEditor, properties);
                MaterialPropertyState("_GearWidthA", true, materialEditor, properties);
                MaterialPropertyState("_GearWidthB", true, materialEditor, properties);
                MaterialPropertyState("_GearHeight", true, materialEditor, properties);
                MaterialPropertyState("_GearCornerRoundness", true, materialEditor, properties);
                MaterialPropertyState("_GearRadialOffset", true, materialEditor, properties);


                BlockDesignA(11, -30, 40, m_BlackColorB);
                MaterialPropertyState("_GearRotation", true, materialEditor, properties);


                RimA(materialEditor, properties, true, 11, 10);


                BlockDesignA(11, -30, 40, m_BlackColorB);
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

