using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ProceduralUIElements
{

#if UNITY_EDITOR

    public abstract class ShaderGUIHelper_PUE : ShaderGUI
    {
        public bool _PointsState
        {
            get { return PlayerPrefs.GetInt("_PointsState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_PointsState", value ? 1 : 0); }
        }

        bool _DisplaceShape
        {
            get { return PlayerPrefs.GetInt("_DisplaceShape") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_DisplaceShape", value ? 1 : 0); }
        }

        bool _AlphaClipState
        {
            get { return PlayerPrefs.GetInt("_AlphaClipState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_AlphaClipState", value ? 1 : 0); }
        }

        bool _ColorModeAState
        {
            get { return PlayerPrefs.GetInt("_ColorModeAState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_ColorModeAState", value ? 1 : 0); }
        }

        bool _TextureOverlayAState
        {
            get { return PlayerPrefs.GetInt("_TextureOverlayAState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_TextureOverlayAState", value ? 1 : 0); }
        }

        bool _LinesAState
        {
            get { return PlayerPrefs.GetInt("_LineAState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_LineAState", value ? 1 : 0); }
        }

        bool _BorderAState
        {
            get { return PlayerPrefs.GetInt("_BorderAState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_BorderAState", value ? 1 : 0); }
        }

        bool _DropShadowAState
        {
            get { return PlayerPrefs.GetInt("_ShadowOneState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_ShadowOneState", value ? 1 : 0); }
        }

        bool _InnerShadowBState
        {
            get { return PlayerPrefs.GetInt("_InnerShadowBState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_InnerShadowBState", value ? 1 : 0); }
        }

        public bool _FireLayerAState
        {
            get { return PlayerPrefs.GetInt("_FireLayerAState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_FireLayerAState", value ? 1 : 0); }
        }

        public bool _FireLayerBState
        {
            get { return PlayerPrefs.GetInt("_FireLayerBState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_FireLayerBState", value ? 1 : 0); }
        }

        public bool _FireLayerCState
        {
            get { return PlayerPrefs.GetInt("_FireLayerCState") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("_FireLayerCState", value ? 1 : 0); }
        }



        public Color m_BlackColorA = new Color(0, 0, 0, 1.0f);
        public Color m_BlackColorB = new Color(0, 0, 0, 0.6f);
        public Color m_YellowColorA = new Color(1, 1, 0.1f, 0.8f);
        public Color m_YellowColorB = new Color(1, 1, 0.1f, 0.5f);
        public Color m_BlueColorA = new Color(0.0f, 0.2f, 0.9f, 0.6f);
        public Color m_RedColorA = new Color(0.8f, 0.0f, 0.0f, 0.8f);

        public Color m_PurpleA = new Color(0.7f, 0.0f, 0.4f, 0.8f);




        public void MaterialPropertyState(string _PropertyName, bool _State, MaterialEditor _MaterialEditor, MaterialProperty[] _Properties)
        {
            if (_State)
            {
                MaterialProperty _Property = ShaderGUI.FindProperty(_PropertyName, _Properties);
                _MaterialEditor.ShaderProperty(_Property, _Property.displayName);
            }
        }

        public void BlockDesignA(int _TopSpace, int _BottomSpace, int _Height, Color _Color)
        {
            GUILayout.Space(_TopSpace);
            GUI.backgroundColor = _Color;
            GUI.enabled = false;
            GUILayout.Button("", GUILayout.Height(_Height));
            GUI.enabled = true;
            GUILayout.Space(_BottomSpace);
            GUI.backgroundColor = Color.white;
        }

        public void Header(int _TopSpace, string _Title, int _Height, int _Width)
        {
            GUILayout.Space(_TopSpace);
            GUI.backgroundColor = m_BlackColorA;
            GUILayout.Button(_Title, GUILayout.Height(_Height), GUILayout.MaxWidth(_Width));
            GUI.backgroundColor = Color.white;
        }




        public void PointsBlock(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            MaterialProperty _NoOfPoints = ShaderGUI.FindProperty("_NoOfPoints", properties);
            GUILayout.Space(1);
            GUI.backgroundColor = m_BlackColorA;
            string _Text = _PointsState ? "Minimize" : "Maximize";
            if (GUILayout.Button(_Text, GUILayout.Height(20), GUILayout.MaxWidth(80)))
            {
                _PointsState = !_PointsState;
            }
            GUI.backgroundColor = m_BlackColorB;
            float _H = 45 + (_NoOfPoints.floatValue + 3) * 70 - _NoOfPoints.floatValue * 5.0f;
            GUI.enabled = false;
            GUILayout.TextArea("", GUILayout.Height(_PointsState ? _H : 40));
            GUI.enabled = true;
            GUI.backgroundColor = Color.white;
            GUILayout.Space(_PointsState ? -_H - 10 : -50 - 0);
            materialEditor.ShaderProperty(_NoOfPoints, _NoOfPoints.displayName);

            MaterialPropertyState("_PointsIdentifier", _PointsState, materialEditor, properties);

            if (_PointsState == true)
            {
                if (_NoOfPoints.floatValue >= 0)
                {
                    PointSliders(materialEditor, properties, 1, true, new Color(1, 0, 0, 1));
                    PointSliders(materialEditor, properties, 2, true, new Color(0, 1, 0, 1));
                    PointSliders(materialEditor, properties, 3, true, new Color(0, 0, 1, 1));
                }

                PointSliders(materialEditor, properties, 4, _NoOfPoints.floatValue >= 1, new Color(1, 1, 0, 1));
                PointSliders(materialEditor, properties, 5, _NoOfPoints.floatValue >= 2, new Color(1, 1, 1, 1));
                PointSliders(materialEditor, properties, 6, _NoOfPoints.floatValue >= 3, new Color(0, 0, 0, 1));
                PointSliders(materialEditor, properties, 7, _NoOfPoints.floatValue >= 4, new Color(0.5f, 0.05f, 0.05f, 1));
                PointSliders(materialEditor, properties, 8, _NoOfPoints.floatValue >= 5, new Color(0.5f, 0, 1, 1));
                PointSliders(materialEditor, properties, 9, _NoOfPoints.floatValue >= 6, new Color(0, 0.5f, 1, 1));
                PointSliders(materialEditor, properties, 10, _NoOfPoints.floatValue >= 7, new Color(0, 0.4f, 0, 1));
            }
        }

        void PointSliders(MaterialEditor materialEditor, MaterialProperty[] properties, int _Index, bool _State, Color _Color)
        {
            if (_State == false) return;

            GUI.backgroundColor = _Color;
            GUILayout.Space(5);
            GUILayout.Button("", GUILayout.Height(21), GUILayout.MaxWidth(40));
            GUILayout.Space(-32);
            GUI.backgroundColor = Color.white;
            MaterialPropertyState("_X_" + _Index.ToString(), _State, materialEditor, properties);
            MaterialPropertyState("_Y_" + _Index.ToString(), _State, materialEditor, properties);
        }


        public void CheckForEditorTheme()
        {
            if (EditorGUIUtility.isProSkin)
            {
                m_BlackColorA = new Color(0, 0, 0, 0.85f);
                m_BlackColorB = new Color(0, 0, 0, 0.5f);
            }
            else
            {
                m_BlackColorA = new Color(0.97f, 0.97f, 0.97f, 1);
                m_BlackColorB = new Color(0.97f, 0.97f, 0.97f, 1);
            }
        }



        public void ImageSizeRatioA(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            CheckForEditorTheme();

            BlockDesignA(20, -55, 50, m_BlackColorA);
            MaterialPropertyState("_ImageSizeRatio", true, materialEditor, properties);
            GUI.backgroundColor = Color.white;
        }




        #region Shape Fill, Rim, BendShape, Displace Shape




        public void RimA(MaterialEditor materialEditor, MaterialProperty[] properties, bool _Gamma, int _TopSpace, int _Adjustment)
        {
            MaterialProperty _EnableRim = ShaderGUI.FindProperty("_EnableRim", properties);
            int _H = _EnableRim.floatValue == 1 ? (_Gamma ? 80 : 60) : 40;
            BlockDesignA(_TopSpace, -_H + _Adjustment, _H, m_BlackColorB);
            materialEditor.ShaderProperty(_EnableRim, _EnableRim.displayName);
            MaterialPropertyState("_RimWidth", _EnableRim.floatValue == 1, materialEditor, properties);
            if (_Gamma)
                MaterialPropertyState("_RimGamma", _EnableRim.floatValue == 1, materialEditor, properties);
        }

        public void FillA(MaterialEditor materialEditor, MaterialProperty[] properties, int _TopSpace)
        {
            MaterialProperty _EnableFill = ShaderGUI.FindProperty("_EnableFill", properties);
            int _Height = _EnableFill.floatValue == 1 ? 105 : 40;
            BlockDesignA(_TopSpace, -_Height - 12, _Height, m_BlackColorA);
            materialEditor.ShaderProperty(_EnableFill, _EnableFill.displayName);

            if (_EnableFill.floatValue == 1)
            {
                GUILayout.Space(5);
                MaterialPropertyState("_FillMode", true, materialEditor, properties);
                MaterialPropertyState("_FillAmount", true, materialEditor, properties);
                MaterialPropertyState("_FillAngle", true, materialEditor, properties);
            }
        }

        public void AlphaNoiseClipA(MaterialEditor materialEditor, MaterialProperty[] properties, int _TopSpace)
        {
            GUILayout.Space(_TopSpace);
            GUI.backgroundColor = m_BlackColorA;
            string _Text = _AlphaClipState ? "Minimize" : "Maximize";
            if (GUILayout.Button(_Text, GUILayout.Height(20), GUILayout.MaxWidth(80)))
            {
                _AlphaClipState = !_AlphaClipState;
            }

            GUI.enabled = false;
            GUILayout.TextArea("", GUILayout.Height(_AlphaClipState ? 185 : 30));
            GUI.enabled = true;
            GUI.backgroundColor = Color.white;
            GUILayout.Space(_AlphaClipState ? -185 - 15 : -45);

            MaterialProperty _NoiseAlphaClip = ShaderGUI.FindProperty("_NoiseAlphaClip", properties);
            materialEditor.ShaderProperty(_NoiseAlphaClip, _NoiseAlphaClip.displayName);

            GUI.enabled = _NoiseAlphaClip.floatValue == 1;
            MaterialPropertyState("_NoiseTex", _AlphaClipState, materialEditor, properties);
            MaterialPropertyState("_NoiseTexScale", _AlphaClipState, materialEditor, properties);
            MaterialPropertyState("_NoiseTexMoveSpeed", _AlphaClipState, materialEditor, properties);
            MaterialPropertyState("_NoiseTexMoveDirection", _AlphaClipState, materialEditor, properties);
            MaterialPropertyState("_NoiseTexOffset", _AlphaClipState, materialEditor, properties);
            GUI.enabled = true;
        }

        public void BendShapeA(MaterialEditor materialEditor, MaterialProperty[] properties, int _TopSpace)
        {
            MaterialProperty _EnableBending = ShaderGUI.FindProperty("_EnableBending", properties);
            int _Height = _EnableBending.floatValue == 1 ? 100 : 40;
            BlockDesignA(_TopSpace, -_Height - 10, _Height, m_BlackColorA);

            materialEditor.ShaderProperty(_EnableBending, _EnableBending.displayName);
            if (_EnableBending.floatValue == 1)
            {
                MaterialPropertyState("_MirrorBending", true, materialEditor, properties);
                MaterialPropertyState("_BendX", true, materialEditor, properties);
                MaterialPropertyState("_BendY", true, materialEditor, properties);
            }
        }

        public void DisplaceShapeA(MaterialEditor materialEditor, MaterialProperty[] properties, int _TopSpace)
        {
            GUILayout.Space(_TopSpace);
            GUI.backgroundColor = m_BlackColorA;
            string _Text = _DisplaceShape ? "Minimize" : "Maximize";
            if (GUILayout.Button(_Text, GUILayout.Height(20), GUILayout.MaxWidth(80)))
            {
                _DisplaceShape = !_DisplaceShape;
            }

            GUI.enabled = false;
            GUILayout.TextArea("", GUILayout.Height(_DisplaceShape ? 120 : 40));
            GUI.enabled = true;
            GUI.backgroundColor = Color.white;
            GUILayout.Space(_DisplaceShape ? -120 - 10 : -50);

            MaterialProperty _EnableDisplaceShape = ShaderGUI.FindProperty("_EnableDisplaceShape", properties);
            materialEditor.ShaderProperty(_EnableDisplaceShape, _EnableDisplaceShape.displayName);

            if (_DisplaceShape)
            {
                GUI.enabled = _EnableDisplaceShape.floatValue == 1;
                MaterialPropertyState("_BGColor", true, materialEditor, properties);
                MaterialPropertyState("_DisplaceShapeEdgeBlur", true, materialEditor, properties);
                MaterialPropertyState("_ShapeOffsetX", true, materialEditor, properties);
                MaterialPropertyState("_ShapeOffsetY", true, materialEditor, properties);
                GUI.enabled = true;
            }

        }




        #endregion




        #region ColorMode




        public void Texture_ColorMode(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            GUILayout.Space(10);
            MaterialPropertyState("_MainTex", true, materialEditor, properties);
            GUILayout.Space(10);
            MaterialPropertyState("_TexClipping", true, materialEditor, properties);
            MaterialPropertyState("_TexScale", true, materialEditor, properties);
            MaterialPropertyState("_TexRotation", true, materialEditor, properties);
            GUILayout.Space(10);
            MaterialPropertyState("_TexXOffset", true, materialEditor, properties);
            MaterialPropertyState("_TexYOffset", true, materialEditor, properties);
        }

        public void LinearGradientA_ColorMode(MaterialEditor materialEditor, MaterialProperty[] properties, MaterialProperty _EnableToon, MaterialProperty _GradientMode)
        {
            GUILayout.Space(10);
            materialEditor.ShaderProperty(_EnableToon, _EnableToon.displayName);
            MaterialPropertyState("_StepsToonGradient", _EnableToon.floatValue == 1, materialEditor, properties);
            GUILayout.Space(10);
            MaterialPropertyState("_GradientMode", true, materialEditor, properties);
            MaterialPropertyState("_ColorA", true, materialEditor, properties);
            MaterialPropertyState("_ColorB", true, materialEditor, properties);
            MaterialPropertyState("_ColorC", (_GradientMode.floatValue > 0), materialEditor, properties);
            MaterialPropertyState("_ColorD", (_GradientMode.floatValue > 1), materialEditor, properties);
            GUILayout.Space(10);
            MaterialPropertyState("_GradientAngle", true, materialEditor, properties);
            MaterialPropertyState("_GradientScale", true, materialEditor, properties);
            GUILayout.Space(10);
            MaterialPropertyState("_GradientXOffset", true, materialEditor, properties);
            MaterialPropertyState("_GradientYOffset", true, materialEditor, properties);
        }

        public void RadialGradientA_ColorMode(MaterialEditor materialEditor, MaterialProperty[] properties, MaterialProperty _EnableToon)
        {
            GUILayout.Space(10);
            materialEditor.ShaderProperty(_EnableToon, _EnableToon.displayName);
            MaterialPropertyState("_StepsToonGradient", _EnableToon.floatValue == 1, materialEditor, properties);
            GUILayout.Space(10);
            MaterialPropertyState("_ColorA", true, materialEditor, properties);
            MaterialPropertyState("_ColorB", true, materialEditor, properties);
            GUILayout.Space(10);
            MaterialProperty _RadialType = ShaderGUI.FindProperty("_RadialType", properties);
            MaterialPropertyState("_RadialType", true, materialEditor, properties);
            MaterialPropertyState("_RadialScale", _RadialType.floatValue == 0, materialEditor, properties);
            MaterialPropertyState("_RadialSpread", _RadialType.floatValue == 0, materialEditor, properties);
            MaterialPropertyState("_RadialGamma", _RadialType.floatValue == 1 || _RadialType.floatValue == 2, materialEditor, properties);
            if (_RadialType.floatValue == 0)
            {
                GUILayout.Space(10);
                MaterialPropertyState("_GradientXOffset", true, materialEditor, properties);
                MaterialPropertyState("_GradientYOffset", true, materialEditor, properties);
            }
        }

        public void SplitBoundaryGradientA_ColorMode(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            GUILayout.Space(10);
            MaterialPropertyState("_ColorA", true, materialEditor, properties);
            MaterialPropertyState("_ColorB", true, materialEditor, properties);
            GUILayout.Space(10);
            MaterialPropertyState("_GradientAngle", true, materialEditor, properties);
            MaterialPropertyState("_BoundaryBlur", true, materialEditor, properties);
            MaterialPropertyState("_BoundaryOffset", true, materialEditor, properties);
        }

        public void ColorModeType(MaterialEditor materialEditor, MaterialProperty[] properties, string _ColorMode, MaterialProperty _Toon, MaterialProperty _GradientMode)
        {
            if (_ColorMode == "Color")
            {
                MaterialPropertyState("_Color", true, materialEditor, properties);
            }
            else if (_ColorMode == "Texture")
            {
                Texture_ColorMode(materialEditor, properties);
            }
            else if (_ColorMode == "RadialA")
            {
                RadialGradientA_ColorMode(materialEditor, properties, _Toon);
            }
            else if (_ColorMode == "LinearA")
            {
                LinearGradientA_ColorMode(materialEditor, properties, _Toon, _GradientMode);
            }
            else if (_ColorMode == "Split")
            {
                SplitBoundaryGradientA_ColorMode(materialEditor, properties);
            }
        }

        public float ColorModeContainerHeight(string _ColorMode, float _Toon, float _GradientMode, float _RadialMode)
        {
            int _H = 0;
            if (_ColorMode == "Color")
            {
                _H = 60;
            }
            else if (_ColorMode == "Texture")
            {
                _H = 245;
            }
            else if (_ColorMode == "RadialA")
            {
                _H = _Toon == 1 ? 195 : 175;
                _H += _RadialMode == 0 ? 68 : 0;
            }
            else if (_ColorMode == "LinearA")
            {
                _H = 243;
                _H += (int)_Toon * 20;
                _H += (int)_GradientMode == 1 ? 21 : 0;
                _H += (int)_GradientMode == 2 ? 41 : 0;
            }
            else if (_ColorMode == "Split")
            {
                _H = 163;
            }

            return _H;
        }

        public void ColorModeA(MaterialEditor materialEditor, MaterialProperty[] properties, string _TopProperty)
        {
            var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "Texture" }, { 2, "RadialA" }, { 3, "LinearA" }, { 4, "Split" } };

            MaterialProperty _ColorMode = ShaderGUI.FindProperty("_ColorMode", properties);
            MaterialProperty _EnableToonGradient = ShaderGUI.FindProperty("_EnableToonGradient", properties);
            MaterialProperty _GradientMode = ShaderGUI.FindProperty("_GradientMode", properties);
            MaterialProperty _RadialType = ShaderGUI.FindProperty("_RadialType", properties);
            _ColorModeAState = MinimizeMaximizerB(45, _ColorModeAState, _ColorMode, materialEditor, properties, _TopProperty);
            if (_ColorModeAState)
            {
                GUILayout.Space(-20);
                int _H = (_TopProperty != "" ? 20 : 0) + (int)ColorModeContainerHeight(_ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient.floatValue, _GradientMode.floatValue, _RadialType.floatValue);
                BlockDesignA(20, -_H - 10, _H, m_BlackColorA);

                if (_TopProperty != "")
                    MaterialPropertyState(_TopProperty, true, materialEditor, properties);

                materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
                ColorModeType(materialEditor, properties, _ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient, _GradientMode);
            }
        }

        public void ColorModeB(MaterialEditor materialEditor, MaterialProperty[] properties, string _TopProperty)
        {
            var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "RadialA" }, { 2, "LinearA" } };

            MaterialProperty _ColorMode = ShaderGUI.FindProperty("_ColorMode", properties);
            MaterialProperty _EnableToonGradient = ShaderGUI.FindProperty("_EnableToonGradient", properties);
            MaterialProperty _GradientMode = ShaderGUI.FindProperty("_GradientMode", properties);
            MaterialProperty _RadialType = ShaderGUI.FindProperty("_RadialType", properties);
            _ColorModeAState = MinimizeMaximizerB(45, _ColorModeAState, _ColorMode, materialEditor, properties, _TopProperty);
            if (_ColorModeAState)
            {
                GUILayout.Space(-20);
                int _H = (_TopProperty != "" ? 20 : 0) + (int)ColorModeContainerHeight(_ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient.floatValue, _GradientMode.floatValue, _RadialType.floatValue);
                BlockDesignA(20, -_H - 10, _H, m_BlackColorA);

                if (_TopProperty != "")
                    MaterialPropertyState(_TopProperty, true, materialEditor, properties);

                materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
                ColorModeType(materialEditor, properties, _ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient, _GradientMode);
            }
        }

        public void ColorModeC(MaterialEditor materialEditor, MaterialProperty[] properties, string _TopProperty)
        {
            var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "RadialA" }, { 2, "LinearA" }, { 3, "Split" } };

            MaterialProperty _ColorMode = ShaderGUI.FindProperty("_ColorMode", properties);
            MaterialProperty _EnableToonGradient = ShaderGUI.FindProperty("_EnableToonGradient", properties);
            MaterialProperty _GradientMode = ShaderGUI.FindProperty("_GradientMode", properties);
            MaterialProperty _RadialType = ShaderGUI.FindProperty("_RadialType", properties);
            _ColorModeAState = MinimizeMaximizerB(45, _ColorModeAState, _ColorMode, materialEditor, properties, _TopProperty);
            if (_ColorModeAState)
            {
                GUILayout.Space(-20);
                int _H = (_TopProperty != "" ? 20 : 0) + (int)ColorModeContainerHeight(_ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient.floatValue, _GradientMode.floatValue, _RadialType.floatValue);
                BlockDesignA(20, -_H - 10, _H, m_BlackColorA);

                if (_TopProperty != "")
                    MaterialPropertyState(_TopProperty, true, materialEditor, properties);

                materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
                ColorModeType(materialEditor, properties, _ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient, _GradientMode);
            }
        }



        #endregion




        #region Minimizer & Maximizer



        public bool MinimizeMaximizerB(int _TopSpace, bool _State, MaterialProperty _ColorMode, MaterialEditor materialEditor, MaterialProperty[] properties, string _ExtraProperty)
        {
            GUILayout.Space(_TopSpace);
            GUI.backgroundColor = m_BlackColorA;

            _State = CopyPasteBtns(_State, materialEditor, properties, "_ColorMode");

            GUI.backgroundColor = Color.white;

            if (_State == false)
            {
                int _H = _ColorMode.floatValue == 0 ? 60 : 40;
                _H += _ExtraProperty != "" ? 20 : 0;
                GUI.backgroundColor = m_BlackColorA;
                GUI.enabled = false;
                GUILayout.TextArea("", GUILayout.Height(_H));
                GUI.enabled = true;
                GUILayout.Space(-_H - 10 - (_ExtraProperty != "" ? 0 : 0));
                GUI.backgroundColor = Color.white;
                if (_ExtraProperty != "")
                {
                    MaterialPropertyState(_ExtraProperty, true, materialEditor, properties);
                }
                materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
                MaterialPropertyState("_Color", (_ColorMode.floatValue == 0), materialEditor, properties);
            }

            return _State;
        }

        public bool MinimizeMaximizerD(int _TopSpace, int _Temp, bool _State, string _PropertyName, MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            GUILayout.Space(_TopSpace);
            GUI.backgroundColor = m_BlackColorA;

            _State = CopyPasteBtns(_State, materialEditor, properties, "_EnableLines");

            GUI.backgroundColor = Color.white;
            if (_State == false)
            {
                GUI.backgroundColor = m_BlackColorA;
                GUI.enabled = false;
                GUILayout.TextArea("", GUILayout.Height(40));
                GUI.enabled = true;
                GUILayout.Space(-_Temp);
                GUI.backgroundColor = Color.white;
                MaterialPropertyState(_PropertyName, true, materialEditor, properties);
            }
            return _State;
        }

        public bool MinimizeMaximizerC(int _TopSpace, bool _State, string _PropertyName, MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            GUILayout.Space(_TopSpace);
            GUI.backgroundColor = m_BlackColorA;

            _State = CopyPasteBtns(_State, materialEditor, properties, _PropertyName);

            GUI.backgroundColor = Color.white;
            if (_State == false)
            {
                GUI.backgroundColor = m_BlackColorA;
                GUI.enabled = false;
                GUILayout.TextArea("", GUILayout.Height(40));
                GUI.enabled = true;
                if (_PropertyName != "")
                {
                    GUILayout.Space(-50);
                }
                GUI.backgroundColor = Color.white;
                MaterialPropertyState(_PropertyName, true, materialEditor, properties);
            }
            return _State;
        }

        bool CopyPasteBtns(bool _State, MaterialEditor materialEditor, MaterialProperty[] properties, string _PropertyName)
        {
            GUILayout.BeginHorizontal();
            {
                string _Text1 = _State ? "Minimize" : "Maximize";
                if (GUILayout.Button(_Text1, EditorStyles.miniButtonLeft, GUILayout.Height(20), GUILayout.MaxWidth(80)))
                {
                    _State = !_State;
                }
                GUI.backgroundColor = Color.white;
                GUILayout.Space(200);
                if (GUILayout.Button("Copy", EditorStyles.miniButtonRight))
                {
                    CopyMaterialProperties(materialEditor, properties, _PropertyName);
                }
                GUILayout.Space(5);
                if (GUILayout.Button("Paste", EditorStyles.miniButtonRight))
                {
                    PasteMaterialProperties(materialEditor, properties, _PropertyName);
                }
            }
            GUILayout.EndHorizontal();

            return _State;
        }



        #endregion




        #region Copy Paste Properties



        public void CopyMaterialProperties(MaterialEditor materialEditor, MaterialProperty[] properties, string _PropertyName)
        {
            if (string.Compare(_PropertyName, "_ColorMode") == 0)
            {
                if (ShaderGUI.FindProperty("_EnableColor", properties, false) != null)
                {
                    PlayerPrefs.SetFloat("_EnableColor", ShaderGUI.FindProperty("_EnableColor", properties).floatValue);
                }

                PlayerPrefs.SetFloat("_ColorMode", ShaderGUI.FindProperty("_ColorMode", properties).floatValue);
                SaveColorValues("_Color", ShaderGUI.FindProperty("_Color", properties).colorValue);


                if (ShaderGUI.FindProperty("_TexClipping", properties, false) != null)
                {
                    PlayerPrefs.SetFloat("_TexClipping", ShaderGUI.FindProperty("_TexClipping", properties).floatValue);
                    PlayerPrefs.SetFloat("_TexScale", ShaderGUI.FindProperty("_TexScale", properties).floatValue);
                    PlayerPrefs.SetFloat("_TexRotation", ShaderGUI.FindProperty("_TexRotation", properties).floatValue);
                    PlayerPrefs.SetFloat("_TexXOffset", ShaderGUI.FindProperty("_TexXOffset", properties).floatValue);
                    PlayerPrefs.SetFloat("_TexYOffset", ShaderGUI.FindProperty("_TexYOffset", properties).floatValue);
                }

                PlayerPrefs.SetFloat("_EnableToonGradient", ShaderGUI.FindProperty("_EnableToonGradient", properties).floatValue);
                PlayerPrefs.SetFloat("_StepsToonGradient", ShaderGUI.FindProperty("_StepsToonGradient", properties).floatValue);

                PlayerPrefs.SetFloat("_GradientMode", ShaderGUI.FindProperty("_GradientMode", properties).floatValue);

                SaveColorValues("_ColorA", ShaderGUI.FindProperty("_ColorA", properties).colorValue);
                SaveColorValues("_ColorB", ShaderGUI.FindProperty("_ColorB", properties).colorValue);
                SaveColorValues("_ColorC", ShaderGUI.FindProperty("_ColorC", properties).colorValue);
                SaveColorValues("_ColorD", ShaderGUI.FindProperty("_ColorD", properties).colorValue);

                PlayerPrefs.SetFloat("_RadialType", ShaderGUI.FindProperty("_RadialType", properties).floatValue);
                PlayerPrefs.SetFloat("_RadialScale", ShaderGUI.FindProperty("_RadialScale", properties).floatValue);
                PlayerPrefs.SetFloat("_RadialSpread", ShaderGUI.FindProperty("_RadialSpread", properties).floatValue);
                PlayerPrefs.SetFloat("_RadialGamma", ShaderGUI.FindProperty("_RadialGamma", properties).floatValue);

                PlayerPrefs.SetFloat("_GradientAngle", ShaderGUI.FindProperty("_GradientAngle", properties).floatValue);
                PlayerPrefs.SetFloat("_GradientScale", ShaderGUI.FindProperty("_GradientScale", properties).floatValue);

                if (ShaderGUI.FindProperty("_BoundaryBlur", properties, false) != null)
                {
                    PlayerPrefs.SetFloat("_BoundaryBlur", ShaderGUI.FindProperty("_BoundaryBlur", properties).floatValue);
                    PlayerPrefs.SetFloat("_BoundaryOffset", ShaderGUI.FindProperty("_BoundaryOffset", properties).floatValue);
                }

                PlayerPrefs.SetFloat("_GradientXOffset", ShaderGUI.FindProperty("_GradientXOffset", properties).floatValue);
                PlayerPrefs.SetFloat("_GradientYOffset", ShaderGUI.FindProperty("_GradientYOffset", properties).floatValue);

            }
            else if (string.Compare(_PropertyName, "_EnableTextureOverlay") == 0)
            {
                PlayerPrefs.SetFloat("_EnableTextureOverlay", ShaderGUI.FindProperty("_EnableTextureOverlay", properties).floatValue);
                PlayerPrefs.SetFloat("_TextureOverlayOpacity", ShaderGUI.FindProperty("_TextureOverlayOpacity", properties).floatValue);
                PlayerPrefs.SetFloat("_TextureOverlayClipping", ShaderGUI.FindProperty("_TextureOverlayClipping", properties).floatValue);
                PlayerPrefs.SetFloat("_TextureOverlayScale", ShaderGUI.FindProperty("_TextureOverlayScale", properties).floatValue);
                PlayerPrefs.SetFloat("_TextureOverlayRotation", ShaderGUI.FindProperty("_TextureOverlayRotation", properties).floatValue);
                PlayerPrefs.SetFloat("_TextureOverlayOffsetX", ShaderGUI.FindProperty("_TextureOverlayOffsetX", properties).floatValue);
                PlayerPrefs.SetFloat("_TextureOverlayOffsetY", ShaderGUI.FindProperty("_TextureOverlayOffsetY", properties).floatValue);
            }
            else if (string.Compare(_PropertyName, "_EnableLines") == 0)
            {
                PlayerPrefs.SetFloat("_EnableLines", ShaderGUI.FindProperty("_EnableLines", properties).floatValue);
                PlayerPrefs.SetFloat("_LinesMode", ShaderGUI.FindProperty("_LinesMode", properties).floatValue);

                SaveColorValues("_LinesColor", ShaderGUI.FindProperty("_LinesColor", properties).colorValue);
                PlayerPrefs.SetFloat("_LinesOpacity", ShaderGUI.FindProperty("_LinesOpacity", properties).floatValue);
                PlayerPrefs.SetFloat("_LinesRadialOpacity", ShaderGUI.FindProperty("_LinesRadialOpacity", properties).floatValue);

                PlayerPrefs.SetFloat("_NoOfLines", ShaderGUI.FindProperty("_NoOfLines", properties).floatValue);
                PlayerPrefs.SetFloat("_LinesWidth", ShaderGUI.FindProperty("_LinesWidth", properties).floatValue);
                PlayerPrefs.SetFloat("_LinesEdgeBlur", ShaderGUI.FindProperty("_LinesEdgeBlur", properties).floatValue);

                PlayerPrefs.SetFloat("_A1", ShaderGUI.FindProperty("_A1", properties).floatValue);
                PlayerPrefs.SetFloat("_A2", ShaderGUI.FindProperty("_A2", properties).floatValue);
                PlayerPrefs.SetFloat("_A3", ShaderGUI.FindProperty("_A3", properties).floatValue);

                PlayerPrefs.SetFloat("_LinesRotation", ShaderGUI.FindProperty("_LinesRotation", properties).floatValue);
                PlayerPrefs.SetFloat("_LinesRotateMoveSpeed", ShaderGUI.FindProperty("_LinesRotateMoveSpeed", properties).floatValue);
                PlayerPrefs.SetFloat("_LinesOffsetX", ShaderGUI.FindProperty("_LinesOffsetX", properties).floatValue);
                PlayerPrefs.SetFloat("_LinesOffsetY", ShaderGUI.FindProperty("_LinesOffsetY", properties).floatValue);
            }
            else if (string.Compare(_PropertyName, "_EnableBorder") == 0)
            {
                PlayerPrefs.SetFloat("_EnableBorder", ShaderGUI.FindProperty("_EnableBorder", properties).floatValue);
                PlayerPrefs.SetFloat("_BorderBoundaryOffset", ShaderGUI.FindProperty("_BorderBoundaryOffset", properties).floatValue);
                PlayerPrefs.SetFloat("_BorderWidth", ShaderGUI.FindProperty("_BorderWidth", properties).floatValue);
                PlayerPrefs.SetFloat("_BorderBlur", ShaderGUI.FindProperty("_BorderBlur", properties).floatValue);
                PlayerPrefs.SetFloat("_BorderGamma", ShaderGUI.FindProperty("_BorderGamma", properties).floatValue);
                PlayerPrefs.SetFloat("_BorderOpacity", ShaderGUI.FindProperty("_BorderOpacity", properties).floatValue);

                PlayerPrefs.SetFloat("_BorderColorMode", ShaderGUI.FindProperty("_BorderColorMode", properties).floatValue);
                PlayerPrefs.SetFloat("_GradientType", ShaderGUI.FindProperty("_GradientType", properties).floatValue);
                SaveColorValues("_BorderColor", ShaderGUI.FindProperty("_BorderColor", properties).colorValue);
                SaveColorValues("_ColorE", ShaderGUI.FindProperty("_ColorE", properties).colorValue);
                SaveColorValues("_ColorF", ShaderGUI.FindProperty("_ColorF", properties).colorValue);
                PlayerPrefs.SetFloat("_BorderGradientAngle", ShaderGUI.FindProperty("_BorderGradientAngle", properties).floatValue);
                PlayerPrefs.SetFloat("_BorderGradientScale", ShaderGUI.FindProperty("_BorderGradientScale", properties).floatValue);
            }
            else if (string.Compare(_PropertyName, "_EnableInnerShadow") == 0)
            {
                PlayerPrefs.SetFloat("_EnableInnerShadow", ShaderGUI.FindProperty("_EnableInnerShadow", properties).floatValue);
                PlayerPrefs.SetFloat("_InnerShadowSize", ShaderGUI.FindProperty("_InnerShadowSize", properties).floatValue);
                PlayerPrefs.SetFloat("_InnerShadowSpread", ShaderGUI.FindProperty("_InnerShadowSpread", properties).floatValue);
                PlayerPrefs.SetFloat("_InnerShadowGamma", ShaderGUI.FindProperty("_InnerShadowGamma", properties).floatValue);
                PlayerPrefs.SetFloat("_InnerShadowXOffset", ShaderGUI.FindProperty("_InnerShadowXOffset", properties).floatValue);
                PlayerPrefs.SetFloat("_InnerShadowYOffset", ShaderGUI.FindProperty("_InnerShadowYOffset", properties).floatValue);
                PlayerPrefs.SetFloat("_InnerShadowOpacity", ShaderGUI.FindProperty("_InnerShadowOpacity", properties).floatValue);
                PlayerPrefs.SetFloat("_InnerShadowColorMode", ShaderGUI.FindProperty("_InnerShadowColorMode", properties).floatValue);
                PlayerPrefs.SetFloat("_InnerShadowGradientType", ShaderGUI.FindProperty("_InnerShadowGradientType", properties).floatValue);
                SaveColorValues("_InnerShadowColor", ShaderGUI.FindProperty("_InnerShadowColor", properties).colorValue);
                SaveColorValues("_InnerShadowColorX", ShaderGUI.FindProperty("_InnerShadowColorX", properties).colorValue);
                SaveColorValues("_InnerShadowColorY", ShaderGUI.FindProperty("_InnerShadowColorY", properties).colorValue);
                PlayerPrefs.SetFloat("_InnerShadowGradientAngle", ShaderGUI.FindProperty("_InnerShadowGradientAngle", properties).floatValue);
                PlayerPrefs.SetFloat("_InnerShadowGradientScale", ShaderGUI.FindProperty("_InnerShadowGradientScale", properties).floatValue);
            }
            else if (string.Compare(_PropertyName, "_EnableDropShadow") == 0)
            {
                PlayerPrefs.SetFloat("_EnableDropShadow", ShaderGUI.FindProperty("_EnableDropShadow", properties).floatValue);
                PlayerPrefs.SetFloat("_DropShadowSize", ShaderGUI.FindProperty("_DropShadowSize", properties).floatValue);
                PlayerPrefs.SetFloat("_DropShadowSpread", ShaderGUI.FindProperty("_DropShadowSpread", properties).floatValue);
                PlayerPrefs.SetFloat("_DropShadowGamma", ShaderGUI.FindProperty("_DropShadowGamma", properties).floatValue);
                PlayerPrefs.SetFloat("_DropShadowXOffset", ShaderGUI.FindProperty("_DropShadowXOffset", properties).floatValue);
                PlayerPrefs.SetFloat("_DropShadowYOffset", ShaderGUI.FindProperty("_DropShadowYOffset", properties).floatValue);
                PlayerPrefs.SetFloat("_DropShadowOpacity", ShaderGUI.FindProperty("_DropShadowOpacity", properties).floatValue);
                PlayerPrefs.SetFloat("_DropShadowColorMode", ShaderGUI.FindProperty("_DropShadowColorMode", properties).floatValue);
                PlayerPrefs.SetFloat("_DropShadowGradientMode", ShaderGUI.FindProperty("_DropShadowGradientMode", properties).floatValue);
                SaveColorValues("_DropShadowColor", ShaderGUI.FindProperty("_DropShadowColor", properties).colorValue);
                SaveColorValues("_ColorE", ShaderGUI.FindProperty("_ColorE", properties).colorValue);
                SaveColorValues("_ColorF", ShaderGUI.FindProperty("_ColorF", properties).colorValue);
                SaveColorValues("_ColorG", ShaderGUI.FindProperty("_ColorG", properties).colorValue);
                SaveColorValues("_ColorH", ShaderGUI.FindProperty("_ColorH", properties).colorValue);
                PlayerPrefs.SetFloat("_DropShadowGradientAngle", ShaderGUI.FindProperty("_DropShadowGradientAngle", properties).floatValue);
                PlayerPrefs.SetFloat("_DropShadowGradientScale", ShaderGUI.FindProperty("_DropShadowGradientScale", properties).floatValue);
            }
        }

        public void PasteMaterialProperties(MaterialEditor materialEditor, MaterialProperty[] properties, string _PropertyName)
        {
            if (string.Compare(_PropertyName, "_ColorMode") == 0)
            {
                if (ShaderGUI.FindProperty("_EnableColor", properties, false) != null)
                {
                    ShaderGUI.FindProperty("_EnableColor", properties).floatValue = PlayerPrefs.GetFloat("_EnableColor");
                }

                //ShaderGUI.FindProperty("_ColorMode", properties).floatValue = PlayerPrefs.GetFloat("_ColorMode");
                ShaderGUI.FindProperty("_Color", properties).colorValue = GetColorValues("_Color");

                if (ShaderGUI.FindProperty("_TexClipping", properties, false) != null)
                {
                    ShaderGUI.FindProperty("_TexClipping", properties).floatValue = PlayerPrefs.GetFloat("_TexClipping");
                    ShaderGUI.FindProperty("_TexScale", properties).floatValue = PlayerPrefs.GetFloat("_TexScale");
                    ShaderGUI.FindProperty("_TexRotation", properties).floatValue = PlayerPrefs.GetFloat("_TexRotation");
                    ShaderGUI.FindProperty("_TexXOffset", properties).floatValue = PlayerPrefs.GetFloat("_TexXOffset");
                    ShaderGUI.FindProperty("_TexYOffset", properties).floatValue = PlayerPrefs.GetFloat("_TexYOffset");
                }

                ShaderGUI.FindProperty("_EnableToonGradient", properties).floatValue = PlayerPrefs.GetFloat("_EnableToonGradient");
                ShaderGUI.FindProperty("_StepsToonGradient", properties).floatValue = PlayerPrefs.GetFloat("_StepsToonGradient");
                ShaderGUI.FindProperty("_GradientMode", properties).floatValue = PlayerPrefs.GetFloat("_GradientMode");

                ShaderGUI.FindProperty("_ColorA", properties).colorValue = GetColorValues("_ColorA");
                ShaderGUI.FindProperty("_ColorB", properties).colorValue = GetColorValues("_ColorB");
                ShaderGUI.FindProperty("_ColorC", properties).colorValue = GetColorValues("_ColorC");
                ShaderGUI.FindProperty("_ColorD", properties).colorValue = GetColorValues("_ColorD");

                ShaderGUI.FindProperty("_RadialType", properties).floatValue = PlayerPrefs.GetFloat("_RadialType");
                ShaderGUI.FindProperty("_RadialScale", properties).floatValue = PlayerPrefs.GetFloat("_RadialScale");
                ShaderGUI.FindProperty("_RadialSpread", properties).floatValue = PlayerPrefs.GetFloat("_RadialSpread");
                ShaderGUI.FindProperty("_RadialGamma", properties).floatValue = PlayerPrefs.GetFloat("_RadialGamma");

                ShaderGUI.FindProperty("_GradientAngle", properties).floatValue = PlayerPrefs.GetFloat("_GradientAngle");
                ShaderGUI.FindProperty("_GradientScale", properties).floatValue = PlayerPrefs.GetFloat("_GradientScale");

                if (ShaderGUI.FindProperty("_BoundaryBlur", properties, false) != null)
                {
                    ShaderGUI.FindProperty("_BoundaryBlur", properties).floatValue = PlayerPrefs.GetFloat("_BoundaryBlur");
                    ShaderGUI.FindProperty("_BoundaryOffset", properties).floatValue = PlayerPrefs.GetFloat("_BoundaryOffset");
                }

                ShaderGUI.FindProperty("_GradientXOffset", properties).floatValue = PlayerPrefs.GetFloat("_GradientXOffset");
                ShaderGUI.FindProperty("_GradientYOffset", properties).floatValue = PlayerPrefs.GetFloat("_GradientYOffset");

            }
            else if (string.Compare(_PropertyName, "_EnableTextureOverlay") == 0)
            {
                ShaderGUI.FindProperty("_EnableTextureOverlay", properties).floatValue = PlayerPrefs.GetFloat("_EnableTextureOverlay");
                ShaderGUI.FindProperty("_TextureOverlayOpacity", properties).floatValue = PlayerPrefs.GetFloat("_TextureOverlayOpacity");
                ShaderGUI.FindProperty("_TextureOverlayClipping", properties).floatValue = PlayerPrefs.GetFloat("_TextureOverlayClipping");
                ShaderGUI.FindProperty("_TextureOverlayScale", properties).floatValue = PlayerPrefs.GetFloat("_TextureOverlayScale");
                ShaderGUI.FindProperty("_TextureOverlayRotation", properties).floatValue = PlayerPrefs.GetFloat("_TextureOverlayRotation");
                ShaderGUI.FindProperty("_TextureOverlayOffsetX", properties).floatValue = PlayerPrefs.GetFloat("_TextureOverlayOffsetX");
                ShaderGUI.FindProperty("_TextureOverlayOffsetY", properties).floatValue = PlayerPrefs.GetFloat("_TextureOverlayOffsetY");
            }
            else if (string.Compare(_PropertyName, "_EnableLines") == 0)
            {
                ShaderGUI.FindProperty("_EnableLines", properties).floatValue = PlayerPrefs.GetFloat("_EnableLines");
                ShaderGUI.FindProperty("_LinesMode", properties).floatValue = PlayerPrefs.GetFloat("_LinesMode");

                ShaderGUI.FindProperty("_LinesColor", properties).colorValue = GetColorValues("_LinesColor");
                ShaderGUI.FindProperty("_LinesOpacity", properties).floatValue = PlayerPrefs.GetFloat("_LinesOpacity");
                ShaderGUI.FindProperty("_LinesRadialOpacity", properties).floatValue = PlayerPrefs.GetFloat("_LinesRadialOpacity");

                ShaderGUI.FindProperty("_NoOfLines", properties).floatValue = PlayerPrefs.GetFloat("_NoOfLines");
                ShaderGUI.FindProperty("_LinesWidth", properties).floatValue = PlayerPrefs.GetFloat("_LinesWidth");
                ShaderGUI.FindProperty("_LinesEdgeBlur", properties).floatValue = PlayerPrefs.GetFloat("_LinesEdgeBlur");

                ShaderGUI.FindProperty("_A1", properties).floatValue = PlayerPrefs.GetFloat("_A1");
                ShaderGUI.FindProperty("_A2", properties).floatValue = PlayerPrefs.GetFloat("_A2");
                ShaderGUI.FindProperty("_A3", properties).floatValue = PlayerPrefs.GetFloat("_A3");

                ShaderGUI.FindProperty("_LinesRotation", properties).floatValue = PlayerPrefs.GetFloat("_LinesRotation");
                ShaderGUI.FindProperty("_LinesRotateMoveSpeed", properties).floatValue = PlayerPrefs.GetFloat("_LinesRotateMoveSpeed");
                ShaderGUI.FindProperty("_LinesOffsetX", properties).floatValue = PlayerPrefs.GetFloat("_LinesOffsetX");
                ShaderGUI.FindProperty("_LinesOffsetY", properties).floatValue = PlayerPrefs.GetFloat("_LinesOffsetY");
            }
            else if (string.Compare(_PropertyName, "_EnableBorder") == 0)
            {
                ShaderGUI.FindProperty("_EnableBorder", properties).floatValue = PlayerPrefs.GetFloat("_EnableBorder");
                ShaderGUI.FindProperty("_BorderBoundaryOffset", properties).floatValue = PlayerPrefs.GetFloat("_BorderBoundaryOffset");
                ShaderGUI.FindProperty("_BorderWidth", properties).floatValue = PlayerPrefs.GetFloat("_BorderWidth");
                ShaderGUI.FindProperty("_BorderBlur", properties).floatValue = PlayerPrefs.GetFloat("_BorderBlur");
                ShaderGUI.FindProperty("_BorderGamma", properties).floatValue = PlayerPrefs.GetFloat("_BorderGamma");
                ShaderGUI.FindProperty("_BorderOpacity", properties).floatValue = PlayerPrefs.GetFloat("_BorderOpacity");
                ShaderGUI.FindProperty("_BorderColorMode", properties).floatValue = PlayerPrefs.GetFloat("_BorderColorMode");
                ShaderGUI.FindProperty("_GradientType", properties).floatValue = PlayerPrefs.GetFloat("_GradientType");
                ShaderGUI.FindProperty("_BorderColor", properties).colorValue = GetColorValues("_BorderColor");
                ShaderGUI.FindProperty("_ColorE", properties).colorValue = GetColorValues("_ColorE");
                ShaderGUI.FindProperty("_ColorF", properties).colorValue = GetColorValues("_ColorF");
                ShaderGUI.FindProperty("_BorderGradientAngle", properties).floatValue = PlayerPrefs.GetFloat("_BorderGradientAngle");
                ShaderGUI.FindProperty("_BorderGradientScale", properties).floatValue = PlayerPrefs.GetFloat("_BorderGradientScale");
            }
            else if (string.Compare(_PropertyName, "_EnableInnerShadow") == 0)
            {
                ShaderGUI.FindProperty("_EnableInnerShadow", properties).floatValue = PlayerPrefs.GetFloat("_EnableInnerShadow");
                ShaderGUI.FindProperty("_InnerShadowSize", properties).floatValue = PlayerPrefs.GetFloat("_InnerShadowSize");
                ShaderGUI.FindProperty("_InnerShadowSpread", properties).floatValue = PlayerPrefs.GetFloat("_InnerShadowSpread");
                ShaderGUI.FindProperty("_InnerShadowGamma", properties).floatValue = PlayerPrefs.GetFloat("_InnerShadowGamma");
                ShaderGUI.FindProperty("_InnerShadowXOffset", properties).floatValue = PlayerPrefs.GetFloat("_InnerShadowXOffset");
                ShaderGUI.FindProperty("_InnerShadowYOffset", properties).floatValue = PlayerPrefs.GetFloat("_InnerShadowYOffset");
                ShaderGUI.FindProperty("_InnerShadowOpacity", properties).floatValue = PlayerPrefs.GetFloat("_InnerShadowOpacity");
                ShaderGUI.FindProperty("_InnerShadowColorMode", properties).floatValue = PlayerPrefs.GetFloat("_InnerShadowColorMode");
                ShaderGUI.FindProperty("_InnerShadowGradientType", properties).floatValue = PlayerPrefs.GetFloat("_InnerShadowGradientType");
                ShaderGUI.FindProperty("_InnerShadowColor", properties).colorValue = GetColorValues("_InnerShadowColor");
                ShaderGUI.FindProperty("_InnerShadowColorX", properties).colorValue = GetColorValues("_InnerShadowColorX");
                ShaderGUI.FindProperty("_InnerShadowColorY", properties).colorValue = GetColorValues("_InnerShadowColorY");
                ShaderGUI.FindProperty("_InnerShadowGradientAngle", properties).floatValue = PlayerPrefs.GetFloat("_InnerShadowGradientAngle");
                ShaderGUI.FindProperty("_InnerShadowGradientScale", properties).floatValue = PlayerPrefs.GetFloat("_InnerShadowGradientScale");
            }
            else if (string.Compare(_PropertyName, "_EnableDropShadow") == 0)
            {
                ShaderGUI.FindProperty("_EnableDropShadow", properties).floatValue = PlayerPrefs.GetFloat("_EnableDropShadow");
                ShaderGUI.FindProperty("_DropShadowSize", properties).floatValue = PlayerPrefs.GetFloat("_DropShadowSize");
                ShaderGUI.FindProperty("_DropShadowSpread", properties).floatValue = PlayerPrefs.GetFloat("_DropShadowSpread");
                ShaderGUI.FindProperty("_DropShadowGamma", properties).floatValue = PlayerPrefs.GetFloat("_DropShadowGamma");
                ShaderGUI.FindProperty("_DropShadowXOffset", properties).floatValue = PlayerPrefs.GetFloat("_DropShadowXOffset");
                ShaderGUI.FindProperty("_DropShadowYOffset", properties).floatValue = PlayerPrefs.GetFloat("_DropShadowYOffset");
                ShaderGUI.FindProperty("_DropShadowOpacity", properties).floatValue = PlayerPrefs.GetFloat("_DropShadowOpacity");
                ShaderGUI.FindProperty("_DropShadowColorMode", properties).floatValue = PlayerPrefs.GetFloat("_DropShadowColorMode");
                ShaderGUI.FindProperty("_DropShadowGradientMode", properties).floatValue = PlayerPrefs.GetFloat("_DropShadowGradientMode");
                ShaderGUI.FindProperty("_DropShadowColor", properties).colorValue = GetColorValues("_DropShadowColor");
                ShaderGUI.FindProperty("_ColorE", properties).colorValue = GetColorValues("_ColorE");
                ShaderGUI.FindProperty("_ColorF", properties).colorValue = GetColorValues("_ColorF");
                ShaderGUI.FindProperty("_ColorG", properties).colorValue = GetColorValues("_ColorG");
                ShaderGUI.FindProperty("_ColorH", properties).colorValue = GetColorValues("_ColorH");
                ShaderGUI.FindProperty("_DropShadowGradientAngle", properties).floatValue = PlayerPrefs.GetFloat("_DropShadowGradientAngle");
                ShaderGUI.FindProperty("_DropShadowGradientScale", properties).floatValue = PlayerPrefs.GetFloat("_DropShadowGradientScale");
            }
        }

        void SaveColorValues(string _Name, Color _Color)
        {
            PlayerPrefs.SetFloat(_Name + "r", _Color.r);
            PlayerPrefs.SetFloat(_Name + "g", _Color.g);
            PlayerPrefs.SetFloat(_Name + "b", _Color.b);
            PlayerPrefs.SetFloat(_Name + "a", _Color.a);
        }

        Color GetColorValues(string _Name)
        {
            float _R = PlayerPrefs.GetFloat(_Name + "r");
            float _G = PlayerPrefs.GetFloat(_Name + "g");
            float _B = PlayerPrefs.GetFloat(_Name + "b");
            float _A = PlayerPrefs.GetFloat(_Name + "a");
            return new Color(_R, _G, _B, _A);
        }




        #endregion




        public void TextureOverlayA(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            MaterialProperty _EnableTextureOverlay = ShaderGUI.FindProperty("_EnableTextureOverlay", properties);
            _TextureOverlayAState = MinimizeMaximizerC(45, _TextureOverlayAState, "_EnableTextureOverlay", materialEditor, properties);
            if (_TextureOverlayAState)
            {
                int _Height = 263;
                BlockDesignA(0, -_Height - 10, _Height, m_BlackColorA);
                materialEditor.ShaderProperty(_EnableTextureOverlay, _EnableTextureOverlay.displayName);
                GUILayout.Space(10);
                GUI.enabled = _EnableTextureOverlay.floatValue == 1;
                MaterialPropertyState("_TextureOverlay", true, materialEditor, properties);
                MaterialPropertyState("_TextureOverlayOpacity", true, materialEditor, properties);
                GUILayout.Space(10);
                MaterialPropertyState("_TextureOverlayClipping", true, materialEditor, properties);
                MaterialPropertyState("_TextureOverlayScale", true, materialEditor, properties);
                MaterialPropertyState("_TextureOverlayRotation", true, materialEditor, properties);
                GUILayout.Space(10);
                MaterialPropertyState("_TextureOverlayOffsetX", true, materialEditor, properties);
                MaterialPropertyState("_TextureOverlayOffsetY", true, materialEditor, properties);
                GUI.enabled = true;
            }
        }

        public void LinesA(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            MaterialProperty _EnableLines = ShaderGUI.FindProperty("_EnableLines", properties);
            MaterialProperty _LinesMode = ShaderGUI.FindProperty("_LinesMode", properties);
            _LinesAState = MinimizeMaximizerC(45, _LinesAState, "_EnableLines", materialEditor, properties);
            if (_LinesAState)
            {
                int _Height = 0;
                if (_LinesMode.floatValue == 0)
                {
                    _Height = 243;
                }
                else if (_LinesMode.floatValue == 1)
                {
                    _Height = 310;
                }
                else if (_LinesMode.floatValue == 2)
                {
                    _Height = 400;
                }
                BlockDesignA(0, -_Height - 10, _Height, m_BlackColorA);
                materialEditor.ShaderProperty(_EnableLines, _EnableLines.displayName);
                GUILayout.Space(10);
                GUI.enabled = _EnableLines.floatValue == 1;
                MaterialPropertyState("_LinesMode", true, materialEditor, properties);
                GUILayout.Space(10);
                MaterialPropertyState("_LinesColor", true, materialEditor, properties);
                MaterialPropertyState("_LinesOpacity", true, materialEditor, properties);
                MaterialPropertyState("_LinesRadialOpacity", _LinesMode.floatValue > 0, materialEditor, properties);
                GUILayout.Space(10);
                MaterialPropertyState("_NoOfLines", true, materialEditor, properties);
                MaterialPropertyState("_LinesWidth", true, materialEditor, properties);
                MaterialPropertyState("_LinesEdgeBlur", true, materialEditor, properties);
                if (_LinesMode.floatValue == 2)
                {
                    GUILayout.Space(10);
                    GUILayout.Label("Spiral Parameters");
                    MaterialPropertyState("_A1", true, materialEditor, properties);
                    MaterialPropertyState("_A2", true, materialEditor, properties);
                    MaterialPropertyState("_A3", true, materialEditor, properties);
                }
                GUILayout.Space(10);
                MaterialPropertyState("_LinesRotation", true, materialEditor, properties);
                MaterialPropertyState("_LinesRotateMoveSpeed", true, materialEditor, properties);
                if (_LinesMode.floatValue > 0)
                {
                    GUILayout.Space(10);
                    MaterialPropertyState("_LinesOffsetX", true, materialEditor, properties);
                    MaterialPropertyState("_LinesOffsetY", true, materialEditor, properties);
                }
                GUI.enabled = true;
            }

        }

        public void LinesB(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            MaterialProperty _EnableLines = ShaderGUI.FindProperty("_EnableLines", properties);
            MaterialProperty _LinesMode = ShaderGUI.FindProperty("_LinesMode", properties);
            _LinesAState = MinimizeMaximizerD(45, 30, _LinesAState, "_EnableLines", materialEditor, properties);
            if (_LinesAState)
            {
                int _Height = 0;
                if (_LinesMode.floatValue == 0)
                {
                    _Height = 262;
                }
                else if (_LinesMode.floatValue == 1)
                {
                    _Height = 332;
                }
                else if (_LinesMode.floatValue == 2)
                {
                    _Height = 421;
                }
                BlockDesignA(0, -_Height - 10, _Height, m_BlackColorA);
                MaterialPropertyState("_ApplyPerCell", true, materialEditor, properties);
                materialEditor.ShaderProperty(_EnableLines, _EnableLines.displayName);
                GUILayout.Space(10);
                GUI.enabled = _EnableLines.floatValue == 1;
                MaterialPropertyState("_LinesMode", true, materialEditor, properties);
                GUILayout.Space(10);
                MaterialPropertyState("_LinesColor", true, materialEditor, properties);
                MaterialPropertyState("_LinesOpacity", true, materialEditor, properties);
                MaterialPropertyState("_LinesRadialOpacity", _LinesMode.floatValue > 0, materialEditor, properties);
                GUILayout.Space(10);
                MaterialPropertyState("_NoOfLines", true, materialEditor, properties);
                MaterialPropertyState("_LinesWidth", true, materialEditor, properties);
                MaterialPropertyState("_LinesEdgeBlur", true, materialEditor, properties);
                if (_LinesMode.floatValue == 2)
                {
                    GUILayout.Space(10);
                    GUILayout.Label("Spiral Parameters");
                    MaterialPropertyState("_A1", true, materialEditor, properties);
                    MaterialPropertyState("_A2", true, materialEditor, properties);
                    MaterialPropertyState("_A3", true, materialEditor, properties);
                }
                GUILayout.Space(10);
                MaterialPropertyState("_LinesRotation", true, materialEditor, properties);
                MaterialPropertyState("_LinesRotateMoveSpeed", true, materialEditor, properties);
                if (_LinesMode.floatValue > 0)
                {
                    GUILayout.Space(10);
                    MaterialPropertyState("_LinesOffsetX", true, materialEditor, properties);
                    MaterialPropertyState("_LinesOffsetY", true, materialEditor, properties);
                }
                GUI.enabled = true;
            }
        }

        public void BorderA(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            MaterialProperty _EnableBorder = ShaderGUI.FindProperty("_EnableBorder", properties);
            MaterialProperty _BorderColorMode = ShaderGUI.FindProperty("_BorderColorMode", properties);
            _BorderAState = MinimizeMaximizerC(45, _BorderAState, "_EnableBorder", materialEditor, properties);
            if (_BorderAState)
            {
                int _Height = _BorderColorMode.floatValue == 1 ? 293 : 203;
                BlockDesignA(0, -_Height - 10, _Height, m_BlackColorA);
                materialEditor.ShaderProperty(_EnableBorder, _EnableBorder.displayName);
                GUILayout.Space(10);
                GUI.enabled = _EnableBorder.floatValue == 1;
                MaterialPropertyState("_BorderBoundaryOffset", true, materialEditor, properties);
                MaterialPropertyState("_BorderWidth", true, materialEditor, properties);
                MaterialPropertyState("_BorderBlur", true, materialEditor, properties);
                MaterialPropertyState("_BorderGamma", true, materialEditor, properties);
                GUILayout.Space(10);
                MaterialPropertyState("_BorderOpacity", true, materialEditor, properties);
                materialEditor.ShaderProperty(_BorderColorMode, _BorderColorMode.displayName);
                MaterialPropertyState("_GradientType", _BorderColorMode.floatValue == 1, materialEditor, properties);
                MaterialPropertyState("_BorderColor", _BorderColorMode.floatValue == 0, materialEditor, properties);
                if (_BorderColorMode.floatValue == 1)
                {
                    MaterialPropertyState("_ColorE", true, materialEditor, properties);
                    MaterialPropertyState("_ColorF", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_BorderGradientAngle", true, materialEditor, properties);
                    MaterialPropertyState("_BorderGradientScale", true, materialEditor, properties);
                }
                GUI.enabled = true;
            }
        }




        public void InnerShadowA(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            MaterialProperty _EnableInnerShadow = ShaderGUI.FindProperty("_EnableInnerShadow", properties);
            MaterialProperty _InnerShadowColorMode = ShaderGUI.FindProperty("_InnerShadowColorMode", properties);
            _InnerShadowBState = MinimizeMaximizerC(45, _InnerShadowBState, "_EnableInnerShadow", materialEditor, properties);
            if (_InnerShadowBState)
            {
                int _Height = _InnerShadowColorMode.floatValue == 1 ? 323 : 233;
                BlockDesignA(0, -_Height - 10, _Height, m_BlackColorA);
                materialEditor.ShaderProperty(_EnableInnerShadow, _EnableInnerShadow.displayName);
                GUILayout.Space(10);
                GUI.enabled = _EnableInnerShadow.floatValue == 1;
                MaterialPropertyState("_InnerShadowSize", true, materialEditor, properties);
                MaterialPropertyState("_InnerShadowSpread", true, materialEditor, properties);
                MaterialPropertyState("_InnerShadowGamma", true, materialEditor, properties);
                GUILayout.Space(10);
                MaterialPropertyState("_InnerShadowXOffset", true, materialEditor, properties);
                MaterialPropertyState("_InnerShadowYOffset", true, materialEditor, properties);
                GUILayout.Space(10);
                MaterialPropertyState("_InnerShadowOpacity", true, materialEditor, properties);
                materialEditor.ShaderProperty(_InnerShadowColorMode, _InnerShadowColorMode.displayName);
                MaterialPropertyState("_InnerShadowGradientType", _InnerShadowColorMode.floatValue == 1, materialEditor, properties);
                MaterialPropertyState("_InnerShadowColor", _InnerShadowColorMode.floatValue == 0, materialEditor, properties);
                if (_InnerShadowColorMode.floatValue == 1)
                {
                    MaterialPropertyState("_InnerShadowColorX", true, materialEditor, properties);
                    MaterialPropertyState("_InnerShadowColorY", true, materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_InnerShadowGradientAngle", true, materialEditor, properties);
                    MaterialPropertyState("_InnerShadowGradientScale", true, materialEditor, properties);
                }
                GUI.enabled = true;
            }
        }

        public void DropShadowA(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            MaterialProperty _EnableShadow = ShaderGUI.FindProperty("_EnableDropShadow", properties);
            MaterialProperty _ShadowColorMode = ShaderGUI.FindProperty("_DropShadowColorMode", properties);
            MaterialProperty _ShadowGradientMode = ShaderGUI.FindProperty("_DropShadowGradientMode", properties);
            _DropShadowAState = MinimizeMaximizerC(45, _DropShadowAState, "_EnableDropShadow", materialEditor, properties);
            if (_DropShadowAState)
            {
                int _Height = _ShadowColorMode.floatValue == 1 ? 324 : 234;
                if (_ShadowColorMode.floatValue == 1)
                {
                    _Height += _ShadowGradientMode.floatValue == 1 ? 20 : 0;
                    _Height += _ShadowGradientMode.floatValue == 2 ? 40 : 0;
                }
                BlockDesignA(0, -_Height - 10, _Height, m_BlackColorA);
                materialEditor.ShaderProperty(_EnableShadow, _EnableShadow.displayName);
                GUILayout.Space(10);
                GUI.enabled = _EnableShadow.floatValue == 1;
                MaterialPropertyState("_DropShadowSize", true, materialEditor, properties);
                MaterialPropertyState("_DropShadowSpread", true, materialEditor, properties);
                MaterialPropertyState("_DropShadowGamma", true, materialEditor, properties);
                GUILayout.Space(10);
                MaterialPropertyState("_DropShadowXOffset", true, materialEditor, properties);
                MaterialPropertyState("_DropShadowYOffset", true, materialEditor, properties);
                GUILayout.Space(10);
                MaterialPropertyState("_DropShadowOpacity", true, materialEditor, properties);
                materialEditor.ShaderProperty(_ShadowColorMode, _ShadowColorMode.displayName);
                if (_ShadowColorMode.floatValue == 0)
                {
                    MaterialPropertyState("_DropShadowColor", true, materialEditor, properties);
                }
                else if (_ShadowColorMode.floatValue == 1)
                {
                    materialEditor.ShaderProperty(_ShadowGradientMode, _ShadowGradientMode.displayName);
                    float _Value = _ShadowGradientMode.floatValue;
                    MaterialPropertyState("_ColorE", true, materialEditor, properties);
                    MaterialPropertyState("_ColorF", true, materialEditor, properties);
                    MaterialPropertyState("_ColorG", (_Value > 0), materialEditor, properties);
                    MaterialPropertyState("_ColorH", (_Value > 1), materialEditor, properties);
                    GUILayout.Space(10);
                    MaterialPropertyState("_DropShadowGradientAngle", true, materialEditor, properties);
                    MaterialPropertyState("_DropShadowGradientScale", true, materialEditor, properties);
                }
                GUI.enabled = true;
            }
        }




        public void ReflectionA(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            GUILayout.Space(50);
            GUI.backgroundColor = m_BlackColorA;
            GUILayout.Button("Reflection Properties", GUILayout.Height(20), GUILayout.MaxWidth(140));
            GUI.backgroundColor = Color.white;

            BlockDesignA(1, -40 - 10, 40, m_BlackColorA);
            MaterialProperty _EnableMaskColor = ShaderGUI.FindProperty("_EnableMaskColor", properties);
            materialEditor.ShaderProperty(_EnableMaskColor, _EnableMaskColor.displayName);

            MaterialProperty _EnableAlphaGradient = ShaderGUI.FindProperty("_EnableAlphaGradient", properties);
            int _H1 = _EnableAlphaGradient.floatValue == 1 ? 140 : 80;
            BlockDesignA(11, -_H1 - 11, _H1, m_BlackColorA);
            MaterialPropertyState("_Color", true, materialEditor, properties);
            MaterialPropertyState("_Opacity", true, materialEditor, properties);
            materialEditor.ShaderProperty(_EnableAlphaGradient, _EnableAlphaGradient.displayName);

            if (_EnableAlphaGradient.floatValue == 1)
            {
                MaterialPropertyState("_AlphaGradientAngle", true, materialEditor, properties);
                MaterialPropertyState("_AlphaGradientScale", true, materialEditor, properties);
                MaterialPropertyState("_AlphaGradientGamma", true, materialEditor, properties);
            }

            MaterialProperty _ChooseReflectionShape = ShaderGUI.FindProperty("_ChooseReflectionShape", properties);
            MaterialProperty _ChooseLineMode = ShaderGUI.FindProperty("_ChooseLineMode", properties);

            int _H2 = _ChooseReflectionShape.floatValue == 1 ? 213 : 153;
            _H2 += _ChooseLineMode.floatValue == 1 ? 40 : 0;
            BlockDesignA(12, -_H2 + 10, _H2, m_BlackColorA);
            materialEditor.ShaderProperty(_ChooseReflectionShape, _ChooseReflectionShape.displayName);

            if (_ChooseReflectionShape.floatValue == 1)
            {
                GUILayout.Space(10);
                MaterialPropertyState("_CircleRadius", true, materialEditor, properties);
                MaterialPropertyState("_CircleBlur", true, materialEditor, properties);
                GUILayout.Space(10);
                MaterialPropertyState("_CircleXOffset", true, materialEditor, properties);
                MaterialPropertyState("_CircleYOffset", true, materialEditor, properties);
                GUILayout.Space(10);
                MaterialPropertyState("_CircleYScale", true, materialEditor, properties);
                MaterialPropertyState("_CircleYBend", true, materialEditor, properties);
                MaterialPropertyState("_CircleRotation", true, materialEditor, properties);

            }
            else if (_ChooseReflectionShape.floatValue == 0)
            {
                GUILayout.Space(10);
                materialEditor.ShaderProperty(_ChooseLineMode, _ChooseLineMode.displayName);
                MaterialPropertyState("_LineWidth", _ChooseLineMode.floatValue == 0, materialEditor, properties);
                MaterialPropertyState("_LineWidthA", _ChooseLineMode.floatValue == 1, materialEditor, properties);
                MaterialPropertyState("_LineWidthB", _ChooseLineMode.floatValue == 1, materialEditor, properties);
                MaterialPropertyState("_LinesSeparation", _ChooseLineMode.floatValue == 1, materialEditor, properties);
                MaterialPropertyState("_LineEdgeBlur", true, materialEditor, properties);
                MaterialPropertyState("_Rotate", true, materialEditor, properties);
                MaterialPropertyState("_LineOffset", true, materialEditor, properties);

                MaterialProperty _EnableBend = ShaderGUI.FindProperty("_EnableBend", properties);
                int _H3 = _EnableBend.floatValue == 1 ? 60 : 40;
                BlockDesignA(14, -_H3 + 10, _H3, m_BlackColorA);
                materialEditor.ShaderProperty(_EnableBend, _EnableBend.displayName);
                MaterialPropertyState("_Bend", _EnableBend.floatValue == 1, materialEditor, properties);

                MaterialProperty _EnableAnimation = ShaderGUI.FindProperty("_EnableAnimation", properties);
                int _H4 = _EnableAnimation.floatValue == 1 ? 80 : 40;
                BlockDesignA(11, -_H4 + 10, _H4, m_BlackColorA);
                materialEditor.ShaderProperty(_EnableAnimation, _EnableAnimation.displayName);
                MaterialPropertyState("_MoveSpeed", _EnableAnimation.floatValue == 1, materialEditor, properties);
                MaterialPropertyState("_Frequency", _EnableAnimation.floatValue == 1, materialEditor, properties);
            }
        }




    }// Class


#endif


}/// Name Space 















