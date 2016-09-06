using UnityEngine;
using System.Collections;

public class CameraMouseMovement : MonoBehaviour 
{
	public float moveSpeed;
	private int border = 15;
	public int minX;
	public int maxX;
	public int minZ;
	public int maxZ;

	public int zoomMax;
	public int zoomMin;
	public float zoomSpeed;

	private float mouseXrotate;
	public float rotateSpeed;

	void Update()
	{
		MoveMouse();
		ZoomCamera();
		RotateCamera();

	}

	void LateUpdate()
	{
		mouseXrotate = Input.mousePosition.x;
	}

	void RotateCamera()
	{
		if (Input.GetMouseButton(2))
		{
			if (Input.mousePosition.x != mouseXrotate) 
			{
				var cameraRotationX = (Input.mousePosition.x - mouseXrotate) * rotateSpeed * Time.deltaTime; 
				transform.Rotate (0, cameraRotationX, 0);

			}
		}
	}

	void MoveMouse()
	{
		var mouseX = Input.mousePosition.x;
		var mouseY = Input.mousePosition.y;
		var previousPosition = Vector3.zero;
		var currentPosition = Vector3.zero;

		previousPosition = transform.position;

		if (mouseX < border) 
			transform.Translate (Vector3.right * -moveSpeed * Time.deltaTime);

		if (mouseX >= Screen.width - border)
			transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);

		if (mouseY < border)
			transform.Translate (Vector3.forward * -moveSpeed * Time.deltaTime);

		if (mouseY >= Screen.height - border)
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

		currentPosition = transform.position;

		if (currentPosition.z < minZ || currentPosition.z > maxZ)
			transform.position = previousPosition;

		if (currentPosition.x < minX || currentPosition.x > maxX)
			transform.position = previousPosition;
	}

	void ZoomCamera()
	{
		if (transform.position.y > zoomMin && Input.GetAxis ("Mouse ScrollWheel") > 0)
			transform.Translate (0, -zoomSpeed, zoomSpeed);

		if (transform.position.y < zoomMax && Input.GetAxis ("Mouse ScrollWheel") < 0)
			transform.Translate (0, zoomSpeed, -zoomSpeed);
	}
}
