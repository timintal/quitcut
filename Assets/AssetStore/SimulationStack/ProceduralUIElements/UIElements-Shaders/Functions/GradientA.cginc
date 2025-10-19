
float4 FourColorGradientA(float2 UV, float Angle, float4 A, float4 B, float4 C, float4 D, float GradientType, float ToonSteps, float Scale, float Spread, float4 Offset)
{
    float2 UVA = RotateXY(UV - Offset.xy, Angle) * (1.0/ Scale);

  /*  float Value = UVA.y + 0.5;
    float Temp = pow(abs(Value), Spread);
    Temp *= Value > 0 ? 1 : -1;*/

    float Y = UVA.y + 0.5;

    if (ToonSteps > 0)
    {
        Y = floor(Y * ToonSteps) / ToonSteps;
    }
    if (GradientType == 0)
    {
        return lerp(A, B, Y);
    }
    else if (GradientType == 1)
    {
        return lerp(lerp(A, B, UVA.x + 0.5), C, Y);
    }
    else 
    {
        return lerp(lerp(A, B, UVA.x + 0.5), lerp(C, D, UVA.x + 0.5), Y);
    }
}
