using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCameraScript : MonoBehaviour {
	private Transform rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Transform>();

		
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.position.y > 65) {
			rb.position -= Vector3.up * 0.1F;
		}
	}
}
