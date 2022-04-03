using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMover : MonoBehaviour
{
	[SerializeField]
	float speed;

	//Vector3 dif;
	Vector3 velocity;
	Vector3 displacement;
	public Vector3 mousePosition;
	Vector3 screenPos;

	public Vector3 objPosition;

	public float distance;


	// Update is called otnce per frame
	void FixedUpdate()
	{
		objPosition = this.transform.position;

		Vector3 worldMousePosition = GetWorldMousePosition();
		Vector3 dir = (worldMousePosition - transform.position).normalized;
		dir.y = 0;
		velocity = dir * speed;
		distance = Vector3.Distance(mousePosition, objPosition);
		Mover();

		//ROTATION
		//dif = worldMousePosition - transform.position;
		//float radians = Mathf.Atan2(dif.y, dif.x);
		//transform.localRotation = Quaternion.Euler(0f, 0f, radians * Mathf.Rad2Deg);
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

	public void Mover()
	{
        if (distance < 0.1)
        {
			displacement = Vector3.zero;
        }
        else
        {
			displacement = velocity * Time.deltaTime;
			transform.position = transform.position + displacement;
        }
	}
}
