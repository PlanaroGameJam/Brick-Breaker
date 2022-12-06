using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidBody2D;
    private bool m_isOutOfRange = false;
    private int m_level = 1;
    private bool m_isStart = false;

    // Start is called before the first frame update
    void Awake()
    {
        m_rigidBody2D.position = new Vector2(0.0f, -2.0f);
    }

    // Update is called once per frame
    public void Execute()
    {
        if(!m_isStart)
        {
            m_rigidBody2D.AddForce(Parameter.BALL_INIT_VELOCITY, ForceMode2D.Impulse);
            m_isStart = true;
        }
    }

    private void FixedUpdate()
    {

    }

    private void BoundFast()
    {
        m_rigidBody2D.velocity *= -1 * Parameter.SUCCESS_TO_REFLECT_BALL_VELOCITY_MULTIPLY;
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
            float last_speed = m_rigidBody2D.velocity.magnitude;
            float new_speed = Mathf.Max(last_speed, Parameter.BALL_MIN_VELOCITY.magnitude);
            //BALL_MIN_VELOCITYÇÕëÂÇ´Ç≥ÇÃÇ›ÇéQè∆Ç∑ÇÈ

            m_rigidBody2D.velocity = m_rigidBody2D.velocity.normalized * new_speed;
            if (m_rigidBody2D.velocity.magnitude < Parameter.BALL_MIN_VELOCITY.magnitude)
            {
                m_rigidBody2D.sharedMaterial.bounciness = 1.0f;
            }
            else
            {
                m_rigidBody2D.sharedMaterial.bounciness = Parameter.BALL_BOUND_VELOCITY_MULTIPLY;
            }
        }

        if(collision.gameObject.CompareTag("Paddle"))
        {
            float last_speed = m_rigidBody2D.velocity.magnitude;

            Debug.Log($"{collision.contacts[0].point}, {(Vector2)collision.gameObject.transform.position}");
            m_rigidBody2D.velocity = collision.contacts[0].point - (Vector2)collision.gameObject.transform.position;
            m_rigidBody2D.velocity = m_rigidBody2D.velocity.normalized * last_speed;
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JustCollision"))
        {
            collision.gameObject.GetComponentInParent<Paddle>().GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("JustCollision"))
        {
            collision.gameObject.GetComponentInParent<Paddle>().GetComponent<SpriteRenderer>().color = Color.cyan;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("JustCollision"))
        {
            collision.GetComponentInParent<Paddle>().GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Range"))
        {
            m_isOutOfRange = true;
        }

        if (collision.CompareTag("JustCollision"))
        {
            collision.GetComponentInParent<Paddle>().GetComponent<SpriteRenderer>().color = Color.cyan;
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

    private void SetLevel(int level)
    {
        m_level += level;
        m_level = Mathf.Clamp(m_level, 1, 10);
    }
}
