using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    float enemySpeed = 1f;
    bool isPlaying = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (isPlaying)
        {
            Vector3 playerPosition = player.GetComponent<Transform>().position;
            Vector3 enemyPosition = GetComponent<Transform>().position;
            if (playerPosition.x < enemyPosition.x)
            {
                GetComponent<Transform>().position += Vector3.left * Time.deltaTime * enemySpeed;
            }
            if (playerPosition.x > enemyPosition.x)
            {
                GetComponent<Transform>().position += Vector3.right * Time.deltaTime * enemySpeed;
            }

            if (playerPosition.z < enemyPosition.z)
            {
                GetComponent<Transform>().position += Vector3.back * Time.deltaTime * enemySpeed;
            }
            if (playerPosition.z > enemyPosition.z)
            {
                GetComponent<Transform>().position += Vector3.forward * Time.deltaTime * enemySpeed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Movement>().Die();
        isPlaying = false;
        Destroy(this);
    }

}
