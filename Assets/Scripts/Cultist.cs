using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultist : MonoBehaviour {

	[SerializeField] private Sprite piglet;
	[SerializeField] private Sprite cultist;
	[SerializeField] private float vel;
	[SerializeField] private TextMesh _text;

	private string letters = "abcdefghijklmnopqrstuvwyz";
	private bool flag = true;
	private char[] result;
	
	
	
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().sprite = piglet;
	}
	
	void Update ()
	{
		if (Satan.active)
			gameObject.GetComponent<SpriteRenderer>().sprite = cultist;
		else
			gameObject.GetComponent<SpriteRenderer>().sprite = piglet;


		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, vel);
		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
		
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, -vel);
		if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
		
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(vel, gameObject.GetComponent<Rigidbody2D>().velocity.y);
		if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
		
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-vel, gameObject.GetComponent<Rigidbody2D>().velocity.y);
		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("piglet"))
		{
			if (Satan.active && flag)
				purge();
		}
	}

	void purge()
	{
//		for (int i = 0; i < 5;i++)
//		{
			//_text.text += " " + Rand();
		
				
			//result[i] = letters[Random.Range(0, letters.Length - 1)];
			//Debug.Log(Rand());
		//}
		//Destroy(gameObject);
		flag = false;
	}

	char Rand()
	{
		return letters[Random.Range(0, letters.Length)];
	}
}