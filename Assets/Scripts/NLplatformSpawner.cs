using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLplatformSpawner : MonoBehaviour
{
    // declare/initialize objects and variables
    public GameObject NLplatform;
    public GameObject NLdiamond;
    public bool NLgameOver;
    Vector3 NLlastPosition; 
    float NLplatformSize;

	// Use this for initialization
	void Start ()
    {
        // initialize platform position and size
        NLlastPosition = NLplatform.transform.position;
        NLplatformSize = NLplatform.transform.localScale.x;	

        // create initial platforms
        for (int i = 0; i < 20; i++) 
        {
            NLspawnPlatform();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        // if game is over, stop creating platforms
        if (NLgameManagement.NLinstance.NLgameOver == true)
            CancelInvoke("NLspawnPlatform");
	}
    
    public void NLstartSpawningPlatforms()
    {
        // create platforms continually
        InvokeRepeating("NLspawnPlatform", 0.1f, 0.2f); 
    }

    void NLspawnPlatform()
    {
        // randomize platform
        int NLrandom = Random.Range(0, 6); // 0 to 5
        if (NLrandom < 3)
            NLspawnX();
        else if (NLrandom >= 3)
            NLspawnZ();
    }

    void NLspawnX() 
    {
        // create platform in X direction
        Vector3 NLposition = NLlastPosition;
        NLposition.x += NLplatformSize;
        Instantiate(NLplatform, NLposition, Quaternion.identity);
        NLlastPosition = NLposition;

        int NLrandom = Random.Range(0, 4);
        if (NLrandom < 1)
            Instantiate(NLdiamond, new Vector3(NLposition.x, NLposition.y + 1.0f, NLposition.z), NLdiamond.transform.rotation);
    }

    void NLspawnZ()
    {
        // create platform in Z direction
        Vector3 NLposition = NLlastPosition;
        NLposition.z += NLplatformSize;
        Instantiate(NLplatform, NLposition, Quaternion.identity);
        NLlastPosition = NLposition;

        int NLrandom = Random.Range(0, 4);
        if (NLrandom < 1)
            Instantiate(NLdiamond, new Vector3(NLposition.x, NLposition.y + 1.0f, NLposition.z), NLdiamond.transform.rotation);
    }
}