//GUILayout.Space(20);

//GUI.enabled=false;
//GUILayout.Button("GUI Theme", GUILayout.Height(20), GUILayout.MaxWidth(5000));
//GUI.enabled=true;

//GUI.enabled = _LightBtn;
//if (GUILayout.Button("Light", GUILayout.Height(20), GUILayout.MaxWidth(5000)))
//{
//    _LightGUIMode = true;
//    _LightBtn=false;
//    _DarkBtn=true;
//}
//GUI.enabled=true;

//GUI.enabled=_DarkBtn;
//if (GUILayout.Button("Dark", GUILayout.Height(20), GUILayout.MaxWidth(5000)))
//{
//    _LightGUIMode = false;
//    _DarkBtn=false;
//    _LightBtn=true;
//}
//GUI.enabled = true;

//if(_LightGUIMode)
//{
//    m_BlackColorA = new Color(1,1,1,1)*0.99f;
//    m_BlackColorB = new Color(1,1,1,1)*0.94f;
//}
//else
//{
//    m_BlackColorA = new Color(0, 0, 0, 1.0f);
//    m_BlackColorB = new Color(0, 0, 0, 0.6f);
//}

//GUILayout.Space(20);




#region  waste Code








//public void FillA(MaterialEditor materialEditor, MaterialProperty[] properties)
//{
//    GUILayout.Space(20);
//    GUI.backgroundColor = m_BlackColorB;
//    string _Text = _FillAState ? "Minimize" : "Maximize";
//    if (GUILayout.Button(_Text, GUILayout.Height(20), GUILayout.MaxWidth(80)))
//    {
//        _FillAState = !_FillAState;
//    }

