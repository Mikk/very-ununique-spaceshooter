using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour {

	public float speed;
	GameObject player;
	public float health;

	private float phase = 0;
	private float phaseTime = 0;
	private Vector3 targetPos;

	private bool hasDealtDamage = false;
	private bool kill = false;

	void Start()
	{
		player = GameObject.Find("Player");
		targetPos = player.transform.position;
		transform.up = transform.position - player.transform.position;
	}

	void ApplyDamage(int damage)
	{
		health -= damage;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == 11)
		{

			if (!hasDealtDamage)
			{
				other.SendMessage("ApplyDamage", 3);

			}
			hasDealtDamage = true;
			kill = true;
		}
	}

	// Update is called once per frame
	void Update()
	{

		if (health <= 0 || kill)
		{
			Destroy(gameObject);
		}

		float time = Time.deltaTime;

		phaseTime += time;

		if (phase == 0)
		{

			float step = speed * time;

			if (phaseTime > 0.5)
			{
				phaseTime -= 0.5f;
				phase = 1;
				step = speed * (time - phaseTime);
			}

			transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

		}
		else if (phase == 1)
		{
			if (phaseTime > 0.5)
			{
				phaseTime = 0;
				phase = 2;
			}

			transform.up = Vector3.Lerp(transform.up,transform.position - player.transform.position,time*10);
		}
		else if (phase == 2)
		{
			if (phaseTime > 2)
			{
				phaseTime = 0;
				phase = 0;
				targetPos = player.transform.position;
			}

			transform.up = transform.position - player.transform.position;
		}
	}
}
