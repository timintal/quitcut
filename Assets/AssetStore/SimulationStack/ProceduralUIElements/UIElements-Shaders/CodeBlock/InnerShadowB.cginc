
col = _InnerShadowColor;
float Temp = 1;
if(_InnerShadowColorMode==1)
{
    //float Y = (RotateXY(ShadowUV, _InnerShadowGradientAngle) * (1.0/_InnerShadowGradientScale)) + 0.5;
   // col = lerp(_InnerShadowColorX, _InnerShadowColorY, Y);

    float2 UVGrad = RotateXY(ShadowUV, _InnerShadowGradientAngle) * (1.0 / _InnerShadowGradientScale);
    float Y = _InnerShadowGradientType == 0 ? (UVGrad.y + 0.5) : abs(UVGrad.x);
    col = lerp(_InnerShadowColorX, _InnerShadowColorY, Y);
    Temp = col.a;
}
col.a = pow(smoothstep(_InnerShadowSize, _InnerShadowSize * (0.999 - _InnerShadowSpread), -ShadowSDF ), _InnerShadowGamma) * _InnerShadowOpacity;
col.a *= Temp;