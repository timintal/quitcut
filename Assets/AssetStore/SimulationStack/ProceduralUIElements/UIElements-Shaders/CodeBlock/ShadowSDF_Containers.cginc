                if (_MaskContainer == 0)
                {
                    ShadowSDF = length(ShadowUV) - _Radius;
                }
                else if (_MaskContainer == 1)
                {
                    ShadowSDF = RoundBoxSDF(ShadowUV, float2(_Width, _Height), _CornerRoundness);
                }
                else if (_MaskContainer == 2)
                {
                    ShadowSDF = StarSDF(ShadowUV, _PolygonSize, _PolygonTurns, _PolygonEdgeAngle) - _CornerRoundness;
                }
                else if (_MaskContainer == 3)
                {
                    ShadowSDF = HeartSDF_Custom(ShadowUV * (12 - _HeartSize));
                }