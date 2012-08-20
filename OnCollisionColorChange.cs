using UnityEngine;
using System.Collections;

public class OnCollisionColorChange : MonoBehaviour {
	
	public Color[] collidingColors;
	public float colorFadeSecs = 0;
	public float colorMorphSpeed = 0.1f;
	
	private Color initialColor;
	private float timeLeftForColorFade;
	private bool inCollision;
	private bool isInCollision;
	private int curCollidingColorIndex = 0;
	private int nextCollidingColorIndex = 1;
	private Color curCollidingColor;
	private float collidingColorLerpAmount; //DEBUG
	
	void Start() {
		initialColor = transform.renderer.material.color;
		if (colorFadeSecs < 0) {
			colorFadeSecs = 0;
			Debug.LogWarning("colorFadeSecs cannot be negative. Setting to 0.", this);
		}
		timeLeftForColorFade = 0;
		curCollidingColor = collidingColors[0];
	}
	
	void OnCollisionEnter() {
		isInCollision = true;
		renderer.material.color = curCollidingColor;
		timeLeftForColorFade = colorFadeSecs;
	}
	
	void OnCollisionExit() {
		isInCollision = false;
		if (colorFadeSecs == 0) {
			renderer.material.color = initialColor;
		}
	}
	
	void UpdateCurrentColliderColor() {
		collidingColorLerpAmount += colorMorphSpeed * Time.deltaTime;		
		curCollidingColor = Color.Lerp (collidingColors[curCollidingColorIndex], 
			collidingColors[nextCollidingColorIndex], collidingColorLerpAmount);
	}
	
	void Update() {
		
		if (collidingColors.GetLength(0) >= 2) {
			UpdateCurrentColliderColor();			
		}
		
		if (!isInCollision && timeLeftForColorFade > 0) {
			timeLeftForColorFade -= Time.deltaTime;
			renderer.material.color = Color.Lerp(curCollidingColor, collidingColors[curCollidingColorIndex],
				timeLeftForColorFade / colorFadeSecs);
		}
		
	}
}