//    GUI.enabled = false;
//    GUILayout.TextArea("", GUILayout.Height(_FillAState ? 100 : 30));
//    GUI.enabled = true;
//    GUI.backgroundColor = Color.white;
//    GUILayout.Space(_FillAState ? -110 : -45);

//    MaterialProperty _EnableFill = ShaderGUI.FindProperty("_EnableFill", properties);
//    materialEditor.ShaderProperty(_EnableFill, _EnableFill.displayName);

//    GUI.enabled = _EnableFill.floatValue == 1;
//    MaterialPropertyState("_FillMode", _FillAState, materialEditor, properties);
//    MaterialPropertyState("_FillAmount", _FillAState, materialEditor, properties);
//    MaterialPropertyState("_FillAngle", _FillAState, materialEditor, properties);
//    GUI.enabled = true;



//}



//public void GradientB(MaterialEditor materialEditor, MaterialProperty[] properties)
//{
//    MaterialProperty _ColorMode = ShaderGUI.FindProperty("_ColorMode", properties);
//    MaterialProperty _EnableToonGradient = ShaderGUI.FindProperty("_EnableToonGradient", properties);
//    MaterialProperty _GradientMode = ShaderGUI.FindProperty("_GradientMode", properties);

//    GUILayout.Space(30);
//    Color _ContainerColor = m_BlackColorA;
//    GUI.backgroundColor = _ContainerColor;
//    string _Text = _ColorModeAState ? "Minimize" : "Maximize";
//    if (GUILayout.Button(_Text, GUILayout.Height(20), GUILayout.MaxWidth(80)))
//    {
//        _ColorModeAState = !_ColorModeAState;
//    }

