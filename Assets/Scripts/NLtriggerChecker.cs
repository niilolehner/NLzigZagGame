using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLtriggerChecker : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // check if ball has exited platform trigger, if so, make platform fall
    void OnTriggerExit(Collider NLcollider)
    {
        // check if ball has exited platform trigger
        if (NLcollider.gameObject.tag == "NLball")
            Invoke("NLfallDown", 0.2f);
    }

    void NLfallDown()
    {
        // make platform fall, clean up fallen platform
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 2.0f);
    }
}
