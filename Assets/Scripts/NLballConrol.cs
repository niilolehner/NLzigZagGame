using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLballConrol : MonoBehaviour 
{
    // declare/initialize objects and variables
    public GameObject NLparticle;
    [SerializeField] float NLspeed;
    [SerializeField] float NLfallSpeed;
    bool NLstarted;
    bool NLgameOver;
    Rigidbody NLrb;

    // Use for anything happening before Start()
    void Awake()
    {
        NLrb = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start ()
    {
        // initialize started and gameOver variables
        NLstarted = false;
        NLgameOver = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!NLstarted)
        {   
            // check if player has clicked his mouse
            if (Input.GetMouseButtonDown(0))
            {
                // move ball in x direction
                NLrb.velocity = new Vector3(NLspeed, 0, 0); 
                NLstarted = true;

                // actually start the game
                NLgameManagement.NLinstance.NLgameSTART(); 
            }
        }

        // check if raycast is not hitting anything, i.e. the ball has fallen off
        if (!Physics.Raycast(transform.position, Vector3.down, 1.0f)) 
        {
            // set game over, stop/destroy the ball
            NLgameOver = true;
            NLrb.velocity = new Vector3(0, -NLfallSpeed, 0);
            Destroy(gameObject, 1.0f);

            // set game over also in camera
            Camera.main.GetComponent<NLcameraControl>().NLgameOver = true;

            // actually end the game
            NLgameManagement.NLinstance.NLgameOVER(); 
        }

        if (Input.GetMouseButtonDown(0) && !NLgameOver)
        {
            // switch ball direction
            NLchangeDirection();
        }
	}

    void NLchangeDirection()
    {
        // change the direction of the ball (z or x)
        if (NLrb.velocity.z > 0)
            NLrb.velocity = new Vector3(NLspeed, 0, 0);
        else if (NLrb.velocity.x > 0)
            NLrb.velocity = new Vector3(0, 0, NLspeed);
    }

    void OnTriggerEnter(Collider NLcollider)
    {
        // check if ball has rolled over a diamond
        if (NLcollider.gameObject.tag == "NLdiamond")
        {
            // if ball rolls over diamond, diamond is removed, particle effect created and score is added
            GameObject NLparticles = Instantiate(NLparticle, NLcollider.gameObject.transform.position, Quaternion.identity);
            Destroy(NLcollider.gameObject);
            Destroy(NLparticles, 1.0f);
            NLscoreManagement.NLinstance.NLaddScore();
        }
    }
}
