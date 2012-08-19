using UnityEngine;
using System.Collections;

public class OnCollisionColorChange : MonoBehaviour {
	
	public Color collidingColor;
	public float colorFadeSecs = 0;
	private Color initialColor;
	private float timeLeftForColorFade;
	private bool inCollision;
	private bool isInCollision;
	
	void Start() {
		initialColor = transform.renderer.material.color;
		if (colorFadeSecs < 0) {
			colorFadeSecs = 0;
			Debug.LogWarning("colorFadeSecs cannot be negative. Setting to 0.", this);
		}
		timeLeftForColorFade = colorFadeSecs;
	}
	
	void OnCollisionEnter() {
		isInCollision = true;
		renderer.material.color = collidingColor;
		timeLeftForColorFade = colorFadeSecs;
	}
	
	void OnCollisionExit() {
		isInCollision = false;
		if (colorFadeSecs == 0) {
			renderer.material.color = initialColor;
		}
	}
	
	void Update() {
		if (!isInCollision && timeLeftForColorFade > 0) {
			timeLeftForColorFade -= Time.deltaTime;
			renderer.material.color = Color.Lerp(initialColor, collidingColor,
				timeLeftForColorFade / colorFadeSecs);
		}
	}
}