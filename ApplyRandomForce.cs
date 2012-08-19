using UnityEngine;
using System.Collections;

public class ApplyRandomForce : MonoBehaviour {
	
	public float secsBetweenRandomForce = 1.0f;
	public int minRandomForce = 1;
	public int maxRandomForce = 5;
	
	private Rigidbody rb;
	private float secsUntilRandomForce;
	private System.Random random = new System.Random();
	private float forceDampener = 0.1f;
	
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		if (rb == null) {
			throw new System.Exception("The gameobject must have a rigidbody for this script to work.");
		}
		secsUntilRandomForce = secsBetweenRandomForce;
	}
	
	// Update is called once per frame
	void Update () {
		secsUntilRandomForce -= Time.deltaTime;
		if (secsUntilRandomForce < 0) {
			secsUntilRandomForce = secsBetweenRandomForce;
			rb.AddForce(random.Next(minRandomForce, maxRandomForce) * forceDampener,
				random.Next(minRandomForce, maxRandomForce) * forceDampener,
				random.Next(minRandomForce, maxRandomForce) * forceDampener,
				ForceMode.Impulse);
		}
	}
}
