Shader "Custom/UnderwaterDistortionShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _Distortion ("Distortion", Range (0, 1)) = 0.5
        _WaveSpeed ("Wave Speed", Range (0, 10)) = 1
    }
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _NormalMap;
            float4 _NormalMap_ST;
            float _Distortion;
            float _WaveSpeed;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                float2 uv = i.uv;
                float2 normal = UnpackNormal(tex2D(_NormalMap, uv));
                uv.x += sin((uv.y + _Time.y * _WaveSpeed) * 10) * _Distortion * normal.x;
                uv.y += sin((uv.x + _Time.y * _WaveSpeed) * 10) * _Distortion * normal.y;
                fixed4 col = tex2D(_MainTex, uv);
                return col;
            }
            ENDCG
        }
    }
}