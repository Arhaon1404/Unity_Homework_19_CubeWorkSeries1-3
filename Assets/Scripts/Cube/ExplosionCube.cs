using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class ExplosionCube : MonoBehaviour
{
    private Renderer _renderer;

    private float _chanceSeparation;
    private float _dividerSeparation;
    private int _spanwCubeCapacity;

    public float ChanceSeparation => _chanceSeparation;
    public float DividerSeparation => _dividerSeparation;
    public int SpawnCubeCapacity => _spanwCubeCapacity;

    private void Awake()
    {
        _dividerSeparation = 1;
        _chanceSeparation = 100;
        _spanwCubeCapacity = Random.Range(2,6);

        SetColor();
    }

    public void IncreaseDilider(float number)
    {
        if (number > 0)
        {
            _dividerSeparation = number;

            _chanceSeparation /= _dividerSeparation;
        }

    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    public void DecreaseScale()
    {
        float scaleDivider = 2;

        float scaleX = transform.localScale.x / scaleDivider;
        float scaleY = transform.localScale.y / scaleDivider;
        float scaleZ = transform.localScale.z / scaleDivider;

        transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    }

    private void SetColor()
    {
        _renderer = GetComponent<Renderer>();

        float RedComponent = Random.Range(0f,1f);
        float GreenComponent = Random.Range(0f,1f);
        float BlueComponent = Random.Range(0f,1f);

        _renderer.material.color = new Color(RedComponent, GreenComponent, BlueComponent);
    }
}
