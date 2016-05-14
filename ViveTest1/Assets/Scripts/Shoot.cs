using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public float speed;
    public GameObject bullet;
    public Transform shotSpawn;

    private SteamVR_Controller.Device device;
    private SteamVR_TrackedObject trackedController;

    void Awake()
    {
        trackedController = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);

        }
    }

    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedController.index);
    }

}
