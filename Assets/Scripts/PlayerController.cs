using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public ParticleSystem jumpParticle;
    private Vector3 jumpParticpleSpawnPos;

    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce = 50.0f;
    public float gravityModifier = 20.0f;
    public float score;
    public float playerTilt;
    public bool isOnGround = true;
    public bool gameOver;
    public bool secondJump;
    public bool coolTime = false;
    public float coolTimeLength = 0.2f;
    public bool boostOn;
    public float speed;

    public bool powerUpCollision = false;

    private MoveLeft moveLeftScript;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerTilt = transform.rotation.z;

        // Updated Physics.gravity - Physics.gravity = Physics.gravity * gravityModifier
        Physics.gravity *= gravityModifier;
        boostOn = false;

        moveLeftScript = GameObject.Find("Background").GetComponent<MoveLeft>();
        speed = moveLeftScript.speed;

    }

    // Update is called once per frame
    void Update()
    {
        jumpParticpleSpawnPos = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y, playerRb.transform.position.z);

        Jump1();
        Jump2();
        Boost();
        ScoreCounter();

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("PoooooweeeeeeerUUUUUUUUUUUUUPPPPPPPPP");
            powerUpCollision = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }

    }

    // Original Jump Script

    // void Jump()
    // {
    //     if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) //gameOver != true
    //     {
    //         playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //         isOnGround = false;
    //         playerAnim.SetTrigger("Jump_trig");
    //         Debug.Log("Boom");
    //         dirtParticle.Stop();
    //         playerAudio.PlayOneShot(jumpSound, 1.0f);

    //         Instantiate(jumpParticle, jumpParticpleSpawnPos, jumpParticle.transform.rotation);

    //     }
    // }


    // Copy Jump() for testing

    void Jump1()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) //gameOver != true
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            secondJump = true;
            coolTime = true;
            Invoke("CoolDown", coolTimeLength);

            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            Instantiate(jumpParticle, jumpParticpleSpawnPos, jumpParticle.transform.rotation);
            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }
    }

    void Jump2()
    {
        if(Input.GetKeyDown(KeyCode.Space) && secondJump && !coolTime && !gameOver) //gameOver != true
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            secondJump = false;

            Instantiate(jumpParticle, jumpParticpleSpawnPos, jumpParticle.transform.rotation);
            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }
    }

    void CoolDown()
    {
        coolTime = false;
    }


    void Boost()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            boostOn = true;
        }
        else
        {
            boostOn = false;
        }
    }


    // Increases the score over time, and multiplies by the speed
    void ScoreCounter()
    {
        if(!gameOver) 
        {
            score += (Time.deltaTime * speed); // boostSpeed / runSpeed
        }
        // Debug.Log("Score = " + Mathf.Ceil(score));
    }

}

