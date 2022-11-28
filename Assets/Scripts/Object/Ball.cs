using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidBody2D;

    // Start is called before the first frame update
    void Awake()
    {
        m_rigidBody2D.AddForce(Parameter.BALL_INIT_VELOCITY, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Paddle"))
        //{
        //    Vector2 reflect = Vector2.Reflect(m_rigidBody2D.velocity, collision.contacts.First().normal);
        //    m_rigidBody2D.velocity = reflect;
        //}
    }


}
