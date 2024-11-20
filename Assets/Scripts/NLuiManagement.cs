using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NLuiManagement : MonoBehaviour
{
    // declare/initialize objects and variables
    public static NLuiManagement NLinstance;
    public GameObject NLtitlePanel;
    public GameObject NLgameOverPanel;
    public GameObject NLclickText;
    public Text NLscore;
    public Text NLhighScore1;
    public Text NLhighScore2;

    void Awake()
    {
        // check if this exists, and that only one exists
        if (NLinstance == null)
            NLinstance = this;
    }

	// Use this for initialization
	void Start ()
    {
        // initialize High score
        NLhighScore1.text = "High Score: " + PlayerPrefs.GetInt("NLhighScore");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // start the game for the ui
    public void NLgameSTART()
    {
        // hide click to start text
        NLclickText.SetActive(false);
        // fire panel up animation
        NLtitlePanel.GetComponent<Animator>().Play("NLpanelUp");
    }

    // end the game for the ui
    public void NLgameOVER()
    {
        // set the score
        NLscore.text = PlayerPrefs.GetInt("NLscore").ToString();
        // set the high score
        NLhighScore2.text = PlayerPrefs.GetInt("NLhighScore").ToString();
        // show the game over panel
        NLgameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        // reset the scene
        SceneManager.LoadScene(0);
    }

    public void NLendGame()
    {
        // exit the game, depending if in editor or live app, change method
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    }
}
