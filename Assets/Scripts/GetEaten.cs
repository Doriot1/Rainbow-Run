using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEaten : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Movement>().IncreaseScore();
        Destroy(this.gameObject);
    }
    
}
