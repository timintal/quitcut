
float ToonGradient = _EnableToonGradient == 1 ? _StepsToonGradient : 0;
ColorUV = RotateXY(ColorUV - GradientOffset.xy, _GradientAngle) * (1.0 / _GradientScale);

//float Value = ColorUV.y +0.5;
//float Temp = pow(abs(Value), 1.0/_GradientSpread);
//Temp *= Value > 0 ? 1 : -1;

float Y = ColorUV.y + 0.5;

if (ToonGradient > 0)
{
    Y = floor(Y * ToonGradient) / ToonGradient;
}

if (_GradientMode == 0)
{
    SelectedColor= lerp(_ColorA, _ColorB, Y);
}
else if (_GradientMode == 1)
{
    SelectedColor= lerp(lerp(_ColorA, _ColorB, ColorUV.x + 0.5), _ColorC, Y);
}
else
{
    SelectedColor= lerp(lerp(_ColorA, _ColorB, ColorUV.x + 0.5), lerp(_ColorC, _ColorD, ColorUV.x + 0.5), Y);
}
