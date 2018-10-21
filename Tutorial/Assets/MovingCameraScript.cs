using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCameraScript : MonoBehaviour {
	private Transform tr;
	public GameObject player;
	private Transform playerTr;

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform>();
		playerTr = player.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (playerTr.position.y < tr.position.y -60) {
			tr.position -= Vector3.up * 0.5F;
		}
	}
}
