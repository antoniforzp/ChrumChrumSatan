using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piglet : MonoBehaviour
{
    [SerializeField] private float vel = 3;
    //[SerializeField] private float angular = 30;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * vel;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * vel;
            //gameObject.GetComponent<Rigidbody2D>().angularVelocity = angular;
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
        }
    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
//    }

    void Update()
    {
        if (Satan.active)
            vel = 10;

        else
            vel = 3;
    }
}    