using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {



	public GameObject singleShooter;
	public GameObject doubleShooter;
	public GameObject tripleShooter;
	public GameObject bombShooter;
	public GameObject carrier;
	public GameObject boss;

	public int wave = 0;
	public float waveCountdown = 0;
	public float waveCooldown = 5;


	private float screenHeight;
	private float screenWidth;

	private Vector3 pos;
	private Quaternion rot;


	void Start ()
	{
		//waveCountdown = waveCooldown;

		screenHeight = Camera.main.orthographicSize;
		screenWidth = screenHeight * Screen.width / Screen.height;

		pos = new Vector3();
		rot = new Quaternion();
		pos.y = 5;
	}

	void Update () {

		waveCountdown -= Time.deltaTime;
		if (waveCountdown <= 0)
		{
			spawn();
			waveCountdown = waveCooldown;
		}
	}

	void spawn()
	{
		if (wave == 0)
		{
			Instantiate(singleShooter, pos, rot);
		}
		if (wave == 1)
		{
			pos.x = screenWidth * -0.6f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.6f;
			Instantiate(singleShooter, pos, rot);
		}
		if (wave == 2)
		{
			pos.x = screenWidth * -0.6f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.6f;
			Instantiate(singleShooter, pos, rot);
			pos.x = 0;
			Instantiate(singleShooter, pos, rot);
		}
		if (wave == 3)
		{
			pos.x = screenWidth * -0.6f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.2f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * -0.2f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.6f;
			Instantiate(singleShooter, pos, rot);
		}
		if (wave == 4)
		{

			pos.x = screenWidth * -0.65f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.3f;
			Instantiate(singleShooter, pos, rot);
			pos.x = 0;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * -0.3f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.65f;
			Instantiate(singleShooter, pos, rot);
		}
		if (wave == 5)
		{
			pos.x = screenWidth * -0.6f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.6f;
			Instantiate(singleShooter, pos, rot);
			pos.x = 0;
			Instantiate(doubleShooter, pos, rot);
		}
		if (wave == 6)
		{
			pos.x = screenWidth * -0.6f;
			Instantiate(doubleShooter, pos, rot);
			pos.x = screenWidth * 0.6f;
			Instantiate(doubleShooter, pos, rot);
			pos.x = 0;
			Instantiate(singleShooter, pos, rot);
			waveCooldown = 10;
		}
		if (wave == 7)
		{
			Instantiate(tripleShooter, pos, rot);
			waveCooldown = 13;
		}
		if (wave == 8)
		{
			pos.x = screenWidth * -0.65f;
			Instantiate(tripleShooter, pos, rot);
			pos.x = screenWidth * 0.3f;
			Instantiate(doubleShooter, pos, rot);
			pos.x = 0;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * -0.3f;
			Instantiate(doubleShooter, pos, rot);
			pos.x = screenWidth * 0.65f;
			Instantiate(tripleShooter, pos, rot);
		}
		if (wave == 9)
		{
			pos.x = screenWidth * -0.65f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.3f;
			Instantiate(singleShooter, pos, rot);
			pos.x = 0;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * -0.3f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.65f;
			Instantiate(singleShooter, pos, rot);
			waveCooldown = 24;
		}
		if (wave == 10)
		{

			pos.x = 0;
			Instantiate(carrier, pos, rot);
			waveCooldown = 20;
		}
		if (wave == 11)
		{
			waveCooldown = 6;
			pos.x = screenWidth * -0.65f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.3f;
			Instantiate(singleShooter, pos, rot);
			pos.x = 0;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * -0.3f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.65f;
			Instantiate(singleShooter, pos, rot);
		}
		if (wave == 12)
		{
			pos.x = screenWidth * -0.65f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.3f;
			Instantiate(singleShooter, pos, rot);
			pos.x = 0;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * -0.3f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.65f;
			Instantiate(singleShooter, pos, rot);
		}
		if (wave == 13)
		{
			pos.x = screenWidth * -0.65f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.3f;
			Instantiate(singleShooter, pos, rot);
			pos.x = 0;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * -0.3f;
			Instantiate(singleShooter, pos, rot);
			pos.x = screenWidth * 0.65f;
			Instantiate(singleShooter, pos, rot);
			waveCooldown = 11;
		}
		if (wave == 14)
		{
			pos.x = screenWidth * -0.6f;
			Instantiate(carrier, pos, rot);
			pos.x = screenWidth * 0.6f;
			Instantiate(carrier, pos, rot);
			waveCooldown = 25;
		}
		if (wave == 15)
		{
			waveCooldown = 7;
			pos.x = 0;
			Instantiate(bombShooter, pos, rot);
		}
		if (wave == 16)
		{
			waveCooldown = 8;
			pos.x = screenWidth * -0.6f;
			Instantiate(bombShooter, pos, rot);
			pos.x = screenWidth * 0.6f;
			Instantiate(bombShooter, pos, rot);
			pos.x = 0;
		}
		if (wave == 17)
		{
			pos.x = screenWidth * -0.6f;
			Instantiate(bombShooter, pos, rot);
			pos.x = screenWidth * 0.6f;
			Instantiate(bombShooter, pos, rot);
			pos.x = 0;
			Instantiate(bombShooter, pos, rot);
			waveCooldown = 10;
		}
		if (wave == 18)
		{
			pos.x = 0;
			Instantiate(singleShooter, pos, rot);
		}
		if (wave == 19)
		{
			waveCooldown = 15;
			pos.x = screenWidth * -0.65f;
			Instantiate(carrier, pos, rot);
			pos.x = screenWidth * 0.3f;
			Instantiate(bombShooter, pos, rot);
			pos.x = 0;
			Instantiate(carrier, pos, rot);
			pos.x = screenWidth * -0.3f;
			Instantiate(bombShooter, pos, rot);
			pos.x = screenWidth * 0.65f;
			Instantiate(carrier, pos, rot);
		}
		if (wave == 20)
		{
			pos.x = screenWidth * -0.6f;
			Instantiate(bombShooter, pos, rot);
			pos.x = screenWidth * 0.6f;
			Instantiate(bombShooter, pos, rot);
			pos.x = 0;
		}
		if (wave == 21) { 
			waveCooldown = 10;
			pos.x = 0;
			Instantiate(singleShooter, pos, rot);
		}
		if (wave == 22)
		{
			Instantiate(boss,pos,rot);
		}
		wave++;
	}
}
