Shader "ProceduralUIElements/UIElement_4E"
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
        [KeywordEnum(Three, Four, Five, Six, Seven, Eight, Nine, Ten)] _NoOfPoints("No Of Points", Float) = 0
        [Toggle(PointsIdentifier)] _PointsIdentifier("Points Identifier", float) = 0
        [Header(P1)]
        [Space(5)]
        _X_1("X", Range(-1.0, 1.0)) = 0.0
        _Y_1("Y", Range(-1.0, 1.0)) = 0.0

        [Header(P2)]
        [Space(5)]
        _X_2("X", Range(-1.0, 1.0)) = 0.0
        _Y_2("Y", Range(-1.0, 1.0)) = 0.0

        [Header(P3)]
        [Space(5)]
        _X_3("X", Range(-1.0, 1.0)) = 0.0
        _Y_3("Y", Range(-1.0, 1.0)) = 0.0

        [Header(P4)]
        [Space(5)]
        _X_4("X", Range(-1.0, 1.0)) = 0.0
        _Y_4("Y", Range(-1.0, 1.0)) = 0.0

        [Header(P5)]
        [Space(5)]
        _X_5("X", Range(-1.0, 1.0)) = 0.0
        _Y_5("Y", Range(-1.0, 1.0)) = 0.0

        [Header(P6)]
        [Space(5)]
        _X_6("X", Range(-1.0, 1.0)) = 0.0
        _Y_6("Y", Range(-1.0, 1.0)) = 0.0

        [Header(P7)]
        [Space(5)]
        _X_7("X", Range(-1.0, 1.0)) = 0.0
        _Y_7("Y", Range(-1.0, 1.0)) = 0.0

        [Header(P8)]
        [Space(5)]
        _X_8("X", Range(-1.0, 1.0)) = 0.0
        _Y_8("Y", Range(-1.0, 1.0)) = 0.0

        [Header(P9)]
        [Space(5)]
        _X_9("X", Range(-1.0, 1.0)) = 0.0
        _Y_9("Y", Range(-1.0, 1.0)) = 0.0

        [Header(P10)]
        [Space(5)]
        _X_10("X", Range(-1.0, 1.0)) = 0.0
        _Y_10("Y", Range(-1.0, 1.0)) = 0.0


        [Space(20)]
        _CornerRoundness("Corner Roundness", Range(0.00,0.25)) = 0.01
        [Toggle(EnableRim)] _EnableRim("Enable Rim", float) = 0
        _RimWidth("Rim Width", Range(0.0, 0.1)) = 0.02
        _EdgeBlur("Edge Blur", Range(0.0,0.2)) = 0.05


        ///
        ///  Mask Color
        /// 


        [Space(20)]
        [Toggle(EnableMaskColor)] _EnableMaskColor("Mask Color", float) = 0


        /// 
        ///  Reflection
        /// 


        [Space(20)]
        _Color("Reflection Layer Color", Color) = (1.0, 1.0, 1.0, 1)
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
            #include "../CodeBlock/Variables_4.cginc"
            #include "../CodeBlock/Variables_ReflectionA.cginc"
            float _EnableMaskColor;
            float4 _MaskColor;

            fixed4 frag(v2f i) : SV_Target
            {
                #include "../CodeBlock/SizeRatioA.cginc"
                #include "../CodeBlock/ReflectionA.cginc"
                #include "../CodeBlock/CodeBlock_4.cginc"
                float MaskSDF = PolygonSDF(UV, Points, _NoOfPoints + 3) - _CornerRoundness;
                #include "../CodeBlock/ReflectionASub.cginc"

                #include "../CodeBlock/PointsIdentifier.cginc"

                col *= i.color;
                return col;
            }
            ENDCG
        }
    }

   CustomEditor "ProceduralUIElements.ShaderGUI_UIElement_4E"
}
