using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health;
	public int type;
	public void ApplyDamage(int damage)
	{
		health -= damage;
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0)
		{	
			if (type == 0)
			{
				GetComponentInParent<BossMovement>().bodyDestroyed = true;
			}
			if (type == 1)
			{
				GetComponentInParent<BossMovement>().gun1Destroyed = true;
				if(GetComponentInParent<BossMovement>().gun2Destroyed != true)
				{
					transform.parent.GetComponentInChildren<BossSeeker>().mines = true;
				}
				if (GetComponentInParent<BossMovement>().gunDestroyed != true)
				{
					transform.parent.GetComponentInChildren<BossShooter>().bombActive = true;
					transform.parent.GetComponentInChildren<BossShooter>().cooldown /= 2;
				}
			}
			if (type == 2)
			{
				GetComponentInParent<BossMovement>().gun2Destroyed = true;
				if (GetComponentInParent<BossMovement>().gun1Destroyed != true)
				{
					transform.parent.GetComponentInChildren<BossCarrier>().phase += 1;
				}
				if (GetComponentInParent<BossMovement>().gunDestroyed != true)
				{
					transform.parent.GetComponentInChildren<BossShooter>().missileActive = true;
					transform.parent.GetComponentInChildren<BossShooter>().cooldown /= 2;
				}
			}
			if (type == 3)
			{
				GetComponentInParent<BossMovement>().gunDestroyed = true;
				if (GetComponentInParent<BossMovement>().gun2Destroyed != true)
				{
					transform.parent.GetComponentInChildren<BossSeeker>().speed *= 2;
				}
				if (GetComponentInParent<BossMovement>().gun1Destroyed != true)
				{
					transform.parent.GetComponentInChildren<BossCarrier>().phase += 1;
				}
			}
			Destroy(gameObject);
		}
	}
}
