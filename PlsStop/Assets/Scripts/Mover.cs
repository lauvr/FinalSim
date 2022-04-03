using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	[SerializeField]
	float speed;

	Vector3 worldPos;
	Vector2 position;

	Rigidbody2D rb;

    private void Start()
    {
		rb = GetComponent<Rigidbody2D>();  
    }


    // Update is called otnce per frame
    void Update()
	{
		Camera camera = Camera.main;
		Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
		worldPos = Camera.main.ScreenToWorldPoint(screenPos);
		position = Vector2.Lerp(transform.position, worldPos, speed);

		Debug.DrawLine(Vector3.zero, transform.position, Color.cyan);


		//float radians = Mathf.Atan2(dif.y, dif.x);
		//transform.localRotation = Quaternion.Euler(0f, 0f, radians * Mathf.Rad2Deg);


	}

    private void FixedUpdate()
    {
		rb.MovePosition(position);
    }
}
