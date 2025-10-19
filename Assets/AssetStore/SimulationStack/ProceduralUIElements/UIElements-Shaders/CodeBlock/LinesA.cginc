
float2 LinesUV = UV - float2(_LinesOffsetX, _LinesOffsetY) * (_LinesMode != 0);
float LinesX = 0;
col = _LinesColor;
LinesUV = RotateXY(LinesUV, _LinesRotation);
if (_LinesMode == 0)
{
    LinesX = frac(LinesUV * _NoOfLines + _Time.y * _LinesRotateMoveSpeed).x - 0.5;
}
else if (_LinesMode == 1)
{
    float Angular = ((atan2(LinesUV.y, LinesUV.x) + 3.1415926) / 6.2831852);
    float AngularFrac = frac(Angular * _NoOfLines + _Time.y * _LinesRotateMoveSpeed) - 0.5;
    LinesX = AngularFrac;
}
else if (_LinesMode == 2)
{
    _A1 *= 500;
    float _Spiral = pow(_A3 / length(LinesUV), _A2) * _A1;
    LinesUV = RotateXY(LinesUV, _Spiral);
    float Angular = ((atan2(LinesUV.y, LinesUV.x) + 3.1415926) / 6.2831852);
    float AngularFrac = frac(Angular * _NoOfLines + _Time.y * _LinesRotateMoveSpeed) - 0.5;
    LinesX = AngularFrac;
}
col.a = smoothstep(_LinesWidth, _LinesWidth * (0.99 - _LinesEdgeBlur), abs(LinesX));
col.a *= _LinesMode != 0? smoothstep(0, _LinesRadialOpacity, length(LinesUV)):1;
col.a *= _LinesOpacity;
