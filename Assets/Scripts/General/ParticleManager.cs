using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ParticleManager : MonoBehaviour, IPointerDownHandler
{
    [System.Serializable]
    public enum ParticleType
    {
        FIRE,
        LIGHTNING,
        LEAF,
    }

    [SerializeField] ParticleType m_particleType = ParticleType.FIRE;
    [SerializeField] GameObject m_fireParticleTemplate = null;
    [SerializeField] GameObject m_lightningParticleTemplate = null;
    [SerializeField] GameObject m_leafParticleTemplate = null;
    [SerializeField] Transform m_particleLocation = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SwitchElement("fire");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchElement("lightning");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchElement("leaf");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 position = ray.direction * 10.0f;
        position += Camera.main.transform.position;
        //Debug.DrawLine(Camera.main.transform.position, position, Color.red, 5.0f);
        CreateParticle(position);
    }

    private void CreateParticle(Vector3 position)
    {
        switch (m_particleType)
        {
            case ParticleType.FIRE:
                Create(m_fireParticleTemplate, position, m_particleLocation, true, false);
                break;
            case ParticleType.LIGHTNING:
                Create(m_lightningParticleTemplate, position, m_particleLocation, true, false);
                break;
            case ParticleType.LEAF:
                Create(m_leafParticleTemplate, position, m_particleLocation, true, false);
                break;
        }
    }

    public GameObject Create(GameObject particleObject, Vector3 position, Transform parent, bool playOnAwake, bool killAfterFinished)
    {
        GameObject particle = Instantiate(particleObject, position, Quaternion.identity, parent);

        return particle;
    }

    public void SwitchElement(string type)
    {
        switch (type.ToLower())
        {
            case "fire":
                m_particleType = ParticleType.FIRE;
                break;
            case "lightning":
                m_particleType = ParticleType.LIGHTNING;
                break;
            case "leaf":
                m_particleType = ParticleType.LEAF;
                break;
            default:
                m_particleType = ParticleType.FIRE;
                break;
        }
    }
}
