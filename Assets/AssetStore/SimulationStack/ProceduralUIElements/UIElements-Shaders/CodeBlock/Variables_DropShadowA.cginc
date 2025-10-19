

float _EnableDropShadow;
float _DropShadowSize;
float _DropShadowSpread;
float _DropShadowGamma;
float _DropShadowOpacity;
float _DropShadowXOffset, _DropShadowYOffset;

float _DropShadowColorMode;
fixed4 _DropShadowColor;
float _DropShadowGradientMode;
fixed4 _ColorE, _ColorF, _ColorG, _ColorH;
float _DropShadowGradientAngle, _DropShadowGradientScale, _DropShadowGradientSpread;


//fixed4 DropShadowA(float2 UV,float Rim,float SDF)
//{
//	fixed4 Color = fixed4(0, 0, 0, 0);
//	SDF -= _ShadowShapeSize;
//	SDF = Rim == 0 ? SDF : abs(SDF);
//	fixed4 Gradient = FourColorGradientA(UV + float2(_ShadowXOffset, _ShadowYOffset), _ShadowGradientAngle, _ColorE, _ColorF, _ColorG, _ColorH, _ShadowGradientMode, 0, _ShadowGradientScale, 1, 0);
//	Color = _ShadowColorMode == 0 ? _ShadowColor : Gradient;
//	Color.a = smoothstep(_ShadowSpread, 0, SDF) * _ShadowOpacity;
//	Color.a = pow(Color.a, _ShadowGamma);
//	return Color;
//}
