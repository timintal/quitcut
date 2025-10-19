Shader "ProceduralUIElements/UIElement_14F"
{
    Properties
    {
        [Space(20)]
        _ImageSizeRatio("Image Size Ratio", Vector) = (1.0, 1.0, 0.0, 0.0)


        /// 
        ///  Container Shape Properties
        /// 


        [Space(20)]
        [KeywordEnum(Circle, Rectangle, Texture Mask, None)] _MaskContainer("Select Container(Mask)", Float) = 0
        //
        _CircleRadius("Circle Radius", Range(0.00,0.45)) = 0.3
        //
        [KeywordEnum(Percentage, Margin)] _ChooseDimensionParameters("Choose Dimension Parameters", Float) = 0
        _Width("Width %", Range(0.0, 1.0)) = 0.5
        _Height("Height %", Range(0.0, 1.0)) = 0.5
        _WidthMargin("Width Margin", Float) = 20
        _HeightMargin("Height Margin", Float) = 20
        //
        _CornerRoundness("Corner Roundness", Range(0.0,0.25)) = 0.01
        _ContainerEdgeBlur("Edge Blur", Range(0.0, 0.05)) = 0.01
        //
        _MainTex("Texture (Mask)", 2D) = "white" {}

        /// 
        ///  Grid Properties
        /// 


        [Space(20)]
        _GridSize ("Grid Size", Range(0,50)) = 5.0
        //
        _LineWidth("Line Width", Range(0.0, 0.25)) = 0.05
        _Blur("Edge Blur", Range(0.0, 1.0)) = 0.5
        _Gamma("Gamma", Range(0.0, 1.0)) = 0.5
        //
        _Rotate("Rotate", Range(0.0, 360.0)) = 0.0
        _Twist("Twist", Range(-90, 90.0)) = 0.0
        //
        _Opacity("Opacity", Range(0.0, 1.0)) = 0.5


        /// 
        ///  Distortion
        /// 
        

        [Space(30)]
        [Toggle(EnableDistortion)] _EnableDistortion("Enable Distortion", float) = 0
        _DistortionTexture("Distortion Texture", 2D) = "white" {}
        _DistortionTextureScale("Distortion Texture Scale", Range(0.0, 10.0)) = 0.5
        _DistortionIntensity("Distortion Intensity", Range(0.0, 5.0)) = 0.5
        _AnimateDistortion("Animate Distortion", Vector) = (0.0, 0.0, 0.0, 0.0)


        /// 
        ///  Color Mode
        /// 


        [Space(20)]
        [KeywordEnum(Color, RadialGradient, LinearGradient, SharpBoundary)] _ColorMode("Color Mode", Float) = 0
        _Color("Color", Color) = (1.0, 1.0, 1.0, 1)
        //
        [Toggle(ToonGradient)] _EnableToonGradient("Enable Toon Gradient", float) = 0
        _StepsToonGradient("Number Of Steps", Range(0.0, 20.0)) = 4.0
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
        _GradientAngle("Angle", Range(0, 360)) = 0
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
                #include "/ColorMode.cginc"
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
                #include "/InnerShadow.cginc"
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
                #include "/Border.cginc"
                ENDCG
            }
    }

    CustomEditor "ProceduralUIElements.ShaderGUI_UIElement_14F"
}
