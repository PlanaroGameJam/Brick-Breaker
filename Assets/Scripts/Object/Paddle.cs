using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidBody2D;

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
