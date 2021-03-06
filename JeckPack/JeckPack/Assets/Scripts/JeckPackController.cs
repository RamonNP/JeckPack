﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeckPackController : MonoBehaviour
{
    public ParticleSystem jeckPack;
    private uint coins = 0;
    private bool isDead = false;
    public float jetpackForce = 75.0f;
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;    
    public float forwardMovementSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        bool jetpackActive = Input.GetButton("Fire1");
        jetpackActive = jetpackActive && !isDead;

        if(jeckPack != null)
        {
            if (jetpackActive)
            {
                jeckPack.Play();
                playerRigidbody.AddForce(new Vector2(0, jetpackForce));
            } else
            {
                jeckPack.Stop();
            }
        }

        if (!isDead)
        {
            Vector2 newVelocity = playerRigidbody.velocity;
            newVelocity.x = forwardMovementSpeed;
            playerRigidbody.velocity = newVelocity;
        }

        //UpdateGroundedStatus();
        //AdjustJetpack(jetpackActive);

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Moeda"))
        {
            CollectCoin(collider);
        }
        else if(collider.gameObject.CompareTag("Dano"))
        {
            HitByLaser(collider);
        }
    }

    void HitByLaser(Collider2D laserCollider)
    {
        isDead = true;
        playerAnimator.SetBool("dead", true);
        playerRigidbody.gravityScale = 0;
        Destroy(jeckPack);
    }

    void CollectCoin(Collider2D coinCollider)
    {
        coins++;
        Destroy(coinCollider.gameObject);
    }

}
