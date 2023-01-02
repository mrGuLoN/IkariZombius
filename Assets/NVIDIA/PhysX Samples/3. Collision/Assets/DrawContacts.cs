using NVIDIA.PhysX;
using UnityEngine;

[RequireComponent(typeof(PxCollider))]
public class DrawContacts : MonoBehaviour
{
    private void OnEnable()
    {
        // Subscribe to On Collision Stay event
        GetComponent<PxCollider>().onCollisionEnter += HandleCollision;
        GetComponent<PxCollider>().onCollisionStay += HandleCollision;
    }

    private void OnDisable()
    {
        // Don't forget to unsubscribe
        GetComponent<PxCollider>().onCollisionEnter -= HandleCollision;
        GetComponent<PxCollider>().onCollisionStay -= HandleCollision;
    }

    void HandleCollision(PxCollision collision)
    {
        // Make a copy of the point array for performance reason
        var points = collision.points;

        foreach (var p in points)
            Debug.DrawLine(p.position, p.position + p.impulse * 0.1f, Color.red);
    }
}
