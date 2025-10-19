using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_19A : ShaderGUIHelper_PUE
    {
        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            Material targetMat = materialEditor.target as Material;
            List<MaterialProperty> propertyList = new List<MaterialProperty>(properties);

            if (propertyList.Count > 0)
            {
                ImageSizeRatioA(materialEditor, properties);


                Header(30, "Shape Properties", 20, 120);
                BlockDesignA(1, -40-10, 40, m_BlackColorB);
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


                ColorModeA(materialEditor, properties, "_EnableColor");


                BorderA(materialEditor, properties);


                InnerShadowA(materialEditor, properties);


                DropShadowA(materialEditor, properties);


                GUILayout.Space(100);


            }
        }
    }


}


