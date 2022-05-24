using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    bool isAnimating = false;
    float prevX = 1;
    float degrees;

    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;     
    }
    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }
    private void Update()
    {
        Vector3 worldMousePosition = GetWorldMousePosition();
        Vector3 diff = worldMousePosition - transform.position;
        degrees = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, degrees);

        if (diff.x > 0)
        {
            ClampNegativeRotation(degrees, 30, -90, 30);
        }
        else
        {
            ClampExtra(degrees, 150, -180, 180, -90, 150);
        }
    }

    private void ClampNegativeRotation(float degree, float min, float max, float clampValue)
    {
        if (degree <= min && degree >= max)
        {
            transform.rotation = Quaternion.Euler(0, 0, clampValue);
        }
    }
    private void ClampExtra(float degree, float mini1, float mini2, float maxi1, float maxi2, float clampValue2)
    {
        if ((degree >= mini1 && degree <= maxi1) || (degree >= mini2 && degree <= maxi2))
        {
            transform.rotation = Quaternion.Euler(0, 0, clampValue2);
        }
    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(screenPos);
        Debug.DrawLine(Vector3.zero, transform.position, Color.cyan);
        mousePosition.z = 0;
        return mousePosition;
    }
    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }
}
