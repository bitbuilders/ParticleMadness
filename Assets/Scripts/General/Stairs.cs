using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 20.0f)] float m_uvScrollSpeed = 0.25f;

    Material m_material;

    private void Start()
    {
        m_material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        m_material.mainTextureOffset += Vector2.up * m_uvScrollSpeed * Time.deltaTime;
    }
}
