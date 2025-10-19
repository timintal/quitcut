Shader "ProceduralUIElements/UIElement_6E"
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
        _Size("Size", Range(0.0, 12.0)) = 5.0
        //
        [Toggle(EnableRim)] _EnableRim("Enable Rim", float) = 0
        _RimWidth("Rim Width", Range(0.0, 0.3)) = 0.02
        //
        _EdgeBlur("Edge Blur", Range(0.0, 1.0)) = 0.25


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
        _CircleRadius("Radius", Range(0.0, 3.0)) = 0.3
        _CircleBlur("Boundary Blur", Range(0.0, 0.1)) = 0.01
        _CircleXOffset("X Offset", Range(-1.0, 1.0)) = 0.0
        _CircleYOffset("Y Offset", Range(-1.0, 1.0)) = 0.0
        //
        _CircleYScale("Y Scale", Range(0.0, 5.0)) = 0.0
        _CircleYBend("Y Bend", Range(0.0, 5.0)) = 0.0
        _CircleRotation("Rotation", Range(0.0, 360.0)) = 0.0
        //
        [KeywordEnum(Single, Double)] _ChooseLineMode("Line Mode", Float) = 0
        _LineWidth("Line Width", Range(0.0, 0.5)) = 0.025
        _LineWidthA("Line A Width", Range(0.0, 0.2)) = 0.05
        _LineWidthB("Line B Width", Range(0.0, 0.2)) = 0.1
        _LinesSeparation("Separation", Range(0.0, 0.2)) = 0.05
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
        [IntRange]_Frequency("Delay", Range(0.0, 10.0)) = 1.0

        


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
            #include "../CodeBlock/Variables_6.cginc"
            #include "../CodeBlock/Variables_ReflectionA.cginc"
            float _EnableMaskColor;
            float4 _MaskColor;

            fixed4 frag(v2f i) : SV_Target
            {
                #include "../CodeBlock/SizeRatioA.cginc"
                #include "../CodeBlock/ReflectionA.cginc"
                float MaskSDF = HeartSDF_Custom(UV * (12 - _Size));
                #include "../CodeBlock/ReflectionASub.cginc"
                col *= i.color;
                return col;
            }
            ENDCG
        }
    }

    CustomEditor "ProceduralUIElements.ShaderGUI_UIElement_6E"
}
