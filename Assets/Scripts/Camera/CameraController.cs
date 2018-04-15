using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 360.0f)] float m_mouseSensitivity = 5.0f;
    [SerializeField] [Range(-90.0f, 0.0f)] float m_minLookAngle = -45.0f;
    [SerializeField] [Range(-90.0f, 0.0f)] float m_maxLookAngle = -45.0f;
    [SerializeField] GameObject m_target = null;

    Vector3 m_offset;

    private void Start()
    {
        m_offset = new Vector3(0.0f, 0.75f, 0.3f);
    }

    private void Update()
    {
        Vector3 rotation = Vector3.zero;
        rotation.y = Input.GetAxis("Mouse Y") * -m_mouseSensitivity;
        rotation.x = Input.GetAxis("Mouse X") * m_mouseSensitivity;
        rotation *= Time.deltaTime;

        Quaternion targetRotation = Quaternion.Euler(Vector3.up * rotation.x);
        m_target.transform.rotation = targetRotation * m_target.transform.rotation;
        transform.rotation = targetRotation * transform.rotation;

        Quaternion cameraRotation = Quaternion.Euler(Vector3.right * rotation.y);
        transform.rotation = transform.rotation * cameraRotation;
    }

    void LateUpdate()
    {
        Vector3 offset = m_target.transform.rotation * m_offset;
        transform.position = m_target.transform.position + offset;
    }
}
