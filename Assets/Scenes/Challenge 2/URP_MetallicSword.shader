Shader "Custom/URP_MetallicSword_NoLight"
{
    Properties
    {
        _BaseMap("Albedo (RGB)", 2D) = "white" {}
        _BaseColor("Color Tint", Color) = (1,1,1,1)
        _Metallic("Metallic", Range(0,1)) = 1
        _Smoothness("Smoothness", Range(0,1)) = 0.8
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "Queue" = "Geometry" }

        Pass
        {
            Name "Unlit"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);
            float4 _BaseColor;
            float _Metallic;
            float _Smoothness;

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = IN.uv;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                float4 baseMap = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv);
                float3 color = baseMap.rgb * _BaseColor.rgb;

                // Fake lighting: brighter edges
                float3 fakeLight = color * (0.5 + 0.5 * dot(normalize(float3(IN.uv - 0.5, 0.5)), float3(0,0,1)));

                return float4(fakeLight, 1.0);
            }

            ENDHLSL
        }
    }

    FallBack "Hidden/InternalErrorShader"
}
