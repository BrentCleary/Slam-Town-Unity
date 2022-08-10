using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float totalBackgroundWidth;
    private float repeatWidth;
    public float backgroundResetPoint;
    public float numberOfBackgrounds = 3;
    

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        backgroundResetPoint = 1 / numberOfBackgrounds;
        totalBackgroundWidth = GetComponentInChildren<BoxCollider>().size.x * numberOfBackgrounds;
        repeatWidth = totalBackgroundWidth * backgroundResetPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
