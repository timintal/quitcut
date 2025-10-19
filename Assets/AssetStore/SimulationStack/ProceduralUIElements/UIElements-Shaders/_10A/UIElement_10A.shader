Shader "ProceduralUIElements/UIElement_10A"
{
    Properties
    {
        

        [Space(20)]
        _ImageSizeRatio("Image Size Ratio", Vector) = (1.0, 1.0, 1.0, 1.0)


        ///
        ///  Container Shape Properties
        ///


        [Space(20)]
        [KeywordEnum(Circle, Rectangle,Polygone,Heart,Texture,None)] _MaskContainer("Select Container(Mask)", Float) = 0
        //
        _Radius("Circle Radius", Range(0.00,0.50)) = 0.4
        //
        [KeywordEnum(Percentage, Margin)] _ChooseDimensionParameters("Choose Dimension Parameters", Float) = 0
        _Width("Width %", Range(0.0, 1.0)) = 0.5
        _Height("Height %", Range(0.0, 1.0)) = 0.5
        _WidthMargin("Width Margin", Float) = 20
        _HeightMargin("Height Margin", Float) = 20
        //
        _PolygonSize("Size", Range(0.01,0.5)) = 0.25
        [IntRange]_PolygonTurns("Turns", Range(0,12)) = 5
        _PolygonEdgeAngle("Edge Angle", Range(1.2, 8.5)) = 3.0
        //
        _HeartSize("Size", Range(0.01, 12.0)) = 8.0
        //
        _CornerRoundness("Corner Roundness", Range(0.0,0.5)) = 0.01
        _ContainerEdgeBlur("Edge Blur", Range(0.0, 0.05)) = 0.01
        //
        _MainTex("Container Texture", 2D) = "white" {}


        ///
        ///  Bg Color
        /// 


        [Space(20)]
        [Toggle(EnableBG)] _EnableBG("Enabel Background",float) = 0
        _BGColor("Background Color", Color) = (0.0, 0.0, 0.0, 1.0)


        /// 
        ///  WaveA & WaveB Fill
        /// 


        [Space(20)]
        _WaveA_FillAmount("Fill Amount  (Wave A)", Range(0.001, 1.0)) = 0.6
        _WaveB_FillAmount("Fill Amount  (Wave B)", Range(0.001, 1.0)) = 0.4


        ///
        ///  Wave A Properties
        ///


        [Space(20)]
        [Toggle(EnableWaveA)] _EnableWaveA("Enable Wave A", float) = 1
        _WaveAAmplitude("Amplitude", Range(0.0, 0.5)) = 0.12
        _WaveACycles("Cycles", Range(0.0, 10)) = 3.0
        _WaveASpeed("Speed", Range(0.00,20)) = 5.0
        _WaveAPhase("Phase", Range(0.00,20)) = 0.0
        _WaveAEdgeBlur("Edge Blur", Range(0.0, 0.1)) = 0.01
        _WaveAOpacity("Opacity", Range(0.0, 1.0)) = 1.0
        [KeywordEnum(ColorA, GradientA)] _WaveAColorMode("Color Mode", Float) = 1
        _WaveAColor("Color", Color) = (0.5, 0.3, 0.7, 1.0)
        _WaveAColorA("Color A", Color) = (0.70, 0.0, 1.0, 1.0)
        _WaveAColorB("Color B", Color) = (0.40, 0.0, 0.50, 1.0)
        _WaveAGradientAngle("Gradient Angle", Range(0, 360)) = 180
        _WaveAGradientScale("Gradient Scale", Range(0.0, 2.0)) = 0.6
        _WaveAGradientOffset("Gradient Offset", Range(-0.5, 0.5)) = 0


        /// 
        ///  Wave B Properties
        /// 


        [Space(20)]
        [Toggle(EnableWaveB)] _EnableWaveB("Enable Wave B", float) = 0
        _WaveBAmplitude("Amplitude", Range(0.00,1.0)) = 0.16
        _WaveBCycles("Cycles", Range(0.0, 10)) = 2.5
        _WaveBSpeed("Speed", Range(0.00,20)) = 6.0
        _WaveBPhase("Phase", Range(0.00,20)) = 4
        _WaveBEdgeBlur("Edge Blur", Range(0.0, 0.1)) = 0.01
        _WaveBOpacity("Opacity", Range(0.0, 1.0)) = 1.0
        [KeywordEnum(ColorB, GradientB)] _WaveBColorMode("Color Mode", Float) = 0
        _WaveBColor("Color", Color) = (0.0, 0.55, 0.95, 1.0)
        _WaveBColorA("Color A", Color) = (0.50, 0.0, 0.2, 1.0)
        _WaveBColorB("Color B", Color) = (0.3, 0.7, 0.0, 1.0)
        _WaveBGradientAngle("Gradient Angle", Range(0, 360)) = 90
        _WaveBGradientScale("Gradient Scale", Range(0.0, 2.0)) = 0.5
        _WaveBGradientOffset("Gradient Offset", Range(-0.5, 0.5)) = 0


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
        ///  BG Color
        /// 
        

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "../CodeBlock/BaseFilesB.cginc"
            float4 _ImageSizeRatio;
            float _EnableBG;
            fixed4 _BGColor;
            #include "/Variables.cginc"
            float _EnableBorder;

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableBG == 0)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                if(_MaskContainer>=4)
                { 
                    float Clipping = smoothstep(0.5, 0.499, abs(UV.x)) * smoothstep(0.5, 0.499, abs(UV.y));
                    Mask = _MaskContainer==4? tex2D(_MainTex, UV - float2(0.5,0.5)).x * Clipping :1;
                }
                else
                {
                    #include "../CodeBlock/SDF_Containers.cginc"
                    Mask = smoothstep(_ContainerEdgeBlur, 0.0, SDF);
                }
                col = _BGColor;
                col.a*=Mask;
                col *= i.color;
                return col;
            }
            ENDCG
        }


        ///
        ///  Wave A
        ///


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "../CodeBlock/BaseFilesB.cginc"
            #include "../Functions/GradientB.cginc"
            float4 _ImageSizeRatio;
            float _WaveA_FillAmount, _WaveB_FillAmount;
            float _EnableWaveA,_WaveAAmplitude, _WaveACycles, _WaveASpeed, _WaveAPhase, _WaveAEdgeBlur;
            float _WaveAColorMode;
            fixed4 _WaveAColor;
            float _WaveAOpacity;
            fixed4 _WaveAColorA, _WaveAColorB;
            float _WaveAGradientAngle, _WaveAGradientScale, _WaveAGradientOffset;
            #include "/Variables.cginc"
            float _EnableBorder;

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableWaveA == 0) return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                if(_MaskContainer>=4)
                { 
                    float Clipping = smoothstep(0.5, 0.499, abs(UV.x)) * smoothstep(0.5, 0.499, abs(UV.y));
                    Mask = _MaskContainer==4? tex2D(_MainTex, UV - float2(0.5,0.5)).x * Clipping :1;
                }
                else
                {
                    #include "../CodeBlock/SDF_Containers.cginc"
                    Mask = smoothstep(_ContainerEdgeBlur, 0.0, SDF);
                }

                float2 WaveAUV = UV + float2(0.5 , 0.5);
                WaveAUV.y += sin(WaveAUV.x * _WaveACycles + _Time.y * _WaveASpeed + _WaveAPhase) * _WaveAAmplitude;
                float4 GradientColor = TwoColorGradient(WaveAUV - float2(0.5, 0.5), _WaveAGradientAngle, _WaveAColorA, _WaveAColorB, _WaveAGradientScale, 1, _WaveAGradientOffset);
                col = _WaveAColorMode == 1 ? GradientColor : _WaveAColor;
                col.a = smoothstep(_WaveA_FillAmount, _WaveA_FillAmount * (0.99 - _WaveAEdgeBlur), WaveAUV.y) * _WaveAOpacity * Mask;
                col *= i.color;
                return col;
            }
            ENDCG
        }


        ///
        ///  Wave B
        ///


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "../CodeBlock/BaseFilesB.cginc"
            #include "../Functions/GradientB.cginc"
            float _EnableWaveB;
            float4 _ImageSizeRatio;
            float _WaveA_FillAmount, _WaveB_FillAmount;
            float _WaveBAmplitude, _WaveBCycles, _WaveBSpeed, _WaveBPhase, _WaveBEdgeBlur;
            float _WaveBColorMode;
            fixed4 _WaveBColor;
            float _WaveBOpacity;
            fixed4 _WaveBColorA, _WaveBColorB;
            float _WaveBGradientAngle, _WaveBGradientScale, _WaveBGradientOffset;
            #include "/Variables.cginc"
            float _EnableBorder;

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableWaveB == 0) return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                if(_MaskContainer>=4)
                { 
                    float Clipping = smoothstep(0.5, 0.499, abs(UV.x)) * smoothstep(0.5, 0.499, abs(UV.y));
                    Mask = _MaskContainer==4? tex2D(_MainTex, UV - float2(0.5,0.5)).x * Clipping :1;
                }
                else
                {
                    #include "../CodeBlock/SDF_Containers.cginc"
                    Mask = smoothstep(_ContainerEdgeBlur, 0.0, SDF);
                }

                float2 WaveUV = UV + float2(0.5, 0.5);
                WaveUV.y += sin(WaveUV.x * _WaveBCycles + _Time.y * _WaveBSpeed + _WaveBPhase) * _WaveBAmplitude;
                fixed4 GradientColor = TwoColorGradient(WaveUV - float2(0.5, 0.5), _WaveBGradientAngle, _WaveBColorA, _WaveBColorB, _WaveBGradientScale, 1, _WaveBGradientOffset);
                col = _WaveBColorMode == 1 ? GradientColor : _WaveBColor;
                col.a = smoothstep(_WaveB_FillAmount, _WaveB_FillAmount * (0.99 - _WaveBEdgeBlur), WaveUV.y) * _WaveBOpacity * Mask;
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
            #include "../Functions/GradientB.cginc"
            float4 _ImageSizeRatio;
            #include "/Variables.cginc"
            #include "../CodeBlock/Variables_InnerShadowB.cginc"
            float _EnableBorder;

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableInnerShadow == 0 || _MaskContainer>=4)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                #include "../CodeBlock/SDF_Containers.cginc"
                float2 ShadowUV = UV - float2(_InnerShadowXOffset, _InnerShadowYOffset);
                float ShadowSDF = 0;
                if (_MaskContainer == 0)
                {
                    ShadowSDF = length(ShadowUV) - _Radius;
                }
                else if (_MaskContainer == 1)
                {
                    ShadowSDF = RoundBoxSDF(ShadowUV, float2(_Width, _Height), _CornerRoundness);
                }
                else if (_MaskContainer == 2)
                {
                    ShadowSDF = StarSDF(ShadowUV, _PolygonSize, _PolygonTurns, _PolygonEdgeAngle) - _CornerRoundness;
                }
                else if (_MaskContainer == 3)
                {
                    ShadowSDF = HeartSDF_Custom(ShadowUV * (12 - _HeartSize));
                }

                #include "../CodeBlock/InnerShadowB.cginc"
                col.a *= smoothstep(_ContainerEdgeBlur, 0, SDF);
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
            float4 _ImageSizeRatio;
            #include "/Variables.cginc"
            #include "../CodeBlock/Variables_BorderA.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableBorder == 0 || _MaskContainer >= 4)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                #include "../CodeBlock/SDF_Containers.cginc"
                #include "../CodeBlock/BorderA.cginc"
                col *= i.color;
                return col;
            }
            ENDCG
        }
    }


    CustomEditor "ProceduralUIElements.ShaderGUI_UIElement_10A"
}