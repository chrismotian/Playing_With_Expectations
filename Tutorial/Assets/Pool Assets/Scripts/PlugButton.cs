using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugButton : MonoBehaviour {

    private GameObject sinkExit;
    private bool active = false;

    void Start () {
        sinkExit = GameObject.FindWithTag("SinkExit");
    }

    public void Activate() {
        if (active) return;
        active = true;

        // Show button pressed down.
        gameObject.transform.Translate(0, -0.01f, 0);
        gameObject.transform.Rotate(27, 0, 0);

        // Make the plug jump out.
        Rigidbody rb = sinkExit.GetComponent<Rigidbody>();
        rb.isKinematic = false; // Let the object move freely.
        rb.AddForce(0.02f, 0.2f, -0.03f, ForceMode.Impulse); // Apply force, so it jumps out.
    }

}
