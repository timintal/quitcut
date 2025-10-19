using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_7G : ShaderGUIHelper_PUE
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


                BlockDesignA(11, -80 +10, 80, m_BlackColorB);
                MaterialPropertyState("_Arc", true, materialEditor, properties);
                MaterialPropertyState("_Separation", true, materialEditor, properties);
                MaterialPropertyState("_Thickness", true, materialEditor, properties);


                BlockDesignA(11, -80+10 , 80, m_BlackColorB);
                MaterialPropertyState("_XOffset", true, materialEditor, properties);
                MaterialPropertyState("_YOffset", true, materialEditor, properties);
                MaterialPropertyState("_Rotation", true, materialEditor, properties);


                RimA(materialEditor, properties, true, 11, 10);


                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_EdgeBlur", true, materialEditor, properties);


                BlockDesignA(50, -40-10, 40, m_YellowColorA);
                MaterialPropertyState("_FillAmount", true, materialEditor, properties);


                ColorModeA(materialEditor, properties, "_EnableColor");


                DropShadowA(materialEditor, properties);


                BorderA(materialEditor, properties);


                GUILayout.Space(100);


            }
        }


    }// Class


}// NameSpace