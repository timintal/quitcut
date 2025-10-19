
float2 UVFrac = frac((UV + float2(0.5, 0.5)) * _NoOfCells) - float2(0.5, 0);
float AnimationValue = (floor(i.uv * _NoOfCells).x / _NoOfCells);

if(_AnimatePosition > 0)
{
    UV.y -= abs(sin(AnimationValue * _AnimationScale + _Time.y * _AnimationSpeed)) * _AnimatePosition;
}

if(_AnimateScale > 0)
{
    if(_DotShape == 0)
    {
        _Radius *= 1.0 - abs(sin(AnimationValue * _AnimationScale + _Time.y * _AnimationSpeed)) * _AnimateScale;
    }
    else
    {
        _Width *= 1.0 - abs(sin(AnimationValue * _AnimationScale + _Time.y * _AnimationSpeed)) * _AnimateScale;
        _Height *= 1.0 - abs(sin(AnimationValue * _AnimationScale + _Time.y * _AnimationSpeed)) * _AnimateScale;
    }
}

float2 CellUV = float2(UVFrac.x, UV.y * _NoOfCells);
CellUV = RotateXY(CellUV, _Rotation);
float SDF = 0;
if (_DotShape == 0)
{
    SDF = length(CellUV) - _Radius;
}
else if (_DotShape == 1)
{
    SDF = RoundBoxSDF(CellUV, float2(_Width, _Height), _CornerRoundness);
}
