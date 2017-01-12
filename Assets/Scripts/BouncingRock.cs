using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingRock : MonoBehaviour {

	public float ySpeed;
	public float xSpeed;
	public int health;

	private float objectWidth;
	private float objectHeight;
	private bool hasDealtDamage = false;
	private bool kill = false;

	// Use this for initialization
	void Start()
	{
		objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
		objectHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == 11)
		{

			if (!hasDealtDamage)
			{
				other.SendMessage("ApplyDamage", 5);

			}
			hasDealtDamage = true;
			kill = true;
		}
	}

	void ApplyDamage(int damage)
	{
		health -= 1;
	}

	// Update is called once per frame
	void Update () {

		if (health <= 0 || kill)
		{
			Destroy(gameObject);
		}

		float time = Time.deltaTime;
		Vector3 pos = transform.position;

		float screenHeight = Camera.main.orthographicSize;
		float screenWidth = screenHeight * Screen.width / Screen.height;


		if (pos.y > screenHeight - objectHeight)
		{
			ySpeed = -Mathf.Abs(ySpeed);
		}
		else if (pos.y < -screenHeight + objectHeight)
		{
			ySpeed = Mathf.Abs(ySpeed);
		}
		if (pos.x > screenWidth - objectWidth)
		{
			xSpeed = -Mathf.Abs(xSpeed);
		}
		else if (pos.x < -screenWidth + objectWidth)
		{
			xSpeed = Mathf.Abs(xSpeed);
		}

		pos.x += xSpeed*time;
		pos.y += ySpeed*time;
		transform.position = pos;

	}
}
