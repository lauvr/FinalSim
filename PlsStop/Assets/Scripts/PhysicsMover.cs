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
	Vector3 worldPos;
	Vector3 screenPos;

	// Update is called otnce per frame
	void Update()
	{
		Vector3 worldMousePosition = GetWorldMousePosition();
		Vector3 dir = (worldMousePosition - transform.position).normalized;
		velocity = dir * speed;
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
		worldPos = Camera.main.ScreenToWorldPoint(screenPos);
		Debug.DrawLine(Vector3.zero, transform.position, Color.cyan);
		worldPos.z = 0;
		return worldPos;
	}

	public void Mover()
	{
        if (transform.position == screenPos)
        {
			Debug.Log("Match mouse position");
			displacement = Vector3.zero;
        }
        else
        {
			displacement = velocity * Time.deltaTime;
			transform.position = transform.position + displacement;
        }
	}
}
