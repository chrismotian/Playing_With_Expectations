using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;

    // Variables all related to jumping.
    private bool inAir = false;
    private float lastJumpTime = 0;
    private bool isJumping = false;

	public float amountForce = 10;
    public float amountJumpForce = 15;
    public float timeBetweenJumps = 0.4f;
    public bool canJump = false; // only some levels allow jumping

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    float GetJumpMovement() {
        // If player can't jump or is already in the air or is already jumping, we return 0 (no more jump force added).
        if (!canJump/* || inAir */) {
            return 0;
        }

        // Check jump button.
        if (Input.GetAxis("Jump") > 0) {
            // Only allow jumping again, when the jumping button is released.
            if (!isJumping) {
                isJumping = true;

                // If player is jumping too soon, we don't allow it again.
                float currentTime = Time.time;
                if (currentTime - lastJumpTime < timeBetweenJumps) {
                    return 0;
                }

                // Jumping allowed, but remember at which time.
                lastJumpTime = currentTime;
                return amountJumpForce;
            }
        } else {
            // Jump button released.
            isJumping = false;
        }

        // No jump input.
        return 0;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVeritcal = Input.GetAxis("Vertical");
        float moveJump = GetJumpMovement();

        Vector3 movement = new Vector3(moveHorizontal, moveJump, moveVeritcal);

        rb.AddForce(movement * amountForce);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (inAir) {
            inAir = false;
        }

        // Check if we hit the plug button.
        PlugButton button = collision.gameObject.GetComponent<PlugButton>();
        if (button != null) {
            Debug.Log("Player.OnCollisionEnter (PlugButton hit): velocity=" + rb.velocity + ", gameObject=" + collision.gameObject);
            // Only activate button if player was on the way down, i.e. velocity.y is negative. We compare with -0.1f to make sure player is moving in y direction.
            if (rb.velocity.y <= -0.1f) {
                button.Activate();
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (!inAir) {
            inAir = true;
        }
    }
}
