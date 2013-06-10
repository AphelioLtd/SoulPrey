using UnityEngine;
using System.Collections;
using RAIN;

public class EnemyController : MonoBehaviour {
	
	GameObject atkTarget;
	public float atkTime;
	public float atkSpeed;
	public float atkDmg;
	Transform myTransform;
	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(atkTarget != null && Vector3.Distance(atkTarget.transform.position, myTransform.position) < 5f)
				{
					if(Time.timeSinceLevelLoad >= atkTime)
					{
						atkTime = atkTime + (1f/atkSpeed);
						Debug.Log(name + " is attacking " + atkTarget.name + " now !");	
						atkTarget.GetComponent<EntityData>().changeLife(atkDmg*-1);
			}
					
		}	
		
		
	}
	
	public void changeAtkTarget(GameObject obj)
	{
		atkTarget = obj;
	}
}
