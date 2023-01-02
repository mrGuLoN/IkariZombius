using NVIDIA.PhysX;
using UnityEngine;

[RequireComponent(typeof(PxCollider))]
public class HandleTrigger : MonoBehaviour
{
    public Material m_greenMaterial;
    public Material m_redMaterial;

    private void OnEnable()
    {
        // Subscribe to trigger events
        GetComponent<PxCollider>().onTriggerEnter += OnEnter;
        GetComponent<PxCollider>().onTriggerExit += OnExit;

        m_renderer = GetComponent<MeshRenderer>();
    }

    private void OnDisable()
    {
        // Don't forget to unsubscribe
        GetComponent<PxCollider>().onTriggerEnter -= OnEnter;
        GetComponent<PxCollider>().onTriggerExit -= OnExit;
    }

    private void OnEnter(PxCollider collider)
    {
        if (m_counter++ == 0)
        {
            if (m_renderer) m_renderer.material = m_redMaterial;
        }
    }

    private void OnExit(PxCollider collider)
    {
        if (--m_counter == 0)
        {
            if (m_renderer) m_renderer.material = m_greenMaterial;
        }
    }

    MeshRenderer m_renderer;
    int m_counter = 0;
}
