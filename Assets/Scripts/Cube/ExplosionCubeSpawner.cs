using UnityEngine;

[RequireComponent(typeof(ExplosionCube))]

public class ExplosionCubeSpawner : MonoBehaviour
{
    [SerializeField] private ExplosionCube _spawnbleObject;
    [SerializeField] private float _dividerMultipler;

    public void CreateCubes(ExplosionCube originalCube)
    {
        float dividerSeparation = originalCube.DividerSeparation *_dividerMultipler;
        float explosionPowerModifier = originalCube.ExplosionPowerModifier;
        float explosionRadiusModifier = originalCube.ExplosionRadiusModifier;
        int spawnCubeCapacity = originalCube.SpawnCubeCapacity;

        for (int i = 0; i < spawnCubeCapacity; i++)
        {
            float axesX = Random.Range(-0.5f, 0.5f);
            float axesY = Random.Range(0, 0.5f);
            float axesZ = Random.Range(-0.5f, 0.5f);

            Vector3 randomSpawnDistance = new Vector3(axesX, axesY, axesZ);

            Vector3 newSpawnPosition = originalCube.transform.position + randomSpawnDistance;

            ExplosionCube spawnedObject = Instantiate(_spawnbleObject, newSpawnPosition, transform.rotation);

            spawnedObject.DecreaseChanceSeparation(dividerSeparation);
            spawnedObject.IncreaseModifiers(explosionPowerModifier, explosionRadiusModifier);
            spawnedObject.DecreaseScale();
        }
    }
}
