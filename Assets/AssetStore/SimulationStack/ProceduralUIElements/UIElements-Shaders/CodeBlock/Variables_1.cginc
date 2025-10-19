
float4 _ImageSizeRatio;
float _Radius, _EnableRim, _RimWidth, _RimGamma, _EdgeBlur;


float CalculateSDF(float2 UV)
{
	return length(UV) - _Radius;
}
