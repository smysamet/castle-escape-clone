using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScreenResolutionController : MonoBehaviour
{

    private void Awake()
    {
        //Set screen size for Standalone
#if UNITY_STANDALONE
        Screen.SetResolution(564, 960, false);
        Screen.fullScreen = false;
#endif
    }


    public float desiredAspectRatio = 9f / 16f; // Desired aspect ratio (e.g., 16:9)

    [SerializeField]
    Camera camObject;
    Camera cam;

    private void Start()
    {
        cam = camObject.GetComponent<Camera>();
        UpdateCameraAspect();
    }

    private void Update()
    {
        // Check if the current aspect ratio is different from the desired aspect ratio
        if (Mathf.Abs(cam.aspect - desiredAspectRatio) > 0.01f)
        {
            UpdateCameraAspect();
        }
    }

    private void UpdateCameraAspect()
    {
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / desiredAspectRatio;

        Rect rect = cam.rect;

        if (scaleHeight < 1)
        {
            rect.width = 1;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1 - scaleHeight) / 2;
        }
        else
        {
            float scaleWidth = 1f / scaleHeight;
            rect.width = scaleWidth;
            rect.height = 1;
            rect.x = (1 - scaleWidth) / 2;
            rect.y = 0;
        }

        cam.rect = rect;
    }
}
