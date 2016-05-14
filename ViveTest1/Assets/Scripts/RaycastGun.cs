using UnityEngine;
using System.Collections;

public class GunHit
{
    public float damage;
    public RaycastHit raycastHit;
    public Vector3 origin;
}

public class RaycastGun : MonoBehaviour
{
    public float fireDelay = 0.01f;
    public float damage = 1.0f;
    public float maxBulletSpreadAngle = 15.0f;
    public float timeTillMaxSpreadAngle = 1.0f;
    public AnimationCurve bulletSpreadCurve;
    public LayerMask layerMask = -1;

    private SteamVR_Controller.Device device;

    private bool readyToFire = true;
    private float fireTime;
    private Transform bulletOrigin;
    // Use this for initialization
    void Awake()
    {
        Transform t = this.transform.FindChild("HandGun");
        bulletOrigin = t.FindChild("BulletOrigin");
    }

    void Start()
    {

        var trackedController = GetComponent<SteamVR_TrackedController>();
        if (trackedController == null)
        {
            trackedController = gameObject.AddComponent<SteamVR_TrackedController>();
        }

        trackedController.TriggerClicked += new ClickedEventHandler(OnTriggerEnter);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(bulletOrigin.position, bulletOrigin.right, Color.green);

    }

    void SetReadyToFire()
    {
        readyToFire = true;
    }
   

    void OnTriggerEnter(object sender, ClickedEventArgs e)
    {

        fireTime += Time.deltaTime;

        if (readyToFire)
        {
            RaycastHit hit;

            if (Physics.Raycast(bulletOrigin.position, bulletOrigin.right, out hit, Mathf.Infinity, layerMask))
            {

                GunHit gunHit = new GunHit();
                gunHit.damage = damage;
                gunHit.raycastHit = hit;
                gunHit.origin = bulletOrigin.right;
                hit.collider.SendMessage("Damage", gunHit, SendMessageOptions.DontRequireReceiver);
                readyToFire = false;
                Invoke("SetReadyToFire", fireDelay);
            }
        }


    }

    void OnTriggerExit(Collider collider)
    {
        SetReadyToFire();
    }
}
