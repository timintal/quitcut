if(_SelectShape==0)
{
    TempSDFA = length(UV - float2(_X, _Y))- _Radius;
}
else
{
    TempSDFA = BoxSDF(RotateXY(UV, _Rotation), float2(_Width, _Height))- _CornerRoundness;
}
SDF = SmoothUnionSDF(SDF, TempSDFA, _SmoothBlend);