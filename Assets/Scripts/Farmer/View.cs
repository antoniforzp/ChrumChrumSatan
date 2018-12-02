using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour {

    Farmer farmer;
    MusicManager Music;

    void Awake()
    {
        Music = GameObject.Find("Main Camera").GetComponent<MusicManager>();
        farmer = transform.parent.GetComponent<Farmer>();
    }

    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "cultist")
        {
            
            Cultist cultist = col.gameObject.GetComponent<Cultist>();
            if (cultist.IsBeast)
            {
                if (farmer.CultistsCounter == 2)
                //Couroutine To Play Death Animation
                {
                    cultist.IsDying = true;
                    cultist._rigidbody.velocity = Vector3.zero;
                    cultist.IsBeast = false;
                    StartCoroutine(cultist.PlayDeathAnimation());
                }
            }
                
                // --
            //else
            // Load Win screen scene
            
        }
    }

}
