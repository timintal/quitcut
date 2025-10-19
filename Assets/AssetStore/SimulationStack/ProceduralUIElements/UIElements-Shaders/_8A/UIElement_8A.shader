Shader "ProceduralUIElements/UIElement_8A"
{
    Properties
    {
         [Space(20)]
        _ImageSizeRatio("Image Size Ratio", Vector) = (1.0, 1.0, 0.0, 0.0)


        ///
        ///  Blend Operation
        /// 


        [Space(20)]
        [KeywordEnum(Union, Subtraction)] _ShapeBlendMode("Shape Blend Mode", Float) = 0
        _Blend("Blend", Range(0.0, 1.0)) = 0.1


        /// 
        ///  Shape Properties
        /// 
       

        [KeywordEnum(Circle, Rectangle)] _ChooseShapeA("Choose Shape A", Float) = 0
        _RadiusA("Radius", Range(0.0, 0.5)) = 0.05
        _WidthA("Width", Range(0.0, 2.0)) = 0.1
        _HeightA("Height", Range(0.0, 2.0)) = 0.1
        _CornerRoundnessA("Corner Roundness", Range(0.0, 0.2)) = 0.0
        _RotationA("Rotate", Range(0.0, 360.0)) = 0.0
        _XOffsetA("X Offset", Range(-1.0, 1.0)) = 0.0
        _YOffsetA("Y Offset", Range(-1.0, 1.0)) = 0.0
        //
        [KeywordEnum(Circle, Rectangle)] _ChooseShapeB("Choose Shape B", Float) = 0
        _RadiusB("Radius", Range(0.0, 0.5)) = 0.05
        _WidthB("Width", Range(0.0, 2.0)) = 0.1
        _HeightB("Height", Range(0.0, 2.0)) = 0.1
        _CornerRoundnessB("Corner Roundness", Range(0.0, 0.2)) = 0.0
        _RotationB("Rotate", Range(0.0, 360.0)) = 0.0
        _XOffsetB("X Offset", Range(-1.0, 1.0)) = 0.0
        _YOffsetB("Y Offset", Range(-1.0, 1.0)) = 0.0
        //
        [Space(20)]
        [Toggle(EnableRim)] _EnableRim("Enable Rim", float) = 0
        _RimWidth("Rim Width", Range(0.0, 0.1)) = 0.02
        _RimGamma("Rim Gamma", Range(0.0, 1.5)) = 1.0
        //
        _EdgeBlur("Edge Blur", Range(0.0, 0.2)) = 0.05


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
        _DropShadowGamma("Gamma", Range(0.0, 3.0)) = 1.0
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
            #include "/Variables2.cginc"
            #include "../CodeBlock/Variables_DropShadowA.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableDropShadow == 0)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                UV = UV - float2(_DropShadowXOffset, _DropShadowYOffset);
                float SDF = CalculateSDF(UV);
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
            #include "/Variables2.cginc"
            #include "../CodeBlock/Variables_ColorModeA.cginc"
            float _EnableColor;

            fixed4 frag(v2f i) : SV_Target
            {
                if(_EnableColor==0)
                    return 0;
                float Rim = _EnableRim==1?_RimWidth:1;
                #include "../CodeBlock/SizeRatioA.cginc"
                float SDF = CalculateSDF(UV);
                #include "../CodeBlock/ColorModeA.cginc"
                col = SelectedColor;
                #include "../CodeBlock/RimSDFBlock.cginc"
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
            #include "/Variables2.cginc"
            #include "../CodeBlock/Variables_InnerShadowB.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableInnerShadow == 0)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                float SDF = CalculateSDF(UV);
                SDF = _EnableRim==1?abs(SDF) - _RimWidth:SDF;
                float2 ShadowUV = UV - float2(_InnerShadowXOffset, _InnerShadowYOffset);
                float ShadowSDF = CalculateSDF(ShadowUV);
                ShadowSDF = _EnableRim==1?abs(ShadowSDF) - _RimWidth: ShadowSDF;
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
            #include "/Variables2.cginc"
            #include "../CodeBlock/Variables_BorderA.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableBorder == 0)
                    return 0;
                #include "../CodeBlock/SizeRatioA.cginc"
                float SDF = CalculateSDF(UV);
                SDF = _EnableRim==1?abs(SDF) - _RimWidth:SDF;
                #include "../CodeBlock/BorderA.cginc"
                col *= i.color;
                return col;
            }
            ENDCG
        }
    }

    CustomEditor "ProceduralUIElements.ShaderGUI_UIElement_8A"
}
