#include "UnityCG.cginc"
#include "UnityUI.cginc"

struct appdata_t
{
    float4 vertex : POSITION;
    float2 uv : TEXCOORD0;

    float4 color : COLOR;
    UNITY_VERTEX_INPUT_INSTANCE_ID
};

struct v2f
{
    float4 vertex : POSITION;
    float4 uvgrab : TEXCOORD0;
    float2 uv: TEXCOORD1;

    fixed4 color : COLOR;
    UNITY_VERTEX_OUTPUT_STEREO
};

sampler2D _MainTex;
float4 _MainTex_ST;

sampler2D _GrabTexture;
float4 _GrabTexture_TexelSize;

float _BlurMagnitude;

float _EnableNoise;
float _TextureScale;
float _NoiseIntensity;
float4  _NoiseAnimate;

float dot2(float2 v) { return dot(v, v); }
#include "/Variables.cginc"


v2f vert(appdata_t v)
{
    v2f o;
    UNITY_SETUP_INSTANCE_ID(v);
    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);

    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = TRANSFORM_TEX(v.uv, _MainTex);

#if UNITY_UV_STARTS_AT_TOP
    float scale = -1.0;
#else
    float scale = 1.0;
#endif
    o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y * scale) + o.vertex.w) * 0.5;
    o.uvgrab.zw = o.vertex.zw;

    o.color = v.color * fixed4(1, 1, 1, 1);

    return o;
}