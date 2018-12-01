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


    private Rigidbody _rigidbody;
    
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
		//sprite
		gameObject.GetComponent<SpriteRenderer>().sprite = piglet;

		source = gameObject.GetComponent<AudioSource>();
		source.clip = SatanLaugh;

        _rigidbody = GetComponent<Rigidbody>();

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

        

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0,vel);
		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
			_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, 0);
		
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, -vel);
		if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
		 _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, 0);
		
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			_rigidbody.velocity = new Vector3(vel, 0, _rigidbody.velocity.z);
		if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
			_rigidbody.velocity = new Vector3(0, 0,_rigidbody.velocity.z);
		
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			_rigidbody.velocity = new Vector3(-vel,0, _rigidbody.velocity.z);
		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
			_rigidbody.velocity = new Vector3(0,0, _rigidbody.velocity.z);

	}
	

	private void OnCollisionEnter(Collision collision)
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