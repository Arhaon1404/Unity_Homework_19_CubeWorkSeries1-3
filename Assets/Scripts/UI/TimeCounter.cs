using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private float _timeDelay;

    private Coroutine _counterCoroutine;
    private WaitForSeconds _coroutineDelay;

    private bool _isActivate;
    private bool _isCoroutineDone = true;

    private void Start()
    {
        _coroutineDelay = new WaitForSeconds(_timeDelay);
        _isActivate = false;
    }

    public void SwitchState()
    {
        _isActivate = _isActivate == false ? true : false;

        if (_isActivate)
            LaunchCoroutine();
    }

    private void LaunchCoroutine()
    {
        if (_counterCoroutine != null)
        {
            StopCoroutine(_counterCoroutine);
        }

        if (_isCoroutineDone == true)
        {
            _isCoroutineDone = false;
            _counterCoroutine = StartCoroutine(ActCoroutine());
        }
    }


    private IEnumerator ActCoroutine()
    {
        while (_isActivate)
        {
            int count = Convert.ToInt32(_counterText.text);

            _counterText.text = Convert.ToString(count + 1);

            yield return _coroutineDelay;
        }

        _isCoroutineDone = true;
    }
}
