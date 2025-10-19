float _EnableDisplaceShape;
fixed4 _BGColor;
float _DisplaceShapeEdgeBlur;
float _ShapeOffsetX;
float _ShapeOffsetY;

fixed4 DisplaceShape(float2 UV, fixed4 SelectedColor)
{
	float DisplaceShapeSDF = CalculateSDF(UV - float2(_ShapeOffsetX, _ShapeOffsetY));
	return (_EnableDisplaceShape == 0) ? SelectedColor : lerp(_BGColor, SelectedColor, smoothstep(_DisplaceShapeEdgeBlur, 0, DisplaceShapeSDF));
}