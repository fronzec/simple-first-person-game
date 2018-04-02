using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] private int _requiredKeys = 6;

    [SerializeField] private PanelsController _hud;
    private MyGameController _myGameController;

    private void Start()
    {
        _myGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MyGameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerController>().keysPickeds >= _requiredKeys)
            {
                //Show cursor on screen or something like that
                _hud.OpenMessagePanel("Exelent you scape from Lvl 1 \n Press Enter to continue ...");
                _myGameController.SetLevelComplete();
            }
            else
            {
                _hud.OpenMessagePanel("You don't have enought information to scape !!!");
                StartCoroutine("HideNeedMoreKeysPanel");
            }
        }
    }

    IEnumerator HideNeedMoreKeysPanel()
    {
        yield return new WaitForSeconds(2);
        _hud.CloseMessagePanel();
    }
}