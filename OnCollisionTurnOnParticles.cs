using UnityEngine;
using System.Collections;

public class OnCollisionTurnOnParticles : MonoBehaviour {
	
	public ParticleEmitter pe;
	
	void OnCollisionEnter() {
		Debug.Log ("something hit me");
		pe.emit = true;
	}
	
}
