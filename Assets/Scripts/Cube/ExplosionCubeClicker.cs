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
            _explosionCubeSpawner.CreateCubes(_clickbleCube);
        }
        else
        {
            _fuser.Explode(_clickbleCube.ExplosionPowerModifier,_clickbleCube.ExplosionRadiusModifier);
        }

        _clickbleCube.DestroyObject();
    }
}
