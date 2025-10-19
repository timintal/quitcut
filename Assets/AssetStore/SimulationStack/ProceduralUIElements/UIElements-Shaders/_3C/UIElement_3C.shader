Shader "ProceduralUIElements/UIElement_3C"
{
    Properties
    {
        [Space(20)]
        _ImageSizeRatio("Image Size Ratio", Vector) = (1.0, 1.0, 0.0, 0.0)


        /// 
        ///  Shape Properties
        /// 


        [Space(20)]
        _Size ("Size", Range(0.01,0.5)) = 0.25
        _Turns ("Turns", Range(0,12)) = 5
        _EdgeAngle ("Edge Angle", Range(0.0, 10.0)) = 3.0
        //
        _CornerRoundness("Roundness", Range(0.0, 0.1)) = 0.01
        //
        [Toggle(EnableRim)] _EnableRim("Enable Rim", float) = 0
        _RimWidth("Rim Width", Range(0.0, 0.1)) = 0.02
        _RimGamma("Rim Gamma", Range(0.0, 1.5)) = 1.0
        //
        _EdgeBlur("Edge Blur", Range(0.001,0.15)) = 0.05


        /// 
        ///  Fill
        /// 


        [Space(20)]
        [Toggle(EnableFill)] _EnableFill("Enable Fill", float) = 0
        [KeywordEnum(Linear, Clockwise, AntiClockWise)] _FillMode("Fill Mode", Float) = 0
        _FillAmount("Fill Amount", Range(0.0, 1.0)) = 1.0
        _FillAngle("Angle", Range(0.0, 360.0)) = 0.0

            
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
        /// Drop Shadow
        ///


        [Space(20)]
        [Toggle(EnableDropShadow)] _EnableDropShadow("Enable Drop Shadow", float) = 0
        _DropShadowSize("Size", Range(-0.2, 0.2)) = 0.0
        _DropShadowSpread("Spread", Range(0.0, 1.0)) = 0.35
        _DropShadowGamma("Gamma", Range(0.0, 6.0)) = 1.0
        _DropShadowXOffset("Offset X", Range(-0.1, 0.1)) = 0.0
        _DropShadowYOffset("Offset Y", Range(-0.1, 0.1)) = 0.0
        _DropShadowOpacity("Opacity", Range(0.0, 3.0)) = 1.0
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
        ///  Drop Shadow Pass
        /// 

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "/DropShadow.cginc"
            ENDCG
        }

        /// 
        ///  Color Mode Pass
        /// 

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "/ColorMode.cginc"
            ENDCG
        }
    }

    CustomEditor "ProceduralUIElements.ShaderGUI_UIElement_3C"
}
