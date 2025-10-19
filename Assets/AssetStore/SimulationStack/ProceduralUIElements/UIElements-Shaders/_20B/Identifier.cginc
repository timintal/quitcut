if (_ShapeIdentifier == 1)
{
    float S1 = length(UV - float2(_X_1, _Y_1)) - 0.01;
    float S2 = length(UV - float2(_X_2, _Y_2)) - 0.01;
    float S3 = length(UV - float2(_X_3, _Y_3)) - 0.01;
    float S4 = length(UV - float2(_X_4, _Y_4)) - 0.01;
    float S5 = length(UV - float2(_X_5, _Y_5)) - 0.01;
    float S6 = length(UV - float2(_X_6, _Y_6)) - 0.01;
    col *= smoothstep(0.0, 0.01, S1);
    col *= smoothstep(0.0, 0.01, S2);
    col *= (_NoOfShapes >= 1) ? smoothstep(0.0, 0.01, S3) : 1;
    col *= (_NoOfShapes >= 2) ? smoothstep(0.0, 0.01, S4) : 1;
    col *= (_NoOfShapes >= 3) ? smoothstep(0.0, 0.01, S5) : 1;
    col *= (_NoOfShapes >= 4) ? smoothstep(0.0, 0.01, S6) : 1;
    col += float4(1, 0, 0, 1) * smoothstep(0.01, 0, S1);
    col += float4(0, 1, 0, 1) * smoothstep(0.01, 0, S2);
    col += float4(0, 0, 1, 1) * smoothstep(0.01, 0, S3) * (_NoOfShapes >= 1);
    col += float4(1, 1, 0, 1) * smoothstep(0.01, 0, S4) * (_NoOfShapes >= 2);
    col += float4(1, 1, 1, 1) * smoothstep(0.01, 0, S5) * (_NoOfShapes >= 3);
    col += float4(0, 0, 0, 1) * smoothstep(0.01, 0, S6) * (_NoOfShapes >= 4);
}