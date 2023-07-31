using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Vector3 cameraPos;
    public Vector3 startPos = new Vector3(10, 10, -50); // This variable may be redundant
    public Vector3 behindPos = new Vector3(-30, 6, 0);
    public Vector3 playerPos;

    public Quaternion startRotation;
    public Quaternion behindRotation;

    [Range(0f,1f)] public float lerpPct;

    public float desiredDuration = 1.0f;
    public float elapsedTime = 0f;
    public float lerpChangeValue;


    // Start is called before the first frame update
    void Start()
    {
        cameraPos = GetComponent<Transform>().position;
        startRotation = GetComponent<Transform>().rotation;
        startPos = cameraPos;
        behindRotation = Quaternion.Euler(0,90,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        CameraRotateBehind();

    }

    void CameraRotateBehind()
    {
        playerPos = GameObject.Find("Player").GetComponent<Transform>().position;

        if(Input.GetKey(KeyCode.C) && lerpPct < 1.0f)
        {
            elapsedTime += Time.deltaTime;
            lerpChangeValue = elapsedTime/desiredDuration;
            lerpPct += lerpChangeValue;

            transform.rotation = Quaternion.Lerp(startRotation, behindRotation, Mathf.SmoothStep( 0, 1, lerpPct));
            transform.position = Vector3.Lerp(startPos, behindPos + playerPos, Mathf.SmoothStep( 0, 1, lerpPct));

            Debug.Log("Pressed Camera Button");
        }
        if(Input.GetKey(KeyCode.V) && lerpPct > 0f)
        {
            elapsedTime += Time.deltaTime;
            lerpChangeValue = elapsedTime/desiredDuration;
            lerpPct -= lerpChangeValue;

            transform.rotation = Quaternion.Lerp(startRotation, behindRotation, Mathf.SmoothStep( 0, 1, lerpPct));
            transform.position = Vector3.Lerp(startPos, behindPos + playerPos, Mathf.SmoothStep( 0, 1, lerpPct));

            Debug.Log("Pressed Camera Button");
        }
        else
        {
            elapsedTime = 0f;
        }

    }

}
