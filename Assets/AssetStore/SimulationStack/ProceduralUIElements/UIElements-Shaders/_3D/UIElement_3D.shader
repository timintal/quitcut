Shader "ProceduralUIElements/UIElement_3D"
{
    Properties
    {
        [Space(20)]
        _ImageSizeRatio("Image Size Ratio", Vector) = (1.0, 1.0, 0.0, 0.0)


        /// 
        ///  Shape Propertiess
        /// 


        [Space(20)]
        _Size ("Size", Range(0.01, 0.6)) = 0.2
        [IntRange]_Turns("Turns", Range(0,12)) = 5
        _EdgeAngle ("EdgeAngle", Range(1.2,9)) = 3
        //
        _CornerRoundness ("Corner Roundness", Range(0.00,0.25)) = 0.01
        //
        [Toggle(EnableRim)] _EnableRim("Enable Rim", float) = 0
        _RimWidth("Rim Width", Range(0.0, 0.1)) = 0.02
        _RimGamma("Rim Gamma", Range(0.0, 2.0)) = 1.0
        //
        _EdgeBlur ("Edge Blur", Range(0.001,0.05)) = 0.025
        //
        _Rotation("Rotate", Range(0.0, 360)) = 0.0


        /// 
        ///  Fill
        /// 


        [Space(20)]
        [Toggle(EnableFill)] _EnableFill("Enable Fill", float) = 0
        [KeywordEnum(Linear, Clockwise, AntiClockWise)] _FillMode("Fill Mode", Float) = 0
        _FillAmount("Fill", Range(0.0001, 1.0)) = 1.0
        _FillAngle("Fill Angle", Range(0.0, 360.0)) = 0.0


        /// 
        ///  Displace Shape
        /// 

            
        [Space(20)]
        [Toggle(EnableDisplaceShape)] _EnableDisplaceShape("Displace Shape Layer", float) = 0
        _BGColor("BG Color", Color) = (1.0, 1.0, 1.0, 1)
        _DisplaceShapeEdgeBlur("Displace Shape Edge Blur", Range(0.001,0.05)) = 0.001
        _ShapeOffsetX("X Offset", Range(-0.5, 0.5)) = 0.0
        _ShapeOffsetY("Y Offset", Range(-0.5, 0.5)) = 0.0


        /// 
        /// Color Mode
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
        ///  Texture Overlay
        /// 


        [Space(20)]
        [Toggle(TextureOverlay)] _EnableTextureOverlay("Enable Texture Overlay", float) = 0
        _TextureOverlay("Overlay Texture", 2D) = "white" {}
        [Toggle(TextureOverlayClipping)] _TextureOverlayClipping("Clipping", float) = 0
        _TextureOverlayOpacity("Opacity", Range(0.0, 1.0)) = 1.0
        _TextureOverlayScale("Scale", Range(0.1, 2.5)) = 1.0
        _TextureOverlayRotation("Rotation", Range(0.0, 360)) = 0.0
        _TextureOverlayOffsetX("X Offset", Range(-0.5, 0.5)) = 0.0
        _TextureOverlayOffsetY("Y Offset", Range(-0.5, 0.5)) = 0.0


        ///
        /// Lines Overlay
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
            #include "../CodeBlock/Variables_3.cginc"
            #include "../CodeBlock/Variables_DropShadowA.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableDropShadow == 0)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                UV = UV - float2(_DropShadowXOffset, _DropShadowYOffset);
                UV = RotateXY(UV, _Rotation);
                float SDF = StarSDF(UV, _Size , _Turns, _EdgeAngle) - _CornerRoundness;
                float Rim = _EnableRim;
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
            #include "../CodeBlock/Variables_3.cginc"
            #include "../CodeBlock/Variables_FillA.cginc"
            float _EnableDisplaceShape;
            fixed4 _BGColor;
            float _DisplaceShapeEdgeBlur;
            float _ShapeOffsetX;
            float _ShapeOffsetY;
            #include "../CodeBlock/Variables_ColorModeA.cginc"
            float _EnableColor;
 
            fixed4 frag(v2f i) : SV_Target
            {
                if(_EnableColor==0)
                    return 0;

                float Rim = _EnableRim==1?_RimWidth:1;
                #include "../CodeBlock/SizeRatioA.cginc"
                UV = RotateXY(UV, _Rotation);
                float SDF = StarSDF(UV, _Size, _Turns, _EdgeAngle) - _CornerRoundness;
                #include "../CodeBlock/FillA.cginc"
                #include "../CodeBlock/ColorModeA.cginc"
                float DisplaceShapeSDF=StarSDF(UV - float2(_ShapeOffsetX, _ShapeOffsetY), _Size, _Turns, _EdgeAngle) - _CornerRoundness;
                col = (_EnableDisplaceShape == 0) ? SelectedColor : lerp(_BGColor, SelectedColor, smoothstep(_DisplaceShapeEdgeBlur, 0, DisplaceShapeSDF));
                #include "../CodeBlock/RimSDFBlock.cginc"                
                col.a *= FillAmount;
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
            #include "../CodeBlock/Variables_3.cginc"
            #include "../CodeBlock/Variables_FillA.cginc"
            #include "../CodeBlock/Variables_TextureOverlayA.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableTextureOverlay == 0)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                UV = RotateXY(UV, _Rotation);
                float SDF = StarSDF(UV, _Size, _Turns, _EdgeAngle) - _CornerRoundness;
                #include "../CodeBlock/FillA.cginc"
                if (_EnableRim == 1)
                {
                    SDF = abs(SDF) - _RimWidth;
                }
                #include "../CodeBlock/TextureOverlayA.cginc"
                col.a *= FillAmount;
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
            #include "../CodeBlock/Variables_3.cginc"
            #include "../CodeBlock/Variables_FillA.cginc"
            #include "../CodeBlock/Variables_LinesA.cginc"

             fixed4 frag(v2f i) : SV_Target
             {
                 if (_EnableLines == 0)
                     return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                UV = RotateXY(UV, _Rotation);
                float SDF = StarSDF(UV, _Size, _Turns, _EdgeAngle) - _CornerRoundness;
                #include "../CodeBlock/FillA.cginc"
                if (_EnableRim == 1)
                {
                    SDF = abs(SDF) - _RimWidth;
                }
                #include "../CodeBlock/LinesA.cginc"
                col.a *= smoothstep(_EdgeBlur, 0, SDF);
                col.a *=  FillAmount;
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
            #include "../CodeBlock/Variables_3.cginc"
            #include "../CodeBlock/Variables_InnerShadowB.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableInnerShadow == 0)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                float2 ShadowUV = UV - float2(_InnerShadowXOffset, _InnerShadowYOffset);
                float SDF = StarSDF(RotateXY(UV,_Rotation), _Size, _Turns, _EdgeAngle) - _CornerRoundness;
                float ShadowSDF = StarSDF(RotateXY(ShadowUV, _Rotation), _Size, _Turns, _EdgeAngle) - _CornerRoundness;
                if(_EnableRim==1)
                {
                    SDF = abs(SDF) - _RimWidth;
                    ShadowSDF = abs(ShadowSDF) - _RimWidth;
                }  
                #include "../CodeBlock/InnerShadowB.cginc"
                col.a *= smoothstep(_EdgeBlur, 0, SDF);
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
            #include "../CodeBlock/Variables_3.cginc"
            #include "../CodeBlock/Variables_BorderA.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableBorder == 0)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                UV = RotateXY(UV, _Rotation);
                float SDF = StarSDF(UV, _Size, _Turns, _EdgeAngle) - _CornerRoundness;
                if(_EnableRim==1)
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

    CustomEditor "ProceduralUIElements.ShaderGUI_UIElement_3D"
}

