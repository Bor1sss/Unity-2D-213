using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField]
    private Transform rotAnchor;

    private float minRotAngle = -50.0f;
    private float maxRotAngle = 70.0f;

    private Vector2 lastMousePosition;

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
          
        if (Input.GetMouseButton(0))
        {
            Vector2 currentMousePosition = Input.mousePosition;
            float dy = currentMousePosition.y - lastMousePosition.y;

            float curRotAngle = NormalizeAngle(transform.eulerAngles.z);
            float newAngle = curRotAngle + dy * 0.1f; 

           
            if (newAngle > minRotAngle && newAngle < maxRotAngle)
            {
                transform.RotateAround(rotAnchor.position, Vector3.forward, -dy * 0.1f);
            }

            lastMousePosition = currentMousePosition;
        }
    }

    private float NormalizeAngle(float angle)
    {
        angle = angle % 360;
        if (angle > 180) angle -= 360;
        return angle;
    }
}