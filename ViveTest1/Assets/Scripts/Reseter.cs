using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Reseter : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Damage(GunHit gunHit)
    {
        Debug.LogError("Resetting world");
        ResetWorld();
    }

    public void ResetWorld()
    {
        SceneManager.LoadScene("testController");

    } 
}
