using UnityEngine;
using System.Collections;

public class EntityData : MonoBehaviour {
	
	public float life;
	public float maxLife = 200;
	
	// Use this for initialization
	void Start () {
	life = maxLife;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public float getLife()
	{
	 return life;	
	}
	public float getMaxLife()
	{
	 return maxLife;	
	}
	public void changeLife(float change)
	{
		life += change;
		if(life < 0)
			life = 0;
		else if(life > maxLife)
			life = maxLife;
	}
	
	public void forceAggresiveBehavior(GameObject obj)
	{
		this.GetComponent<EnemyController>().changeAtkTarget(obj.gameObject);
	}
}
