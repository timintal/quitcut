using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_4E : ShaderGUIHelper_PUE
    {

        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            Material targetMat = materialEditor.target as Material;
            List<MaterialProperty> propertyList = new List<MaterialProperty>(properties);

            if (propertyList.Count > 0)
            {

                ImageSizeRatioA(materialEditor, properties);


                GUILayout.Space(30);
                GUI.backgroundColor = m_BlackColorA;
                GUILayout.Button("Shape Properties", GUILayout.Height(20), GUILayout.MaxWidth(120));
                GUI.backgroundColor = Color.white;
                PointsBlock(materialEditor, properties);


                BlockDesignA(11, -40 - 10, 40, m_BlackColorB);
                MaterialPropertyState("_CornerRoundness", true, materialEditor, properties);


                MaterialProperty _EnableRim = ShaderGUI.FindProperty("_EnableRim", properties);
                int _H = _EnableRim.floatValue == 1 ? 60 : 40;
                BlockDesignA(11, -_H + 10, _H, m_BlackColorB);
                materialEditor.ShaderProperty(_EnableRim, _EnableRim.displayName);
                MaterialPropertyState("_RimWidth", _EnableRim.floatValue == 1, materialEditor, properties);


                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_EdgeBlur", true, materialEditor, properties);


                ReflectionA(materialEditor, properties);


                GUILayout.Space(100);


            }
        }
    }


}
