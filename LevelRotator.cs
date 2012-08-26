using UnityEngine;
using System.Collections;

public class LevelRotator : MonoBehaviour {
	
	public float secsBetweenLevelChanges = 300.0f;
	private float secsUntilLevelChanges;
	private int curLevel = 0;
	
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Use this for initialization
	void Start () {
		secsUntilLevelChanges = secsBetweenLevelChanges;
	
	}
	
	// Update is called once per frame
	void Update () {
		secsUntilLevelChanges -= Time.deltaTime;
	
		if (secsUntilLevelChanges <= 0) {
			curLevel++;
			curLevel %= Application.levelCount;
			secsUntilLevelChanges = secsBetweenLevelChanges;
			Application.LoadLevel (curLevel);
		}
	}
}
