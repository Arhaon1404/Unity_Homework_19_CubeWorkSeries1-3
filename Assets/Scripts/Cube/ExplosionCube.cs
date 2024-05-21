using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class ExplosionCube : MonoBehaviour
{
    private Renderer _renderer;

    private float _chanceSeparation;
    private float _dividerSeparation;
    private int _spanwCubeCapacity;
    private bool _isSeparation;

    public bool IsSeparation => _isSeparation;
    public float DividerSeparation => _dividerSeparation;
    public int SpawnCubeCapacity => _spanwCubeCapacity;

    private void Awake()
    {
        _dividerSeparation = 1;
        _chanceSeparation = 100;
        _isSeparation = true;
        _spanwCubeCapacity = Random.Range(2,6);

        SetColor();
    }

    public void DecreaseChanceSeparation(float dividerSeparation)
    {
        if (dividerSeparation > 0)
        {
            _dividerSeparation = dividerSeparation;

            _chanceSeparation /= _dividerSeparation;
        }

        IsChanceSeparation();
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    public void DecreaseScale()
    {
        float scaleDivider = 2;

        transform.localScale /= scaleDivider;
    }

    private void SetColor()
    {
        _renderer = GetComponent<Renderer>();

        float redComponent = Random.Range(0f,1f);
        float greenComponent = Random.Range(0f,1f);
        float blueComponent = Random.Range(0f,1f);

        _renderer.material.color = new Color(redComponent, greenComponent, blueComponent);
    }

    private void IsChanceSeparation()
    {
        float spawnChance = Random.Range(0, 100);

        if (spawnChance <= _chanceSeparation)
        {
            _isSeparation = true;
        }
        else
        {
            _isSeparation = false;
        }
    }
}
