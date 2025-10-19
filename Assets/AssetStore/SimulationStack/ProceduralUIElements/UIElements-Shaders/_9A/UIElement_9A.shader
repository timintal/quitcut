Shader "ProceduralUIElements/UIElement_9A" 
{
    Properties
    {
        [Space(20)]
        _ImageSizeRatio("Image Size Ratio", Vector) = (1.0, 1.0, 0.0, 0.0)


        /// 
        ///  Shape Properties
        /// 


        [Space(20)]
        [KeywordEnum(Circle, Rectangle, Polygon, Heart, Texture, None)] _MaskContainer("Choose Shape", Float) = 0
        //
        _Radius("Radius", Range(0.0, 0.5)) = 0.25
        //
        [KeywordEnum(Percentage, Margin)] _ChooseDimensionParameters("Choose Dimension Parameters", Float) = 0
        _Width("Width %", Range(0.0, 1.0)) = 0.5
        _Height("Height %", Range(0.0, 1.0)) = 0.5
        _WidthMargin("Width Margin", Float) = 20
        _HeightMargin("Height Margin", Float) = 20
        //
        _PolygonSize("Size", Range(0.01, 0.5)) = 0.25
        [IntRange]_PolygonTurns("Turns", Range(2, 12)) = 5
        _PolygonEdgeAngle("Edge Angle", Range(1.2, 8.5)) = 3.0
        //
        _HeartSize("Size", Range(0.0, 12.0)) = 5.0
        //
        _ShapeTexture("Texture (Mask)", 2D) = "white" {}
        //
        _CornerRoundness("Corner Roundness", Range(0.0, 0.3)) = 0.01
        //
        [Toggle(EnableRim)] _EnableRim("Enable Rim", float) = 0
        _RimWidth("Rim Width", Range(0.0, 0.2)) = 0.02
        //
        _EdgeBlur("Edge Blur", Range(0.0, 0.1)) = 0.01


        /// 
        ///  Blur Properties
        /// 


        [Space(20)]
        _BlurMagnitude("Blur Magnitude", Range(0, 20.0)) = 1


        /// 
        ///  Noise Texture
        /// 


        [Space(20)]
        [Toggle(EnableNoise)] _EnableNoise("Enable Texture Noise", float) = 0
        _MainTex("Noise Texture", 2D) = "white" {}
        _TextureScale("Texture Scale", Range(0.0, 10.0)) = 1.0
        _NoiseIntensity("Noise Intensity", Range(0.0, 15.0)) = 1.0
        _NoiseAnimate("Animate", Vector) = (0.0, 0.0, 0.0, 0.0)
        

        ///
        ///  Color Mode
        ///


        [Space(20)]
        _Opacity("Opacity", Range(0.0, 1.0)) = 0
        [KeywordEnum(Color, RadialGradient, LinearGradient, SharpBoundary)] _ColorMode("Color Mode", Float) = 0
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
        _RadialScale("Radial Scale", Range(0.0, 1.0)) = 1.0
        _RadialSpread("Radial Spread", Range(0.0, 3.0)) = 1.0
        _RadialGamma("Radial Gamma", Range(0.0, 3.0)) = 1.0
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
        ///  Drop Shadow
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
        ///  Horizontal Blur Pass
        ///

        GrabPass 
        {
            Tags { "LightMode" = "Always" }
        }
        Pass 
        {
            Tags { "LightMode" = "Always" }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #pragma fragmentoption ARB_precision_hint_fastest
            #include "/CodeBlockA.cginc"

            half4 frag(v2f i) : COLOR 
            {
                #include "../CodeBlock/SizeRatioA.cginc"
                col = float4(0,0,0,0);
                #define GRABPIXEL(weight,kernelx) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(float4(i.uvgrab.x + _GrabTexture_TexelSize.x * kernelx*_BlurMagnitude, i.uvgrab.y, i.uvgrab.z, i.uvgrab.w))) * weight
                #include "/CodeBlockB.cginc"
                col *= i.color;
                return col;
            }
            ENDCG
        }

        ///
        ///  Verticle Blur Pass 
        /// 

        GrabPass 
        {
            Tags { "LightMode" = "Always" }
        }
        Pass 
        {
            Tags { "LightMode" = "Always" }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #pragma fragmentoption ARB_precision_hint_fastest
            #include "/CodeBlockA.cginc"

            half4 frag(v2f i) : COLOR
            {
                #include "../CodeBlock/SizeRatioA.cginc"
                col = float4(0,0,0,0);
                #define GRABPIXEL(weight,kernely) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(float4(i.uvgrab.x, i.uvgrab.y + _GrabTexture_TexelSize.y * kernely*_BlurMagnitude, i.uvgrab.z, i.uvgrab.w))) * weight
                #include "/CodeBlockB.cginc"
                col *= i.color;
                return col;
            }
            ENDCG
        }


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
            #include "../CodeBlock/Variables_DropShadowA.cginc"
            #include "/Variables.cginc"

            fixed4 frag(v2f i) : SV_Target
            {
                if (_EnableDropShadow == 0 || _MaskContainer == 4 || _MaskContainer==5)
                    return 0;
                float Rim = _EnableRim;
                #include "../CodeBlock/SizeRatioA.cginc"
                #include "../CodeBlock/SDF_Containers.cginc"
                SDF = _EnableRim == 1?abs(SDF) - _RimWidth: SDF;
                //SDF -= _DropShadowSize;
                float SDFWithoutRim = SDF;
                //SDF = Rim == 0 ? SDF : abs(SDF);
                fixed4 Gradient = FourColorGradientA(UV , _DropShadowGradientAngle, _ColorE, _ColorF, _ColorG, _ColorH, _DropShadowGradientMode, 0, _DropShadowGradientScale, 1, 0);
                col = _DropShadowColorMode == 0 ? _DropShadowColor : Gradient;
                col.a = smoothstep(_DropShadowSpread, 0, SDF) * _DropShadowOpacity;
                col.a = pow(col.a, _DropShadowGamma);
                if(Rim==0)
                {
                    col.a *= smoothstep(0.0, _EdgeBlur, SDF);
                }
                else
                {
                    col.a *= smoothstep(0.0, _EdgeBlur, SDFWithoutRim);
                }
                
                col *= i.color;
                return col;
            }
            ENDCG
        }


        ///
        ///  Container Color
        /// 


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "../CodeBlock/BaseFilesB.cginc"
            #include "../CodeBlock/Variables_ColorModeC.cginc"
            #include "/Variables.cginc"
            float _Opacity;

            fixed4 frag(v2f i) : SV_Target
            {
                float Rim=_EnableRim?_RimWidth:1;
                #include "../CodeBlock/SizeRatioA.cginc"
                #include "../CodeBlock/SDF_Containers.cginc"
                #include "../CodeBlock/ColorModeC.cginc"
                col = SelectedColor;
 
                if(_MaskContainer >= 4)
                {
                    float Clipping = smoothstep(0.5, 0.499, abs(UV.x)) * smoothstep(0.5, 0.499, abs(UV.y));
                    float TextureAlpha = tex2D(_ShapeTexture, UV - float2(0.5, 0.5)).x * Clipping;
                    col.a *= (_MaskContainer == 5 ? 1 : TextureAlpha) * _Opacity;
                }
                else
                {
                    // #include "/Rim.cginc"             
                    // col.a =  Rim * _Opacity;
                    SDF = _EnableRim == 1?abs(SDF) - _RimWidth: SDF;
                    col.a *= smoothstep(_EdgeBlur, 0.0, SDF);             
                    col.a *= _Opacity;
                }
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
                if (_EnableBorder == 0 || _MaskContainer == 4 || _MaskContainer==5)
                    return 0;

                #include "../CodeBlock/SizeRatioA.cginc"
                #include "../CodeBlock/SDF_Containers.cginc"
                SDF = _EnableRim == 1 ? abs(SDF) - _RimWidth : SDF;
                #include "../CodeBlock/BorderA.cginc"
                col *= i.color;
                return col;
            }
            ENDCG
        }

    }

    CustomEditor "ProceduralUIElements.ShaderGUI_UIElement_9A"
}
