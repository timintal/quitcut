float FillAmount = 1;
if (_EnableFill == 1)
{
    float2 AngleUV = RotateXY(UV, _FillAngle);
    float Angular = ((atan2(AngleUV.y, AngleUV.x) + 3.1415926) / 6.2831852);

    if (_FillMode == 0)
    {
        float2 TempUV = RotateXY(UV, _FillAngle);
        FillAmount = smoothstep(_FillAmount, _FillAmount * 0.98, TempUV.x + 0.5);
    }
    else if (_FillMode == 1 || _FillMode == 2)
    {
        FillAmount = _FillMode == 1 ? (Angular <= _FillAmount) : (1.0 - Angular <= _FillAmount);
    }

    FillAmount = _EnableFill == 1 ? FillAmount : 1;
}

