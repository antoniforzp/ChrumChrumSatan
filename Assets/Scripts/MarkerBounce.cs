using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerBounce : MonoBehaviour
{

	private float init;
	private GameObject player;
	[SerializeField] private float offset = 0.01f;
	[SerializeField] private float maxOffset = 0.2f;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Cultist");
		init = transform.position.y - player.transform.position.y;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
		if (((transform.position.y - player.transform.position.y) > (init + maxOffset)) ||
		    ((transform.position.y - player.transform.position.y) < init))
			offset *= -1;
	}
}