//    GUI.backgroundColor = Color.white;

//    if (_ColorModeAState == false)
//    {
//        int _H0 = _ColorMode.floatValue == 0 ? 60 : 40;
//        GUI.backgroundColor = _ContainerColor;
//        GUI.enabled = false;
//        GUILayout.TextArea("", GUILayout.Height(_H0));
//        GUI.enabled = true;
//        GUILayout.Space(-_H0 - 10);
//        GUI.backgroundColor = Color.white;
//        materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
//        MaterialPropertyState("_Color", (_ColorMode.floatValue == 0), materialEditor, properties);

//    }
//    else
//    {
//        GUILayout.Space(-20);

//        if (_ColorMode.floatValue == 0)
//        {
//            BlockDesignA(20, -70, 60, _ContainerColor);
//        }
//        else if (_ColorMode.floatValue == 1)
//        {
//            int _H = _EnableToonGradient.floatValue == 1 ? 240 : 230;
//            BlockDesignA(20, -_H - 10, _H, _ContainerColor);
//        }
//        else if (_ColorMode.floatValue == 2)
//        {
//            int _BlockHeight = 275;
//            _BlockHeight += (int)_EnableToonGradient.floatValue * 25;
//            _BlockHeight += (int)_GradientMode.floatValue == 1 ? 30 : 0;
//            _BlockHeight += (int)_GradientMode.floatValue == 2 ? 45 : 0;

