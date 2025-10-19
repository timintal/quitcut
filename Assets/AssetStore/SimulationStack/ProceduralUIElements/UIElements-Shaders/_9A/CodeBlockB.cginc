

//col += GRABPIXEL(0.02, -5.0);
//col += GRABPIXEL(0.05, -4.0);
//col += GRABPIXEL(0.09, -3.0);
//col += GRABPIXEL(0.12, -2.0);
//col += GRABPIXEL(0.15, -1.0);
//col += GRABPIXEL(0.18, 0.0);
//col += GRABPIXEL(0.15, +1.0);
//col += GRABPIXEL(0.12, +2.0);
//col += GRABPIXEL(0.09, +3.0);
//col += GRABPIXEL(0.05, +4.0);
//col += GRABPIXEL(0.02, +5.0);

col += GRABPIXEL(0.025, -7.0);
col += GRABPIXEL(0.05, -6.0);
col += GRABPIXEL(0.075, -5.0);
col += GRABPIXEL(0.1, -4.0);
col += GRABPIXEL(0.125, -3.0);
col += GRABPIXEL(0.15, -2.0);
col += GRABPIXEL(0.175, -1.0);
col += GRABPIXEL(0.20, 0.0);
col += GRABPIXEL(0.175, +1.0);
col += GRABPIXEL(0.15, +2.0);
col += GRABPIXEL(0.125, +3.0);
col += GRABPIXEL(0.10, +4.0);
col += GRABPIXEL(0.075, +5.0);
col += GRABPIXEL(0.05, +6.0);
col += GRABPIXEL(0.025, +7.0);

col /= 1.6;

if (_MaskContainer >= 4)
{
    float Clipping = smoothstep(0.5, 0.499, abs(UV.x)) * smoothstep(0.5, 0.499, abs(UV.y));
    col.a *= _MaskContainer==5?1:  tex2D(_ShapeTexture, UV - float2(0.5,0.5)).x * Clipping;
}
else
{
    #include "../CodeBlock/SDF_Containers.cginc"
    // #include "/Rim.cginc"
    // col.a *= Rim;
    SDF = _EnableRim == 1?abs(SDF) - _RimWidth: SDF;
    col.a *= smoothstep(_EdgeBlur, 0.0, SDF);             
    //col.a *= _Opacity;
}

if (_EnableNoise)
{
    col.a *= tex2D(_MainTex, UV * (1 - _TextureScale) + float2(0.5, 0.5) + _NoiseAnimate.xy * _Time.y).x * _NoiseIntensity;
}
