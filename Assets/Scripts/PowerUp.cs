using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public ParticleSystem powerUpParticle;

    // Start is called before the first frame update
    void Start()
    {
        powerUpParticle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            powerUpParticle.Play();
            GetComponent<Renderer>().material.color = Color.green;
            Debug.Log("I've Got The Powa");
        }
    }
}
