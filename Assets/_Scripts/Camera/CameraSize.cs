using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraSize : MonoBehaviour
{
    private Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        CheckCameraSize();
    }

    public void CheckCameraSize()
    {
        var resolution = Screen.safeArea;

        float rate = resolution.height / resolution.width;

        rate = Mathf.Max(rate, 1f);

        camera.orthographicSize *= rate;
    }
}
