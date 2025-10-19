
float Radial = 0;
if (_RadialType == 0)
{
    Radial = pow(length(ColorUV - GradientOffset.xy) * (1.0/_RadialScale), _RadialSpread);
}
else if (_RadialType == 1)
{
    Radial = smoothstep(Rim, 0, abs(SDF)*0.8);
    Radial = pow(Radial, 1/_RadialGamma);
}

if (_EnableToonGradient == 1)
{
    Radial = floor(Radial * _StepsToonGradient) / _StepsToonGradient;
}
SelectedColor = lerp(_ColorA, _ColorB, Radial);