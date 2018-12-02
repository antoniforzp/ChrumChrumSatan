using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{

    Farmer farmer;
    MusicManager Music;
    bool IsCollidingWithWall;
    List<GameObject> walls = new List<GameObject>();

    void Awake()
    {
        Music = GameObject.Find("Main Camera").GetComponent<MusicManager>();
        farmer = transform.parent.GetComponent<Farmer>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "wall")
        {
            IsCollidingWithWall = true;
            walls.Add(col.gameObject);
        }
        else if (col.gameObject.tag == "cultist")
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
                    cultist.Marker.sprite = null;
                    if (cultist.IsKilling)
                    {
                        Piglet piglet = cultist._touchedPiglet;
                        piglet.Rb.velocity =
                        new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized * piglet._vel;
                        piglet.Rb.drag = 0;
                        cultist._text.text = "";
                    }
                    StartCoroutine(cultist.PlayDeathAnimation());
                }
            }

            // --
            //else
            // Load Win screen scene

        }
    }


    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "wall")
        {
            
            walls.Remove(col.gameObject);
            if (walls.Count == 0) IsCollidingWithWall = false; 
        }
    }
}

   
