using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLgameManagement : MonoBehaviour
{
    // declare/initialize objects and variables
    public static NLgameManagement NLinstance;
    public bool NLgameOver;

    void Awake()
    {
        // check if this exists, and that only one exists
        if (NLinstance == null)
            NLinstance = this;
    }

	// Use this for initialization
	void Start ()
    {
        // initializes game over
        NLgameOver = false;		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // actually start the game
    public void NLgameSTART()
    {
        // tell ui the game has started
        NLuiManagement.NLinstance.NLgameSTART();
        // start spawning platforms when the game starts
        GameObject.Find("NLplatformSpawner").GetComponent<NLplatformSpawner>().NLstartSpawningPlatforms();
    }

    // actually end the game
    public void NLgameOVER()
    {
        // tell ui the game has ended
        NLuiManagement.NLinstance.NLgameOVER();
        // stop scoring
        NLscoreManagement.NLinstance.NLstopScore();
        // set game over to true
        NLgameOver = true;
    }
}
