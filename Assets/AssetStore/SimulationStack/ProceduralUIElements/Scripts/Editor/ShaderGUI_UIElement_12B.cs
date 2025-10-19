using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;



namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_12B : ShaderGUIHelper_PUE
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
                MaterialPropertyState("_Radius", true, materialEditor, properties);
                //MaterialPropertyState("_RingWidth", true, materialEditor, properties);


                BlockDesignA(11, -40+10, 40, m_BlackColorB);
                MaterialPropertyState("_NumberOfCells", true, materialEditor, properties);
                BlockDesignA(11, -60 + 10, 60, m_BlackColorB);
                MaterialPropertyState("_CellHeight", true, materialEditor, properties);
                MaterialPropertyState("_CellWidth", true, materialEditor, properties);
                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_CornerRoundness", true, materialEditor, properties);
                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_EdgeBlur", true, materialEditor, properties);


                MaterialProperty _DisableCell = ShaderGUI.FindProperty("_DisableCell", properties);
                int _H2 = _DisableCell.floatValue == 1 ? 120 : 100;
                BlockDesignA(50, -_H2 - 11, _H2, m_YellowColorA);
                MaterialPropertyState("_FillAmount", true, materialEditor, properties);
                materialEditor.ShaderProperty(_DisableCell, _DisableCell.displayName);
                MaterialPropertyState("_DisableCellColor", _DisableCell.floatValue == 1, materialEditor, properties);
                MaterialPropertyState("_IncludeBorder", true, materialEditor, properties);
                MaterialPropertyState("_IncludeLines", true, materialEditor, properties);


                ColorModeA(materialEditor, properties, "");


                LinesB(materialEditor, properties);


                BorderA(materialEditor, properties);


                GUILayout.Space(100);


            }
        }


    }// Class


}// NameSpace