//            BlockDesignA(20, -(_BlockHeight + 10), _BlockHeight, _ContainerColor);
//        }
//        else if (_ColorMode.floatValue == 3)
//        {
//            int _H = 160;
//            BlockDesignA(20, -_H - 10, _H, _ContainerColor);
//        }

//        materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
//        MaterialPropertyState("_Color", (_ColorMode.floatValue == 0), materialEditor, properties);

//        if (_ColorMode.floatValue > 0)
//        {
//            if (_ColorMode.floatValue != 3)
//            {
//                MaterialPropertyState("_EnableToonGradient", true, materialEditor, properties);
//                MaterialPropertyState("_StepsToonGradient", _EnableToonGradient.floatValue == 1, materialEditor, properties);
//            }

//            if (_ColorMode.floatValue == 1)
//            {
//                MaterialPropertyState("_RadialScale", true, materialEditor, properties);
//                MaterialPropertyState("_RadialSpread", true, materialEditor, properties);
//            }

//            MaterialPropertyState("_GradientMode", (_ColorMode.floatValue == 2), materialEditor, properties);

//            MaterialPropertyState("_ColorA", true, materialEditor, properties);
//            MaterialPropertyState("_ColorB", true, materialEditor, properties);
//            if (_ColorMode.floatValue == 2)
//            {
//                MaterialPropertyState("_ColorC", (_GradientMode.floatValue > 0), materialEditor, properties);
//                MaterialPropertyState("_ColorD", (_GradientMode.floatValue > 1), materialEditor, properties);
//            }

