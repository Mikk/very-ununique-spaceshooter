using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDisc : MonoBehaviour {

	public float ySpeed;
	public float xSpeed;
	public float cooldown;
	public int health;
	public GameObject bullet;

	private float objectWidth;
	private float objectHeight;
	private float timer = 0;


	// Use this for initialization
	void Start()
	{
		objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
		objectHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
	}

	void ApplyDamage(int damage)
	{
		health -= 1;
	}

	// Update is called once per frame
	void Update()
	{

		if (health <= 0)
		{
			Destroy(gameObject);
		}

		float time = Time.deltaTime;
		timer += time;

		if (timer > cooldown)
		{
			timer -= cooldown;
			shot();
		}
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

		pos.x += xSpeed * time;
		pos.y += ySpeed * time;
		transform.position = pos;
	}

	void shot()
	{
		Vector3 bulletPos = transform.position;
		Instantiate(bullet, bulletPos, transform.rotation);
	}
}
