using UnityEngine;
using System.Collections;

public class CharacterBehavior : MonoBehaviour {

    public bool isGood;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void Damage(GunHit gunHit)
    {
        LevelManager.Instance.SetScore((isGood) ? -100 : 100);
    }

}
