

float4 TwoColorGradient(float2 UV, float Angle, float4 A, float4 B, float Scale, float Spread, float Offset)
{
    float2 UVA = RotateXY(UV - float2(0, Offset),Angle) * (1.0 / Scale);
    float4 ColorGradient = lerp(A, B, UVA.y+0.5);
    return ColorGradient;
}

//UV.y += Offset;
    //UV *= (1.0/Scale);
    //float2 UVRotated = RotateXY(UV, Angle);
    //float4 GradientOne = lerp(A, B, UVRotated.x + 0.5);
    /*float Value = UVRotated.y + 0.5;
    float Temp = pow(abs(Value), Spread);
    Temp *= Value > 0 ? 1 : -1;*/