

float ShapeASDF = 0;

if (_ChooseShapeA == 0)
{
    ShapeASDF = CircleSDF(UV - float2(_OffsetXCircleA, _OffsetYCircleA), _RadiusCircleA);
}
else if (_ChooseShapeA == 1)
{
    ShapeASDF = BoxSDF(RotateXY(UV - float2(_OffsetXRectangleA, _OffsetYRectangleA), _RectangleARotation), float2(_SizeXRectangleA, _SizeYRectangleA)) - _RoundnessRectangleA;
}

float ShapeBSDF = 0;

if (_ChooseShapeB == 0)
{
    ShapeBSDF = CircleSDF(UV - float2(_OffsetXCircleB, _OffsetYCircleB), _RadiusCircleB);
}
else if (_ChooseShapeB == 1)
{
    ShapeBSDF = BoxSDF(RotateXY(UV - float2(_OffsetXRectangleB, _OffsetYRectangleB), _RectangleBRotation), float2(_SizeXRectangleB, _SizeYRectangleB)) - _RoundnessRectangleB;
}

float SDF = 0;

if (_ShapeBlendMode == 0)
{
    SDF = SmoothUnionSDF(ShapeASDF, ShapeBSDF, _Blend);
}
else if (_ShapeBlendMode == 1)
{
    SDF = SmoothDifferenceSDF(ShapeASDF, ShapeBSDF, _Blend);
}


