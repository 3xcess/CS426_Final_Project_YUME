Shader "Custom/LitSwordWithHitFlash_Emission"
{
    Properties
    {
        _BaseMap ("Base Map", 2D) = "white" {}
        _BaseColor ("Base Color", Color) = (1,1,1,1)
        _Metallic ("Metallic", Range(0,1)) = 1
        _Smoothness ("Smoothness", Range(0,1)) = 0.9

        _HitColor ("Hit Flash Color", Color) = (1,0,0,1)
        _HitEffectIntensity ("Hit Flash Intensity", Range(0,1)) = 0

        _EmissionColor ("Emission Color", Color) = (1,0,0,1)
        _EmissionIntensity ("Emission Intensity", Range(0, 10)) = 2
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        LOD 200

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normalWS : TEXCOORD1;
                float3 positionWS : TEXCOORD2;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);
            float4 _BaseMap_ST;

            float4 _BaseColor;
            float _Metallic;
            float _Smoothness;

            float4 _HitColor;
            float _HitEffectIntensity;

            float4 _EmissionColor;
            float _EmissionIntensity;

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseMap);
                OUT.normalWS = normalize(TransformObjectToWorldNormal(IN.normalOS));
                OUT.positionWS = TransformObjectToWorld(IN.positionOS.xyz);
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                float3 normal = normalize(IN.normalWS);
                float3 viewDir = normalize(_WorldSpaceCameraPos - IN.positionWS);

                Light light = GetMainLight();
                float3 lightDir = normalize(light.direction);
                float3 halfDir = normalize(lightDir + viewDir);

                float3 baseMap = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv).rgb;
                float3 albedo = baseMap * _BaseColor.rgb;

                albedo = lerp(albedo, _HitColor.rgb, _HitEffectIntensity);

                float NdotL = saturate(dot(normal, lightDir));
                float spec = pow(saturate(dot(normal, halfDir)), _Smoothness * 128.0);

                float3 diffuse = albedo * light.color * NdotL;
                float3 specular = _Metallic * _BaseColor.rgb * spec * light.color;

                float3 emission = _EmissionColor.rgb * _EmissionIntensity * _HitEffectIntensity;

                float3 finalColor = diffuse + specular + emission;
                return float4(finalColor, 1.0);
            }

            ENDHLSL
        }
    }

    FallBack "Hidden/InternalErrorShader"
}
