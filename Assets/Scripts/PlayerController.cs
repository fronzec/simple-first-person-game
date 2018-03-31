﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PanelsController _hud;

    private GameObject _tempItem2Pickup;
    private GameObject _myGameControllerObject;
    private MyGameController _myGameController;


    public int keysPickeds { get; set; }

    // Use this for initialization
    void Start()
    {
        _myGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MyGameController>();
        keysPickeds = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (_myGameController.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _myGameController.RestartGame();
            }
        }
        else if (_myGameController.isLevelComplete)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _myGameController.LoadScene("Scene02");
            }
        }
        else
        {
            if (_tempItem2Pickup != null && Input.GetKeyDown(KeyCode.F))
            {
                AddItemKeyToInventory(_tempItem2Pickup);
                _tempItem2Pickup.GetComponent<SphereCollider>().enabled = false;
                Destroy(_tempItem2Pickup);
                _hud.CloseMessagePanel();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KeyItem"))
        {
            _hud.OpenMessagePanel("-Press F to Pickup Key");
            _tempItem2Pickup = other.gameObject;
        }
        else if (other.CompareTag("CapturedArea"))
        {
            _hud.OpenMessagePanel("You are been captured!!! \n Press R to restart the game ");
//            _hud.OpenTryAgainPanel();
            Debug.Log("You are been captured");
            _myGameController.SetAGameOver();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("KeyItem"))
        {
            _hud.CloseMessagePanel();
            _tempItem2Pickup = null;
        }
    }

    public void AddItemKeyToInventory(GameObject item)
    {
        //TODO replace by more efficient inventory mecanism like a List
        keysPickeds++;
        Debug.Log("Now you have " + keysPickeds);
    }
}