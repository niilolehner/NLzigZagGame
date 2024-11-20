using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLcameraControl : MonoBehaviour
{
    // declare/initialize objects and variables
    public GameObject NLball;
    Vector3 NLoffset; 
    public float NLlerpRate; 
    public bool NLgameOver;

	// Use this for initialization
	void Start ()
    {
        // initializes game over and camera follow distance
        NLoffset = NLball.transform.position - transform.position;
        NLgameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        // if game is not over, camera will follow
        if (!NLgameOver)
            NLcameraFollow();
	}

    void NLcameraFollow()
    {
        // set camera position
        Vector3 NLposition = transform.position;
        // keep a certain distance from the ball
        Vector3 NLtargetPosition = NLball.transform.position - NLoffset;
        // add a little hovering lag behind the ball following the camera 
        NLposition = Vector3.Lerp(NLposition, NLtargetPosition, NLlerpRate * Time.deltaTime); 
        transform.position = NLposition;
    }
}
