using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.WSA;

public class Cultist : MonoBehaviour {

	[SerializeField] private Sprite piglet;
	[SerializeField] private Sprite cultist;
	
	[SerializeField] private bool _isBeast = false;
	[SerializeField] private float vel;
	
	[SerializeField] private TextMeshProUGUI _text;
	
	[SerializeField] private AudioClip SatanLaugh;
	
	[SerializeField] private AudioSource source;
	
	public static bool active = false;

	// left side of keyboard
	private string letters = "wasdqertfzxcvb";

	private KeyCode[] _keys = new KeyCode[5];
	private int _currKey;
	private Piglet _touchedPiglet;
	
	private bool flag = true;
	private bool sound_flag = false;

	
	void Start () {
		//sprite
		gameObject.GetComponent<SpriteRenderer>().sprite = piglet;
		
		//obtain music components
		source = gameObject.GetComponent<AudioSource>();
		source.clip = SatanLaugh;
	}
	
	void Update ()
	{
		//trun on off satan mode
		if (Input.GetKeyDown(KeyCode.Space))
		{
			active = !active;
			sound_flag = true;
			
			if (active && sound_flag)
			{
				source.Stop();
				source.PlayOneShot(source.clip);
				sound_flag = false;
			}
		}
		
		if (!Satan.active)
		{
			_text.text = "";
			flag = true;
			_currKey = 0;
		}
		
		
		if (Satan.active)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = cultist;
			if (_currKey <= 4)
			{
				if (Input.GetKeyDown(_keys[_currKey]))
				{
					if (_currKey == 4)
					{
						_touchedPiglet.gameObject.SetActive(false);
						_text.text = "";
						flag = true;
						_currKey = 0;
					}
					_currKey++;
				}
			}
		}
		else
			gameObject.GetComponent<SpriteRenderer>().sprite = piglet;


		if (Input.GetKey(KeyCode.W))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, vel);
		if (Input.GetKeyUp(KeyCode.W))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
		
		if (Input.GetKey(KeyCode.S))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, -vel);
		if (Input.GetKeyUp(KeyCode.S))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
		
		if (Input.GetKey(KeyCode.D))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(vel, gameObject.GetComponent<Rigidbody2D>().velocity.y);
		if (Input.GetKeyUp(KeyCode.D))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
		
		if (Input.GetKey(KeyCode.A))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-vel, gameObject.GetComponent<Rigidbody2D>().velocity.y);
		if (Input.GetKeyUp(KeyCode.A))
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}
	
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