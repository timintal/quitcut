Shader "ProceduralUIElements/UIElement_20D"
{
    Properties
    {
        [Space(15)]
        _ImageSizeRatio("Image Size Ratio", Vector) = (1.0, 1.0, 0.0, 0.0)


        /// 
        ///  Shape Properties
        /// 

        [Space(20)]
        [KeywordEnum(Two, Three, Four, Five, Six)] _NoOfShapes("No Of Shapes", Float) = 0
        [Toggle(ShapeIdentifier)] _ShapeIdentifier("Shape Identifier", float) = 0
        [Header(Shape 1)]
        [Space(5)]
        [KeywordEnum(Circle, Rectangle)] _SelectShape_1("Select Shape", Float) = 0
        _Radius_1("Radius", Range(0.0, 0.5)) = 0.2
        _Width_1("Width", Range(0.0, 2.0)) = 0.2
        _Height_1("Height", Range(0.0, 0.5)) = 0.2
        _CornerRoundness_1("Corner Roundness", Range(0.0, 0.5)) = 0.01
        _Rotation_1("Rotation", Range(0.0, 360)) = 0.0
        _X_1("X Offset", Range(-1.0, 1.0)) = 0.0
        _Y_1("Y Offset", Range(-1.0, 1.0)) = 0.0


        [Header(Shape 2)]
        [Space(5)]
        [KeywordEnum(Circle, Rectangle)] _SelectShape_2("Select Shape", Float) = 0
        _Radius_2("Radius", Range(0.0, 0.5)) = 0.2
        _Width_2("Width", Range(0.0, 1.0)) = 0.2
        _Height_2("Height", Range(0.0, 0.5)) = 0.2
        _CornerRoundness_2("Corner Roundness", Range(0.0, 0.5)) = 0.01
        _Rotation_2("Rotation", Range(0.0, 360)) = 0.0
        _X_2("X Offset", Range(-1.0, 1.0)) = 0.0
        _Y_2("Y Offset", Range(-1.0, 1.0)) = 0.0

        [Header(Shape 3)]
        [Space(5)]
        [KeywordEnum(Circle, Rectangle)] _SelectShape_3("Select Shape", Float) = 0
        _Radius_3("Radius", Range(0.0, 0.5)) = 0.2
        _Width_3("Width", Range(0.0, 0.5)) = 0.2
        _Height_3("Height", Range(0.0, 0.5)) = 0.2
        _CornerRoundness_3("Corner Roundness", Range(0.0, 0.5)) = 0.01
        _Rotation_3("Rotation", Range(0.0, 360)) = 0.0
        _X_3("X Offset", Range(-1.0, 1.0)) = 0.0
        _Y_3("Y Offset", Range(-1.0, 1.0)) = 0.0

        [Header(Shape 4)]
        [Space(5)]
        [KeywordEnum(Circle, Rectangle)] _SelectShape_4("Select Shape", Float) = 0
        _Radius_4("Radius", Range(0.0, 0.5)) = 0.2
        _Width_4("Width", Range(0.0, 0.5)) = 0.2
        _Height_4("Height", Range(0.0, 0.5)) = 0.2
        _CornerRoundness_4("Corner Roundness", Range(0.0, 0.5)) = 0.01
        _Rotation_4("Rotation", Range(0.0, 360)) = 0.2
        _X_4("X Offset", Range(-1.0, 1.0)) = 0.0
        _Y_4("Y Offset", Range(-1.0, 1.0)) = 0.0

        [Header(Shape 5)]
        [Space(5)]
        [KeywordEnum(Circle, Rectangle)] _SelectShape_5("Select Shape", Float) = 0
        _Radius_5("Radius", Range(0.0, 0.5)) = 0.2
        _Width_5("Width", Range(0.0, 0.5)) = 0.2
        _Height_5("Height", Range(0.0, 0.5)) = 0.2
        _CornerRoundness_5("Corner Roundness", Range(0.0, 0.5)) = 0.01
        _Rotation_5("Rotation", Range(0.0, 360)) = 0.0
        _X_5("X Offset", Range(-2.0, 2.0)) = 0.0
        _Y_5("Y Offset", Range(-2.0, 2.0)) = 0.0

        [Header(Shape 6)]
        [Space(5)]
        [KeywordEnum(Circle, Rectangle)] _SelectShape_6("Select Shape", Float) = 0
        _Radius_6("Radius", Range(0.0, 0.5)) = 0.2
        _Width_6("Width", Range(0.0, 0.5)) = 0.2
        _Height_6("Height", Range(0.0, 0.5)) = 0.2
        _CornerRoundness_6("Corner Roundness", Range(0.0, 0.5)) = 0.01
        _Rotation_6("Rotation", Range(0.0, 360)) = 0.0
        _X_6("X Offset", Range(-2.0, 2.0)) = 0.0
        _Y_6("Y Offset", Range(-2.0, 2.0)) = 0.0



        [Space(20)]
        [Toggle(EnableRim)] _EnableRim("Enable Rim", float) = 0
        _RimWidth("Rim Width", Range(0.0, 0.1)) = 0.02
        _RimGamma("Rim Gamma", Range(0.0, 1.5)) = 1.0


        [Space(20)]
        _SmoothBlend("SmoothBlend", Range(0.0, 0.5)) = 0.05


        [Space(20)]
        _EdgeBlur("Edge Blur", Range(0.0, 0.1)) = 0.05


        /// 
        ///  Color Mode
        /// 


        [Space(20)]
        [Toggle(EnableColor)] _EnableColor("Enable Color", float) = 1
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
        _RadialScale("Radial Scale", Range(0.0, 1.0)) = 1.0
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
        ///  Texture Overlay
        /// 


        [Space(20)]
        [Toggle(TextureOverlay)] _EnableTextureOverlay("Enable Texture Overlay", float) = 0
        _TextureOverlay("Overlay Texture", 2D) = "white" {}
        _TextureOverlayOpacity("Opacity", Range(0.0, 1.0)) = 1.0
        [Toggle(TextureOverlayClipping)] _TextureOverlayClipping("Clipping", float) = 0
        _TextureOverlayScale("Scale", Range(0.1, 2.5)) = 1.0
        _TextureOverlayRotation("Rotation", Range(0.0, 360)) = 0.0
        _TextureOverlayOffsetX("X Offset", Range(-0.5, 0.5)) = 0.0
        _TextureOverlayOffsetY("Y Offset", Range(-0.5, 0.5)) = 0.0


        ///
        ///  Lines Overlay
        /// 


        [Space(20)]
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
        _A1("A1", Range(0.0, 1.0)) = 0.6
        _A2("A2", Range(0.0, 1.0)) = 0.4
        _A3("A3", Range(0.0, 2.0)) = 0.2
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


        ///
        ///  Inner Shadow
        /// 


        [Space(20)]
        [Toggle(EnableInnerShadow)] _EnableInnerShadow("Enable Inner Shadow", float) = 0
        _InnerShadowSize("Size", Range(0, 0.5)) = 0.3
        _InnerShadowSpread("Spread", Range(0, 5.0)) = 3.0
        _InnerShadowGamma("Gamma", Range(0, 3.0)) = 1.0
        _InnerShadowXOffset("Offset X", Range(-0.2, 0.2)) = 0.0
        _InnerShadowYOffset("Offset Y", Range(-0.2, 0.2)) = 0.0
        _InnerShadowOpacity("Opacity", Range(0, 3.0)) = 0.25
        [KeywordEnum(Color, Gradient)] _InnerShadowColorMode("Color Mode", Float) = 0
        [KeywordEnum(A, B)] _InnerShadowGradientType("Gradient Type", Float) = 0
        _InnerShadowColor("Color", Color) = (0.0, 0.0, 0.0, 1.0)
        _InnerShadowColorX("Color A", Color) = (0.0, 0.0, 0.0, 1.0)
        _InnerShadowColorY("Color B", Color) = (0.0, 0.0, 0.0, 1.0)
        _InnerShadowGradientAngle("Gradient Angle", Range(0, 360)) = 0
        _InnerShadowGradientScale("Gradient Scale", Range(0.0, 2.0)) = 0.5


        ///
        ///  Drop Shadow
        ///


        [Space(20)]
        [Toggle(EnableDropShadow)] _EnableDropShadow("Enable Drop Shadow", float) = 0
        _DropShadowSize("Size", Range(-0.2, 0.2)) = 0.0
        _DropShadowSpread("Spread", Range(0.0, 1.0)) = 0.35
        _DropShadowGamma("Gamma", Range(0.0, 6.0)) = 1.0
        _DropShadowXOffset("Offset X", Range(-0.1, 0.1)) = 0.0
        _DropShadowYOffset("Offset Y", Range(-0.1, 0.1)) = 0.0
        _DropShadowOpacity("Opacity", Range(0.0, 1.0)) = 1.0
        [KeywordEnum(Color, Gradient)] _DropShadowColorMode("Color Mode", Float) = 0
        [KeywordEnum(2 Color, 3 Color, 4 Color)] _DropShadowGradientMode("Gradient Mode", Float) = 0
        _DropShadowColor("Shadow Color", Color) = (0.45, 0.45, 0.45, 1)
        _ColorE("Gradient Color A", Color) = (0.45, 0.45, 0.45, 1.0)
        _ColorF("Gradient Color B", Color) = (0.45, 0.45, 0.45, 1.0)
        _ColorG("Gradient Color C", Color) = (0.45, 0.45, 0.45, 1.0)
        _ColorH("Gradient Color D", Color) = (0.45, 0.45, 0.45, 1.0)
        _DropShadowGradientAngle("Gradient Angle", Range(0, 360)) = 0
        _DropShadowGradientScale("Gradient Scale", Range(0.0, 2.0)) = 0.5



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
        ///  Drop Shadow
        /// 


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "../CodeBlock/BaseFilesB.cginc"
            #include "../Functions/GradientA.cginc"
            #include "../CodeBlock/Variables_20.cginc"
            #include "../CodeBlock/Variables_DropShadowA.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableDropShadow == 0)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                UV = UV - float2(_DropShadowXOffset, _DropShadowYOffset);
                float SDF=0;
                #include "../CodeBlock/CodeBlock_20.cginc"
                float Rim = 1;
                #include "../CodeBlock/DropShadowA.cginc"
                col *= i.color;
                return col;
            }
            ENDCG
        }


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
            #include "../CodeBlock/Variables_20.cginc"
            #include "../CodeBlock/Variables_ColorModeA.cginc"
            float _EnableColor;

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableColor == 0)
                    return 0;

                float Rim = _EnableRim==1?_RimWidth:1;
                #include "../CodeBlock/SizeRatioA.cginc"
                float SDF=0;
                #include "../CodeBlock/CodeBlock_20.cginc"
                #include "../CodeBlock/ColorModeA.cginc"
                col = SelectedColor;
                #include "../CodeBlock/RimSDFBlock.cginc"
                #include "/Identifier.cginc"
                col *= i.color;
                return col;
            }
            ENDCG
        }


        /// 
        ///  Texture Overlay
        ///


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "../CodeBlock/BaseFilesB.cginc"
            #include "../CodeBlock/Variables_20.cginc"
            #include "../CodeBlock/Variables_TextureOverlayA.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableTextureOverlay == 0)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                float SDF=0;
                #include "../CodeBlock/CodeBlock_20.cginc"
                if (_EnableRim == 1)
                {
                    SDF = abs(SDF) - _RimWidth;
                }
                #include "../CodeBlock/TextureOverlayA.cginc"
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
            #include "../CodeBlock/Variables_20.cginc"
            #include "../CodeBlock/Variables_LinesA.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableLines == 0)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                float SDF=0;
                #include "../CodeBlock/CodeBlock_20.cginc"
                if (_EnableRim == 1)
                {
                    SDF = abs(SDF) - _RimWidth;
                }
                #include "../CodeBlock/LinesA.cginc"
                col.a *= smoothstep(_EdgeBlur, 0, SDF);
                col *= i.color;
                return col;
            }
            ENDCG
        }


        /// 
        ///  Inner Shadow
        /// 


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "../CodeBlock/BaseFilesB.cginc"
            #include "../Functions/GradientA.cginc"
            #include "../CodeBlock/Variables_20.cginc"
            #include "../CodeBlock/Variables_InnerShadowB.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableInnerShadow == 0)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                float SDF=0;
                #include "../CodeBlock/CodeBlock_20.cginc"
                float MaskSDF = SDF;
                float2 ShadowUV = UV - float2(_InnerShadowXOffset, _InnerShadowYOffset);
                UV = UV - float2(_InnerShadowXOffset, _InnerShadowYOffset);
                #include "../CodeBlock/CodeBlock_20.cginc"
                float ShadowSDF = SDF;
                if(_EnableRim==1)
                {
                    MaskSDF = abs(MaskSDF) - _RimWidth;
                    ShadowSDF = abs(ShadowSDF) - _RimWidth;
                }  
                #include "../CodeBlock/InnerShadowB.cginc"
                col.a *= smoothstep(_EdgeBlur, 0, MaskSDF);
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
            #include "../CodeBlock/Variables_20.cginc"
            #include "../CodeBlock/Variables_BorderA.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableBorder == 0)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                float SDF=0;
                #include "../CodeBlock/CodeBlock_20.cginc"
                if (_EnableRim == 1)
                {
                    SDF = abs(SDF) - _RimWidth;
                }
                #include "../CodeBlock/BorderA.cginc"
                col *= i.color;
                return col;
            }
            ENDCG
        }

    }

    CustomEditor "ProceduralUIElements.ShaderGUI_UIElement_20D"
}

