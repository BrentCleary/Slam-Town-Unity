using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public ParticleSystem jumpParticle;
    public ParticleSystem powerUpParticle;
    private Vector3 jumpParticleSpawnPos;

    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce = 50.0f;
    public float gravityModifier = 20.0f;
    public float score;
    public Vector3 playerTilt;

    public bool isOnGround = true;
    public bool gameOver;
    public bool secondJump;
    public bool coolTime = false;
    public float coolTimeLength = 0.2f;
    public bool boostOn;
    public float speed;

    public bool powerUpState = false;

    public GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // Updated Physics.gravity - Physics.gravity = Physics.gravity * gravityModifier
        Physics.gravity *= gravityModifier;
        boostOn = false;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpParticleSpawnPos = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y, playerRb.transform.position.z);


        Jump1();
        Jump2();
        Boost();

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            powerUpState = true;

            Debug.Log("PoooooweeeeeeerUUUUUUUUUUUUUPPPPPPPPP");
            
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
            Instantiate(jumpParticle, jumpParticleSpawnPos, jumpParticle.transform.rotation);
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

            Instantiate(jumpParticle, jumpParticleSpawnPos, jumpParticle.transform.rotation);
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


}

