using UnityEngine;

[ExecuteInEditMode]
public class PostProcess : MonoBehaviour
{
    [SerializeField] private Material material;

    private void OnRenderImage (RenderTexture source, RenderTexture destination) {
        UnityEngine.Debug.Log(source);
        UnityEngine.Debug.Log(destination);
        Graphics.Blit(source, destination, material);
    }    
}