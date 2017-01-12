using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSeeker : MonoBehaviour {

	public float speed;
	GameObject player;

	public float phase = 0;
	private float phaseTime = 0;
	private Vector3 targetPos;

	public bool mines = false;
	public float mineCooldown;
	private float cooldownTimer = 0;

	public GameObject mine;

	void Start()
	{
		player = GameObject.Find("Player");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
				other.SendMessage("ApplyDamage", 1);

			
	}

	// Update is called once per frame
	void Update () {
		float time = Time.deltaTime;
		if (phase != 0)
		{
			phaseTime += time;
		}
		if (phase == 1)
		{
			if (phaseTime > 0.5)
			{
				phaseTime = 0;
				phase = 2;
			}

			transform.up = Vector3.Lerp(transform.up, transform.position - player.transform.position, time * 10);
		}
		else if (phase == 2)
		{
			if (phaseTime > 2)
			{
				phaseTime = 0;
				phase = 3;
				targetPos = player.transform.position;
			}

			transform.up = transform.position - player.transform.position;
		}
		else if (phase == 3)
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

		Vector3 pos = transform.position;
		float xSpeed = -GetComponentInParent<BossMovement>().xSpeed;
		pos.x += xSpeed*time;
		transform.position = pos;


		if (mines)
		{
			cooldownTimer += time;
			if (cooldownTimer > mineCooldown)
			{
				cooldownTimer -= mineCooldown;
				Vector3 bulletPos = transform.position;
				Instantiate(mine, bulletPos, transform.rotation);
			}
		}

	}
}
