using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsController : MonoBehaviour
{
    [SerializeField] private GameObject messagesPanel;
    [SerializeField] private GameObject tryAgainPanel;

    public void OpenMessagePanel(string message)
    {
        //Use careful
        messagesPanel.GetComponentInChildren<Text>().text = message;
        messagesPanel.SetActive(true);
    }

    public void CloseMessagePanel()
    {
        messagesPanel.SetActive(false);
    }

    public void OpenTryAgainPanel()
    {
        tryAgainPanel.SetActive(true);
    }

    public void CloseTryAgainPanel()
    {
        tryAgainPanel.SetActive(false);
    }
}