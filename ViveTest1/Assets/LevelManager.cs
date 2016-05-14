using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    static LevelManager _instance;
    List<Transform> listOfNodes = new List<Transform>();
    int currentSpawnTime = 5;
    public int spawnTimer = 1;

    public GameObject goodGuy;
    public GameObject badGuy;

    public int score = 0;
    public Text scoreText;

    public static LevelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<LevelManager>();
            }

            return _instance;
        }
    }


	// Use this for initialization

    
	void Start () {
        GameObject parent = GameObject.Find("SpawnNodeAnchor");
        Transform anchorLocations = parent.transform;
        foreach(Transform t in anchorLocations)
        {
            listOfNodes.Add(t);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(Time.time > currentSpawnTime)
        {
            Debug.LogError("SPAWN ME");
            GameObject go = new GameObject();

            go = (Random.Range(0, 2) == 1) ? Instantiate(goodGuy) : Instantiate(badGuy);

            go.transform.parent = listOfNodes[Random.Range(0, listOfNodes.Count)];

            Vector3 spawnVector = new Vector3(0, (go.GetComponent<BoxCollider>().size.y / 2), 0);
            go.transform.localPosition = spawnVector;
            go.transform.localRotation = Quaternion.Euler(new Vector3(0,90,0));
            currentSpawnTime += spawnTimer;
        }
	}

    public void SetScore(int score)
    {
        this.score += score;
        this.scoreText.text = "SCORE: " + this.score;
    }
}