//            if (_ColorMode.floatValue == 2 || _ColorMode.floatValue == 3)
//            {
//                MaterialPropertyState("_GradientAngle", true, materialEditor, properties);
//            }

//            if (_ColorMode.floatValue == 2)
//            {
//                MaterialPropertyState("_GradientScale", true, materialEditor, properties);
//                MaterialPropertyState("_GradientSpread", true, materialEditor, properties);
//            }

//            if (_ColorMode.floatValue == 3)
//            {
//                MaterialPropertyState("_BoundaryBlur", true, materialEditor, properties);
//                MaterialPropertyState("_BoundaryOffset", true, materialEditor, properties);
//            }

//            if (_ColorMode.floatValue == 1 || _ColorMode.floatValue == 2)
//            {

//                MaterialPropertyState("_GradientXOffset", true, materialEditor, properties);
//                MaterialPropertyState("_GradientYOffset", true, materialEditor, properties);
//            }
//        }
//    }
//}




//public void GradientB(MaterialEditor materialEditor, MaterialProperty[] properties)
//{
//    var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "RadialA" }, { 2, "LinearA" }, { 3, "Split" } };
//    //ColorModeC(materialEditor, properties, _ColorModeIndex);


//    //MaterialProperty _ColorMode = ShaderGUI.FindProperty("_ColorMode", properties);
//    //MaterialProperty _EnableToonGradient = ShaderGUI.FindProperty("_EnableToonGradient", properties);
//    //MaterialProperty _GradientMode = ShaderGUI.FindProperty("_GradientMode", properties);
//    //_ColorModeAState = MinimizeMaximizerB(30, _ColorModeAState, _ColorMode, materialEditor, properties,"");
//    //if(_ColorModeAState)
//    //{
//    //    GUILayout.Space(-20);
//    //    var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "RadialA" }, { 2, "LinearA" }, { 3, "Split" } };
//    //    int _H = (int)ColorModeContainerHeight(_ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient.floatValue, _GradientMode.floatValue,0);
//    //    BlockDesignA(20, -_H - 10, _H, m_BlackColorA);
//    //    materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
//    //    ColorMode(materialEditor, properties, _ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient, _GradientMode);
//    //}
//}

