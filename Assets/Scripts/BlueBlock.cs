using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlock : MonoBehaviour
{
    private UnityChanControlScriptWithRgidBody _unityChanControlScript;
    private bool _isBlue;


    private void Start()
    {
        _isBlue = false;
        _unityChanControlScript = GameController.Instance.UnityChan.GetComponent<UnityChanControlScriptWithRgidBody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        _isBlue = true;
    }


    private void OnTriggerExit(Collider other)
    {
        _isBlue = false;
    }


    private void Update()
    {
        if (_isBlue)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (GameController.Instance.UnityChan.GetComponent<UnityChanControlScriptWithRgidBody>()
                        .GetAnimStateInfo().fullPathHash == UnityChanControlScriptWithRgidBody.locoState)
                {
                    if (!GameController.Instance.UnityChan.GetComponent<UnityChanControlScriptWithRgidBody>().GetAnim()
                        .IsInTransition(0))
                    {
                        GameController.Instance.UnityChan.GetComponent<UnityChanControlScriptWithRgidBody>().GetAnim()
                            .SetBool("Slide", true);
                    }
                }
            }
            else if (GameController.Instance.UnityChan.GetComponent<UnityChanControlScriptWithRgidBody>()
                         .GetAnimStateInfo().fullPathHash == UnityChanControlScriptWithRgidBody.slideState)
            {
                if (!GameController.Instance.UnityChan.GetComponent<UnityChanControlScriptWithRgidBody>().GetAnim().IsInTransition(0))
                {
                    GameController.Instance.UnityChan.GetComponent<UnityChanControlScriptWithRgidBody>().GetAnim().SetBool("Slide", false);
                }
            }
        }
    }
}