using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disc : MonoBehaviour {


	public float ySpeed;
	public float xSpeed;
	public float cooldown;
	public int health;
	public GameObject bullet;

	private float angle = 180;

	public int direction = 1;

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
	void Update () {

		if (health <= 0)
		{
			Destroy(gameObject);
		}

		if (angle > 359)
		{
			angle = 0;
		}
		if (angle < -1)
		{
			angle = 352.5f;
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
		GameObject shot = Instantiate(bullet, bulletPos, transform.rotation) as GameObject;
		shot.GetComponent<BulletMovement>().xSpeed = 2 * Mathf.Sin(Mathf.Deg2Rad * angle);
		shot.GetComponent<BulletMovement>().ySpeed = 2 * Mathf.Cos(Mathf.Deg2Rad * angle);
		angle += direction * 15f;
	}
}
