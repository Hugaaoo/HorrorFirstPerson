using UnityEngine;
using UnityEngine.UI;

public class SwitchRenderTexture : MonoBehaviour
{
    public Camera myCamera;
    public RenderTexture firstRenderTexture;
    public RenderTexture secondRenderTexture;
    public RawImage firstRawImage;
    public RawImage secondRawImage;

    void Start()
    {
        // Assurez-vous que la cam�ra utilise la premi�re Render Texture au d�marrage
        myCamera.targetTexture = firstRenderTexture;
        // D�sactivez le deuxi�me RawImage au d�marrage
        secondRawImage.gameObject.SetActive(false);
    }

    public void SwitchToFirstTexture()
    {
        // Changez la Render Texture de la cam�ra � la premi�re
        myCamera.targetTexture = firstRenderTexture;
        // D�sactivez le deuxi�me RawImage
        secondRawImage.gameObject.SetActive(false);
        // Activez le premier RawImage
        firstRawImage.gameObject.SetActive(true);
    }

    public void SwitchToSecondTexture()
    {
        // Changez la Render Texture de la cam�ra � la deuxi�me
        myCamera.targetTexture = secondRenderTexture;
        // D�sactivez le premier RawImage
        firstRawImage.gameObject.SetActive(false);
        // Activez le deuxi�me RawImage
        secondRawImage.gameObject.SetActive(true);
    }
}
