using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satan : MonoBehaviour
{


	public static bool active = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			active = !active;
	}
}
