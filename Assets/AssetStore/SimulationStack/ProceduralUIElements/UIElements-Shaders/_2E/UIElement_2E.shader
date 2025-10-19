Shader "ProceduralUIElements/UIElement_2E"
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
        _CornerRoundness("Corner Roundness", Range(0.00,0.50)) = 0.01
        _TopLeftCornerRoundness("Top Left Corner Roundness", Range(0.00,0.50)) = 0.01
        _TopRightCornerRoundness("Top Right Corner Roundness", Range(0.00,0.50)) = 0.01
        _BottomRightCornerRoundness("Bottom Right Corner Roundness", Range(0.00,0.50)) = 0.01
        _BottomLeftCornerRoundness("Bottom Left Corner Roundness", Range(0.00,0.50)) = 0.01
        //
        [Toggle(EnableRim)] _EnableRim("Enable Rim", float) = 0
        _RimWidth("Rim Width", Range(0.0, 0.1)) = 0.02
        //
        _EdgeBlur("Edge Blur", Range(0.0, 0.2)) = 0.05


        /// 
        ///  Bending
        /// 


        [Space(20)]
        [Toggle(Bending)] _EnableBending("Enable Bending", float) = 0
        [Toggle(MirrorBending)] _MirrorBending("Mirror", float) = 0
        _BendX("Bend X", Range(-0.5, 0.5)) = 0.0
        _BendY("Bend Y", Range(-0.5, 0.5)) = 0.0


        /// 
        ///  Fill Width & Height
        /// 


        [Space(20)]
        _WidthFillAmount("Width Fill Amount", Range(0.0, 1.0)) = 1.0
        _HeightFillAmount("Height Fill Amount", Range(0.0, 1.0)) = 1.0


        ///
        ///  Mask Color
        /// 


        [Space(20)]
        [Toggle(EnableMaskColor)] _EnableMaskColor("Mask Color", float) = 0


        /// 
        ///  Reflection
        /// 


        [Space(20)]
        _Color("Color", Color) = (1.0, 1.0, 1.0, 1)
        _Opacity("Opacity", Range(0.0, 1.0)) = 1.0
        [Toggle(EnableAlphaGradient)] _EnableAlphaGradient("Enable Opacity Gradient", float) = 0
        _AlphaGradientAngle("Angle", Range(0.0, 360)) = 0.0
        _AlphaGradientScale("Scale", Range(0.0, 3.0)) = 1.0
        _AlphaGradientGamma("Gamma", Range(0.0, 10.0)) = 1.0
        //
        [KeywordEnum(Line, Circle)] _ChooseReflectionShape("Reflection Shape", Float) = 0
        _CircleRadius("Radius", Range(0.0, 5.0)) = 0.3
        _CircleBlur("Boundary Blur", Range(0.0, 1.0)) = 0.01
        _CircleXOffset("X Offset", Range(-1.0, 1.0)) = 0.0
        _CircleYOffset("Y Offset", Range(-1.0, 1.0)) = 0.0
        //
        _CircleYScale("Y Scale", Range(0.0, 5.0)) = 0.0
        _CircleYBend("Y Bend", Range(0.0, 5.0)) = 0.0
        _CircleRotation("Rotation", Range(0.0, 360.0)) = 0.0
        [KeywordEnum(Single, Double)] _ChooseLineMode("Line Mode", Float) = 0
        _LineWidth("Line Width", Range(0.0, 1.0)) = 0.025
        _LineWidthA("Line A Width", Range(0.0, 0.25)) = 0.05
        _LineWidthB("Line B Width", Range(0.0, 0.25)) = 0.1
        _LinesSeparation("Separation", Range(0.0, 0.25)) = 0.05
        _LineEdgeBlur("Edge Blur", Range(0.0, 0.1)) = 0.05
        //
        _Rotate("Rotate", Range(0.0, 360.0)) = 0.0
        _LineOffset("Offset", Range(-1.0, 1.0)) = 0.0
        //
        [Toggle(EnableBend)] _EnableBend("Bend/Curvature", float) = 0
        _Bend("Bend", Range(0.0, 1.5)) = 0.5
        //
        [Toggle(EnableAnimation)] _EnableAnimation("Animation", float) = 0
        _MoveSpeed("Animation Speed", Float) = 0.2
        [IntRange]_Frequency("Delay", Range(0.0, 30.0)) = 1.0





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
            float _EnableMaskColor;
            float4 _MaskColor;
            #include "../CodeBlock/Variables_2.cginc"
            //float _FillAmount;
            #include "../CodeBlock/Variables_ReflectionA.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                #include "../CodeBlock/SizeRatioA.cginc"
                #include "../CodeBlock/BendA.cginc"
                #include "../CodeBlock/RectangleCodeBlock.cginc"
                float4 Roundness = float4(_TopRightCornerRoundness, _BottomRightCornerRoundness, _TopLeftCornerRoundness, _BottomLeftCornerRoundness);//  );
                Roundness = _ChooseRoundnessMode == 0 ? fixed4(1, 1, 1, 1) * _CornerRoundness : Roundness;
                #include "../CodeBlock/ReflectionA.cginc"
                float WidthFill = _WidthFillAmount * _Width;
                float HeightFill = _HeightFillAmount * _Height;
                float MaskSDF = RoundBoxSDFB(UV - float2(WidthFill - _Width, HeightFill - _Height), float2(WidthFill, HeightFill), Roundness);
                #include "../CodeBlock/ReflectionASub.cginc"
                col *= i.color;
                return col;
            }
            ENDCG
        }
    }

    CustomEditor "ProceduralUIElements.ShaderGUI_UIElement_2E"
}
