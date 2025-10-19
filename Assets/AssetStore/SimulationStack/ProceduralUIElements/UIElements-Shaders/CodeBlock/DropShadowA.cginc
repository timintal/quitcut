SDF -= _DropShadowSize;
SDF = Rim == 0 ? SDF : abs(SDF);
col = _DropShadowColor;
float Temp = 1;
if(_DropShadowColorMode==1)
{
    col = FourColorGradientA(UV , _DropShadowGradientAngle, _ColorE, _ColorF, _ColorG, _ColorH, _DropShadowGradientMode, 0, _DropShadowGradientScale, 1, 0);
    Temp = col.a;
}
col.a = smoothstep(_DropShadowSpread, 0, SDF) * _DropShadowOpacity;
col.a = pow(col.a, _DropShadowGamma);
col.a *= Temp;

