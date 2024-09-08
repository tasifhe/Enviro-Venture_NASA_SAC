using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCameraController : MonoBehaviour
{
    public float panSpeed = 10f;
    public float touchPanSpeed = 0.1f;

    void Update()
    {
#if UNITY_WEBGL || UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;

            transform.position += new Vector3(-mouseX, -mouseY, 0f);
        }
#endif

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float touchX = touch.deltaPosition.x * touchPanSpeed * Time.deltaTime;
                float touchY = touch.deltaPosition.y * touchPanSpeed * Time.deltaTime;

                transform.position += new Vector3(-touchX, -touchY, 0f);
            }
        }
    }
}
