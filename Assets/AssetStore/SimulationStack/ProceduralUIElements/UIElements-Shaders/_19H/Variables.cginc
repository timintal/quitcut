
float4 _ImageSizeRatio;
float _GearSize;
float _GearRotation;
float _EdgeBlur;
float _GearRingWidth;
float _NoOfGearTeeths;
float _GearWidthA, _GearWidthB, _GearHeight;
float _GearCornerRoundness;
float _GearRadialOffset;
float _EnableRim, _RimWidth, _RimGamma;

float SDF = 0;

float TrapezoidSDF(float2 p, float r1, float r2, float he)
{
	float2 k1 = float2(r2, he);
	float2 k2 = float2(r2 - r1, 2.0 * he);
	p.x = abs(p.x);
	float2 ca = float2(p.x - min(p.x, (p.y < 0.0) ? r1 : r2), abs(p.y) - he);
	float2 cb = p - k1 + k2 * clamp(dot(k1 - p, k2) / dot2(k2), 0.0, 1.0);
	float s = (cb.x < 0.0 && ca.y < 0.0) ? -1.0 : 1.0;
	return s * sqrt(min(dot2(ca), dot2(cb)));
}

float CalculateSDF(float2 UV)
{
	float2 UVA = RotateXY(UV, _GearRotation + 180.0);
	float Sector = (atan2(UVA.y, UVA.x) + 3.14) / 6.28;
	Sector = round(Sector * _NoOfGearTeeths);
	UVA = RotateXY(UVA, -Sector * (360.0 / _NoOfGearTeeths));
	float TeethSDF = TrapezoidSDF(RotateXY(UVA - float2(-_GearSize - _GearRadialOffset, 0), 270), _GearWidthA, _GearWidthB, _GearHeight) - _GearCornerRoundness;
	float RingSDF = abs(length(UV) - _GearSize) - _GearRingWidth;
	float SDF = min(TeethSDF, RingSDF);
	return SDF;
}

