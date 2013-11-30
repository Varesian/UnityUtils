using UnityEngine;
using System.Collections;

public class AlphaRotator : MonoBehaviour {
	
	public float speed = 0.5f;
	private int changeDirection = 1;
		
	void Start() {
		if (speed > 1.0f || speed < 0) {
			Debug.LogError ("speed values must be between 0 and 1");
		}
	}
	
	// Update is called once per frame
	void Update () {
		float curAlpha = renderer.material.color.a;
		float newAlphaAmount = curAlpha + Time.deltaTime * speed * changeDirection;
		if (newAlphaAmount >= 1.0f || newAlphaAmount <= 0) {
			changeDirection *= -1;
			newAlphaAmount = curAlpha + Time.deltaTime * speed * changeDirection;
		}

		renderer.material.color = new Color(renderer.material.color.r,
			renderer.material.color.g, renderer.material.color.b, newAlphaAmount);
	}
}
