using UnityEngine;
using System.Collections;

public class RespawnIfFalls : MonoBehaviour {
	
	public float respawnIfBelowThisYVal = -50f;
	private Vector3 initialPosition;
	private Quaternion initialRotation;
	
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		initialRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < respawnIfBelowThisYVal) {
			Object newThing = Instantiate(this, initialPosition, initialRotation);
			string oldGoName = gameObject.name;
			Destroy (gameObject);
			newThing.name = oldGoName;
		}
	}
}
