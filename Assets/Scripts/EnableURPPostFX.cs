using UnityEngine;
using UnityEngine.Rendering.Universal;

[ExecuteAlways]
public class EnableURPPostFX : MonoBehaviour
{
    void Start()
    {
        var camera = GetComponent<Camera>();
        var additionalData = camera.GetUniversalAdditionalCameraData();

        if (additionalData != null)
        {
            additionalData.renderPostProcessing = true;
            Debug.Log("✅ Post-processing enabled manually.");
        }
        else
        {
            Debug.LogWarning("⚠️ Could not find URP camera data.");
        }
    }
}
