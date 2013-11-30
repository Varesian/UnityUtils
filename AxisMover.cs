using UnityEngine;
using System.Collections;

public class AxisMover : MonoBehaviour {
			
	public float speed = 0.1f;
	public float xOffset, yOffset, zOffset;
	private Vector3 startPosition;
	private Vector3 farthestPosition;
	private int changeDirection = 1;
	private float lerpAmount = 0.0f;
		
	// Use this for initialization
	void Start() {
		startPosition = transform.position;
		farthestPosition = transform.position + new Vector3(xOffset, yOffset, zOffset);
	}
	
	// Update is called once per frame
	void Update () {
		
		float newLerpAmount = lerpAmount + Time.deltaTime * speed * changeDirection;
		
		if (newLerpAmount >= 1.0f || newLerpAmount <= 0) {
			changeDirection *= -1;
			newLerpAmount = lerpAmount + Time.deltaTime * speed * changeDirection;
		}
		lerpAmount = newLerpAmount;

		transform.position = Vector3.Lerp(startPosition, farthestPosition, lerpAmount);
	}
}
