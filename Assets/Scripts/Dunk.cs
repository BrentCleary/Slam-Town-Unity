using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dunk : MonoBehaviour
{
    public ParticleSystem dunkParticles;

    public bool isDunkable;
    private GameObject playerGameObject;
    public float hoopPositionX;
    public Vector3 playerPos;



    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.Find("Player");
        dunkParticles = GetComponentInChildren<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerGameObject.transform.position;
        hoopPositionX = GetComponentInParent<Transform>().position.x;

        DunkAbleTrigger();

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("SLAM DUNK");
            dunkParticles.Play();
            GetComponent<Renderer>().material.color = Color.green;
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void DunkAbleTrigger()
    {
        // Sets isDunkable to true if player is within x range of basket
        if(hoopPositionX < 80f && hoopPositionX > -5f)
        {
            isDunkable = true;
        }
        else
        {
            isDunkable = false;
        }
    }

}


