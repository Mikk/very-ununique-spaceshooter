using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {

	public float xSpeed;
	public float ySpeed;
	public float health;

	private float objectWidth;
	private float objectHeight;

	void Start()
	{
		objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
		objectHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
		if (Random.Range(0.0f, 1.0f) > 0.5f)
		{
			xSpeed = xSpeed * -1;
		}

		transform.position = transform.position + new Vector3(0, objectHeight, 0);
	}


	void OnTriggerStay2D(Collider2D other)
	{
		other.SendMessage("ApplyDamage", 1);
	}

	void ApplyDamage(int damage)
	{
		health -= damage;
	}

	// Update is called once per frame
	void Update () {

		if (health <= 0)
		{
			Destroy(gameObject);
		}

		float time = Time.deltaTime;
		float screenHeight = Camera.main.orthographicSize;
		float screenWidth = screenHeight * Screen.width / Screen.height;

		Vector3 pos = transform.position;

		pos.y += time * ySpeed;
		pos.x += time * xSpeed;

		//Remove the object if it is out of bounds
		if (pos.y > screenHeight + objectHeight ||
			pos.y < -screenHeight - 2 * objectHeight)
		{
			Destroy(gameObject);
		}

		if (pos.x >= screenWidth - objectWidth)
		{
			xSpeed = -xSpeed;
			pos.x = 2 * (screenWidth - objectWidth) - pos.x;
		}
		else if (pos.x <= -screenWidth + objectWidth)
		{
			pos.x = 2 * (-screenWidth + objectWidth) - pos.x;
			xSpeed = -xSpeed;
		}

		transform.position = pos;
	}
}
