using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	public float slowSpeed;
	public float fastSpeed;
	public int health;

	private int phase = 0;

	private float timer = 0;


	private GameObject player;
	private Vector3 targetPos;


	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}

	void ApplyDamage(int damage)
	{
		health -= damage;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == 11)
		{

			if (!(phase < 3))
			{
				other.SendMessage("ApplyDamage", 3);

			}
			phase = 5;
		}
	}

	// Update is called once per frame
	void Update () {

		if (health == 0 || phase == 5)
		{
			explode();
		}

		float time = Time.deltaTime;
		timer += time;

		if (phase == 0)
		{
			if (timer > 1)
			{
				timer = 0;
				phase = 1;
			}
			Vector3 pos = transform.position;

			pos.y += time * slowSpeed;

			transform.position = pos;
		}
		else if (phase == 1)
		{
			transform.up = Vector3.Lerp(transform.up, -transform.position + player.transform.position, time * 7);
			if (timer > 1)
			{
				timer = 0;
				phase = 2;
				transform.up = -transform.position + player.transform.position;
				targetPos = player.transform.position;
			}
		}
		else if (phase == 2)
		{
			float step = fastSpeed * time;
			transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
			if (transform.position == targetPos)
			{
				timer = 0;
				phase = 3;
				explode();
			}
		}
		else if (phase == 3)
		{
			transform.GetChild(0).transform.localScale += new Vector3(20, 13.33f, 0) * time;
			Vector3 moveTowardsVector = transform.position - player.transform.position;
			float distance = moveTowardsVector.x * moveTowardsVector.x + moveTowardsVector.y * moveTowardsVector.y;
			if (distance <= 0.3f)
			{
				player.SendMessage("ApplyDamage", 4);
			}
			if (timer > 0.5)
			{
				phase = 4;
			}
		}
		else if (phase == 4)
		{
			Vector3 moveTowardsVector = transform.position - player.transform.position;
			float distance = moveTowardsVector.x * moveTowardsVector.x + moveTowardsVector.y * moveTowardsVector.y;
			if (distance <= 0.3f)
			{
				player.SendMessage("ApplyDamage", 4);
			}
			Destroy(gameObject);
		}
	}

	private void explode()
	{
		GetComponent<Renderer>().enabled = false;
		phase = 3;
		timer = 0;
	}
}
