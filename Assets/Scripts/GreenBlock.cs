using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GreenBlock : MonoBehaviour
{
    private bool _isBoosted;
    private float _buffDuration;

    [FormerlySerializedAs("_particleSystem")]
    public ParticleSystem ParticleSystem;

    private UnityChanControlScriptWithRgidBody _unityChanControlScript;


    private void Start()
    {
        _unityChanControlScript = GameController.Instance.UnityChan.GetComponent<UnityChanControlScriptWithRgidBody>();
        _isBoosted = false;
        _buffDuration = 0f;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!_isBoosted)
        {
            _unityChanControlScript.forwardSpeed *= 2f;
        }
        _isBoosted = true;
        ParticleSystem.Play(withChildren: true);
    }


    private void Update()
    {
        if (_isBoosted)
        {
            _buffDuration += Time.deltaTime;
            if (_buffDuration > 2f)
            {
                _unityChanControlScript.forwardSpeed /= 2f;
                _isBoosted = false;
                _buffDuration = 0f;
            }
        }
    }
}