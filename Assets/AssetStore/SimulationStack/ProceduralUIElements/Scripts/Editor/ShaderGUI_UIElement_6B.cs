using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_6B : ShaderGUIHelper_PUE
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
                MaterialPropertyState("_Size", true, materialEditor, properties);


                MaterialProperty _EnableRim = ShaderGUI.FindProperty("_EnableRim", properties);
                RimA(materialEditor, properties, false, 11, 10);


                Header(50, "Bloom Properties", 20, 120);
                int _H = 40 + (_EnableRim.floatValue == 0 ? 20 : 0);
                BlockDesignA(1, -_H - 10, _H, m_BlackColorA);
                MaterialPropertyState("_Bloom", true, materialEditor, properties);
                MaterialPropertyState("_BloomGamma", _EnableRim.floatValue == 0, materialEditor, properties);


                ColorModeB(materialEditor, properties, "");


                GUILayout.Space(100);


            }
        }


    }// Class


}// Name Space