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