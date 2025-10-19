Shader "ProceduralUIElements/UIElement_12B"
{
    Properties
    {
        [Space(20)]
        _ImageSizeRatio("Image Size Ratio", Vector) = (1.0, 1.0, 0.0, 0.0)


        /// 
        ///  Shape Properties
        /// 


        [Space(20)]
        _Radius ("Radius", Range(0,0.5)) = 0.3
        //_RingWidth("Ring Width", Range(0, 0.15)) = 0.05


        /// 
        ///  Cells Shape Properties
        /// 


        [IntRange]_NumberOfCells("Number Of Cells", Range(0,30)) = 5
        _CellHeight("Cell Height", Range(0.0, 1.0)) = 0.15
        _CellWidth("Cell Width", Range(0.0, 1.0)) = 0.15
        _CornerRoundness("Corner Roundness", Range(0, 0.5)) = 0.01
        _EdgeBlur ("Edge Blur", Range(0,0.1)) = 0.03


        /// 
        ///  Fill
        /// 


        [Space(20)]
        _FillAmount("Fill Amount", Range(0.0, 1.0)) = 1.0
        [Toggle(DisableCell)] _DisableCell("Disable Cell", float) = 0
        _DisableCellColor("Disable Cell Color", Color) = (1.0, 0.0, 0.0, 1)
        [Toggle(IncludeBorder)] _IncludeBorder("Include Border In Fill", float) = 0
        [Toggle(IncludeLine)] _IncludeLines("Include Lines In Fill", float) = 0

        
        ///
        ///  Color Mode
        ///
     

        [Space(20)]
        [KeywordEnum(Color, TextureColor, RadialGradient, LinearGradient, SharpBoundary)] _ColorMode("Color Mode", Float) = 0
        _Color("Color", Color) = (1.0, 1.0, 1.0, 1)
        //
        [Toggle(ToonGradient)] _EnableToonGradient("Enable Toon Gradient", float) = 0
        _StepsToonGradient("Number Of Steps", Range(0.0, 20.0)) = 4.0
        //
        _MainTex("Texture", 2D) = "white" {}
        [Toggle(TexClipping)] _TexClipping("Clipping", float) = 0
        _TexScale("Scale", Range(0.1, 2.5)) = 1.0
        _TexRotation("Rotation", Range(0.0, 360)) = 0.0
        _TexXOffset("X Offset", Range(-0.5, 0.5)) = 0.0
        _TexYOffset("Y Offset", Range(-0.5, 0.5)) = 0.0
        //
        [KeywordEnum(2 Color, 3 Color, 4 Color)] _GradientMode("Gradient Mode", Float) = 0
        _ColorA("Color A", Color) = (1, 0, 0, 1)
        _ColorB("Color B", Color) = (1, 1, 0, 1)
        _ColorC("Color C", Color) = (0, 1, 0, 1)
        _ColorD("Color D", Color) = (0, 0, 1, 1)
        //
        [KeywordEnum(A, B)] _RadialType("Radial Type", Float) = 0
        _RadialScale("Radial Scale", Range(0.0, 3.0)) = 1.0
        _RadialSpread("Radial Spread", Range(0.0, 3.0)) = 1.0
        _RadialGamma("Radial Gamma", Range(0.0, 5.0)) = 1.0
        //
        _GradientAngle("Angle", Range(0,360)) = 0
        _GradientScale("Gradient Scale", Range(0.0, 1.0)) = 1.0
        //
        _BoundaryBlur("Boundary Blur", Range(0.0, 1.0)) = 0.005
        _BoundaryOffset("Boundary Offset", Range(-1.5, 1.5)) = 0.0
        //
        _GradientXOffset("Offset X", Range(-0.5, 0.5)) = 0.0
        _GradientYOffset("Offset Y", Range(-0.5, 0.5)) = 0.0


        ///
        ///  Lines Overlay
        /// 


        [Space(20)]
        [Toggle(ApplyPerCell)] _ApplyPerCell("Apply Per Cell", float) = 0
        [Toggle(EnableLines)] _EnableLines("Enable Lines (Linear, Radial, Spiral)", float) = 0
        [KeywordEnum(Linear, Radial, Spiral)] _LinesMode("Lines Mode", Float) = 0
        _LinesColor("Color", Color) = (0.45, 0.45, 0.45, 1)
        _LinesOpacity("Opacity", Range(0.0, 1.0)) = 0.1
        _LinesRadialOpacity("Radial Opacity", Range(0.0, 1.0)) = 0.1
        _NoOfLines("No. Of Lines", Float) = 5.0
        _LinesWidth("Lines Width", Range(0.0, 1.0)) = 0.1
        _LinesEdgeBlur("Lines Edge Blur", Range(0.0, 1.0)) = 0.1
        _LinesRotation("Rotation", Range(0.0, 360.0)) = 0.0
        _LinesRotateMoveSpeed("Speed (Rotation/Movement)", Float) = 0.0
        _A1("A1", Range(0.0, 1.0)) = 0.1
        _A2("A2", Range(0.0, 1.0)) = 0.1
        _A3("A3", Range(0.0, 2.0)) = 0.1
        _LinesOffsetX("Lines X Offset", Range(-0.5, 0.5)) = 0.0
        _LinesOffsetY("Lines Y Offset", Range(-0.5, 0.5)) = 0.0


        ///
        ///  Border
        ///


        [Space(20)]
        [Toggle(EnableBorder)] _EnableBorder("Enable Border", float) = 0
        _BorderBoundaryOffset("Boundary Offset", Range(0.0, 0.1)) = 0.0
        _BorderWidth("Border Width", Range(0.0, 0.1)) = 0.01
        _BorderBlur("Border Blur", Range(0.0, 1.0)) = 0.5
        _BorderGamma("Gamma", Range(0.0, 1.0)) = 0.28
        _BorderOpacity("Opacity", Range(0.0, 1.0)) = 1.0
        [KeywordEnum(Color, Gradient)] _BorderColorMode("Color Mode", Float) = 0
        [KeywordEnum(A, B)] _GradientType("Gradient Type", Float) = 0
        _BorderColor("Border Color", Color) = (0.0, 0.0, 0.0, 1.0)
        _ColorE("Color A", Color) = (0.45, 0.45, 0.45, 1.0)
        _ColorF("Color B", Color) = (0.45, 0.45, 0.45, 1.0)
        _BorderGradientAngle("Gradient Angle", Range(0, 360)) = 0
        _BorderGradientScale("Gradient Scale", Range(0.0, 2.0)) = 0.5





        [Space(100)]
        _StencilComp("Stencil Comparison", Float) = 8.000000
        _Stencil("Stencil ID", Float) = 0.000000
        _StencilOp("Stencil Operation", Float) = 0.000000
        _StencilWriteMask("Stencil Write Mask", Float) = 255.000000
        _StencilReadMask("Stencil Read Mask", Float) = 255.000000
        _ColorMask("Color Mask", Float) = 15.000000
    }
    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
            "PreviewType" = "Plane"
            "CanUseSpriteAtlas" = "True"
        }

        Stencil
        {
            Ref[_Stencil]
            Comp[_StencilComp]
            Pass[_StencilOp]
            ReadMask[_StencilReadMask]
            WriteMask[_StencilWriteMask]
        }

        Cull Off
        Lighting Off
        ZWrite Off
        ZTest[unity_GUIZTestMode]
        Blend SrcAlpha OneMinusSrcAlpha
        ColorMask[_ColorMask]


        ///
        ///  Color Mode
        /// 


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "../CodeBlock/BaseFilesB.cginc"
            #include "/Variables.cginc"
            fixed4 _DisableCellColor;
            float _DisableCell;
            #include "../CodeBlock/Variables_ColorModeA.cginc"
            float _EnableBorder;

            fixed4 frag(v2f i) : SV_Target
            {
                float Rim=1;
                #include "/CodeBlock.cginc"
                UV = float2(Radial, AngularFrac);
                #include "../CodeBlock/ColorModeA.cginc"
                float Fill = (floor(Angular * _NumberOfCells) / _NumberOfCells) < _FillAmount;
                _DisableCellColor = _DisableCell == 1 ? _DisableCellColor : fixed4(0,0,0,0);
                col = (Fill ? SelectedColor : _DisableCellColor);
                col.a = Fill ? smoothstep(_EdgeBlur, 0, SDF) : _DisableCell == 1? smoothstep(_EdgeBlur, 0, SDF) :0;
                col *= i.color;
                return col;
            }
            ENDCG
        }


        /// 
        ///  Lines Overlay
        /// 


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "../CodeBlock/BaseFilesB.cginc"
            #include "/Variables.cginc"
            float _ApplyPerCell;
            #include "../CodeBlock/Variables_LinesA.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableLines == 0)
                    return 0;

                # include "/CodeBlock.cginc"
                if (_ApplyPerCell == 1)
                {
                    UV = float2(Radial - 0.5, AngularFrac);
                }
                #include "../CodeBlock/LinesA.cginc"
                float Fill =  (floor(Angular * _NumberOfCells) / _NumberOfCells) < _FillAmount;
                col.a *= smoothstep(_EdgeBlur, 0, SDF) *(_IncludeLines==1? Fill:1);
                col *= i.color;
                return col;
            }
            ENDCG
        }


        /// 
        ///  Border 
        /// 


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "../CodeBlock/BaseFilesB.cginc"
            #include "../Functions/GradientB.cginc"
            #include "/Variables.cginc"
            #include "../CodeBlock/Variables_BorderA.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableBorder == 0)
                    return 0;

                float Fill = 1;
                # include "/CodeBlock.cginc"
                if (_IncludeBorder == 1)
                {
                    Fill =  (floor(Angular * _NumberOfCells) / _NumberOfCells) < _FillAmount;
                }
                #include "../CodeBlock/BorderA.cginc"
                col.a *= Fill;
                col *= i.color;
                return col;
            }
            ENDCG
        }
    }

    CustomEditor "ProceduralUIElements.ShaderGUI_UIElement_12B"
}


               