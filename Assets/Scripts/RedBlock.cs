using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class RedBlock : MonoBehaviour
{
    private UnityChanControlScriptWithRgidBody _unityChanControlScript;
    private float _jumpTime;
    private bool _isStarted;
    private Animator _anim;

    public ParticleSystem ParticleSystem;

    private void Awake()
    {
        _jumpTime = 3f;
        _isStarted = false;
    }

    
    private void Start()
    {
        _unityChanControlScript = GameController.Instance.UnityChan.GetComponent<UnityChanControlScriptWithRgidBody>();
        _anim = _unityChanControlScript.GetAnim();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        _isStarted = true;
        ParticleSystem.Play();
    }


    private void Update()
    {
        if (_isStarted)
        {
            _jumpTime -= Time.deltaTime;
            GameController.Instance.JumpTimer.text = string.Format("{0:N2}", _jumpTime);
            if (_unityChanControlScript.GetAnimStateInfo().fullPathHash == UnityChanControlScriptWithRgidBody.jumpState)
            {
                _isStarted = false;
                ParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                _jumpTime = 3f;
                GameController.Instance.JumpTimer.text = "";
            }
            if (_jumpTime <= 0)
            {
                // todo: show "player lost" screen and terminate the level
                GameController.Instance.JumpTimer.text = "0.00";
                _isStarted = false;
                Debug.Log("You lost");
                GameController.Instance.DidLose = true;
            }
        }
    }
}