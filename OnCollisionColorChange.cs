using UnityEngine;
using System.Collections;

public class OnCollisionColorChange : MonoBehaviour {
	
	public Color[] collidingColors;
	public float colorFadeSecs = 0;
	public float colorMorphSpeed = 0.1f;
	
	private Color initialColor;
	private float timeLeftForColorFade;
	private bool isInCollision;
	private int curCollidingColorIndex = 0;
	private int nextCollidingColorIndex = 1;
	private Color curCollidingColor;
	//0 to 1 (how much to blend nth and (n+1)th colors in array
	private float collidingColorLerpAmount; 
	private Color colorAtCollision;
	
	void Start() {
		initialColor = transform.renderer.material.color;
		if (colorFadeSecs < 0) {
			colorFadeSecs = 0;
			Debug.LogWarning("colorFadeSecs cannot be negative. Setting to 0.", this);
		}
		timeLeftForColorFade = 0;
		curCollidingColor = collidingColors[0];
	}
	
	public void Collide() {
		OnCollisionEnter ();
	}
	
	public void ColliderExit() {
		OnCollisionExit ();
	}
	
	void OnCollisionEnter() {
		isInCollision = true;
		renderer.material.color = curCollidingColor;
		colorAtCollision = curCollidingColor;
		timeLeftForColorFade = colorFadeSecs;
	}
	
	void OnCollisionExit() {
		isInCollision = false;
		if (colorFadeSecs == 0) {
			renderer.material.color = initialColor;
		}
	}
	
	//modulo incrementer. So array indices stay within bounds when cycling through colors
	int modIncrement(int i) {
		return i % collidingColors.GetLength(0);
	}
	
	void UpdateCurrentColliderColor() {
		collidingColorLerpAmount += colorMorphSpeed * Time.deltaTime;		
		curCollidingColor = Color.Lerp (collidingColors[curCollidingColorIndex], 
			collidingColors[nextCollidingColorIndex], collidingColorLerpAmount);
		
		if (collidingColorLerpAmount > 1.0f) {
			collidingColorLerpAmount = 0;
			curCollidingColorIndex = modIncrement(curCollidingColorIndex + 1);
			nextCollidingColorIndex = modIncrement(nextCollidingColorIndex + 1);
		}
	}
	
	void Update() {
		
		if (collidingColors.GetLength(0) >= 2) {
			UpdateCurrentColliderColor();			
		}
		
		if (!isInCollision && timeLeftForColorFade > 0) {
			timeLeftForColorFade -= Time.deltaTime;
			renderer.material.color = Color.Lerp(initialColor, colorAtCollision,
				timeLeftForColorFade / colorFadeSecs);
		}
		
	}
}