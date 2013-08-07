using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour 
{
    public int Damage = 10;
    public int Range = 1;
    public int Speed = 1;
    private bool InRange = false;


	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    void BasicAttack(GameObject target)
    {
        InRange = true;
        target.SendMessage("OnHarm", Damage);
    }

    IEnumerator BasicAttackLoop(GameObject target)
    {
        renderer.material.color = Color.red;
        InRange = true;
        while (InRange)
        {
            if (Vector3.Distance(this.transform.position, target.transform.position) > Range) InRange = false;
            target.SendMessage("OnHarm", Damage);
            yield return new WaitForSeconds(Speed);
        }
        renderer.material.color = Color.white;
        Debug.Log("Stopping Attack to " + target.name);
    }
}
