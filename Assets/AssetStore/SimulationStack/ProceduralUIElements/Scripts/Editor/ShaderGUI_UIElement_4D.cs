using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;



namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_4D : ShaderGUIHelper_PUE
    {
        

        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            Material targetMat = materialEditor.target as Material;
            List<MaterialProperty> propertyList = new List<MaterialProperty>(properties);

            if (propertyList.Count > 0)
            {

                ImageSizeRatioA(materialEditor, properties);


                Header(30, "Shape Properties", 20, 120);


                PointsBlock(materialEditor, properties);


                BlockDesignA(11, -40 - 10, 40, m_BlackColorB);
                MaterialPropertyState("_CornerRoundness", true, materialEditor, properties);


                RimA(materialEditor, properties, true, 11, 10);


                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_EdgeBlur", true, materialEditor, properties);


                ColorModeA(materialEditor, properties, "_EnableColor");


                TextureOverlayA(materialEditor, properties);


                LinesA(materialEditor, properties);


                InnerShadowA(materialEditor, properties);


                BorderA(materialEditor, properties);


                DropShadowA(materialEditor, properties);


                GUILayout.Space(100);


            }
        }


    }// Class


}// NameSpace



