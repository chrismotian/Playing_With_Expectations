using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug : MonoBehaviour {

    private GameObject sinkExit;
    private int hitCount = 0;

    void Start () {
        sinkExit = GameObject.FindWithTag("SinkExit");
    }

    /**
     * Called when the Plug Button is hit by the Player.
     */
    public void RegisterHitByJumping() {
        hitCount += 1;
        Debug.Log("Plug: RegisterHitByJumping: hitCount=" + hitCount);

        if (hitCount == 1) {
            sinkExit.transform.Translate(0, -0.007f, 0);
        } else if (hitCount == 2) {
            sinkExit.transform.Translate(0, -0.005f, 0);
        } else {
            sinkExit.transform.Translate(0, -0.09f, 0);
        }
    }

}
