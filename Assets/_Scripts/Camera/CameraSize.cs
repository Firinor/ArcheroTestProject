using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraSize : MonoBehaviour
{
    private Camera cameraToTune;

    private void Awake()
    {
        cameraToTune = GetComponent<Camera>();
        CameraOrthographicSizeFitter();
    }

    public void CameraOrthographicSizeFitter()
    {
        var resolution = Screen.safeArea;

        float rate = resolution.height / resolution.width;

        //If the rate is less than 1, then the entire level will be visible.
        rate = Mathf.Max(rate, 1f);

        cameraToTune.orthographicSize *= rate;
    }
}
