using UnityEngine;
using System.Collections;
 
public class LifeBar : MonoBehaviour {
 
private float currentLife;
private float maxLife;
public float barSize;
 
public GUIStyle myGUIStyle;
 private EntityData data;
	
public GUIStyle myBGGUIStyle;
public GUIStyle CDGUIStyle;
public GUIStyle CDBGGUIStyle;
	void Start()
	{
		data = this.transform.root.gameObject.GetComponent<EntityData>();
		currentLife = data.getLife();
		maxLife = data.getMaxLife();	
	}
 
		void OnGUI () {
		 
		currentLife = data.getLife();
		maxLife = data.getMaxLife();
		//For example you have 100 life’s maximum.
		Vector2 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		GUI.Box(new Rect(screenPos.x-35, screenPos.y-100, 0.0007f * Screen.width * barSize,  15f), "LIFE", myBGGUIStyle);
		GUI.Box(new Rect(screenPos.x-35, screenPos.y-100, 0.0007f * Screen.width * barSize * (currentLife/maxLife),  15f), "LIFE", myGUIStyle);
		
		if(this.gameObject.transform.parent.gameObject.name == "Player")
		{
			
			float waitTime = this.gameObject.transform.parent.gameObject.GetComponent<PlayerController>().atkTime - this.gameObject.transform.parent.gameObject.GetComponent<PlayerController>().lastAtkTime;
			float currentTime = Time.timeSinceLevelLoad -  this.gameObject.transform.parent.gameObject.GetComponent<PlayerController>().lastAtkTime;
			if(waitTime > currentTime)
			{
				GUI.Box(new Rect(screenPos.x-35, screenPos.y-200, 0.0007f * Screen.width * barSize,  15f), "TIME", CDBGGUIStyle);
				GUI.Box(new Rect(screenPos.x-35, screenPos.y-200, 0.0007f * Screen.width * barSize * (currentTime/waitTime),  15f), "TIME", CDGUIStyle);
			}
		}
		 
}
 
}