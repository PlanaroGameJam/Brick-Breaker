using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidBody2D;
    private bool m_isOutOfRange = false;
    private int m_level = 2;

    // Start is called before the first frame update
    void Awake()
    {
        m_rigidBody2D.AddForce(Parameter.BALL_INIT_VELOCITY, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        m_rigidBody2D.velocity = new Vector2(Mathf.Clamp(m_rigidBody2D.velocity.x, Parameter.BALL_MIN_VELOCITY.x, -Parameter.BALL_MIN_VELOCITY.x), Mathf.Clamp(m_rigidBody2D.velocity.y, Parameter.BALL_MIN_VELOCITY.y, -Parameter.BALL_MIN_VELOCITY.y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Paddle"))
        //{
        //    Vector2 reflect = Vector2.Reflect(m_rigidBody2D.velocity, collision.contacts.First().normal);
        //    m_rigidBody2D.velocity = reflect;
        //}

        if(collision.gameObject.CompareTag("Block"))
        {
            if(Vector2.SqrMagnitude(m_rigidBody2D.velocity) > 13.0f)
                m_rigidBody2D.sharedMaterial.bounciness = Parameter.BALL_BOUND_VELOCITY_MULTIPLY;
            else
                m_rigidBody2D.sharedMaterial.bounciness = 1.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Range"))
        {
            m_isOutOfRange = true;
        }
    }

    public bool IsOutOfRange()
    {
        return m_isOutOfRange;
    }

    public int GetLevel()
    {
        return m_level;
    }

}
