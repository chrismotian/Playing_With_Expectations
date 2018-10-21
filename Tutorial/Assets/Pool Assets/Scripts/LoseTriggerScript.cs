using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTriggerScript : MonoBehaviour {


	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		else if (other.gameObject.CompareTag ("Volle"))
		{
			RestartController.restarter.addVolleCollisionNumber();
			Destroy(other);
		}
		else if (other.gameObject.CompareTag ("Halbe"))
		{
			RestartController.restarter.addHalbeCollisionNumber();
			Destroy(other);
		}
		else if (other.gameObject.CompareTag ("Sphere"))
		{
			RestartController.restarter.add8();
			Destroy(other);
		}
	}
}
