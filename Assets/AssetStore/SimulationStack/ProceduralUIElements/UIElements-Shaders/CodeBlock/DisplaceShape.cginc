

float DisplaceShapeSDF = CalculateSDF(UV - float2(_ShapeOffsetX, _ShapeOffsetY));
col = (_EnableDisplaceShape == 0) ? SelectedColor : lerp(_BGColor, SelectedColor, smoothstep(_DisplaceShapeEdgeBlur, 0, DisplaceShapeSDF));

