Shader "ProceduralUIElements/UIElement_2B"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}


        [Space(20)]
        _ImageSizeRatio("Image Size Ratio", Vector) = (1.0, 1.0, 0.0, 0.0)


        /// 
        ///  Shape Properties
        /// 


        [Space(20)]
        [KeywordEnum(Percentage, Margin)] _ChooseDimensionParameters("Choose Dimension Parameters", Float) = 0
        _Width("Width %", Range(0.0, 1.0)) = 0.5
        _Height("Height %", Range(0.0, 1.0)) = 0.5
        _WidthMargin("Width Margin", Float) = 20
        _HeightMargin("Height Margin", Float) = 20
        //
        [KeywordEnum(Symetric, Set Each Corner(Asymetric))] _ChooseRoundnessMode("Roundness Mode", Float) = 0
        _CornerRoundness("Corner Roundness", Range(0.00, 0.50)) = 0.01
        _TopLeftCornerRoundness("Top Left Corner Roundness", Range(0.00, 0.50)) = 0.01
        _TopRightCornerRoundness("Top Right Corner Roundness", Range(0.00, 0.50)) = 0.01
        _BottomRightCornerRoundness("Bottom Right Corner Roundness", Range(0.00, 0.50)) = 0.01
        _BottomLeftCornerRoundness("Bottom Left Corner Roundness", Range(0.00, 0.50)) = 0.01
        //
        [Toggle(EnableRim)] _EnableRim("Enable Rim", float) = 0
        _RimWidth("Rim Width", Range(0.0, 0.1)) = 0.02


        ///
        ///  Bending
        /// 


        [Space(20)]
        [Toggle(Bending)] _EnableBending("Enable Bending", float) = 0
        [Toggle(MirrorBending)] _MirrorBending("Mirror", float) = 0
        _BendX("Bend X", Range(-0.15, 0.15)) = 0.0
        _BendY("Bend Y", Range(-0.15, 0.15)) = 0.0


        /// 
        ///  Fill Width & Height
        /// 


        [Space(20)]
        _WidthFillAmount("Width Fill Amount", Range(0.0, 1.0)) = 1.0
        _HeightFillAmount("Height Fill Amount", Range(0.0, 1.0)) = 1.0


        /// 
        ///  Bloom
        /// 


        [Space(20)]
        _Bloom("Bloom", Range(0, 2.0)) = 0.5
        _BloomGamma("Gamma", Range(0, 0.2)) = 0.05



        /// 
        /// Color Mode
        /// 


        [Space(20)]
        [KeywordEnum(Color, RadialGradient, LinearGradient)] _ColorMode("Color Mode", Float) = 0
        [Toggle(ToonGradient)] _EnableToonGradient("Enable Toon Gradient", float) = 0
        _StepsToonGradient("Number Of Steps", Range(0.0, 20.0)) = 4.0
        _Color("Color", Color) = (1.0, 1.0, 1.0, 1)
        //
        [KeywordEnum(2 Color, 3 Color, 4 Color)] _GradientMode("Gradient Mode", Float) = 0
        _ColorA("Color A", Color) = (1, 0, 0, 1)
        _ColorB("Color B", Color) = (1, 1, 0, 1)
        _ColorC("Color C", Color) = (0, 1, 0, 1)
        _ColorD("Color D", Color) = (0, 0, 1, 1)
        //
        [KeywordEnum(A, B)] _RadialType("Radial Type", Float) = 0
        _RadialScale("Radial Scale", Range(0.0, 2.0)) = 1.0
        _RadialSpread("Radial Spread", Range(0.0, 3.0)) = 1.0
        _RadialGamma("Radial Gamma", Range(0.0, 3.0)) = 1.0
        //
        _GradientAngle("Angle", Range(0, 360)) = 0
        _GradientScale("Gradient Scale", Range(0.0, 2.0)) = 1.0
        //
        _GradientXOffset("Offset X", Range(-0.5, 0.5)) = 0.0
        _GradientYOffset("Offset Y", Range(-0.5, 0.5)) = 0.0




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

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "../CodeBlock/BaseFilesB.cginc"
            #include "../CodeBlock/Variables_2.cginc"
            #include "../CodeBlock/Variables_ColorModeB.cginc"
            float _Bloom, _BloomGamma;

            fixed4 frag(v2f i) : SV_Target
            {
                float Rim = _EnableRim==1?_RimWidth:1;
                #include "../CodeBlock/SizeRatioA.cginc"
                #include "../CodeBlock/CodeBlock_2.cginc"
                #include "../CodeBlock/ColorModeB.cginc"
                col = SelectedColor;
                #include "../CodeBlock/BloomSDFBlock.cginc"
                col *= i.color;
                return col;
            }
            ENDCG
        }
    }

    CustomEditor "ProceduralUIElements.ShaderGUI_UIElement_2B"
}

