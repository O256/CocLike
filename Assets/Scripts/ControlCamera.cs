using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public Vector2 minBounds;
    public Vector2 maxBounds;
    public float minZoom;
    public float maxZoom;
    public float zoomSensitivity;
    public float moveSensitivity;

    private Vector3 dragOrigin;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // 处理缩放
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cam.orthographicSize -= scroll * zoomSensitivity;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);

        // 处理移动
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += difference * moveSensitivity;
        }

        // 限制相机移动范围
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = minBounds.x + camWidth;
        float maxX = maxBounds.x - camWidth;
        float minY = minBounds.y + camHeight;
        float maxY = maxBounds.y - camHeight;

        float newX = Mathf.Clamp(cam.transform.position.x, minX, maxX);
        float newY = Mathf.Clamp(cam.transform.position.y, minY, maxY);

        cam.transform.position = new Vector3(newX, newY, cam.transform.position.z);
    }
}
