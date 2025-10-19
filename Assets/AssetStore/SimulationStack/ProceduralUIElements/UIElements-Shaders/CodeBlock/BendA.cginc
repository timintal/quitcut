
if (_EnableBending == 1)
{
    float YMirroring = _MirrorBending == 1 ? (UV.y > 0 ? -1 : 1) : 1;
    float XMirroring = _MirrorBending == 1 ? (UV.x > 0 ? -1 : 1) : 1;

    UV.y -= YMirroring * sin(i.uv.x * 3.1415) * _BendY;
    UV.x -= XMirroring * sin(i.uv.y * 3.1415) * _BendX;
    UV.y += YMirroring * _BendY;
    UV.x += XMirroring * _BendX;

    /*_BendX *= 5.0;
    _BendY *= 5.0;
    float2 UVA = UV;
    UV.y += UVA.x * UVA.x * _BendY * YMirroring;
    UV.x += UVA.y * UVA.y * _BendX * XMirroring;*/
}
