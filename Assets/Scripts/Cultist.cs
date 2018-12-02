using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Cultist : MonoBehaviour {

    public Sprite[] Markers;
    public int Killed = 0;
    public TextMeshProUGUI Counter;
    public bool IsDying = false;
    public bool IsKilling = false;
    public MusicManager Music;
    public int Number = 1;
    public Farmer Farmer;
	[SerializeField] private Sprite piglet;
	[SerializeField] private Sprite cultist;
	
	[SerializeField] private bool _isBeast = false;
	[SerializeField] private float vel;
	
	[SerializeField] public TextMeshProUGUI _text;
	
	[SerializeField] private AudioClip SatanLaugh;
	
	[SerializeField] private AudioSource source;

	private Animator animator;
	
	public static bool active = false;

	// left side of keyboard
	private string letters = "wasdqertfzxcvb";

	private KeyCode[] _keys = new KeyCode[5];
	private int _currKey;
	public Piglet _touchedPiglet;
	
	private bool sound_flag = false;

    public SpriteRenderer Marker;

    public AudioSource KnifeSource;

    public Rigidbody _rigidbody;
    
	public bool IsBeast
	{
		get { return _isBeast; }
		set
		{
			_isBeast = value;
            if (value)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = cultist;
                vel = 7;
                _currKey = 0;
                Music.SetMusic(true, Number);
                _text.text = "";
                Marker.sprite = Markers[1];
            }
            else
            {
                vel = 5;
                gameObject.GetComponent<SpriteRenderer>().sprite = piglet;
                Music.SetMusic(false, Number);
                Marker.sprite = Markers[0];
            }
		}
	}

	
	void Start () {
        Counter = GameObject.Find("Counter" + Number).GetComponent<TextMeshProUGUI>();
        Music = GameObject.Find("Main Camera").GetComponent<MusicManager>();
        Farmer = GameObject.Find("Farmer").GetComponent<Farmer>();
        KnifeSource = transform.GetChild(0).GetComponent<AudioSource>();
        Marker = transform.GetChild(1).GetComponent<SpriteRenderer>();
		source = gameObject.GetComponent<AudioSource>();
		source.clip = SatanLaugh;

        _rigidbody = GetComponent<Rigidbody>();
        if (Number == 2) letters = "ghyuiopjklbnm";

		animator = gameObject.GetComponent<Animator>();
	}
	
	void Update ()
	{
        if (!IsDying && !IsKilling)
        {
            //trun on off satan mode
            if (Number == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    IsBeast = !IsBeast;
                    sound_flag = true;

                    if (IsBeast && sound_flag)
                    {
                        source.Stop();
                        source.PlayOneShot(source.clip);
                        sound_flag = false;
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {

                    IsBeast = !IsBeast;

                    sound_flag = true;

                    if (IsBeast && sound_flag)
                    {
                        source.Stop();
                        source.PlayOneShot(source.clip);
                        sound_flag = false;
                    }
                }
            }


            if (Number == 1)
            {
                int xDelta = 0, yDelta = 0;

                if (Input.GetKey(KeyCode.W)) yDelta++;
                if (Input.GetKey(KeyCode.S)) yDelta--;
                if (Input.GetKey(KeyCode.D)) xDelta++;
                if (Input.GetKey(KeyCode.A)) xDelta--;


                AnimatorIdle();

                

                if (yDelta == 1) animator.SetBool("Up", true);
                else if (yDelta == -1) animator.SetBool("Down", true);

                if (xDelta == 1)
                    animator.SetBool("Right", true);
                else if (xDelta == -1) animator.SetBool("Left", true);

                _rigidbody.velocity = new Vector3(xDelta, 0, yDelta).normalized * vel;


                /*if (Input.GetKey(KeyCode.W))
                {
                    _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, vel);
                    animator.SetBool("Up", true);
                }

                if (Input.GetKeyUp(KeyCode.W))
                {
                    _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, 0);
                    animator.SetBool("Up", false);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, -vel);
                    animator.SetBool("Down", true);
                }

                if (Input.GetKeyUp(KeyCode.S))
                {
                    _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, 0);
                    animator.SetBool("Down", false);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    _rigidbody.velocity = new Vector3(vel, 0, _rigidbody.velocity.z);
                    animator.SetBool("Right", true);
                }

                if (Input.GetKeyUp(KeyCode.D))
                {
                    _rigidbody.velocity = new Vector3(0, 0, _rigidbody.velocity.z);
                    animator.SetBool("Right", false);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    _rigidbody.velocity = new Vector3(-vel, 0, _rigidbody.velocity.z);
                    animator.SetBool("Left", true);
                }

                if (Input.GetKeyUp(KeyCode.A))
                {
                    _rigidbody.velocity = new Vector3(0, 0, _rigidbody.velocity.z);
                    animator.SetBool("Left", false);
                }*/
            }
            else
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, vel);
                    animator.SetBool("Up", true);
                }

                if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, 0);
                    animator.SetBool("Up", false);
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, -vel);
                    animator.SetBool("Down", true);
                }

                if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, 0);
                    animator.SetBool("Down", false);
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    _rigidbody.velocity = new Vector3(vel, 0, _rigidbody.velocity.z);
                    animator.SetBool("Right", true);
                }

                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    _rigidbody.velocity = new Vector3(0, 0, _rigidbody.velocity.z);
                    animator.SetBool("Right", false);
                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    _rigidbody.velocity = new Vector3(-vel, 0, _rigidbody.velocity.z);
                    animator.SetBool("Left", true);
                }

                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    _rigidbody.velocity = new Vector3(0, 0, _rigidbody.velocity.z);
                    animator.SetBool("Left", false);
                }
            }

        }


        if (IsBeast)
        {
            if (_currKey <= 2)
            {
                if (Input.GetKeyDown(_keys[_currKey]))
                {
                    if (_currKey == 2)
                    {
                        _touchedPiglet.gameObject.SetActive(false);
                        Killed++;
                        Counter.text = Killed.ToString();
                        AnimatorIdle();
                        
                        animator.SetBool("Kill", true);
	                    StartCoroutine(Cooldown());
                        _text.text = "";
                        _currKey = 0;
                    }
                    _currKey++;
                }
            }
        }



        

	}
	

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("piglet"))
		{
            if (IsBeast && !IsKilling)
			{
                _touchedPiglet = collision.gameObject.GetComponent<Piglet>();
                _touchedPiglet.Rb.velocity = Vector3.zero;
                _touchedPiglet.Rb.drag = Mathf.Infinity;
                _rigidbody.drag = Mathf.Infinity;
                purge();
			}
		}
	}

	void purge()
	{
        IsKilling = true;
		for (int i = 0; i < 3;i++)
		{
			string key = Rand();
			_text.text += " " + key;
			_keys[i] = (KeyCode) System.Enum.Parse(typeof(KeyCode), key.ToUpper());
		}
    }

	string Rand()
	{
		return letters[Random.Range(0, letters.Length)].ToString();
	}




	IEnumerator Cooldown()
	{
        yield return new WaitForSeconds(0.5f);
        KnifeSource.Play();
        yield return new WaitForSeconds(1.5f);
		animator.SetBool("Kill", false);
        IsKilling = false;
        IsBeast = false;
        _rigidbody.drag = 0f;
    }

    public IEnumerator PlayDeathAnimation()
    {
        //SET DEATH BOOL
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    void AnimatorIdle()
    {
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
    }

}