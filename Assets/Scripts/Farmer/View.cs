using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cultist")
        {
            Cultist cultist = collision.gameObject.GetComponent<Cultist>();
            //if (cultist)
        }
    }
}
