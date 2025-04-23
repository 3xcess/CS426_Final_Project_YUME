Shader "Unlit/MetallicShinyUnlit"
{
    Properties
    {
        _BaseMap ("Base Map (Albedo)", 2D) = "white" {}
        _MetallicMap ("Metallic Map (Grayscale)", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _EmissionMap ("Emission Map", 2D) = "black" {}
        
        _Color ("Color Tint", Color) = (1,1,1,1)
        _SpecColor ("Specular Color", Color) = (1,1,1,1)
        _Glossiness ("Glossiness", Range(0, 1)) = 0.8
        _Shininess ("Shininess", Range(1, 200)) = 100
        _EmissionStrength ("Emission Strength", Range(0, 5)) = 1
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float3 viewDir : TEXCOORD1;
                float3x3 tbnMatrix : TEXCOORD2;
                UNITY_FOG_COORDS(5)
                float4 vertex : SV_POSITION;
            };

            sampler2D _BaseMap;
            float4 _BaseMap_ST;

            sampler2D _MetallicMap;
            float4 _MetallicMap_ST;

            sampler2D _NormalMap;
            float4 _NormalMap_ST;

            sampler2D _EmissionMap;
            float4 _EmissionMap_ST;

            float4 _Color;
            float4 _SpecColor;
            float _Glossiness;
            float _Shininess;
            float _EmissionStrength;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _BaseMap);

                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                float3 worldNormal = UnityObjectToWorldNormal(v.normal);
                float3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
                float3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w;

                o.tbnMatrix = float3x3(worldTangent, worldBinormal, worldNormal);
                o.viewDir = normalize(_WorldSpaceCameraPos - worldPos);
                
                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Sample and unpack the normal map
                float3 normalTS = UnpackNormal(tex2D(_NormalMap, i.uv));
                float3 normalWS = normalize(mul(normalTS, i.tbnMatrix));

                // Fake light from top right
                float3 lightDir = normalize(float3(0.5, 1.0, 0.5));
                float3 reflectDir = reflect(-lightDir, normalWS);
                float specFactor = pow(saturate(dot(i.viewDir, reflectDir)), _Shininess);

                float4 albedo = tex2D(_BaseMap, i.uv) * _Color;
                float metallicMask = tex2D(_MetallicMap, i.uv).r;
                float3 specular = _SpecColor.rgb * specFactor * _Glossiness * metallicMask;

                float3 emission = tex2D(_EmissionMap, i.uv).rgb * _EmissionStrength;

                float3 finalColor = albedo.rgb + specular + emission;
                float4 col = float4(finalColor, albedo.a);

                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
