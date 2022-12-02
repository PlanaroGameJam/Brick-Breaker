using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidBody2D;
    [SerializeField]
    private SpriteRenderer m_spriteRenderer;
    [SerializeField]
    private BoxCollider2D m_boxCollider2D;
    private bool m_isTouchToBlock = false;

    private readonly Color NORMAL_COLOR = Color.cyan;
    private readonly Color ALPHA_COLOR = new Color(0.0f, 1.0f, 1.0f, 0.5f);

    private int m_level = 1;
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_spriteRenderer.color = m_isTouchToBlock ? ALPHA_COLOR : NORMAL_COLOR;
        gameObject.layer = m_isTouchToBlock ? LayerMask.NameToLayer("Alpha") : LayerMask.NameToLayer("Normal");
        m_boxCollider2D.isTrigger = m_isTouchToBlock ? true : false;
    }

    public void Move(InputAction.CallbackContext context)
    {
        var position = context.ReadValue<Vector2>();
        position.x = Mathf.Clamp(position.x, 0.0f, (float)Screen.width);
        position.y = Mathf.Clamp(position.y, 0.0f, 930.0f / 1080.0f * (float)Screen.height);
        m_rigidBody2D.position = Camera.main.ScreenToWorldPoint(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
            m_rigidBody2D.velocity = Vector2.zero;
        if (collision.gameObject.CompareTag("Block"))
        {
            m_isTouchToBlock = true;
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (m_isTouchToBlock)
        {
            DecreaseScore();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            m_isTouchToBlock = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            m_isTouchToBlock = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (m_isTouchToBlock)
        {
            DecreaseScore();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            m_isTouchToBlock = false;
        }
    }


    private void DecreaseScore()
    {
        Parameter.CURRENT_SCORE -= Parameter.DECREASE_SCORE_AMOUNT;
        Parameter.CURRENT_SCORE = Mathf.Clamp(Parameter.CURRENT_SCORE, 0, Parameter.CURRENT_SCORE);
    }

    public int GetLevel()
    {
        return m_level;
    }

    public bool IsTouchToBlock()
    {
        return m_isTouchToBlock;
    }
}
