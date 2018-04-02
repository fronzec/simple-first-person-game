using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//This script modify other scripts in the same object(enable and disable controls)
public class ScriptController : MonoBehaviour
{

	private GameObject _myGameController;
	void Start ()
	{
		_myGameController = GameObject.FindGameObjectWithTag("GameController");
		if (!_myGameController.GetComponent<MyGameController>().isControllsActive)
		{
			//Disable scripts that allow input
			GetComponent<FirstPersonController>().AllowOperations = false;
		}
	}
	
	void Update () {
		///Check every frame if controlls are allowed
		if (_myGameController.GetComponent<MyGameController>().isControllsActive)
		{
			//Disable scripts that allow input
			GetComponent<FirstPersonController>().AllowOperations = true;
		}
		else
		{
			GetComponent<FirstPersonController>().AllowOperations = false;
		}
		
	}
}
