using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_13A : ShaderGUIHelper_PUE
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
                MaterialPropertyState("_NoOfCells", true, materialEditor, properties);


                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialProperty _DotShape = ShaderGUI.FindProperty("_DotShape", properties);
                materialEditor.ShaderProperty(_DotShape, _DotShape.displayName);

                if (_DotShape.floatValue == 0)
                {
                    BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                    MaterialPropertyState("_Radius", _DotShape.floatValue == 0, materialEditor, properties);
                }
                if (_DotShape.floatValue == 1)
                {
                    BlockDesignA(11, -60 + 10, 60, m_BlackColorB);
                    MaterialPropertyState("_Width", _DotShape.floatValue == 1, materialEditor, properties);
                    MaterialPropertyState("_Height", _DotShape.floatValue == 1, materialEditor, properties);

                    BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                    MaterialPropertyState("_CornerRoundness", _DotShape.floatValue == 1, materialEditor, properties);

                    BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                    MaterialPropertyState("_Rotation", _DotShape.floatValue == 1, materialEditor, properties);
                }


                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_EdgeBlur", true, materialEditor, properties);


                BlockDesignA(50, -50, 40, m_YellowColorA);
                MaterialPropertyState("_FillAmount", true, materialEditor, properties);


                Header(50, "Animation Properties", 20, 150);
                BlockDesignA(1, -135 - 10, 135, m_BlueColorA);
                MaterialPropertyState("_AnimatePosition", true, materialEditor, properties);
                MaterialPropertyState("_AnimateScale", true, materialEditor, properties);
                MaterialPropertyState("_AnimateColorAlpha", true, materialEditor, properties);
                GUILayout.Space(15);
                MaterialPropertyState("_AnimationScale", true, materialEditor, properties);
                MaterialPropertyState("_AnimationSpeed", true, materialEditor, properties);


                ColorModeA(materialEditor, properties, "_ApplyColorModeToEachCell");


                BorderA(materialEditor, properties);


                DropShadowA(materialEditor, properties);


                GUILayout.Space(100);


            }
        }


    }// Class


}// NameSpace