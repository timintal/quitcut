using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_2G : ShaderGUIHelper_PUE
    {
        

        public bool _ShadowBState
        {
            get { return PlayerPrefs.GetInt("_ShadowBState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_ShadowBState", value ? 1 : 0); }
        }

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


                RimA(materialEditor, properties, true, 11, 10);


                BlockDesignA(11, -40 + 10, 40, m_BlackColorB);
                MaterialPropertyState("_EdgeBlur", true, materialEditor, properties);

             
                Header(50, "Shape Bend", 20, 80);
                BendShapeA(materialEditor, properties, 1);


                BlockDesignA(50, -60-10, 60, m_YellowColorA);
                MaterialPropertyState("_WidthFillAmount", true, materialEditor, properties);
                MaterialPropertyState("_HeightFillAmount", true, materialEditor, properties);


                ColorModeA(materialEditor, properties,"_EnableColor");


                BorderA(materialEditor, properties);


                InnerShadowA(materialEditor, properties);


                DropShadowA(materialEditor, properties);


                MaterialProperty _EnableDropShadowB = ShaderGUI.FindProperty("_EnableDropShadowB", properties);
                MaterialProperty _DropShadowBColorMode = ShaderGUI.FindProperty("_DropShadowBColorMode", properties);
                MaterialProperty _DropShadowBGradientMode = ShaderGUI.FindProperty("_DropShadowBGradientMode", properties);

                GUILayout.Space(45);
                Color _ContainerColor = m_BlackColorA;
                GUI.backgroundColor = _ContainerColor;
                string _Text = _ShadowBState ? "Minimize" : "Maximize";
                if (GUILayout.Button(_Text, GUILayout.Height(20), GUILayout.MaxWidth(80)))
                {
                    _ShadowBState = !_ShadowBState;
                }
                GUI.backgroundColor = Color.white;
                if (_ShadowBState == false)
                {
                    BlockDesignA(0, -40 - 10, 40, m_BlackColorA);
                    materialEditor.ShaderProperty(_EnableDropShadowB, _EnableDropShadowB.displayName);
                }
                else
                {
                    int _Height = _DropShadowBColorMode.floatValue == 1 ? 324 : 234;
                    if (_DropShadowBColorMode.floatValue == 1)
                    {
                        _Height += _DropShadowBGradientMode.floatValue == 1 ? 20 : 0;
                        _Height += _DropShadowBGradientMode.floatValue == 2 ? 40 : 0;
                    }
                    BlockDesignA(0, -_Height - 10, _Height, _ContainerColor);
                    materialEditor.ShaderProperty(_EnableDropShadowB, _EnableDropShadowB.displayName);
                    GUILayout.Space(10);
                    GUI.enabled = _EnableDropShadowB.floatValue == 1;
                    MaterialPropertyState("_DropShadowBSize", true, materialEditor, properties);
                    MaterialPropertyState("_DropShadowBSpread", true, materialEditor, properties);
                    MaterialPropertyState("_DropShadowBGamma", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_DropShadowBXOffset", true, materialEditor, properties);
                    MaterialPropertyState("_DropShadowBYOffset", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_DropShadowBOpacity", true, materialEditor, properties);
                    materialEditor.ShaderProperty(_DropShadowBColorMode, _DropShadowBColorMode.displayName);

                    if (_DropShadowBColorMode.floatValue == 0)
                    {
                        MaterialPropertyState("_DropShadowBColor", true, materialEditor, properties);
                    }
                    else if (_DropShadowBColorMode.floatValue == 1)
                    {
                        materialEditor.ShaderProperty(_DropShadowBGradientMode, _DropShadowBGradientMode.displayName);
                        float _Value = _DropShadowBGradientMode.floatValue;
                        MaterialPropertyState("_ColorBE", true, materialEditor, properties);
                        MaterialPropertyState("_ColorBF", true, materialEditor, properties);
                        MaterialPropertyState("_ColorBG", (_Value > 0), materialEditor, properties);
                        MaterialPropertyState("_ColorBH", (_Value > 1), materialEditor, properties);
                        GUILayout.Space(10);
                        MaterialPropertyState("_DropShadowBGradientAngle", true, materialEditor, properties);
                        MaterialPropertyState("_DropShadowBGradientScale", true, materialEditor, properties);
                    }
                    GUI.enabled = true;
                }


                GUILayout.Space(100);


            }
        }


    }// Class


}// NameSpace


