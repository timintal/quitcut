Shader "QuitCut/UI/HaloGlowAdaptive"
{
    Properties
    {
        _NoiseTex ("Main Texture", 2D) = "white" {}
        _MaskTex ("Mask Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _NoiseSpeed ("Noise Speed (xy), UVScale(zw)", Vector) = (0.1,0.1,0,0)
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off
        ZTest Always

        Pass
        {
            Name "HaloGlowUI"
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata
            {
                float4 vertex: POSITION; 
                float2 uv: TEXCOORD0;
                float4 color : COLOR;
            };
            struct v2f
            {
                float4 pos: SV_POSITION; 
                float2 uv: TEXCOORD0;
                float4 color : COLOR;
            };

            // Correct texture+sampler declarations
            TEXTURE2D(_NoiseTex);
            SAMPLER(sampler_NoiseTex);
            float4 _NoiseTex_ST;
            float4 _NoiseTex_TexelSize;
            
            TEXTURE2D(_MaskTex);
            SAMPLER(sampler_MaskTex);
            
            float4 _Color;
            float4 _NoiseSpeed;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = TransformObjectToHClip(v.vertex.xyz);
                o.uv = TRANSFORM_TEX(v.uv, _NoiseTex);
                o.color = v.color * _Color;
                return o;
            }

            float4 frag(v2f i): SV_Target
            {
                float2 noiseUV = i.uv * _NoiseSpeed.zw + _NoiseSpeed.xy * _Time.y;
                float noiseVal1 = SAMPLE_TEXTURE2D(_NoiseTex, sampler_NoiseTex, noiseUV).r;
                
                float2 noiseUV2 = noiseUV * 0.5;
                float noiseVal2 = SAMPLE_TEXTURE2D(_NoiseTex, sampler_NoiseTex, noiseUV2).r;
                
                float2 noiseUV3 = noiseUV * 2;
                float noiseVal3 = SAMPLE_TEXTURE2D(_NoiseTex, sampler_NoiseTex, noiseUV3).r;
                
                float totalNoise = noiseVal1 * noiseVal2 * 2.0 * noiseVal3 * 2;
                
                float coreAlpha = SAMPLE_TEXTURE2D(_MaskTex, sampler_MaskTex, i.uv).a;
                totalNoise *= coreAlpha;

                float4 glowCol =  i.color;
                glowCol.a = totalNoise * i.color.a;
                return glowCol;
            }
            ENDHLSL
        }
    }
    FallBack "Hidden/Universal Render Pipeline/Unlit"
}
