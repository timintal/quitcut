using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralUIElements
{


    public class ShaderGUI_UIElement_1B : ShaderGUIHelper_PUE
    {


        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            Material targetMat = materialEditor.target as Material;
            List<MaterialProperty> propertyList = new List<MaterialProperty>(properties);

            if (propertyList.Count > 0)
            {

                ImageSizeRatioA(materialEditor, properties);


                Header(30, "Shape Properties", 20, 120);


                BlockDesignA(1, -40-10, 40, m_BlackColorB);
                MaterialPropertyState("_Radius", true, materialEditor, properties);


                MaterialProperty _EnableRim = ShaderGUI.FindProperty("_EnableRim", properties);
                RimA(materialEditor, properties, false, 11, 10);


                Header(50, "Bloom Properties", 20, 120);
                int _H = 40 + (_EnableRim.floatValue == 0 ? 20 : 0);
                BlockDesignA(1, -_H-10, _H, m_BlackColorA);
                MaterialPropertyState("_Bloom", true, materialEditor, properties);
                MaterialPropertyState("_BloomGamma", _EnableRim.floatValue == 0, materialEditor, properties);


                ColorModeB(materialEditor, properties,"");


                GUILayout.Space(100);


            }
        }


    }// Class


}/// namespace










//void MaterialPropertyState(string _PropertyName,bool _State, MaterialEditor _MaterialEditor, MaterialProperty[] _Properties)
//{
//    if (_State)
//    {
//        MaterialProperty _Property = ShaderGUI.FindProperty(_PropertyName, _Properties);
//        _MaterialEditor.ShaderProperty(_Property, _Property.displayName);
//    }
//}



//MaterialProperty _ChooseColorType = ShaderGUI.FindProperty("_ChooseColorType", properties);
//materialEditor.ShaderProperty(_ChooseColorType, _ChooseColorType.displayName);

//MaterialPropertyState("_Color",(_ChooseColorType.floatValue==0), materialEditor, properties);

//if (_ChooseColorType.floatValue > 0)
//{
//    MaterialPropertyState("_EnableToonGradient", true, materialEditor, properties);
//    MaterialProperty _EnableToonGradient = ShaderGUI.FindProperty("_EnableToonGradient", properties);
//    MaterialPropertyState("_StepsToonGradient", _EnableToonGradient.floatValue == 1, materialEditor, properties);

//    if (_ChooseColorType.floatValue == 1)
//    {
//        MaterialPropertyState("_RadialScale", true, materialEditor, properties);
//        MaterialPropertyState("_RadialSpread", true, materialEditor, properties);
//    }

//    MaterialPropertyState("_ChooseGradientType", (_ChooseColorType.floatValue == 2), materialEditor, properties);
//    MaterialProperty _ChooseGradientType = ShaderGUI.FindProperty("_ChooseGradientType", properties);


//    MaterialPropertyState("_ColorA", true, materialEditor, properties);
//    MaterialPropertyState("_ColorB", true, materialEditor, properties);
//    if (_ChooseColorType.floatValue == 2)
//    {
//        MaterialPropertyState("_ColorC", (_ChooseGradientType.floatValue > 0), materialEditor, properties);
//        MaterialPropertyState("_ColorD", (_ChooseGradientType.floatValue > 1), materialEditor, properties);
//    }


//    if (_ChooseColorType.floatValue == 2)
//    {
//        MaterialPropertyState("_GradientAngle", true, materialEditor, properties);
//        MaterialPropertyState("_GradientScale", true, materialEditor, properties);
//        MaterialPropertyState("_GradientSpread", true, materialEditor, properties);

//        MaterialProperty _SharpBoundary = ShaderGUI.FindProperty("_SharpBoundary", properties);
//        MaterialPropertyState("_SharpBoundary", true, materialEditor, properties);
//        MaterialPropertyState("_BoundaryBlur", _SharpBoundary.floatValue == 1, materialEditor, properties);
//        MaterialPropertyState("_BoundaryOffset", _SharpBoundary.floatValue == 1, materialEditor, properties);
//    }

//    MaterialPropertyState("_GradientXOffset", true, materialEditor, properties);
//    MaterialPropertyState("_GradientYOffset", true, materialEditor, properties);
//}





//public static GUIContent albedoText = EditorGUIUtility.TrTextContent("Albedo", "Albedo (RGB) and Transparency (A)");

//static MaterialProperty FindAndRemoveProperty(string propertyName, List<MaterialProperty> propertyList)
//{
//    return FindAndRemoveProperty(propertyName, propertyList, true);
//}

//static MaterialProperty FindAndRemoveProperty(string propertyName, List<MaterialProperty> propertyList, bool propertyIsMandatory)
//{
//    for (var i = 0; i < propertyList.Count; i++)
//        if (propertyList[i] != null && propertyList[i].name == propertyName)
//        {
//            var property = propertyList[i];
//            propertyList.RemoveAt(i);
//            return property;
//        }

//    // We assume all required properties can be found, otherwise something is broken
//    if (propertyIsMandatory)
//        throw new ArgumentException("Could not find MaterialProperty: '" + propertyName + "', Num properties: " + propertyList.Count);
//    return null;
//}