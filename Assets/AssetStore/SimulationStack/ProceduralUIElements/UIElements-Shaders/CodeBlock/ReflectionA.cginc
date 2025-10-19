
float2 UV1 = RotateXY(UV, _Rotate);
UV1 -= float2(_LineOffset, 0);
float2 UV2 = UV1;

if (_ChooseReflectionShape == 1)
{
    float2 Offset = float2(_CircleXOffset, _CircleYOffset) *(1 + _CircleRadius);
    float2 UVC = RotateXY(UV - Offset,_CircleRotation);
    UVC.y *= (1 + _CircleYScale);
    UVC.y -= sin((UVC+0.5) * 3.14) * _CircleYBend;
    UVC.y += _CircleYBend;
    float SDF = length(UVC) - _CircleRadius ;
    col = _Color;
    col.a = smoothstep(_CircleBlur, 0, SDF);
}
else if (_ChooseReflectionShape == 0)
{
    if (_EnableBend == 1)
    {
        UV2.x -= UV2.y * UV2.y * _Bend;
    }

    if (_EnableAnimation == 0)
    {
        if (_ChooseLineMode == 0)
        {
            col = _Color;
            float SDF0 = BoxSDF(UV2, float2(_LineWidth, 1000.0));
            col.a = smoothstep(_LineEdgeBlur, 0, SDF0);
        }
        else if (_ChooseLineMode == 1)
        {
            float2 UVA = UV1 - float2(_LinesSeparation, 0);
            float2 UVB = UV1 + float2(_LinesSeparation, 0);

            if (_EnableBend == 1)
            {
                UVA.x -= UV1.y * UV1.y * _Bend;
                UVB.x -= UV1.y * UV1.y * _Bend;
            }

            float SDFA = BoxSDF(UVA, float2(_LineWidthA, 1000.0));
            float SDFB = BoxSDF(UVB, float2(_LineWidthB, 1000.0));
            float SDFAB = min(SDFA, SDFB);

            col = _Color;
            col.a = smoothstep(_LineEdgeBlur, 0, SDFAB);
        }
    }
    else if (_EnableAnimation == 1)
    {
        _Inc = (_Time.y * _MoveSpeed);

        if (floor(UV2.x + _Inc) % _Frequency == 0)
        {
            if (_ChooseLineMode == 0)
            {
                col = _Color;
                UV2.x = frac(UV2.x + _Inc) - 0.5;
                float SDF0 = BoxSDF(UV2, float2(_LineWidth, 1000.0));
                col.a = smoothstep(_LineEdgeBlur, 0, SDF0);
            }
            else if (_ChooseLineMode == 1)
            {
                float2 UVA = UV1 - float2(_LinesSeparation, 0);
                float2 UVB = UV1 + float2(_LinesSeparation, 0);

                if (_EnableBend == 1)
                {
                    UVA.x -= UV1.y * UV1.y * _Bend;
                    UVB.x -= UV1.y * UV1.y * _Bend;
                }

                UVA.x = frac(UVA.x + _Inc)-0.5;
                UVB.x = frac(UVB.x + _Inc)-0.5;

                float SDFA = BoxSDF(UVA, float2(_LineWidthA, 1000.0));
                float SDFB = BoxSDF(UVB, float2(_LineWidthB, 1000.0));
                float SDFAB = min(SDFA, SDFB);

                col = _Color;
                col.a = smoothstep(_LineEdgeBlur, 0, SDFAB);
            }
        }
        else
        {
            col = fixed4(0, 0, 0, 0);
        }
    }
}

if (_EnableAlphaGradient == 1)
{
    float2 TempUV = RotateXY(UV1 * _AlphaGradientScale, _AlphaGradientAngle);
    col.a *= pow(smoothstep(1.0, 0, TempUV.y + 0.5), _AlphaGradientGamma);
}








  // float Animate=0;
    // float NoColor=0;
    // if(_EnableAnimation==1)
    // {
    //     _Inc = (_Time.y * _MoveSpeed);
    //     if (floor(UV2.x + _Inc) % _Frequency == 0)
    //     {
    //         Animate=1;
    //     }
    //     else
    //     {
    //         NoColor=1;
    //     }
    // }

    // if (_ChooseLineMode == 0)
    // {
    //     col = _Color;
    //     if(Animate==1)
    //     {
    //         UV2.x = frac(UV2.x + _Inc) - 0.5;
    //     }
    //     float SDF0 = BoxSDF(UV2, float2(_LineWidth, 1000.0));
    //     col.a = smoothstep(_LineEdgeBlur, 0, SDF0);
    // }
    // else if (_ChooseLineMode == 1)
    // {
    //     float2 UVA = UV1 - float2(_LinesSeparation, 0);
    //     float2 UVB = UV1 + float2(_LinesSeparation, 0);

    //     if (_EnableBend == 1)
    //     {
    //         UVA.x -= UV1.y * UV1.y * _Bend;
    //         UVB.x -= UV1.y * UV1.y * _Bend;
    //     }

    //     if(Animate==1)
    //     {
    //         UVA.x = frac(UVA.x + _Inc)-0.5;
    //         UVB.x = frac(UVB.x + _Inc)-0.5;
    //     }

    //     float SDFA = BoxSDF(UVA, float2(_LineWidthA, 1000.0));
    //     float SDFB = BoxSDF(UVB, float2(_LineWidthB, 1000.0));
    //     float SDFAB = min(SDFA, SDFB);

    //     col = _Color;
    //     col.a = smoothstep(_LineEdgeBlur, 0, SDFAB);
    // }

    // if(NoColor)
    // {
    //     col = fixed4(0,0,0,0);
    // }