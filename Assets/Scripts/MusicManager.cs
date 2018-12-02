using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	private AudioSource source;
    public List<Cultist> Cultists = new List<Cultist>();
	[SerializeField] private AudioClip _satan;
	[SerializeField] private AudioClip _noSatan;
	private bool _satanist;
    public GameObject DemonicDecorations;
	



	// Use this for initialization
	void Start ()
	{
		source = gameObject.GetComponent<AudioSource>();
		source.clip = _noSatan;
		Cultists.Add(GameObject.Find("Cultist 1").GetComponent<Cultist>());
        Cultists.Add(GameObject.Find("Cultist 2").GetComponent<Cultist>());
        
	}
	
    public void SetMusic(bool isSatan, int CultistNumber)
    {
        if (isSatan)
        {
            if (CultistNumber == 1)
            {
                if (!Cultists[1].IsBeast)
                {
                    Satan.active = true;
                    Debug.Log("Playing Kurwa");
                    source.clip = _satan;
                    source.Play();
                    DemonicDecorations.SetActive(true);
                }
            }
            else if (CultistNumber == 2)
            {
                if (!Cultists[0].IsBeast)
                {
                    Satan.active = true;
                    source.clip = _satan;
                    source.Play();
                    DemonicDecorations.SetActive(true);
                }
            }

        }
        else
        {
            if (CultistNumber == 1)
            {
                if (!Cultists[1].IsBeast)
                {
                    Satan.active = false;
                    source.clip = _noSatan;
                    source.Play();
                    DemonicDecorations.SetActive(false);
                }
            }
            else if (CultistNumber == 2)
            {
                if (!Cultists[0].IsBeast)
                {
                    Satan.active = false;
                    source.clip = _noSatan;
                    source.Play();
                    DemonicDecorations.SetActive(false);
                }
            }

        }
        
    }

}
