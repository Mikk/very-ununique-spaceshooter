using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour {


	public float xSpeed = 0;
	public float ySpeed = -0.5f;
	private float timeInPlay = 0;
	private bool switched = false;

	public bool bodyDestroyed = false;
	public bool gunDestroyed = false;
	public bool gun1Destroyed = false;
	public bool gun2Destroyed = false;
	


	void Start () {
		transform.position = new Vector3(0, 7, 0);
	}


	void Update () {

		if (bodyDestroyed || gunDestroyed && gun1Destroyed && gun2Destroyed)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
			Destroy(gameObject);
		}

		float time = Time.deltaTime;
		float screenHeight = Camera.main.orthographicSize;
		float screenWidth = screenHeight * Screen.width / Screen.height;

		Vector3 pos = transform.position;

		pos.y += time * ySpeed;
		pos.x += time * xSpeed;
		
		if (pos.x >= screenWidth - 1)
		{
			xSpeed = -xSpeed;
			pos.x = 2 * (screenWidth - 1) - pos.x;
		}
		else if (pos.x <= -screenWidth + 1)
		{
			pos.x = 2 * (-screenWidth + 1) - pos.x;
			xSpeed = -xSpeed;
		}

		transform.position = pos;

		timeInPlay += time;
		if (!switched && timeInPlay > 4)
		{
			xSpeed = 1;
			ySpeed = 0;
			switched = true;
		}


	}
}
