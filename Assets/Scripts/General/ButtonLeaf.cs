using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLeaf : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] ParticleManager m_manager = null;

    public void OnPointerDown(PointerEventData eventData)
    {
        m_manager.SwitchElement("leaf");
    }
}
