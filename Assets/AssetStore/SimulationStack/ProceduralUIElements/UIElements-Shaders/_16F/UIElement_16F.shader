Shader "ProceduralUIElements/UIElement_16F"
{
    Properties
    {
        

        [Space(20)]
        _ImageSizeRatio("Image Size Ratio", Vector) = (1.0, 1.0, 1.0, 1.0)



        ///
        ///  Container Shape Properties
        ///


        [Space(20)]
        [KeywordEnum(Circle, Rectangle,Polygone,Heart, Texture Mask, None)] _MaskContainer("Select Container(Mask)", Float) = 0
        //
        _Radius("Circle Radius", Range(0.00,0.50)) = 0.3
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
        _HeartSize("Heart Size", Range(0.0, 12.0)) = 5.0
        //
        _CornerRoundness("Corner Roundness", Range(0.0,0.5)) = 0.01
        _ContainerEdgeBlur("Edge Blur", Range(0.0, 0.05)) = 0.01
        //
        _MainTex("Texture (Mask)", 2D) = "white" {}


        ///
        ///  Bg Color
        /// 


        [Space(20)]
        [Toggle(EnableBG)] _EnableBG("Enabel Background",float) = 0
        _BGColor("BG Color", Color) = (0.45,0.45,0.45,1)


        ///
        ///  All Layers Parameters
        ///


        [Space(20)]
        _NoiseTex("Noise Texture", 2D) = "white" {}
        _NoiseTexScale("Noise Texture Scale", Range(0.0, 5.0)) = 1.0
        _FireXOffset("Fire X Offset (All Layers)", Range(-0.5, 0.5)) = 0.0
        _FireYOffset("Fire Y Offset (All Layers)", Range(-0.5, 0.5)) = 0.0
        _AnimationSpeed("Animation Speed", Range(0.0, 5.0)) = 0.5


        ///
        ///  Fire Layer A
        ///


        [Space(20)]
        [Toggle(EnableFireLayerA)] _EnableFireLayerA("Enable Layer A", float) = 0
        _FireAHeight("Fire Height", Range(0.0, 1.0)) = 0.1
        _FireAXOffset("X Offset", Range(-0.5, 0.5)) = 0.0
        _FireAYOffset("Y Offset", Range(0.0, 1.0)) = 0.1
        [KeywordEnum(A, B)] _ColorModeFireA("Color Mode", Float) = 0
        _ColorAFireA("Color A", Color) = (0.45, 0.45, 0.45, 1)
        _ColorBFireA("Color B", Color) = (0.45, 0.45, 0.45, 1)
        _GradientAngleFireA("Gradient Angle", Range(0.0, 360)) = 0.0
        _GradientScaleFireA("Gradient Scale", Range(0.0, 4.0)) = 0.1
        _BloomFireA("Bloom", Range(0.0, 5.0)) = 1.0
        _BloomColorFireA("Bloom Color", Color) = (0.45, 0.45, 0.45, 1)
        _BloomEdgeWidthFireA("Bloom Edge Width", Range(0.0, 0.5)) = 0.1


        ///
        ///  Fire Layer B
        ///


        [Space(20)]
        [Toggle(EnableFireLayerB)] _EnableFireLayerB("Enable Layer B", float) = 0
        _FireBHeight("Fire Height", Range(0.0, 1.0)) = 0.1
        _FireBXOffset("X Offset", Range(-0.5, 0.5)) = 0.0
        _FireBYOffset("Y Offset", Range(0.0, 1.0)) = 0.1
        [KeywordEnum(A, B)] _ColorModeFireB("Color Mode", Float) = 0
        _ColorAFireB("Color A", Color) = (0.45, 0.45, 0.45, 1)
        _ColorBFireB("Color B", Color) = (0.45, 0.45, 0.45, 1)
        _GradientAngleFireB("Gradient Angle", Range(0.0, 360)) = 0.0
        _GradientScaleFireB("Gradient Scale", Range(0.0, 4.0)) = 0.1
        _BloomFireB("Bloom", Range(0.0, 5.0)) = 1.0
        _BloomEdgeWidthFireB("Bloom Edge Width", Range(0.0, 0.5)) = 0.1
        _BloomColorFireB("Bloom Color", Color) = (0.45, 0.45, 0.45, 1)


        ///
        ///  Fire Layer C
        ///


        [Space(20)]
        [Toggle(EnableFireLayerC)] _EnableFireLayerC("Enable Layer C", float) = 0
        _FireCHeight("Fire Height", Range(0.0, 1.0)) = 0.1
        _FireCXOffset("X Offset", Range(-0.5, 0.5)) = 0.0
        _FireCYOffset("Y Offset", Range(0.0, 1.0)) = 0.1
        [KeywordEnum(A, B)] _ColorModeFireC("Color Mode", Float) = 0
        _ColorAFireC("Color A", Color) = (0.45, 0.45, 0.45, 1)
        _ColorBFireC("Color B", Color) = (0.45, 0.45, 0.45, 1)
        _GradientAngleFireC("Gradient Angle", Range(0.0, 360)) = 0.0
        _GradientScaleFireC("Gradient Scale", Range(0.0, 4.0)) = 0.1
        _BloomFireC("Bloom", Range(0.0, 5.0)) = 1.0
        _BloomEdgeWidthFireC("Bloom Edge Width", Range(0.0, 0.5)) = 0.1
        _BloomColorFireC("Bloom Color", Color) = (0.45, 0.45, 0.45, 1)


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
            #include "/Variables.cginc"
            float _EnableBG;
            fixed4 _BGColor;

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableBG == 0) return 0;

                #include "/CodeBlock.cginc"
                col = _BGColor;
                col.a *= Mask;
                col *= i.color;
                return col;
            }
            ENDCG
        }


        ///
        ///  Fire Layer A
        ///


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "../CodeBlock/BaseFilesB.cginc"
            #include "../Functions/GradientB.cginc"
            #include "/Variables.cginc"
            sampler2D _NoiseTex;
            float _NoiseTexScale, _FireXOffset, _FireYOffset, _AnimationSpeed;
            float _EnableFireLayerA,_FireAHeight, _FireAYOffset, _FireAXOffset;
            float _ColorModeFireA;
            fixed4 _ColorFireA,_ColorAFireA, _ColorBFireA;
            fixed4 _BloomColorFireA;
            float _GradientAngleFireA, _GradientScaleFireA;
            float _BloomFireA, _BloomEdgeWidthFireA;
            
            fixed4 frag(v2f i) : SV_Target
            {
                if(_EnableFireLayerA==0) return 0;

                #include "/CodeBlock.cginc"
                i.uv.x *= _ImageSizeRatio.x / _ImageSizeRatio.y;
                float2 UVA = i.uv;
                i.uv.x -= _FireAXOffset;
                i.uv.x-= _FireXOffset;
                i.uv.y -= _AnimationSpeed * _Time.y;
                float2 ColorUV = RotateXY(UV , _GradientAngleFireA) * _GradientScaleFireA; 
                col = lerp(_ColorAFireA, _ColorBFireA, (ColorUV.y + 0.5 * _GradientScaleFireA));
                float Temp = smoothstep(_FireAHeight, 0, UVA.y - _FireYOffset - _FireAYOffset);
                i.uv *= _NoiseTexScale;

                if (_ColorModeFireA==0)
                {
                    _BloomEdgeWidthFireA = 0.05;
                    col.a = smoothstep(Temp, Temp * 0.95, tex2D(_NoiseTex, i.uv).x);
                    col.a +=  pow((_BloomEdgeWidthFireA / abs(tex2D(_NoiseTex, i.uv).x - Temp)), 5.01 - _BloomFireA);
                }
                else if(_ColorModeFireA==1)
                {
                    col = lerp(_ColorAFireA, _ColorBFireA, (ColorUV.y + 0.5 * _GradientScaleFireA));
                    col.a = smoothstep(Temp, Temp * 0.95, tex2D(_NoiseTex, i.uv).x);
                    col += _BloomColorFireA*  pow((_BloomEdgeWidthFireA / abs(tex2D(_NoiseTex, i.uv).x - Temp)), 5.01 - _BloomFireA);
                }
                
                col.a *= Mask;
                col *= i.color;
                return col;
            }
            ENDCG
        }



        ///
        ///  Fire Layer B
        ///


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "../CodeBlock/BaseFilesB.cginc"
            #include "../Functions/GradientB.cginc"
            #include "/Variables.cginc"
            sampler2D _NoiseTex;
            float _NoiseTexScale, _FireXOffset, _FireYOffset, _AnimationSpeed;
            float _EnableFireLayerB,_FireBHeight, _FireBYOffset, _FireBXOffset;
            float _ColorModeFireB;
            fixed4 _ColorFireB,_ColorAFireB, _ColorBFireB;
            fixed4 _BloomColorFireB;
            float _GradientAngleFireB, _GradientScaleFireB;
            float _BloomFireB, _BloomEdgeWidthFireB;

            fixed4 frag(v2f i) : SV_Target
            {
                if(_EnableFireLayerB==0) return 0;

                #include "/CodeBlock.cginc"

                i.uv.x *= _ImageSizeRatio.x / _ImageSizeRatio.y;
                float2 UVA = i.uv;
                i.uv.x -= _FireBXOffset;
                i.uv.x-= _FireXOffset;
                i.uv.y -= _AnimationSpeed * _Time.y;
                float2 ColorUV = RotateXY(UV , _GradientAngleFireB) * _GradientScaleFireB; 
                col = lerp(_ColorAFireB, _ColorBFireB, (ColorUV.y + 0.5 * _GradientScaleFireB));
                float Temp = smoothstep(_FireBHeight, 0, UVA.y - _FireYOffset - _FireBYOffset);
                i.uv *= _NoiseTexScale;

                if(_ColorModeFireB==0)
                {
                    _BloomEdgeWidthFireB = 0.05;
                    col.a = smoothstep(Temp, Temp * 0.95, tex2D(_NoiseTex, i.uv).x);
                    col.a +=  pow((_BloomEdgeWidthFireB / abs(tex2D(_NoiseTex, i.uv).x - Temp)), 5.01 - _BloomFireB);
                }
                else if(_ColorModeFireB==1)
                {
                    col = lerp(_ColorAFireB, _ColorBFireB, (ColorUV.y + 0.5 * _GradientScaleFireB));
                    col.a = smoothstep(Temp, Temp * 0.95, tex2D(_NoiseTex, i.uv).x);
                    col += _BloomColorFireB*  pow((_BloomEdgeWidthFireB / abs(tex2D(_NoiseTex, i.uv).x - Temp)), 5.01 - _BloomFireB);
                }
                
                col.a *= Mask;
                col *= i.color;
                return col;
            }
            ENDCG
        }



        ///
        ///  Fire Layer C
        ///


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "../CodeBlock/BaseFilesB.cginc"
            #include "../Functions/GradientB.cginc"
            #include "/Variables.cginc"
            sampler2D _NoiseTex;
            float _NoiseTexScale, _FireXOffset,_FireYOffset, _AnimationSpeed;
            float _EnableFireLayerC,_FireCHeight, _FireCYOffset, _FireCXOffset;
            float _ColorModeFireC;
            fixed4 _ColorFireC,_ColorAFireC, _ColorBFireC;
            fixed4 _BloomColorFireC;
            float _GradientAngleFireC, _GradientScaleFireC;
            float _BloomFireC, _BloomEdgeWidthFireC;

            fixed4 frag(v2f i) : SV_Target
            {
                if(_EnableFireLayerC==0) return 0;

                #include "/CodeBlock.cginc"

                i.uv.x *= _ImageSizeRatio.x / _ImageSizeRatio.y;
                float2 UVA = i.uv;
                i.uv.x -= _FireCXOffset;
                i.uv.x-= _FireXOffset;
                i.uv.y -= _AnimationSpeed * _Time.y;
                float2 ColorUV = RotateXY(UV , _GradientAngleFireC) * _GradientScaleFireC; 
                col = lerp(_ColorAFireC, _ColorBFireC, (ColorUV.y + 0.5 * _GradientScaleFireC));
                float Temp = smoothstep(_FireCHeight, 0, UVA.y - _FireYOffset - _FireCYOffset);
                i.uv *= _NoiseTexScale;
                
                if(_ColorModeFireC==0)
                {
                    _BloomEdgeWidthFireC = 0.05;
                    col.a = smoothstep(Temp, Temp * 0.95, tex2D(_NoiseTex, i.uv).x);
                    col.a +=  pow((_BloomEdgeWidthFireC / abs(tex2D(_NoiseTex, i.uv).x - Temp)), 5.01 - _BloomFireC);
                }
                else if(_ColorModeFireC==1)
                {
                    col = lerp(_ColorAFireC, _ColorBFireC, (ColorUV.y + 0.5 * _GradientScaleFireC));
                    col.a = smoothstep(Temp, Temp * 0.95, tex2D(_NoiseTex, i.uv).x);
                    col += _BloomColorFireC *  pow((_BloomEdgeWidthFireC / abs(tex2D(_NoiseTex, i.uv).x - Temp)), 5.01 - _BloomFireC);
                }
                
                col.a *= Mask;
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
            #include "../CodeBlock/Variables_InnerShadowB.cginc"
            #include "/Variables.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableInnerShadow == 0 || _MaskContainer>=4)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                #include "../CodeBlock/SDF_Containers.cginc"
                float2 ShadowUV = UV - float2(_InnerShadowXOffset, _InnerShadowYOffset);
                float ShadowSDF = 0;
                #include "../CodeBlock/ShadowSDF_Containers.cginc"
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
            #include "../CodeBlock/Variables_BorderA.cginc"
            #include "/Variables.cginc"

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

    CustomEditor "ProceduralUIElements.ShaderGUI_UIElement_16F"
}