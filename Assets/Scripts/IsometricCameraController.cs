using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCameraController : MonoBehaviour
{
    public float panSpeed = 10f;
    public float smoothTime = 0.2f;

    public float zoomSpeed = 5f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public Camera cam;

    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        targetPosition = transform.position;
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    void Update()
    {
        HandleZoom();
        HandleInput();
        SmoothMovement();
    }

    void HandleInput()
    {
#if UNITY_WEBGL || UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;

            targetPosition += new Vector3(-mouseX, -mouseY, 0f);
        }
#endif

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float touchX = touch.deltaPosition.x * panSpeed * Time.deltaTime;
                float touchY = touch.deltaPosition.y * panSpeed * Time.deltaTime;

                targetPosition += new Vector3(-touchX, -touchY, 0f);
            }
        }
    }
    void HandleZoom()
    {
#if UNITY_WEBGL || UNITY_EDITOR
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            if (cam.orthographic)
            {
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - scroll * zoomSpeed, minZoom, maxZoom);
            }
            else
            {
                cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - scroll * zoomSpeed, minZoom, maxZoom);
            }
        }
#endif

        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
            float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;

            float touchDeltaMag = (touch0.position - touch1.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            if (cam.orthographic)
            {
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + deltaMagnitudeDiff * zoomSpeed * Time.deltaTime, minZoom, maxZoom);
            }
            else
            {
                cam.fieldOfView = Mathf.Clamp(cam.fieldOfView + deltaMagnitudeDiff * zoomSpeed * Time.deltaTime, minZoom, maxZoom);
            }
        }
    }

    void SmoothMovement()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
