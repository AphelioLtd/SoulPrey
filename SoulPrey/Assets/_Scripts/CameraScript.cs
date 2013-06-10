using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	private GameObject Player;
	public int DistanceZ = 30;
	public int DistanceY = 10;
	public int DistanceX = 0;
 
    // Use this for initialization
	void Start () {
	Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	Vector3 PlayerPOS = Player.transform.transform.position; 
	transform.position = new Vector3(PlayerPOS.x + DistanceX, PlayerPOS.y + DistanceY, PlayerPOS.z - DistanceZ);
		transform.LookAt(Player.transform);
	}
}