//public void GradientC(MaterialEditor materialEditor, MaterialProperty[] properties)
//{
//    var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "Texture" }, { 2, "RadialC" }, { 3, "AngularA" }, { 4, "LinearA" }, { 5, "Split" } };
//    //ColorModeC(materialEditor, properties, _ColorModeIndex);


//    //MaterialProperty _ColorMode = ShaderGUI.FindProperty("_ColorMode", properties);
//    //MaterialProperty _EnableToonGradient = ShaderGUI.FindProperty("_EnableToonGradient", properties);
//    //MaterialProperty _GradientMode = ShaderGUI.FindProperty("_GradientMode", properties);
//    //_ColorModeAState = MinimizeMaximizerB(30, _ColorModeAState, _ColorMode, materialEditor, properties, "");
//    //if (_ColorModeAState)
//    //{
//    //    GUILayout.Space(-20);
//    //    var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "Texture" }, { 2, "RadialC" },{3,"AngularA" }, { 4, "LinearA" }, { 5, "Split" } };
//    //    int _H = (int)ColorModeContainerHeight(_ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient.floatValue, _GradientMode.floatValue, 0);
//    //    BlockDesignA(20, -_H - 10, _H, m_BlackColorA);
//    //    materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
//    //    ColorMode(materialEditor, properties, _ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient, _GradientMode);
//    //}
//}

//public void GradientD(MaterialEditor materialEditor, MaterialProperty[] properties, string _TopProperty)
//{
//    var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "Texture" }, { 2, "RadialD" }, { 3, "AngularA" }, { 4, "LinearA" }, { 5, "Split" } };
//    //Gradient(materialEditor, properties, _ColorModeIndex);

//    MaterialProperty _ColorMode = ShaderGUI.FindProperty("_ColorMode", properties);
//    MaterialProperty _EnableToonGradient = ShaderGUI.FindProperty("_EnableToonGradient", properties);
//    MaterialProperty _GradientMode = ShaderGUI.FindProperty("_GradientMode", properties);
//    MaterialProperty _RadialType = ShaderGUI.FindProperty("_RadialType", properties);
//    _ColorModeAState = MinimizeMaximizerB(45, _ColorModeAState, _ColorMode, materialEditor, properties, _TopProperty);
//    if (_ColorModeAState)
//    {
//        GUILayout.Space(-20);
//        //var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "Texture" }, { 2, "RadialA" }, { 3, "LinearA" }, { 4, "Split" } };
//        int _H = (_TopProperty!=""?20:0) + (int)ColorModeContainerHeight(_ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient.floatValue, _GradientMode.floatValue, _RadialType.floatValue);
//        BlockDesignA(20, -_H - 10, _H, m_BlackColorA);

//        if(_TopProperty!="")
//        MaterialPropertyState(_TopProperty, true, materialEditor, properties);

//        materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
//        ColorModeType(materialEditor, properties, _ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient, _GradientMode);
//    }



//}

//public void GradientF(MaterialEditor materialEditor, MaterialProperty[] properties, string _TopProperty)
//{
//    var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "RadialE" }, { 2, "LinearA" } };
//    //Gradient(materialEditor, properties, _ColorModeIndex);

//    MaterialProperty _ColorMode = ShaderGUI.FindProperty("_ColorMode", properties);
//    MaterialProperty _EnableToonGradient = ShaderGUI.FindProperty("_EnableToonGradient", properties);
//    MaterialProperty _GradientMode = ShaderGUI.FindProperty("_GradientMode", properties);
//    MaterialProperty _RadialType = ShaderGUI.FindProperty("_RadialType", properties);
//    _ColorModeAState = MinimizeMaximizerB(45, _ColorModeAState, _ColorMode, materialEditor, properties, _TopProperty);
//    if (_ColorModeAState)
//    {
//        GUILayout.Space(-20);
//        //var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "Texture" }, { 2, "RadialA" }, { 3, "LinearA" }, { 4, "Split" } };
//        int _H = (_TopProperty != "" ? 20 : 0) + (int)ColorModeContainerHeight(_ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient.floatValue, _GradientMode.floatValue, _RadialType.floatValue);
//        BlockDesignA(20, -_H - 10, _H, m_BlackColorA);

//        if (_TopProperty != "")
//            MaterialPropertyState(_TopProperty, true, materialEditor, properties);

//        materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
//        ColorModeType(materialEditor, properties, _ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient, _GradientMode);
//    }



//}

