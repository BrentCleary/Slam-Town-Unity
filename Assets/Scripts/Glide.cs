using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glide : MonoBehaviour
{
    public PlayerController playerControllerScript;
    public Rigidbody playerRb;
    
    public bool gliding = false;
    public Vector3 gameGravity;
    private Vector3 antiGravity;
    private float gravityModifier = 5000f;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerRb = GetComponent<Rigidbody>();
        gameGravity = Physics.gravity;
        // antiGravity = new Vector3 (gameGravity.x, gameGravity.y * gravityModifier * Time.deltaTime, gameGravity.z);
        antiGravity = new Vector3 (gameGravity.x, gravityModifier, gameGravity.z);
    }

    // Update is called once per frame
    void Update()
    {
        Glider();
    }

    void Glider()
    {
        if(Input.GetKey(KeyCode.G) && !playerControllerScript.isOnGround && !playerControllerScript.gameOver)
        {
            Debug.Log("Gliding");
            gliding = true;
            playerRb.AddForce(Vector3.up * gravityModifier * Time.deltaTime, ForceMode.Force);
        }
    }

}
