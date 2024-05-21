using UnityEngine;

public class Fuser : MonoBehaviour
{
    [SerializeField] private float _powerExplosion;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwardModifier;

    public void Explode(Collider[] colliders)
    {
        foreach (Collider hit in colliders)
        {
            if (hit.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_powerExplosion, transform.position, _radius, _upwardModifier);
        }
    }
}
