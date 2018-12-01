using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cultist : MonoBehaviour {

	[SerializeField] private Sprite piglet;
	[SerializeField] private Sprite cultist;
	[SerializeField] private float vel;
	[SerializeField] private TextMeshProUGUI _text;

	private string letters = "abcdefghijklmnopqrstuvwyz";
	private bool flag = true;
	private KeyCode[] _keys = new KeyCode[5];
	private int _currKey;
	private Piglet _touchedPiglet;

	[SerializeField]
	private bool _isBeast = false;
	public bool IsBeast
	{
		get { return _isBeast; }
		set
		{
			_isBeast = value;
			if (value)
			{
				_currKey = 0;
			}
		}
	}
	
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().sprite = piglet;
	}
	
	void Update ()
	{
		if (Satan.active)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = cultist;
			if (_currKey <= 4)
			{
				if (Input.GetKeyDown(_keys[_currKey]))
				{
					_currKey++;

					if (_currKey == 4)
					{
						_touchedPiglet.gameObject.SetActive(false);
						_text.text = "";
						flag = true;
						_currKey = 0;

					}
				}
			}
		}
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

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("piglet"))
		{
			if (Satan.active && flag)
			{
				_touchedPiglet = collision.gameObject.GetComponent<Piglet>();
				purge();
			}
		}
	}

	void purge()
	{
		for (int i = 0; i < 5;i++)
		{
			string key = Rand();
			_text.text += " " + key;
			_keys[i] = (KeyCode) System.Enum.Parse(typeof(KeyCode), key.ToUpper());
		}
		flag = false;
		
	}

	string Rand()
	{
		return letters[Random.Range(0, letters.Length)].ToString();
	}
}