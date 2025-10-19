

#include "../CodeBlock/BaseFilesB.cginc"
#include "/Variables.cginc"
float _EnableDistortion;
sampler2D _DistortionTexture;
float _DistortionTextureScale, _DistortionIntensity;
float4 _AnimateDistortion;
#include "../CodeBlock/Variables_ColorModeC.cginc"

fixed4 frag(v2f i) : SV_Target
{
    float Rim = 1;
    #include "../CodeBlock/SizeRatioA.cginc"
    float Mask = 1;
    float SDF = 0;

    if (_MaskContainer == 0)
    {
        SDF = length(UV) - _CircleRadius;
        Mask = smoothstep(_ContainerEdgeBlur, 0, SDF);
    }
    else if (_MaskContainer == 1)
    {
        #include "../CodeBlock/RectangleCodeBlock.cginc"
        SDF = RoundBoxSDF(UV, float2(_Width, _Height), _CornerRoundness);
        Mask = smoothstep(_ContainerEdgeBlur, 0.0, SDF);
    }
    else if (_MaskContainer == 2)
    {
        float Clipping = smoothstep(0.5, 0.499, abs(UV.x)) * smoothstep(0.5, 0.499, abs(UV.y));
        Mask = tex2D(_MainTex, UV - float2(0.5, 0.5)).x * Clipping;
    }

    if (_EnableDistortion == 1)
    {
        UV += tex2D(_DistortionTexture, UV * (1 - _DistortionTextureScale) + float2(0.5, 0.5) + _AnimateDistortion.xy * _Time.y).xy * 0.01 * _DistortionIntensity;
    }

    UV = RotateXY(UV, _Rotate);
    UV = RotateXY(UV, length(UV) * _Twist);
    float2 UVFrac = frac(UV * _GridSize) - float2(0.5, 0.5);
    #include "../CodeBlock/ColorModeC.cginc"
    col = SelectedColor;
    col.a = smoothstep(_LineWidth, _LineWidth * (0.999 - _Blur), abs(UVFrac.x)) * smoothstep(_LineWidth * (0.999 - _Blur), _LineWidth, abs(UVFrac.y));
    col.a += smoothstep(_LineWidth, _LineWidth * (0.999 - _Blur), abs(UVFrac.y));
    col.a = pow(col.a, _Gamma) * _Opacity;
    col.a *= Mask;
    col *= i.color;
    return col;
}
