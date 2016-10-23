using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{

	public float xSpeed;
	public float ySpeed;
	public float damage;
	public GameObject bullet;

	private float objectWidth;
	private float objectHeight;
	private bool kill = false;
	private bool hasDealtDamage = false;
	private float timeExisted;

	void Start()
	{
		objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
		objectHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
		timeExisted = 0;
		//if bullets are not circle shaped then use this to get the correct rotation
		//transform.eulerAngles = new Vector3(0,0,-Mathf.Rad2Deg*Mathf.Atan(xSpeed/ySpeed));       
	}

	void track(string angle)
	{

		GameObject player = GameObject.Find("Player");
		Vector3 playerPos = player.transform.position;
		Vector3 pos = transform.position;
		float ratio = 0;

		if (angle == "left")
		{
			float realRatio = -(playerPos.y - pos.y) / (playerPos.x - pos.x);
			float yShift = 1 / Mathf.Sqrt((realRatio * realRatio + 1));
			float xShift = yShift * realRatio;
			if (playerPos.x - pos.x == 0)
			{
				xShift = 1;
				yShift = 0;
			}

			float fakeTargetY = 4 / Mathf.Sqrt((1 / realRatio / realRatio + 1));
			if (playerPos.y < pos.y)
			{
				fakeTargetY *= -1;
			}
			float fakeTargetX = -fakeTargetY / realRatio + pos.x;
			playerPos.y = pos.y + fakeTargetY;
			playerPos.x = fakeTargetX;

			playerPos.x -= xShift;
			playerPos.y -= yShift;
			ratio = (playerPos.x - pos.x) / (playerPos.y - pos.y);



		}
		else if (angle == "right")
		{
			float realRatio = -(playerPos.y - pos.y) / (playerPos.x - pos.x);
			float yShift = 1 / Mathf.Sqrt((realRatio * realRatio + 1));
			float xShift = yShift * realRatio;
			if (playerPos.x - pos.x == 0)
			{
				xShift = 1;
				yShift = 0;
			}
			float fakeTargetY = 4 / Mathf.Sqrt((1 / realRatio / realRatio + 1));
			if (playerPos.y < pos.y)
			{
				fakeTargetY *= -1;
			}
			float fakeTargetX = -fakeTargetY / realRatio + pos.x;
			playerPos.y = pos.y + fakeTargetY;
			playerPos.x = fakeTargetX;

			playerPos.x += xShift;
			playerPos.y += yShift;
			ratio = (playerPos.x - pos.x) / (playerPos.y - pos.y);

		}
		else if (angle == "middle")
		{
			ratio = (playerPos.x - pos.x) / (playerPos.y - pos.y);
		}
		ySpeed = 2 / Mathf.Sqrt((ratio * ratio + 1));
		if (playerPos.y < pos.y)
		{
			ySpeed *= -1;
		}
		xSpeed = ySpeed * ratio;
		if (playerPos.y == pos.y)
		{
			ySpeed = 0;
			if (playerPos.x < pos.x)
			{
				xSpeed = -2;
			}
			else
			{
				xSpeed = 2;
			}

		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (!hasDealtDamage)
		{
			other.SendMessage("ApplyDamage", damage);

		}
		hasDealtDamage = true;
		kill = true;
	}

	void ApplyDamage()
	{
		kill = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (kill)
		{
			Destroy(gameObject);
		}

		float time = Time.deltaTime;
		Vector3 pos = transform.position;

		float screenHeight = Camera.main.orthographicSize;
		float screenWidth = screenHeight * Screen.width / Screen.height;

		pos.y += time * ySpeed;
		pos.x += time * xSpeed;

		//Remove the object if it is out of bounds
		if (pos.y > screenHeight + objectHeight ||
			pos.y < -screenHeight - objectHeight ||
			pos.x > screenWidth + objectWidth ||
			pos.x < -screenWidth - objectWidth)
		{
			Destroy(gameObject);
		}

		transform.position = pos;

		timeExisted += time;
		if (timeExisted > 1)
		{
			explode();
			Destroy(gameObject);
		}

	}

	void explode()
	{
		GameObject shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		shot.GetComponent<BulletMovement>().xSpeed = 0;
		shot.GetComponent<BulletMovement>().ySpeed = 1;
		shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		shot.GetComponent<BulletMovement>().xSpeed = 0;
		shot.GetComponent<BulletMovement>().ySpeed = -1;
		shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		shot.GetComponent<BulletMovement>().xSpeed = 1;
		shot.GetComponent<BulletMovement>().ySpeed = 0;
		shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		shot.GetComponent<BulletMovement>().xSpeed = -1;
		shot.GetComponent<BulletMovement>().ySpeed = 0;
		shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		shot.GetComponent<BulletMovement>().xSpeed = - 1 / Mathf.Sqrt(2);
		shot.GetComponent<BulletMovement>().ySpeed = - 1 / Mathf.Sqrt(2);
		shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		shot.GetComponent<BulletMovement>().xSpeed = 1 / Mathf.Sqrt(2);
		shot.GetComponent<BulletMovement>().ySpeed = 1 / Mathf.Sqrt(2);
		shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		shot.GetComponent<BulletMovement>().xSpeed = -1 / Mathf.Sqrt(2);
		shot.GetComponent<BulletMovement>().ySpeed = 1 / Mathf.Sqrt(2);
		shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		shot.GetComponent<BulletMovement>().xSpeed = 1 / Mathf.Sqrt(2);
		shot.GetComponent<BulletMovement>().ySpeed = -1 / Mathf.Sqrt(2);
	}
}