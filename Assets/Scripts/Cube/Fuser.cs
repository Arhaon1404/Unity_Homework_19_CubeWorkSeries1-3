using UnityEngine;

public class Fuser : MonoBehaviour
{
    [SerializeField] private float _powerExplosion;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwardModifier;

    public void Explode(float powerModifier, float radiusModifier)
    {
        _powerExplosion += powerModifier;
        _radius += radiusModifier;

        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider hit in colliders)
        {
            if (hit.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_powerExplosion, transform.position, _radius, _upwardModifier);
        }
    }
}
