using UnityEngine;

[RequireComponent(typeof(ExplosionCube), typeof(Renderer), typeof(Rigidbody))]

public class CubeFuser : MonoBehaviour
{
    [SerializeField] private float _powerExplosion;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwardModifier;
    [SerializeField] private float _dividerMultipler;
    [SerializeField] private ExplosionCube _spawnbleObject;

    private ExplosionCube _explosionCube;
    private Renderer _renderer;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _explosionCube = GetComponent<ExplosionCube>();
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        ExplodeCube();
    }

    private void ExplodeCube()
    {
        CreateChilds();

        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider hit in colliders)
        {
            if (hit.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_powerExplosion, transform.position, _radius, _upwardModifier);
        }

        _explosionCube.DestroyObject();
    }

    private void CreateChilds()
    {
        float spawnChance = Random.Range(0,100);

        float chanceSeparation = _explosionCube.ChanceSeparation;
        float dividerSeparation = _explosionCube.DividerSeparation * _dividerMultipler;
        int spawnCubeCapacity = _explosionCube.SpawnCubeCapacity;

        if (spawnChance <= chanceSeparation)
        {
            for (int i = 0; i < spawnCubeCapacity; i++)
            {
                float axesX = Random.Range(-0.5f, 0.5f);
                float axesY = Random.Range(0, 0.5f);
                float axesZ = Random.Range(-0.5f, 0.5f);

                Vector3 RandomSpawnDistance = new Vector3(axesX, axesY, axesZ);

                Vector3 NewSpawnPosition = _explosionCube.transform.position + RandomSpawnDistance;

                ExplosionCube SpawnedObject = Instantiate(_spawnbleObject, NewSpawnPosition, transform.rotation);

                SpawnedObject.DecreaseChanceSeparation(dividerSeparation);
                SpawnedObject.DecreaseScale();
            }
        }

        SwitchOffComponent();
    }

    private void SwitchOffComponent()
    {
        _renderer.enabled = false;
        _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
    }
}
