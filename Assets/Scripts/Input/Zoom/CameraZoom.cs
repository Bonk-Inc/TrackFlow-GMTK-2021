using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private float zoomSpeed;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float min = 1, max = 20;

    private void Update()
    {
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + Input.mouseScrollDelta.y * -zoomSpeed, min, max);
    }

}
