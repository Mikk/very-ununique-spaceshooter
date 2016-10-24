using UnityEngine;
using System.Collections;

public class LoadMainScreen : MonoBehaviour {
	

	public void onClick()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainScreen");
	}
	public void playGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Scene");
	}
}
