using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	public GameObject singleShooter;
	public GameObject doubleShooter;
	public GameObject tripleShooter;
	public GameObject bombShooter;
	public GameObject disc;
	public GameObject rock;
	public GameObject bRock;
	public GameObject seeker;
	public GameObject mine;
	public GameObject missile;
	public GameObject carrier;
	public GameObject mineDisc;
	public GameObject boss;

	public int wave = 0;
	public float timer = 0;
	public float waveCooldown = 5;

	private float screenHeight;
	private float screenWidth;
	private Vector3 pos;
	private Quaternion rot;
	private GameObject obj;

	public void Start () {
		screenHeight = Camera.main.orthographicSize;
		screenWidth = screenHeight * Screen.width / Screen.height;

		pos = new Vector3();
		rot = new Quaternion();
	}
	
	public void Update () {
		timer += Time.deltaTime;
		if (timer > waveCooldown)
		{
			timer -= waveCooldown;
			wave++;
			spawn();
		}
	}

	private void spawn()
	{
		if (wave == 1)
		{
			pos.y = screenHeight;
			GameObject obj = (GameObject)Instantiate(bRock, pos, rot);
			pos.y = -screenHeight;
			obj = (GameObject)Instantiate(bRock, pos, rot);
			obj.GetComponent<BouncingRock>().xSpeed = -obj.GetComponent<BouncingRock>().xSpeed;
			pos.y = 0;
			pos.x = screenWidth;
			obj = (GameObject)Instantiate(bRock, pos, rot);
			pos.x = -screenWidth;
			obj = (GameObject)Instantiate(bRock, pos, rot);
			obj.GetComponent<BouncingRock>().ySpeed = -obj.GetComponent<BouncingRock>().ySpeed;
			waveCooldown = 2.5f;
		} else if (wave == 2) {
			pos.y = screenHeight+0.25f;
			pos.x = 0;
			obj = (GameObject)Instantiate(rock, pos, rot);
		}
		else if (wave == 3)
		{
			pos.x = screenWidth/1.5f;
			obj = (GameObject)Instantiate(rock, pos, rot);
		}
		else if (wave == 4)
		{
			pos.x = -screenWidth/2;
			obj = (GameObject)Instantiate(rock, pos, rot);
		}
		else if (wave == 5)
		{
			pos.x = -screenWidth/3;
			obj = (GameObject)Instantiate(rock, pos, rot);
		}
		else if (wave == 6)
		{
			pos.x = screenWidth/1.25f;
			obj = (GameObject)Instantiate(rock, pos, rot);
			obj = (GameObject)Instantiate(mine, new Vector3(screenWidth,screenHeight,0), rot);
		}
		else if (wave == 7)
		{
			pos.x = -screenWidth / 4;
			obj = (GameObject)Instantiate(rock, pos, rot);
			obj = (GameObject)Instantiate(mine, new Vector3(-screenWidth, -screenHeight, 0), rot);
		}
		else if (wave == 8)
		{
			pos.x = screenWidth / 2;
			obj = (GameObject)Instantiate(rock, pos, rot);
			obj = (GameObject)Instantiate(mine, new Vector3(-screenWidth, screenHeight, 0), rot);

		}
		else if (wave == 9)
		{
			pos.x = -screenWidth / 2;
			obj = (GameObject)Instantiate(rock, pos, rot);
			obj = (GameObject)Instantiate(mine, new Vector3(screenWidth, -screenHeight, 0), rot);
		}
		else if (wave == 10)
		{
			pos.x = 0;
			pos.y = screenHeight;
			obj = (GameObject)Instantiate(bombShooter, pos, rot);
			obj = (GameObject)Instantiate(mine, new Vector3(screenWidth/2, screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(-screenWidth/2, screenHeight, 0), rot);
		}
		else if (wave == 11)
		{
			obj = (GameObject)Instantiate(seeker, new Vector3(screenWidth / 2, screenHeight, 0), rot);
			obj = (GameObject)Instantiate(seeker, new Vector3(-screenWidth / 2, screenHeight, 0), rot);
		} else if (wave == 12) {
			if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
			{
				obj = (GameObject)Instantiate(seeker, new Vector3(screenWidth / 2, screenHeight, 0), rot);
				obj = (GameObject)Instantiate(seeker, new Vector3(-screenWidth / 2, screenHeight, 0), rot);
				obj = (GameObject)Instantiate(seeker, new Vector3(screenWidth, 0, 0), rot);
				obj = (GameObject)Instantiate(seeker, new Vector3(-screenWidth, 0, 0), rot);
				obj = (GameObject)Instantiate(seeker, new Vector3(screenWidth / 2, -screenHeight, 0), rot);
				obj = (GameObject)Instantiate(seeker, new Vector3(-screenWidth / 2, -screenHeight, 0), rot);
			}
			else
			{
				wave--;
			}
		}
		else if (wave == 13)
		{
			waveCooldown = 2;
			obj = (GameObject)Instantiate(carrier, new Vector3(0, screenHeight, 0), rot);
		}
		else if (wave == 14)
		{
			if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
			{
				wave--;
				obj = (GameObject)Instantiate(missile, new Vector3(Random.Range(-screenWidth,screenWidth), screenHeight, 0), missile.transform.rotation);
			}
		}
		else if (wave == 15)
		{
			waveCooldown = 4;
			obj = (GameObject)Instantiate(disc, new Vector3(0, screenHeight, 0), rot);
		}
		else if (wave == 16)
		{
			obj = (GameObject)Instantiate(disc, new Vector3(0, -screenHeight, 0), rot);
		}
		else if (wave == 17)
		{
			obj = (GameObject)Instantiate(disc, new Vector3(screenWidth, 0, 0), rot);
		}
		else if (wave == 18)
		{
			obj = (GameObject)Instantiate(disc, new Vector3(-screenWidth, 0, 0), rot);
		}
		else if (wave == 19)
		{
			obj = (GameObject)Instantiate(tripleShooter, new Vector3(0, screenHeight, 0), rot);
			obj = (GameObject)Instantiate(disc, new Vector3(-screenWidth, screenHeight, 0), rot);
			obj = (GameObject)Instantiate(disc, new Vector3(screenWidth, screenHeight, 0), rot);
		}
		else if (wave == 20)
		{
			waveCooldown = 2;
			if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
			{
				wave--;
				obj = (GameObject)Instantiate(missile, new Vector3(Random.Range(-screenWidth, screenWidth), screenHeight, 0), missile.transform.rotation);

			}
		}
		else if (wave == 21)
		{
			waveCooldown = 3;
			obj = (GameObject)Instantiate(carrier, new Vector3(0, screenHeight, 0), rot);
		}
		else if (wave == 22)
		{
			obj = (GameObject)Instantiate(mine, new Vector3(0, screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(0, -screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(screenWidth, screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(-screenWidth, screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(screenWidth, -screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(-screenWidth, -screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(screenWidth, 0, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(-screenWidth, 0, 0), rot);
		}
		else if (wave == 23)
		{
			obj = (GameObject)Instantiate(mine, new Vector3(0, screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(0, -screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(screenWidth, screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(-screenWidth, screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(screenWidth, -screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(-screenWidth, -screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(screenWidth, 0, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(-screenWidth, 0, 0), rot);
		}
		else if (wave == 24)
		{
			obj = (GameObject)Instantiate(mine, new Vector3(0, screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(0, -screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(screenWidth, screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(-screenWidth, screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(screenWidth, -screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(-screenWidth, -screenHeight, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(screenWidth, 0, 0), rot);
			obj = (GameObject)Instantiate(mine, new Vector3(-screenWidth, 0, 0), rot);
		}
		else if (wave == 25)
		{
			obj = (GameObject)Instantiate(mineDisc, new Vector3(0, screenHeight, 0), rot);
		}
		else if (wave == 26)
		{
			if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
			{
				waveCooldown = 8;
				obj = (GameObject)Instantiate(missile, new Vector3(screenWidth / 2, screenHeight, 0), rot);
				obj = (GameObject)Instantiate(missile, new Vector3(-screenWidth / 2, screenHeight, 0), rot);
				obj = (GameObject)Instantiate(disc, new Vector3(screenWidth, 0, 0), rot);
				obj = (GameObject)Instantiate(seeker, new Vector3(screenWidth / 2, -screenHeight, 0), rot);
				obj = (GameObject)Instantiate(seeker, new Vector3(-screenWidth / 2, -screenHeight, 0), rot);
			}
			else
			{
				wave--;
			}
		}
		else if (wave == 27)
		{
			obj = (GameObject)Instantiate(mineDisc, new Vector3(-screenWidth/2, screenHeight, 0), rot);
			obj.GetComponent<MineDisc>().xSpeed *= -1;
		}
		else if (wave == 28)
		{
			obj = (GameObject)Instantiate(bombShooter, new Vector3(0, screenHeight, 0), rot);
		}
		else if (wave == 29)
		{
			obj.GetComponent<AIMovement>().xSpeed *= -1;
			obj = (GameObject)Instantiate(carrier, new Vector3(0, screenHeight, 0), rot);
			waveCooldown = 2;
		}
		else if (wave == 30)
		{
			if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
			{
				wave--;
				obj = (GameObject)Instantiate(missile, new Vector3(Random.Range(-screenWidth, screenWidth), screenHeight, 0), missile.transform.rotation);

			}
		}
		else if (wave == 31)
		{
			waveCooldown = 5;
		}
		else if (wave == 32)
		{
			Instantiate(boss);
		}
	}
}
