using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_8A : ShaderGUIHelper_PUE
    {


        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            Material targetMat = materialEditor.target as Material;
            List<MaterialProperty> propertyList = new List<MaterialProperty>(properties);

            if (propertyList.Count > 0)
            {

                ImageSizeRatioA(materialEditor, properties);


                Header(30, "Shape Properties", 20, 120);


                BlockDesignA(1, -60-10, 60, m_BlackColorB);
                MaterialPropertyState("_ShapeBlendMode", true, materialEditor, properties);
                MaterialPropertyState("_Blend", true, materialEditor, properties);


                MaterialProperty _ChooseShapeA = ShaderGUI.FindProperty("_ChooseShapeA", properties);
                int _H = _ChooseShapeA.floatValue == 0 ? 100 : 160;
                BlockDesignA(11, -_H + 10, _H, m_BlackColorB);
                materialEditor.ShaderProperty(_ChooseShapeA, _ChooseShapeA.displayName);
                if (_ChooseShapeA.floatValue == 0)
                {
                    MaterialPropertyState("_RadiusA", true, materialEditor, properties);
                    MaterialPropertyState("_XOffsetA", true, materialEditor, properties);
                    MaterialPropertyState("_YOffsetA", true, materialEditor, properties);
                }
                else if (_ChooseShapeA.floatValue == 1)
                {
                    MaterialPropertyState("_WidthA", true, materialEditor, properties);
                    MaterialPropertyState("_HeightA", true, materialEditor, properties);
                    MaterialPropertyState("_CornerRoundnessA", true, materialEditor, properties);
                    MaterialPropertyState("_RotationA", true, materialEditor, properties);
                    MaterialPropertyState("_XOffsetA", true, materialEditor, properties);
                    MaterialPropertyState("_YOffsetA", true, materialEditor, properties);
                }

                MaterialProperty _ChooseShapeB = ShaderGUI.FindProperty("_ChooseShapeB", properties);
                _H = _ChooseShapeB.floatValue == 0 ? 100 : 160;
                BlockDesignA(11, -_H + 10, _H, m_BlackColorB);
                materialEditor.ShaderProperty(_ChooseShapeB, _ChooseShapeB.displayName);
                if (_ChooseShapeB.floatValue == 0)
                {
                    MaterialPropertyState("_RadiusB", true, materialEditor, properties);
                    MaterialPropertyState("_XOffsetB", true, materialEditor, properties);
                    MaterialPropertyState("_YOffsetB", true, materialEditor, properties);
                }
                else if (_ChooseShapeB.floatValue == 1)
                {
                    MaterialPropertyState("_WidthB", true, materialEditor, properties);
                    MaterialPropertyState("_HeightB", true, materialEditor, properties);
                    MaterialPropertyState("_CornerRoundnessB", true, materialEditor, properties);
                    MaterialPropertyState("_RotationB", true, materialEditor, properties);
                    MaterialPropertyState("_XOffsetB", true, materialEditor, properties);
                    MaterialPropertyState("_YOffsetB", true, materialEditor, properties);
                }


                RimA(materialEditor, properties, true, 11, -10);


                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_EdgeBlur", true, materialEditor, properties);


                ColorModeA(materialEditor, properties,"_EnableColor");


                BorderA(materialEditor, properties);


                InnerShadowA(materialEditor, properties);


                DropShadowA(materialEditor, properties);


                GUILayout.Space(100);


            }
        }


    }// Class


}// NameSpace
