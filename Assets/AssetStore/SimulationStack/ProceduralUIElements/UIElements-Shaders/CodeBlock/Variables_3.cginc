
float4 _ImageSizeRatio;
float _Size;
float _Turns;
float _EdgeAngle;
float _CornerRoundness;
float _EnableRim;
float _RimWidth;
float _RimGamma;
float _EdgeBlur;
float _Rotation;

float StarSDF(float2 p, float r, int n, float m)
{
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
