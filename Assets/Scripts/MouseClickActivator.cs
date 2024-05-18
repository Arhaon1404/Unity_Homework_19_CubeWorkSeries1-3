using UnityEngine;

public class MouseClickActivator : MonoBehaviour
{
    [SerializeField] private TimeCounter _timeCounter;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _timeCounter.SwitchState();
        }
    }
}
