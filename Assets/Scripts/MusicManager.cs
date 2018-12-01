using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	private AudioSource source;

	[SerializeField] private AudioClip _satan;
	[SerializeField] private AudioClip _noSatan;
	private bool _satanist;
	
	// Use this for initialization
	void Start ()
	{
		source = gameObject.GetComponent<AudioSource>();
		source.clip = _noSatan;
		_satanist = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Satan.active && !_satanist)
		{
			source.clip = _satan;
			source.Play();
			// source.PlayOneShot(source.clip);
			_satanist = true;
		}
		else if (!Satan.active && _satanist)
		{
			source.clip = _noSatan;
			source.Play();
			_satanist = false;
		}
	}
}
