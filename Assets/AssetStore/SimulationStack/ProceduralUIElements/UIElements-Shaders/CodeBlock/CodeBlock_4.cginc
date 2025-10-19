
Points[0].xy = float2(_X_1, _Y_1);
Points[1].xy = float2(_X_2, _Y_2);
Points[2].xy = float2(_X_3, _Y_3);
Points[3].xy = float2(_X_4, _Y_4);
Points[4].xy = float2(_X_5, _Y_5);
Points[5].xy = float2(_X_6, _Y_6);
Points[6].xy = float2(_X_7, _Y_7);
Points[7].xy = float2(_X_8, _Y_8);
Points[8].xy = float2(_X_9, _Y_9);
Points[9].xy = float2(_X_10, _Y_10);

float SDF = PolygonSDF(UV, Points, _NoOfPoints + 3) - _CornerRoundness;
