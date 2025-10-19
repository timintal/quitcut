

if (_NoiseAlphaClip == 1)
{
    float2 TexUV = RotateXY(i.uv - float2(0.5, 0.5), _NoiseTexMoveDirection) + float2(0.5 + _NoiseTexOffset, 0.5);
    col.a *= tex2D(_NoiseTex, TexUV * _NoiseTexScale + (_Time.y * _NoiseTexMoveSpeed)).x;
    col.a = pow(col.a, 1.0);
}

