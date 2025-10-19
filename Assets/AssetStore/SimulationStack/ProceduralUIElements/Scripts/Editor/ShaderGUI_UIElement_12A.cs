using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_12A : ShaderGUIHelper_PUE
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


                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_EdgeBlur", true, materialEditor, properties);


                MaterialProperty _EnableContainerColor = ShaderGUI.FindProperty("_EnableContainerColor", properties);
                _H = _EnableContainerColor.floatValue == 1 ? 60 : 40;
                BlockDesignA(11, -_H + 10, _H, m_BlackColorB);
                materialEditor.ShaderProperty(_EnableContainerColor, _EnableContainerColor.displayName);
                MaterialPropertyState("_ContainerColor", _EnableContainerColor.floatValue == 1, materialEditor, properties);


                Header(30, "Shape Bend (Container)", 20, 170);


                MaterialProperty _EnableBending = ShaderGUI.FindProperty("_EnableBending", properties);
                _H = _EnableBending.floatValue == 1 ? 100 : 40;
                BlockDesignA(1, -_H - 10, _H, m_BlackColorB);
                materialEditor.ShaderProperty(_EnableBending, _EnableBending.displayName);
                if (_EnableBending.floatValue == 1)
                {
                    MaterialPropertyState("_MirrorBending", true, materialEditor, properties);
                    MaterialPropertyState("_BendX", true, materialEditor, properties);
                    MaterialPropertyState("_BendY", true, materialEditor, properties);
                }


                Header(30, "Shape Properties (Cells)", 20, 150);


                BlockDesignA(1, -40-10, 40, m_BlackColorB);
                MaterialPropertyState("_NoOfCells", true, materialEditor, properties);
                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_CellOffset", true, materialEditor, properties);
                BlockDesignA(11, -60 + 10, 60, m_BlackColorB);
                MaterialPropertyState("_CellWidth", true, materialEditor, properties);
                MaterialPropertyState("_CellHeight", true, materialEditor, properties);
                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_CellCornerRoundness", true, materialEditor, properties);
                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_RotateCell", true, materialEditor, properties);
                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_CellEdgeBlur", true, materialEditor, properties);


                MaterialProperty _EnableDisableCell = ShaderGUI.FindProperty("_EnableDisableCell", properties);
                int _H2 = _EnableDisableCell.floatValue == 1 ? 80 : 55;
                BlockDesignA(50, -_H2 - 10, _H2, m_YellowColorA);
                MaterialPropertyState("_CellsFillAmount", true, materialEditor, properties);
                materialEditor.ShaderProperty(_EnableDisableCell, _EnableDisableCell.displayName);
                MaterialPropertyState("_DisableCellColor", _EnableDisableCell.floatValue == 1, materialEditor, properties);


                ColorModeA(materialEditor, properties, "_ApplyColorModeToEachCell");


                InnerShadowA(materialEditor, properties);


                BorderA(materialEditor, properties);


                GUILayout.Space(100);


            }
        }


    }// Class


}// NameSpace


