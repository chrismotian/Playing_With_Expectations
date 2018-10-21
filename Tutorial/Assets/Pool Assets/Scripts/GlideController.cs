using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideController : MonoBehaviour {
		public float speed;
		
		private Vector3 destination = new Vector3(-16,65,-50);
		
		void Start () {
			
		}
		
		void Update () {
			// If the object is not at the target destination
			if (destination != gameObject.transform.position) {
				// Move towards the destination each frame until the object reaches it
				IncrementPosition ();

			}
			if(gameObject.transform.rotation.x > 0.382){
				gameObject.transform.Rotate((float)-0.006 * speed,0,0);
			}
	}
		
		void IncrementPosition ()
		{
			// Calculate the next position
			float delta = speed * Time.deltaTime;
			Vector3 currentPosition = gameObject.transform.position;
			Vector3 nextPosition = Vector3.MoveTowards (currentPosition, destination, delta);
			
			// Move the object to the next position
			gameObject.transform.position = nextPosition;
		}

	

	}

