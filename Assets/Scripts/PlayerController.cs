using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D m_rigidbody;
    Vector2 m_movement;
    [SerializeField]float m_movespeed;
    [SerializeField] float m_jumpforce;
    [SerializeField] float m_jumplowgravity;
    [SerializeField] float m_jumphighgravity;
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void onMove(InputAction.CallbackContext context)
    {
        m_movement = context.ReadValue<Vector2>();
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_rigidbody.gravityScale = m_jumplowgravity;
            m_rigidbody.velocity += new Vector2(0, m_jumpforce);
        } else if(context.canceled) {
            m_rigidbody.gravityScale = m_jumphighgravity;
        }
    }

    public void Move(Vector2 movement)
    {

        m_rigidbody.velocity = new Vector2(movement.x, m_rigidbody.velocity.y);
    }
    void Update()
    {
        Move(m_movement * m_movespeed);
    }
}
