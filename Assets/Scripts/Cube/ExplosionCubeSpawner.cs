using UnityEngine;

[RequireComponent(typeof(ExplosionCube))]

public class ExplosionCubeSpawner : MonoBehaviour
{
    [SerializeField] private ExplosionCube _spawnbleObject;
    [SerializeField] private float _dividerMultipler;

    private Collider[] _colliders;

    public Collider[] CreateCubes(ExplosionCube originalCube)
    {
        float dividerSeparation = originalCube.DividerSeparation *_dividerMultipler;
        int spawnCubeCapacity = originalCube.SpawnCubeCapacity;

        _colliders = new Collider[spawnCubeCapacity];

        for (int i = 0; i < spawnCubeCapacity; i++)
        {
            float axesX = Random.Range(-0.5f, 0.5f);
            float axesY = Random.Range(0, 0.5f);
            float axesZ = Random.Range(-0.5f, 0.5f);

            Vector3 RandomSpawnDistance = new Vector3(axesX, axesY, axesZ);

            Vector3 NewSpawnPosition = originalCube.transform.position + RandomSpawnDistance;

            ExplosionCube SpawnedObject = Instantiate(_spawnbleObject, NewSpawnPosition, transform.rotation);

            SpawnedObject.DecreaseChanceSeparation(dividerSeparation);
            SpawnedObject.DecreaseScale();

            if(SpawnedObject.TryGetComponent(out Collider collider))
                _colliders[i] = collider;
        }

        return _colliders;
    }
}
