using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Piglet : MonoBehaviour
{
    [FormerlySerializedAs("vel")] [SerializeField] private float _vel = 3;

    
    //[SerializeField] private float angular = 30;

    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity =
            new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * _vel;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("piglet"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity =
                new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * _vel;
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
            _vel = 10;
        else
            _vel = 3;
    }

    public void die()
    {
        Destroy(gameObject);
    }
}