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
    private float m_time = 0.0f;
    private bool m_isCharge = false;
    private bool m_isTouchToJustCollision = false;

    Dictionary<int, Color> m_levelColor = new Dictionary<int, Color>
    {
        {1, Color.cyan},
        {2, Color.yellow},
        {3, Color.green},
        {4, Color.magenta},
        {5, Color.red},
    };

    void Awake()
    {
        TryGetComponent(out m_rigidBody2D);
        TryGetComponent(out m_spriteRenderer);
        transform.localScale = Parameter.PADDLE_SIZE;
    }

    // Update is called once per frame
    public void Execute()
    {

        m_spriteRenderer.color = m_isTouchToBlock ? ALPHA_COLOR : NORMAL_COLOR;
        gameObject.layer = m_isTouchToBlock ? LayerMask.NameToLayer("Alpha") : LayerMask.NameToLayer("Normal");
        m_boxCollider2D.isTrigger = m_isTouchToBlock ? true : false;

        if(m_isCharge)
        {
            m_time += Time.deltaTime;
            m_level = Mathf.Clamp(m_level + Mathf.FloorToInt(m_time / Parameter.PADDLE_LEVEL_UP_INTERVAL), 1, 5);
        }
        m_spriteRenderer.color = m_levelColor[m_level];
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (m_rigidBody2D == null) return;
        var position = context.ReadValue<Vector2>();
        position.x = Mathf.Clamp(position.x, 0.0f, (float)Screen.width);
        position.y = Mathf.Clamp(position.y, 0.0f, 930.0f / 1080.0f * (float)Screen.height);

        if(m_isCharge)
            m_rigidBody2D.position = Vector2.MoveTowards(Camera.main.ScreenToWorldPoint(position), m_rigidBody2D.position, m_rigidBody2D.velocity.magnitude * Parameter.PADDLE_CHARGE_VELOCITY_MULTIPLY);
        else
            m_rigidBody2D.position = Camera.main.ScreenToWorldPoint(position);
    }

    public void Click(InputAction.CallbackContext context)
    {
        if(m_isTouchToJustCollision)
        {
            GameObject ball = GameObject.FindGameObjectWithTag("Ball");
            ball.SendMessage("BoundFast");
        }
    }

    public void ChargePower(InputAction.CallbackContext context)
    {
        m_isCharge = true;
    }

    public void JustRelease(InputAction.CallbackContext context)
    {
        if (m_isTouchToJustCollision)
        {
            GameObject ball = GameObject.FindGameObjectWithTag("Ball");
            ball.SendMessage("SetLevel", m_level);
            ball.SendMessage("BoundFast");
        }
        m_isCharge = false;
        m_level = 1;
        m_time = 0.0f;
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

        if (collision.CompareTag("Ball"))
            m_isTouchToJustCollision = true;
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

        if (collision.CompareTag("Ball"))
            m_isTouchToJustCollision = false;
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
