using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBlock : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        GameController.Instance.DidLose = true;
    }
}