if (_PointsIdentifier == 1)
{
    float R = 0.025;
    float S1 = length(UV - float2(_X_1, _Y_1)) - R;
    float S2 = length(UV - float2(_X_2, _Y_2)) - R;
    float S3 = length(UV - float2(_X_3, _Y_3)) - R;
    float S4 = length(UV - float2(_X_4, _Y_4)) - R;
    float S5 = length(UV - float2(_X_5, _Y_5)) - R;
    float S6 = length(UV - float2(_X_6, _Y_6)) - R;
    float S7 = length(UV - float2(_X_7, _Y_7)) - R;
    float S8 = length(UV - float2(_X_8, _Y_8)) - R;
    float S9 = length(UV - float2(_X_9, _Y_9)) - R;
    float S10 = length(UV - float2(_X_10, _Y_10)) - R;
    col *= smoothstep(0.0, 0.01, S1);
    col *= smoothstep(0.0, 0.01, S2);
    col *= smoothstep(0.0, 0.01, S3);
    col *= (_NoOfPoints >= 1) ? smoothstep(0.0, 0.01, S4) : 1;
    col *= (_NoOfPoints >= 2) ? smoothstep(0.0, 0.01, S5) : 1;
    col *= (_NoOfPoints >= 3) ? smoothstep(0.0, 0.01, S6) : 1;
    col *= (_NoOfPoints >= 4) ? smoothstep(0.0, 0.01, S7) : 1;
    col *= (_NoOfPoints >= 5) ? smoothstep(0.0, 0.01, S8) : 1;
    col *= (_NoOfPoints >= 6) ? smoothstep(0.0, 0.01, S9) : 1;
    col *= (_NoOfPoints >= 7) ? smoothstep(0.0, 0.01, S10) : 1;
    col += float4(1, 0, 0, 1) * smoothstep(0.01, 0, S1);
    col += float4(0, 1, 0, 1) * smoothstep(0.01, 0, S2);
    col += float4(0, 0, 1, 1) * smoothstep(0.01, 0, S3);
    col += float4(1, 1, 0, 1) * smoothstep(0.01, 0, S4) * (_NoOfPoints >= 1);
    col += float4(1, 1, 1, 1) * smoothstep(0.01, 0, S5) * (_NoOfPoints >= 2);
    col += float4(0, 0, 0, 1) * smoothstep(0.01, 0, S6) * (_NoOfPoints >= 3);
    col += float4(0.3, 0.0, 0.0, 1) * smoothstep(0.01, 0, S7) * (_NoOfPoints >= 4);
    col += float4(0.5, 0, 1, 1) * smoothstep(0.01, 0, S8) * (_NoOfPoints >= 5);
    col += float4(0, 0.5, 1, 1) * smoothstep(0.01, 0, S9) * (_NoOfPoints >= 6);
    col += float4(0.0, 0.2, 0, 1) * smoothstep(0.01, 0, S10) * (_NoOfPoints >= 7);
}