using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeckPackController : MonoBehaviour
{
    public float jetpackForce = 75.0f;
    private Rigidbody2D playerRigidbody;
    public float velocidadeMovimento = 3f;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        bool jetpackActive = Input.GetButton("Fire1");
        if (jetpackActive)
        {
            playerRigidbody.AddForce(new Vector2(0, jetpackForce));
        }
        Vector2 newVelocity = playerRigidbody.velocity;
        newVelocity.x = velocidadeMovimento;
        playerRigidbody.velocity = newVelocity;

    }
}
