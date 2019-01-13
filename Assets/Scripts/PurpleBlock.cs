using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBlock : MonoBehaviour
{
    private UnityChanControlScriptWithRgidBody _unityChanControlScript;
    private Vector3 _originalGravity;
    private bool _isStarted;
    public ParticleSystem ParticleSystem;

    private void Start()
    {
        _unityChanControlScript = GameController.Instance.UnityChan.GetComponent<UnityChanControlScriptWithRgidBody>();
        _isStarted = false;
        _originalGravity = Physics.gravity;
    }


    private void OnTriggerEnter(Collider other)
    {
        Physics.gravity = new Vector3(0, 9.81f, 0);
        GameController.Instance.IsGravityInverted = true;
        _isStarted = true;
        ParticleSystem.Play(withChildren: true);
    }


    private void Update()
    {
        if (_isStarted && Input.GetButtonDown("Jump"))
        {
            _isStarted = false;
            Physics.gravity = _originalGravity;
            GameController.Instance.IsGravityInverted = false;
        }
    }
}