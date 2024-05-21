using UnityEngine;

[RequireComponent (typeof(ExplosionCube),typeof(ExplosionCubeSpawner), typeof(Fuser))]

public class ExplosionCubeClicker : MonoBehaviour
{
    private ExplosionCube _clickbleCube;
    private ExplosionCubeSpawner _explosionCubeSpawner;
    private Fuser _fuser;

    private void Start()
    {
        _clickbleCube = GetComponent<ExplosionCube>();
        _explosionCubeSpawner = GetComponent<ExplosionCubeSpawner>();
        _fuser = GetComponent<Fuser>();
    }

    private void OnMouseDown()
    {
        if (_clickbleCube.IsSeparation)
        {
            Collider[] colliders = _explosionCubeSpawner.CreateCubes(_clickbleCube);

            _fuser.Explode(colliders);

            _clickbleCube.DestroyObject();
        }
        else
        {
            _clickbleCube.DestroyObject();
        }
    }
}
