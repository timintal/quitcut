
SDF =  SDF - _BorderBoundaryOffset;
col = _BorderColor;
float Temp = 1;
if(_BorderColorMode == 1)
{
    float2 UVGrad = RotateXY(UV,_BorderGradientAngle) * (1.0 / _BorderGradientScale);
    float Y = _GradientType==0? (UVGrad.y + 0.5) : abs(UVGrad.x);
    col = lerp(_ColorE, _ColorF, Y);
    Temp = col.a;
}
col.a = pow(smoothstep(_BorderWidth, _BorderWidth * (0.99 - _BorderBlur), abs(SDF)), _BorderGamma) * _BorderOpacity;
col.a *= Temp;