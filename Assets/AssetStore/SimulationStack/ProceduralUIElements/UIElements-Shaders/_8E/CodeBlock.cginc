float ShapeASDF = 0;

if (_ChooseShapeA == 0)
{
    ShapeASDF = CircleSDF(UV - float2(_XOffsetA, _YOffsetA), _RadiusA);
}
else if (_ChooseShapeA == 1)
{
    ShapeASDF = BoxSDF(RotateXY(UV - float2(_XOffsetA, _YOffsetA), _RotationA), float2(_WidthA, _HeightA)) - _CornerRoundnessA;
}

float ShapeBSDF = 0;

if (_ChooseShapeB == 0)
{
    ShapeBSDF = CircleSDF(UV - float2(_XOffsetB, _YOffsetB), _RadiusB);
}
else if (_ChooseShapeB == 1)
{
    ShapeBSDF = BoxSDF(RotateXY(UV - float2(_XOffsetB, _YOffsetB), _RotationB), float2(_WidthB, _HeightB)) - _CornerRoundnessB;
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