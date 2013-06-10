using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float baseMoveSpeed = 10f;
	public float rotateSpeed = 10f;
	public float minDistance = 5f;
	private Transform myTransform;
	private Vector3 destinationPosition;		// The destination Point
	private float destinationDistance;			// The distance between myTransform and destinationPosition
	private float moveSpeed = 10f;
	private bool isMoving = false;
	private GameObject[] listCreatures;
	public GameObject atkTarget;
	public float atkSpeed;
	public float atkTime;
	public float lastAtkTime;
	public float atkDmg;
	// Use this for initialization
	void Start () {
		myTransform = transform;
		destinationPosition = myTransform.position;
		listCreatures = GameObject.FindGameObjectsWithTag("Creature");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey("w"))
		{
			transform.position += (transform.TransformDirection(Vector3.forward)* Time.deltaTime * baseMoveSpeed);
			isMoving = false;
		}
		if(Input.GetKey("s"))
		{
			transform.position += (-transform.TransformDirection(Vector3.forward)* Time.deltaTime * baseMoveSpeed);
			isMoving = false;
		}
		if(Input.GetKey("d"))
		{
			transform.Rotate(new Vector3(0,1,0)* Time.deltaTime * rotateSpeed);
			isMoving = false;
		}
		if(Input.GetKey("a"))
		{
			transform.Rotate(new Vector3(0,-1,0)* Time.deltaTime * rotateSpeed);
			isMoving = false;
		}
		
		
	}
	
	void Update() {
	// keep track of the distance between this gameObject and destinationPosition
		destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);
		if(Input.GetMouseButtonDown(0)&& GUIUtility.hotControl ==0)
		{
			foreach(GameObject crea in listCreatures)
				crea.GetComponent<CreatureAutoFollow>().clearAtkTarget();
			atkTarget = null;
			Plane playerPlane = new Plane(Vector3.up, myTransform.position);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float hitdist = 0.0f;
 
			if (playerPlane.Raycast(ray, out hitdist)) {
				Vector3 targetPoint = ray.GetPoint(hitdist);
				destinationPosition = ray.GetPoint(hitdist);
				Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				myTransform.rotation =  targetRotation;
				isMoving = true;
			}
		}
		if (Input.GetMouseButtonDown(1)){ // when button clicked...
        //Shoot ray from mouse position
        Ray ray = Camera.mainCamera.ScreenPointToRay( Input.mousePosition );
        RaycastHit[] hits = Physics.RaycastAll( ray );
        bool gotTarget = false; //This is so we can deselect if we didn't click anything
        foreach( RaycastHit hit in hits ){ //Loop through all the hits
            if( hit.transform.gameObject.layer == 8 ) { //Make a new layer for targets
                //You hit a target!
					//Debug.Log(hit.transform.gameObject);
                atkTarget = hit.transform.gameObject;
					foreach(GameObject crea in listCreatures)
						crea.GetComponent<CreatureAutoFollow>().setAtkTarget(atkTarget);
                gotTarget = true; //Set that we hit something
                break; //Break out because we don't need to check anymore
            }
        }
		}
 		if(isMoving)
		{
			myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
			if(myTransform.position.Equals(destinationPosition))
				isMoving = false;
		}
		if(atkTarget != null && Vector3.Distance(atkTarget.transform.position, myTransform.position) < 5f)
		{
			if(Time.timeSinceLevelLoad >= atkTime)
			{
				lastAtkTime = atkTime;
				atkTime = atkTime + (1f/atkSpeed);
				atkTarget.GetComponent<EntityData>().forceAggresiveBehavior(this.gameObject);
				Debug.Log(name + " is attacking " + atkTarget.name + " now !");	
				atkTarget.GetComponent<EntityData>().changeLife(atkDmg*-1);
			}
		}
		//Now push stuff out of the way
		//foreach(GameObject creature in listCreatures)
		//{
		//	if(Vector3.Distance(creature.transform.position, myTransform.position) < minDistance){
		//		creature.transform.position = Vector3.MoveTowards(creature.transform.position, myTransform.position, -moveSpeed * Time.deltaTime);	
		//	}
		//}
	}
}
