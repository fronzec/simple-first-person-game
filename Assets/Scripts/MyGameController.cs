using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameController : MonoBehaviour
{
    public bool isGameActive;

    public bool isControllsActive;
    [SerializeField] [Range(0, 10)] private int _waitTimeUntilActiveControlls;
    [HideInInspector] public bool isGameOver;
    [SerializeField] public bool isLevelComplete;


    // Use this for initialization
    void Start()
    {
        isControllsActive = false;
        isGameActive = false;
        isGameOver = false;
        isLevelComplete = false;
        StartCoroutine("ActivateGameControlls");
        Debug.Log("Player Controlls Disabled");
    }

    public bool ControllsActives()
    {
        return isGameActive && isControllsActive;
    }

    public void SetAGameOver()
    {
        isGameOver = true;
        isControllsActive = false;
        isGameActive = false;
        isLevelComplete = false;
    }

    public void SetLevelComplete()
    {
        isLevelComplete = true;
        isControllsActive = false;
        isGameActive = false;
    }

    IEnumerator ActivateGameControlls()
    {
        yield return new WaitForSeconds(_waitTimeUntilActiveControlls);
        isControllsActive = true;
        isGameActive = true;
        isLevelComplete = false;
        isGameOver = false;
//        Debug.Log(isControllsActive);
//        Debug.Log(isGameActive);
//        Debug.Log("Player Controlls ENABLED");
    }


    //Reload Game
    public void RestartGame()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}