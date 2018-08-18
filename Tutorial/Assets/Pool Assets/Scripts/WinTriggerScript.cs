﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTriggerScript : MonoBehaviour {

	///add your scenename for this script in the Pool scene 
	///change this comment so the next one will change the script in your scene  
	/// you have also add it at File -> Buildsetting -> Add preview scene
	public string NextScene = "Pool";

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Player")) {

				SceneManager.LoadScene (NextScene);
		}
	}
}