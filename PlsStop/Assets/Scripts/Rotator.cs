using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    Vector3 dif;
    [SerializeField]
    float speed;

    Vector3 velocity;
    Vector3 displacement;
    public Vector3 mousePosition;
    Vector3 screenPos;

    public Vector3 objPosition;

    public float distance;

    public float minRotation = 22.5f;
    public float maxRotation = 67.5f;

    
    void Update()
    {
        //ROTATION
        Vector3 worldMousePosition = GetWorldMousePosition();

        dif = worldMousePosition - transform.position;
        float radians = Mathf.Atan2(dif.y, dif.x);
        transform.localRotation = Quaternion.Euler(0f, 0f, radians * Mathf.Rad2Deg);

        //LIMIT ROTATION
        if (transform.eulerAngles.z > maxRotation)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, maxRotation);
        }
    }

    public Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        mousePosition = Camera.main.ScreenToWorldPoint(screenPos);
        Debug.DrawLine(Vector3.zero, transform.position, Color.cyan);
        mousePosition.z = 0;
        return mousePosition;
    }
}
