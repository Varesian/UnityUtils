using UnityEngine;
using System.Collections;

public class ColorMorpher : MonoBehaviour {
	
	public float minRedVal = 0.25f;
	public float maxRedVal = 1.0f;
	public float colorChangeSpeed = 0.01f;
	private int colorChangeDirection = 1;
		
	// Update is called once per frame
	void Update () {
		float curRedVal = renderer.material.color.r;
		float newRedVal = curRedVal + colorChangeSpeed * colorChangeDirection;
		if (newRedVal > maxRedVal || newRedVal < minRedVal) {
			colorChangeDirection *= -1;
			newRedVal = curRedVal + colorChangeSpeed * colorChangeDirection * Time.deltaTime;
		}
		
		renderer.material.color = new Color(newRedVal, renderer.material.color.g, 
			renderer.material.color.b, renderer.material.color.a);
	}
}
