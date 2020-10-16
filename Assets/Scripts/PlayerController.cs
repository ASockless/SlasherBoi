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
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void onMove(InputAction.CallbackContext context)
    {
        m_movement = context.ReadValue<Vector2>();
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
