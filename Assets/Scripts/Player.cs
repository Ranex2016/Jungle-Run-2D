using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jump;
    public LayerMask ground;
    public LayerMask deathGround;
    private Rigidbody2D rigidBody;
    private Collider2D playerCollider;
    private Animator animator;

    public AudioSource deathSound;
    public AudioSource jumpSound;

    public float mileStone;
    private float mileStoneCount;
    public float speedMultipier;
    public GameManager gameManager;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        mileStoneCount = mileStone;
    }

    void Update()
    {
        // Проверим жив ли игрок
        bool dead = Physics2D.IsTouchingLayers(playerCollider, deathGround);
        if(dead){
            GameOver();
        }

        if (transform.position.x > mileStoneCount)
        {
            mileStoneCount += mileStone;
            speed = speed * speedMultipier;
            mileStone += mileStone * speedMultipier;
            Debug.Log("M = " + mileStone + ", MC = " + mileStoneCount + ", MS = " + speed);

        }

        bool grounded = Physics2D.IsTouchingLayers(playerCollider, ground);
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                jumpSound.Play();
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jump);
            }
        }
        animator.SetBool("Grounded", grounded);
    }
    void GameOver(){
        gameManager.GameOver();
    }
}
