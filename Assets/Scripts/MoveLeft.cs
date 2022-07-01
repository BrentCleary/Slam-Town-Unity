using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private float runSpeed = 40;
    private float boostSpeed = 60;
    private float dragGroundValue = 3f;
    private float dragAirValue = 0.5f;
    private float leftBound = -20;
    private ParticleSystem jumpParticle;

    // You can call a Class the same way you call a GameObject
    private PlayerController playerControllerScript;



    // Start is called before the first frame update
    void Start()
    {
        // This script find the GameObject by tag "Player", and gets the PlayerController class from the object,
        // and assigns it to the private variable playerControllerScript, or type ?PlayerController?
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        jumpParticle = playerControllerScript.jumpParticle;
        speed = runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        { 
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        DestroyOffScreenLeft();
        ChangeSpeedBoost();
        Drag();

    }

    private void DestroyOffScreenLeft()
    {
        if(transform.position.x < leftBound && (gameObject.CompareTag("Obstacle") || jumpParticle || gameObject.CompareTag("Powerup")))
        {
            Destroy(gameObject);
        }
    }


    // Changes speed to 60 if boost bool is true in PlayerController.scr
    void ChangeSpeedBoost()
    {
        if(playerControllerScript.boostOn == true)
        {
            speed = boostSpeed;
        }
    }

    void Drag()
    {
        if(speed > runSpeed && playerControllerScript.isOnGround == true)
        {
            speed -= dragGroundValue * Time.time * Time.deltaTime;
        }

        if(speed > runSpeed && playerControllerScript.isOnGround == false)
        {
            speed -= dragAirValue * Time.time * Time.deltaTime;
        }
    }

    // void PowerupMove()
    // {
    //     if(gameObject.Find("Powerup"))
    //     {
    //         for(var i = 0; i<=10; i++)
    //         {
    //             i = 
    //         }
    //     }

    // }


}


