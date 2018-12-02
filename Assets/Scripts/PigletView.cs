using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigletView : MonoBehaviour
{
    Piglet piglet;
    Farmer farmer;
    private AudioSource source;
    [SerializeField] private AudioClip clip;

    void Awake()
    {
        piglet = transform.parent.GetComponent<Piglet>();
        farmer = GameObject.Find("Farmer").GetComponent<Farmer>();
        source = gameObject.GetComponent<AudioSource>();
        source.clip = clip;

    }

    private void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "cultist")
        {
            Cultist cultist = col.gameObject.GetComponent<Cultist>();
            if (cultist.IsBeast)
            {
                Debug.Log("enterIsBeast!");
                source.PlayOneShot(source.clip);
                farmer.SetIsHunting(true, cultist.transform.position);
            }
        }
    }


    /*private void OnTriggerStay(Collider col)
    {
        
        if (col.gameObject.tag == "cultist")
        {
            Cultist cultist = col.gameObject.GetComponent<Cultist>();
            if (cultist.IsBeast)
            {
                Debug.Log("stayIsBeats!");
                piglet._vel = 10f;
            }
        }
    }*/

    /*private void OnTriggerExit(Collider col)
    {
        
        if (col.gameObject.tag == "cultist")
        {
            Cultist cultist = col.gameObject.GetComponent<Cultist>();
            if (cultist.IsBeast)
            {
                Debug.Log("exitIsBeast!");
                farmer.HuntCounter[cultist.Number - 1]--;
                piglet._vel = 3f;
            }
        }
    }*/
}
