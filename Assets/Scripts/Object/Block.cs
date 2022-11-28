using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private int m_level;
    [SerializeField]
    private SpriteRenderer m_spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
            m_level--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void SetColor(Color color)
    {
        m_spriteRenderer.color = color;
    }
}
