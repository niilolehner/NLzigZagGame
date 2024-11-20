using UnityEngine;
using System.Collections;

public class NLrotator : MonoBehaviour
{	
	// Update is called once per frame
	void Update ()
	{
		// set up object rotation
		transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
