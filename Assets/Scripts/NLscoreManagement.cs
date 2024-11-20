using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLscoreManagement : MonoBehaviour
{
    // declare/initialize objects and variables
    public static NLscoreManagement NLinstance;
    public int NLscore;
    public int NLhighScore;

	void Awake ()
    {
        // check if this exists, and that only one exists
        if (NLinstance == null)
            NLinstance = this;
	}

    // Use this for initialization
    void Start()
    {
        // initializes score
        NLscore = 0;
        PlayerPrefs.SetInt("NLscore", NLscore);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    // add 1 to score
    public void NLaddScore()
    {
        NLscore += 1;
    }

    // stop scoring
    public void NLstopScore()
    {
        // set score one final time at the end
        PlayerPrefs.SetInt("NLscore", NLscore);

        // check if there is already a highScore key
        if (PlayerPrefs.HasKey("NLhighScore")) 
        {
            // check if player score is higher than the highScore
            if (NLscore > PlayerPrefs.GetInt("NLhighScore")) 
            {
                // set highScore key to current score
                PlayerPrefs.SetInt("NLhighScore", NLscore); 
            }
        }
        else 
        {
            // create highScore key and set the score as it
            PlayerPrefs.SetInt("NLhighScore", NLscore);
        }
    }
}
