using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Regeln für 8-Ball Billard
/// 
/// </summary>

public class RestartController : MonoBehaviour {
	public static RestartController restarter;

	int halbeCollisionNumber = 0;
	int volleCollisionNumber = 0;
	bool volle;


	private void Awake()
	{
		restarter = this;
	}

	public void addHalbeCollisionNumber(){
		if(halbeCollisionNumber == 0 && volleCollisionNumber == 0)
			volle = false;
		else if(halbeCollisionNumber >=8 && volle ==false)
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		else
			halbeCollisionNumber++;
	}

	public void addVolleCollisionNumber(){
		if(halbeCollisionNumber == 0 && volleCollisionNumber == 0)
			volle = true;
		else if(volleCollisionNumber >=8 && volle==true)
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		else
			volleCollisionNumber++;
	}
	public void add8(){
		if ((volleCollisionNumber < 7 & volle == true) || (halbeCollisionNumber < 7 & volle == false))
			WinTriggerScript.winner.win();
		addHalbeCollisionNumber ();
		addVolleCollisionNumber ();
	}

}
