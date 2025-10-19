using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_2E : ShaderGUIHelper_PUE
    {


        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            Material targetMat = materialEditor.target as Material;
            List<MaterialProperty> propertyList = new List<MaterialProperty>(properties);

            if (propertyList.Count > 0)
            {

                ImageSizeRatioA(materialEditor, properties);


                Header(30, "Shape Properties", 20, 120);


                int _H = 83;
                BlockDesignA(1, -_H - 10, _H, m_BlackColorB);
                MaterialProperty _ChooseDimensionParameters = ShaderGUI.FindProperty("_ChooseDimensionParameters", properties);
                MaterialPropertyState("_ChooseDimensionParameters", true, materialEditor, properties);
                MaterialPropertyState("_Width", _ChooseDimensionParameters.floatValue==0, materialEditor, properties);
                MaterialPropertyState("_Height", _ChooseDimensionParameters.floatValue==0, materialEditor, properties);
                MaterialPropertyState("_WidthMargin", _ChooseDimensionParameters.floatValue==1, materialEditor, properties);
                MaterialPropertyState("_HeightMargin", _ChooseDimensionParameters.floatValue==1, materialEditor, properties);


                MaterialProperty _ChooseRoundnessMode = ShaderGUI.FindProperty("_ChooseRoundnessMode", properties);
                int _H1 = _ChooseRoundnessMode.floatValue == 1 ? 120 : 60;
                BlockDesignA(14, -_H1 + 10, _H1, m_BlackColorB);
                materialEditor.ShaderProperty(_ChooseRoundnessMode, _ChooseRoundnessMode.displayName);
                MaterialPropertyState("_CornerRoundness", _ChooseRoundnessMode.floatValue == 0, materialEditor, properties);
                MaterialPropertyState("_TopLeftCornerRoundness", _ChooseRoundnessMode.floatValue == 1, materialEditor, properties);
                MaterialPropertyState("_TopRightCornerRoundness", _ChooseRoundnessMode.floatValue == 1, materialEditor, properties);
                MaterialPropertyState("_BottomRightCornerRoundness", _ChooseRoundnessMode.floatValue == 1, materialEditor, properties);
                MaterialPropertyState("_BottomLeftCornerRoundness", _ChooseRoundnessMode.floatValue == 1, materialEditor, properties);


                MaterialProperty _EnableRim = ShaderGUI.FindProperty("_EnableRim", properties);
                int _H2 = _EnableRim.floatValue == 1 ? 60 : 40;
                BlockDesignA(11, -_H2 + 10, _H2, m_BlackColorB);
                materialEditor.ShaderProperty(_EnableRim, _EnableRim.displayName);
                MaterialPropertyState("_RimWidth", _EnableRim.floatValue == 1, materialEditor, properties);


                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_EdgeBlur", true, materialEditor, properties);


                Header(50, "Shape Bend", 20, 80);
                BendShapeA(materialEditor, properties, 1);


                BlockDesignA(50, -60-10, 60, m_YellowColorA);
                MaterialPropertyState("_WidthFillAmount", true, materialEditor, properties);
                MaterialPropertyState("_HeightFillAmount", true, materialEditor, properties);


                ReflectionA(materialEditor, properties);


                GUILayout.Space(100);

            
            }
        }


    }// Class


}// NameSpace