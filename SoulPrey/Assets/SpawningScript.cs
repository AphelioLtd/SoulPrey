using UnityEngine;
using System.Collections;

public class SpawningScript : MonoBehaviour {
	
	public Transform What;
	public Vector3 Where;
	public int HowMany;
	
	// Use this for initialization
	void Start ()
	{		
		for (int i = 0; i < HowMany; i++)
		{
			//Spawn object
			Instantiate(What, Where, Quaternion.identity);
		}
	}
	/*
	// Update is called once per frame
	void Update ()
	{
	
	}*/
}
