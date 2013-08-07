using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
    public int Current;
    public int Base = 100;
    public int Bonus = 0;
    public int Regen = 1;

    public GUIText NamePlateDisplay;

    public int Max
    {
        get { return Base + Bonus; }
    }

	// Use this for initialization
	void Start () 
    {
        Current = Max;
        if (NamePlateDisplay != null) NamePlateDisplay.text = Current.ToString();
        StartCoroutine(Regenerate());
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    void OnHeal(int value)
    {
        Debug.Log("Heal " + value);
        Current += value;
        if (Current > Max) Current = Max;
        if (NamePlateDisplay != null) NamePlateDisplay.text = Current.ToString();
    }

    void OnHarm(int value)
    {
        Debug.Log("Harm " + value);
        Current -= value;
        if (Current < 0) Death();
        if (NamePlateDisplay != null) NamePlateDisplay.text = Current.ToString();
    }

    void OnFortify(int value)
    {
        Bonus += value;
        Current += value;
        if (NamePlateDisplay != null) NamePlateDisplay.text = Current.ToString();
    }

    IEnumerator Regenerate()
    {
        while (true)
        {
            OnHeal(Regen);
            yield return new WaitForSeconds(1.0f);      
        }
    }

    private void Death()
    {
        Current = 0;
    }
}
