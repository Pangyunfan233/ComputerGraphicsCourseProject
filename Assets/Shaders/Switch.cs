using UnityEngine;
using UnityEngine.InputSystem;  

public class ShaderSwitcher : MonoBehaviour
{
    private Renderer targetRenderer;

    public Material diffuseMat;
    public Material ambientMat;
    public Material specularMat;
    public Material wrapMat;

    void Start()
    {
        targetRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            targetRenderer.material = diffuseMat;

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            targetRenderer.material = ambientMat;

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            targetRenderer.material = specularMat;

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
            targetRenderer.material = wrapMat;
    }
}
