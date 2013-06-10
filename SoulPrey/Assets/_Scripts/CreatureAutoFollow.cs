using UnityEngine;
using System.Collections;

public class CreatureAutoFollow : MonoBehaviour {
	public GameObject Target;
	public float minDistance;
	public float moveSpeed;
	public float pushSpeed;
	private Transform myTransform;
	private Vector3 destinationPosition;		// The destination Point
	private float destinationDistance;			// The distance between myTransform and destinationPosition
	private GameObject[] listCreatures;
	public GameObject atkTarget;
	public float atkSpeed;
	public float atkDmg;
	public float atkTime;
	// Use this for initialization
	void Start () {
	
		myTransform = transform;
		destinationPosition = Target.transform.position;			// prevents myTransform reset
		listCreatures = GameObject.FindGameObjectsWithTag("Creature");
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
		
		
		
	// keep track of the distance between this gameObject and destinationPosition
		/*
		destinationPosition = Target.transform.position;
		destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);
		//Debug.Log(destinationDistance);
		if(destinationDistance > (minDistance))
		{
			GameObject creatureAtLimit = null;
			foreach(GameObject creature in creatureList)
			{
				if(Vector3.Distance(creature.transform.position, myTransform.position) <= 5f && creature!=this && (creature==null||Vector3.Distance(creature.transform.position, myTransform.position) < Vector3.Distance(creatureAtLimit.transform.position, myTransform.position)))
				{
					creatureAtLimit = creature;		
				}
			}
			//if(creatureAtLimit==null)
				myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
			//else
			//	myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
		}*/
		//Now push stuff out of the way
		foreach(GameObject creature in listCreatures)
		{
			float distance = Vector3.Distance(creature.transform.position, myTransform.position);
			if(distance < minDistance-1){
				creature.transform.position = Vector3.MoveTowards(creature.transform.position, myTransform.position, -(pushSpeed) * Time.deltaTime);	
			}
		}
		
		
	}
	
	public void setAtkTarget(GameObject obj){
			atkTarget = obj;
	}
	
	public void clearAtkTarget(){
			atkTarget = null;
	}

}
