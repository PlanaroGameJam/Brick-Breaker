using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Block : MonoBehaviour
{
    [SerializeField]
    private int m_level;
    [SerializeField]
    private SpriteRenderer m_spriteRenderer;
    [SerializeField]
    private BoxCollider2D m_boxCollider;

    private Ball m_ball;

    private void Awake()
    {
        m_boxCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_level <= 0)
            Destroy(gameObject);
        m_boxCollider.isTrigger = m_level - m_ball.GetLevel() < 0 ? true : false;

    }

    public int GetLevel()
    {
        return m_level;
    }

    public void SetLevel(in int level)
    {
        m_level = level;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            Parameter.CURRENT_SCORE += Parameter.HIT_BLOCK_SCORE * m_ball.GetLevel();
            m_level -= m_ball.GetLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Parameter.CURRENT_SCORE += Parameter.HIT_BLOCK_SCORE * m_level;
            m_level -= m_ball.GetLevel();
        }
    }

    public void SetColor(Color color)
    {
        if (m_spriteRenderer.color == color) return;
        m_spriteRenderer.color = color;
    }
}
