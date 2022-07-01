using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    public bool Powerupstate = false;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Powerup 
    void PowerupMove()
    {
        if(GameObject.Find("Powerup"))
        {
            Powerupstate = true;
        }

    }
}
