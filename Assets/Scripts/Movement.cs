using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public GameObject scoreText;
    public GameObject victoryText;

    private int pointCount;
    private float score = 0f;

    private void Start()
    {
        GameObject[] pointsArray = GameObject.FindGameObjectsWithTag("Point");
        pointCount = pointsArray.Length;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                GetComponent<Transform>().position += Vector3.forward * Time.deltaTime * speed;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                GetComponent<Transform>().position += Vector3.back * Time.deltaTime * speed;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Transform>().position += Vector3.left * Time.deltaTime * speed;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Transform>().position += Vector3.right * Time.deltaTime * speed;
            }
        }
        if (transform.position.y < -1f)
        {
            victoryText.GetComponent<Text>().text = "YOU FELL LOL";
        }
    }

    public void IncreaseScore()
    {
        score += 10f;
        scoreText.GetComponent<Text>().text = score.ToString();
        pointCount--;
        if (pointCount == 0)
        {
            victoryText.GetComponent<Text>().text = "VICTORY";
            Destroy(this);
        }
    }

    public void Die()
    {
        Destroy(this);
        victoryText.GetComponent<Text>().text = "YOU LOST";
    }
}
