
fixed4 col = fixed4(0, 0, 0, 0);
float2 UV = i.uv - float2(0.5, 0.5);

float Min = _Radius - _CellHeight;
float Max = _Radius + _CellHeight;
float ZeroToOne = (length(UV) - Min) / (Max - Min);

float Radial = (length(UV) - _Radius) * _NumberOfCells * (1/_Radius)*0.16;//*lerp(0.185,0.14,ZeroToOne);// (length(UV) - Min) / (Max - Min);
float Angular = ((atan2(UV.y, UV.x) + 3.1415926) / 6.2831852);
//Radial -= 0.5;
float AngularFrac = frac(Angular * _NumberOfCells) - 0.5;
float SDF = BoxSDF(float2(Radial, AngularFrac), float2(_CellHeight, _CellWidth)) - _CornerRoundness;