//public void GradientG(MaterialEditor materialEditor, MaterialProperty[] properties)
//{
//    MaterialProperty _ColorMode = ShaderGUI.FindProperty("_ColorMode", properties);
//    MaterialProperty _EnableToonGradient = ShaderGUI.FindProperty("_EnableToonGradient", properties);
//    MaterialProperty _GradientMode = ShaderGUI.FindProperty("_GradientMode", properties);
//    MaterialProperty _RadialGradientMode = ShaderGUI.FindProperty("_RadialGradientMode", properties);
//    _ColorModeAState = MinimizeMaximizerB(45, _ColorModeAState, _ColorMode, materialEditor, properties,"_EnableColor");
//    if (_ColorModeAState)
//    {
//        GUILayout.Space(-20);
//        var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "Texture" },{2,"RadialB" }, { 3, "LinearA" }, { 4, "Split" } };
//        int _H =20+ (int)ColorModeContainerHeight(_ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient.floatValue, _GradientMode.floatValue, _RadialGradientMode.floatValue);
//        BlockDesignA(20, -_H - 10, _H, m_BlackColorA);
//        MaterialPropertyState("_EnableColor", true, materialEditor, properties);
//        materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
//        ColorModeType(materialEditor, properties, _ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient, _GradientMode);
//    }
//}

//public void GradientE(MaterialEditor materialEditor, MaterialProperty[] properties)
//{
//    MaterialProperty _ColorMode = ShaderGUI.FindProperty("_ColorMode", properties);
//    MaterialProperty _EnableToonGradient = ShaderGUI.FindProperty("_EnableToonGradient", properties);
//    MaterialProperty _GradientMode = ShaderGUI.FindProperty("_GradientMode", properties);
//    _ColorModeAState = MinimizeMaximizerB(45, _ColorModeAState, _ColorMode, materialEditor, properties, "_Opacity");
//    if(_ColorModeAState)
//    {
//        GUILayout.Space(-20);
//        var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "RadialA" }, { 2, "LinearA" }, { 3, "Split" } };
//        int _H = 20+ (int)ColorModeContainerHeight(_ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient.floatValue, _GradientMode.floatValue, 0);
//        BlockDesignA(20, -_H - 10, _H, m_BlackColorA);
//        MaterialPropertyState("_Opacity", true, materialEditor, properties);
//        materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
//        ColorModeType(materialEditor, properties, _ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient, _GradientMode);
//    }
//}

//public void GradientX(MaterialEditor materialEditor, MaterialProperty[] properties, string _TopAnchorProperty)
//{
//    MaterialProperty _ColorMode = ShaderGUI.FindProperty("_ColorMode", properties);
//    MaterialProperty _EnableToonGradient = ShaderGUI.FindProperty("_EnableToonGradient", properties);
//    MaterialProperty _GradientMode = ShaderGUI.FindProperty("_GradientMode", properties);
//    _ColorModeAState = MinimizeMaximizerB(45, _ColorModeAState, _ColorMode, materialEditor, properties, _TopAnchorProperty);
//    if (_ColorModeAState)
//    {
//        GUILayout.Space(-20);
//        var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "Texture" }, { 2, "RadialA" }, { 3, "LinearA" }, { 4, "Split" } };
//        int _H = 20 + (int)ColorModeContainerHeight(_ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient.floatValue, _GradientMode.floatValue, 0);
//        BlockDesignA(20, -_H - 10, _H, m_BlackColorA);
//        MaterialPropertyState(_TopAnchorProperty, true, materialEditor, properties);
//        materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
//        ColorModeType(materialEditor, properties, _ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient, _GradientMode);
//    }
//}



//public void GradientA1(MaterialEditor materialEditor, MaterialProperty[] properties)
//{
//    //var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "Texture" }, { 2, "RadialA" }, { 3, "LinearA" }, { 4, "Split" } };
//    //Gradient(materialEditor, properties, _ColorModeIndex);

//    MaterialProperty _ColorMode = ShaderGUI.FindProperty("_ColorMode", properties);
//    MaterialProperty _EnableToonGradient = ShaderGUI.FindProperty("_EnableToonGradient", properties);
//    MaterialProperty _GradientMode = ShaderGUI.FindProperty("_GradientMode", properties);
//    _ColorModeAState = MinimizeMaximizerB(45, _ColorModeAState, _ColorMode, materialEditor, properties, "_EnableColor");
//    if (_ColorModeAState)
//    {
//        GUILayout.Space(-20);
//        var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "Texture" }, { 2, "RadialA" }, { 3, "LinearA" }, { 4, "Split" } };
//        int _H = 20+ (int)ColorModeContainerHeight(_ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient.floatValue, _GradientMode.floatValue, 0);
//        BlockDesignA(20, -_H - 10, _H, m_BlackColorA);
//        MaterialPropertyState("_EnableColor", true, materialEditor, properties);
//        materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
//        ColorModeType(materialEditor, properties, _ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient, _GradientMode);
//    }
//}

//public void GradientA(MaterialEditor materialEditor, MaterialProperty[] properties)
//{
//    //var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "Texture" }, { 2, "RadialA" }, { 3, "LinearA" }, { 4, "Split" } };
//    //Gradient(materialEditor, properties, _ColorModeIndex);

//    MaterialProperty _ColorMode = ShaderGUI.FindProperty("_ColorMode", properties);
//    MaterialProperty _EnableToonGradient = ShaderGUI.FindProperty("_EnableToonGradient", properties);
//    MaterialProperty _GradientMode = ShaderGUI.FindProperty("_GradientMode", properties);
//    _ColorModeAState = MinimizeMaximizerB(45, _ColorModeAState, _ColorMode, materialEditor, properties, "");
//    if (_ColorModeAState)
//    {
//        GUILayout.Space(-20);
//        var _ColorModeIndex = new Dictionary<int, string> { { 0, "Color" }, { 1, "Texture" }, { 2, "RadialA" }, { 3, "LinearA" }, { 4, "Split" } };
//        int _H = (int)ColorModeContainerHeight(_ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient.floatValue, _GradientMode.floatValue, 0);
//        BlockDesignA(20, -_H - 10, _H, m_BlackColorA);
//        materialEditor.ShaderProperty(_ColorMode, _ColorMode.displayName);
//        ColorModeType(materialEditor, properties, _ColorModeIndex[(int)_ColorMode.floatValue], _EnableToonGradient, _GradientMode);
//    }
//}





//public void RadialA_Gradient(MaterialEditor materialEditor, MaterialProperty[] properties, MaterialProperty _EnableToon)
//{
//    GUILayout.Space(10);
//    materialEditor.ShaderProperty(_EnableToon, _EnableToon.displayName);
//    MaterialPropertyState("_StepsToonGradient", _EnableToon.floatValue == 1, materialEditor, properties);
//    GUILayout.Space(10);
//    MaterialPropertyState("_ColorA", true, materialEditor, properties);
//    MaterialPropertyState("_ColorB", true, materialEditor, properties);
//    GUILayout.Space(10);
//    MaterialPropertyState("_RadialScale", true, materialEditor, properties);
//    MaterialPropertyState("_RadialSpread", true, materialEditor, properties);
//    GUILayout.Space(10);
//    MaterialPropertyState("_GradientXOffset", true, materialEditor, properties);
//    MaterialPropertyState("_GradientYOffset", true, materialEditor, properties);
//}

//public void RadialB_Gradient(MaterialEditor materialEditor, MaterialProperty[] properties, MaterialProperty _EnableToon)
//{
//    materialEditor.ShaderProperty(_EnableToon, _EnableToon.displayName);
//    MaterialPropertyState("_StepsToonGradient", _EnableToon.floatValue == 1, materialEditor, properties);
//    MaterialPropertyState("_ColorA", true, materialEditor, properties);
//    MaterialPropertyState("_ColorB", true, materialEditor, properties);
//    MaterialProperty _RadialGradientMode = ShaderGUI.FindProperty("_RadialGradientMode", properties);
//    MaterialPropertyState("_RadialGradientMode", true, materialEditor, properties);
//    MaterialPropertyState("_RadialOffset", _RadialGradientMode.floatValue == 1, materialEditor, properties);
//    MaterialPropertyState("_RadialScale", true, materialEditor, properties);
//    MaterialPropertyState("_RadialSpread", true, materialEditor, properties);
//    MaterialPropertyState("_GradientXOffset", true, materialEditor, properties);
//    MaterialPropertyState("_GradientYOffset", true, materialEditor, properties);
//}

//public void RadialC_Gradient(MaterialEditor materialEditor, MaterialProperty[] properties, MaterialProperty _EnableToon)
//{
//    materialEditor.ShaderProperty(_EnableToon, _EnableToon.displayName);
//    MaterialPropertyState("_StepsToonGradient", _EnableToon.floatValue == 1, materialEditor, properties);
//    MaterialPropertyState("_ColorA", true, materialEditor, properties);
//    MaterialPropertyState("_ColorB", true, materialEditor, properties);
//    MaterialPropertyState("_RadialType", true, materialEditor, properties);
//    MaterialPropertyState("_RadialGamma", true, materialEditor, properties);
//}

//public void RadialD_Gradient(MaterialEditor materialEditor, MaterialProperty[] properties, MaterialProperty _EnableToon)
//{
//    GUILayout.Space(10);
//    materialEditor.ShaderProperty(_EnableToon, _EnableToon.displayName);
//    MaterialPropertyState("_StepsToonGradient", _EnableToon.floatValue == 1, materialEditor, properties);
//    GUILayout.Space(10);
//    MaterialPropertyState("_ColorA", true, materialEditor, properties);
//    MaterialPropertyState("_ColorB", true, materialEditor, properties);
//    GUILayout.Space(10);
//    MaterialProperty _RadialType = ShaderGUI.FindProperty("_RadialType", properties);
//    MaterialPropertyState("_RadialType", true, materialEditor, properties);
//    MaterialPropertyState("_RadialScale", _RadialType.floatValue==0, materialEditor, properties);
//    MaterialPropertyState("_RadialSpread", _RadialType.floatValue==0, materialEditor, properties);
//    MaterialPropertyState("_RadialGamma", _RadialType.floatValue==1 || _RadialType.floatValue==2, materialEditor, properties);
//    if (_RadialType.floatValue == 0)
//    {
//        GUILayout.Space(10);
//        MaterialPropertyState("_GradientXOffset", true, materialEditor, properties);
//        MaterialPropertyState("_GradientYOffset", true, materialEditor, properties);
//    }
//}

//public void RadialE_Gradient(MaterialEditor materialEditor, MaterialProperty[] properties, MaterialProperty _EnableToon)
//{
//    GUILayout.Space(10);
//    materialEditor.ShaderProperty(_EnableToon, _EnableToon.displayName);
//    MaterialPropertyState("_StepsToonGradient", _EnableToon.floatValue == 1, materialEditor, properties);
//    GUILayout.Space(10);
//    MaterialPropertyState("_ColorA", true, materialEditor, properties);
//    MaterialPropertyState("_ColorB", true, materialEditor, properties);
//    GUILayout.Space(10);
//    MaterialProperty _RadialType = ShaderGUI.FindProperty("_RadialType", properties);
//    MaterialPropertyState("_RadialType", true, materialEditor, properties);
//    MaterialPropertyState("_RadialScale", _RadialType.floatValue == 0, materialEditor, properties);
//    MaterialPropertyState("_RadialSpread", _RadialType.floatValue == 0, materialEditor, properties);
//    MaterialPropertyState("_RadialGamma", _RadialType.floatValue == 1, materialEditor, properties);
//    if (_RadialType.floatValue == 0)
//    {
//        GUILayout.Space(10);
//        MaterialPropertyState("_GradientXOffset", true, materialEditor, properties);
//        MaterialPropertyState("_GradientYOffset", true, materialEditor, properties);
//    }
//}

//public void AngularA_Gradient(MaterialEditor materialEditor, MaterialProperty[] properties, MaterialProperty _EnableToon)
//{
//    //GUILayout.Space(10);
//    //materialEditor.ShaderProperty(_EnableToon, _EnableToon.displayName);
//    //MaterialPropertyState("_StepsToonGradient", _EnableToon.floatValue == 1, materialEditor, properties);
//    GUILayout.Space(10);
//    MaterialPropertyState("_ColorA", true, materialEditor, properties);
//    MaterialPropertyState("_ColorB", true, materialEditor, properties);
//    GUILayout.Space(10);
//    MaterialPropertyState("_AngularRotate", true, materialEditor, properties);
//    MaterialPropertyState("_AngularGamma", true, materialEditor, properties);
//}



#endregion