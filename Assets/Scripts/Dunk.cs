using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dunk : MonoBehaviour
{
    public ParticleSystem dunkParticles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("SLAM DUNK");
            dunkParticles.Play();
        }
    }
}
