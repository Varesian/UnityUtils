using UnityEngine;
using System.Collections;

public class OnCollisionColorChange : MonoBehaviour {
	
	public Color collidingColor;
	private Color initialColor;
	
	void Start() {
		initialColor = transform.renderer.material.color;
	}
	
	void OnCollisionEnter() {
		transform.renderer.material.color = collidingColor;
	}
	
	void OnCollisionExit() {
		transform.renderer.material.color = initialColor;
	}
	
}
