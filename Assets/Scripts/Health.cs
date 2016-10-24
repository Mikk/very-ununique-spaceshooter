using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health;
	public int type;
	void ApplyDamage(int damage)
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
			}
			if (type == 2)
			{
				GetComponentInParent<BossMovement>().gun2Destroyed = true;
			}
			if (type == 3)
			{
				GetComponentInParent<BossMovement>().gunDestroyed = true;
			}
			Destroy(gameObject);
		}
	}
}
