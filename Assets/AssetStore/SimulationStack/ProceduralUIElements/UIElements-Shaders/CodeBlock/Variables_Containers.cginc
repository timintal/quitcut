
float _MaskContainer;
float _Radius;
float _ChooseDimensionParameters;
float _Width, _Height;
float _WidthMargin, _HeightMargin;
float _PolygonSize, _PolygonTurns, _PolygonEdgeAngle;
float _HeartSize;



float RoundBoxSDF(float2 p, float2 b, float4 r)
{
    r.xy = (p.x > 0.0) ? r.xy : r.zw;
    r.x = (p.y > 0.0) ? r.x : r.y;
    float2 q = abs(p) - b + r.x;
    return min(max(q.x, q.y), 0.0) + length(max(q, 0.0)) - r.x;
}

float HeartSDF_Custom(float2 p)
{
    p *= 1.3;
    p.y += 0.55;
    p.x = abs(p.x);
    if (p.y + p.x > 1.0)
        return sqrt(dot2(p - float2(0.25, 0.75))) - sqrt(2.0) / 4.0;
    return sqrt(min(dot2(p - float2(0.00, 1.00)),
        dot2(p - 0.5 * max(p.x + p.y, 0.0)))) * sign(p.x - p.y);
}

float StarSDF(float2 p, float r, int n, float m)
{
    p.y += n==3? 0.0:0;
    p.y += n == 5 ? -0.0 : 0;
    float an = 3.141593 / float(n);
    float en = 3.141593 / m;
    float2  acs = float2(cos(an), sin(an));
    float2  ecs = float2(cos(en), sin(en));
    p.x = abs(p.x);
    float2 value = float2(atan2(p.x, p.y), 2.0 * an);
    float bn = (value.x - value.y * floor(value.x / value.y)) - an;
    p = length(p) * float2(cos(bn), abs(sin(bn)));
    p -= r * acs;
    p += ecs * clamp(-dot(p, ecs), 0.0, r * acs.y / ecs.y);
    return length(p) * sign(p.x);
}
