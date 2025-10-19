using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_6D : ShaderGUIHelper_PUE
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


                RimA(materialEditor, properties, true, 11, 10);


                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_EdgeBlur", true, materialEditor, properties);


                Header(50, "Shape Fill", 20, 80);
                FillA(materialEditor, properties, 1);


                DisplaceShapeA(materialEditor, properties,50);


                ColorModeA(materialEditor, properties,"_EnableColor");


                TextureOverlayA(materialEditor, properties);


                LinesA(materialEditor, properties);


                BorderA(materialEditor, properties);


                InnerShadowA(materialEditor, properties);


                DropShadowA(materialEditor, properties);


                GUILayout.Space(100);


            }
        }


    }// Class


}// NameSpace