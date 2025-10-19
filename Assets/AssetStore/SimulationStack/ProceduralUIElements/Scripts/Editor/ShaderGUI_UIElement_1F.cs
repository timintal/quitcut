using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralUIElements
{
    
    
    public class ShaderGUI_UIElement_1F : ShaderGUIHelper_PUE
    {
        
        
        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            Material targetMat = materialEditor.target as Material;
            List<MaterialProperty> propertyList = new List<MaterialProperty>(properties);

            if (propertyList.Count > 0)
            {

                ImageSizeRatioA(materialEditor, properties);


                Header(30, "Shape Properties", 20, 120);


                BlockDesignA(1, -60 - 12, 60, m_BlackColorB);
                MaterialPropertyState("_Radius", true, materialEditor, properties);
                MaterialPropertyState("_EdgeBlur", true, materialEditor, properties);


                BlockDesignA(13, -120 - 10, 120, m_BlackColorB);
                GUILayout.Space(18);
                GUILayout.Label("Inner Shadow");
                MaterialPropertyState("_InnerShadowSize", true, materialEditor, properties);
                MaterialPropertyState("_InnerShadowSpread", true, materialEditor, properties);
                MaterialPropertyState("_InnerShadowXOffset", true, materialEditor, properties);
                MaterialPropertyState("_InnerShadowYOffset", true, materialEditor, properties);


                BlockDesignA(14, -120 - 10, 120, m_BlackColorB);
                GUILayout.Space(18);
                GUILayout.Label("Dot");
                MaterialPropertyState("_DotRadius", true, materialEditor, properties);
                MaterialPropertyState("_DotEdgeBlur", true, materialEditor, properties);
                MaterialPropertyState("_DotXOffset", true, materialEditor, properties);
                MaterialPropertyState("_DotYOffset", true, materialEditor, properties);


                ColorModeB(materialEditor, properties, "");


                BorderA(materialEditor, properties);


                GUILayout.Space(100);


            }
        }


    }// Class


}/// namespace