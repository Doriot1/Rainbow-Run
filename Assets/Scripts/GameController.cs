using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance = null;
    public GameObject UnityChan;
    public Text JumpTimer;
    public bool IsGravityInverted;
    public bool CanJump;
    public bool DidLose;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        IsGravityInverted = false;
        CanJump = true;
        DidLose = false;
    }


    private void Update()
    {
        //todo: check for win/loss conditions
    }
}