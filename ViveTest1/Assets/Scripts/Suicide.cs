using UnityEngine;
using System.Collections;

public class Suicide : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(kill());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator kill()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
