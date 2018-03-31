using UnityEngine;

public class ScriptController : MonoBehaviour
{

	private GameObject _myGameController;
	// Use this for initialization
	void Start ()
	{
		_myGameController = GameObject.FindGameObjectWithTag("GameController");
		if (!_myGameController.GetComponent<MyGameController>().isControllsActive)
		{
			//Disable scripts that allow input
			GetComponent<MyFirstPersonController>().AllowOperations = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_myGameController.GetComponent<MyGameController>().isControllsActive)
		{
			//Disable scripts that allow input
			GetComponent<MyFirstPersonController>().AllowOperations = true;
		}
		else
		{
			GetComponent<MyFirstPersonController>().AllowOperations = false;
		}
		
	}
}
