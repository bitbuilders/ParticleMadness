using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] [Range(1.0f, 100.0f)] float m_speed = 50.0f;
    [SerializeField] [Range(1.0f, 900.0f)] float m_turnSpeed = 90.0f;
    [SerializeField] [Range(1.0f, 100.0f)] float m_jumpForce = 25.0f;
    [SerializeField] [Range(1.0f, 10.0f)] float m_jumpResistance = 3.0f;
    [SerializeField] [Range(1.0f, 10.0f)] float m_fallMultiplier = 3.0f;

    Rigidbody m_rigidbody;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector3 force = Vector3.up * m_jumpForce;
            m_rigidbody.AddForce(force, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;
        velocity.z = Input.GetAxis("Vertical");
        velocity.x = Input.GetAxis("Horizontal");
        velocity = velocity * m_speed * 100.0f * Time.deltaTime;
        m_rigidbody.AddRelativeForce(velocity, ForceMode.Force);

        if (m_rigidbody.velocity.y > 0.0f)
        {
            m_rigidbody.velocity += (Vector3.up * Physics.gravity.y) * (m_jumpResistance - 1.0f) * Time.deltaTime;
        }
        else if (m_rigidbody.velocity.y < 0.0f)
        {
            m_rigidbody.velocity += (Vector3.up * Physics.gravity.y) * (m_fallMultiplier - 1.0f) * Time.deltaTime;
        }
    }
}
