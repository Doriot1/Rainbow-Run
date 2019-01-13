using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public UnityChanControlScriptWithRgidBody UnityChanControlScript;


    private void Start()
    {
        UnityChanControlScript = GameController.Instance.UnityChan.GetComponent<UnityChanControlScriptWithRgidBody>();
    }
}