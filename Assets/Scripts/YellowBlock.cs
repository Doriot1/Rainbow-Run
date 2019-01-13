using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBlock : MonoBehaviour
{
    private bool _isStarted;
    private float _timer;


    private void Start()
    {
        _isStarted = false;
        _timer = 0f;
    }


    private void Update()
    {
        if (_isStarted)
        {
            _timer += Time.deltaTime;
            if (_timer > 2f)
            {
                GameController.Instance.CanJump = true;
                _isStarted = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        _isStarted = true;
        GameController.Instance.CanJump = false;
    }
}