using UnityEngine;
public static class MaterialExtensions
{
    public static void ToOpaqueMode(Material material)
    {
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        material.SetInt("_ZWrite", 1);
        material.SetInt("_Surface", 0);

        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Geometry;

        material.SetShaderPassEnabled("DepthOnly", true);
        material.SetShaderPassEnabled("SHADOWCASTER", false);

        material.SetOverrideTag("RenderType", "Opaque");

        material.DisableKeyword("_SURFACE_TYPE_TRANSPARENT");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.SetColor("_BaseColor", new Color(
            material.color.r,
            material.color.g,
            material.color.b,
            1f
        ));
    }

    public static void ToTransparentMode(Material material)
    {
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.SetInt("_Surface", 1);

        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;

        material.SetShaderPassEnabled("DepthOnly", false);
        material.SetShaderPassEnabled("SHADOWCASTER", false);

        material.SetOverrideTag("RenderType", "Transparent");

        material.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
        material.EnableKeyword("_ALPHAPREMULTIPLY_ON");

        material.SetColor("_BaseColor", new Color(
            material.color.r,
            material.color.g,
            material.color.b,
            0.3f
        ));
    }
}