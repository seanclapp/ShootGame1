using UnityEngine;
using System.Collections;

public class SpawnOnDamage : MonoBehaviour
{
    public GameObject objectToSpawn;
    private Rigidbody myRigidBody;
    public int bulletSpeed = 1;
    private bool isHit = false;
    private GunHit myGunHit;

    void Awake()
    {
        myRigidBody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(isHit && myGunHit != null)
        {
            myRigidBody.AddForceAtPosition(myGunHit.origin * bulletSpeed, myGunHit.raycastHit.point);
        }
    }

    void Damage(GunHit gunHit)
    {

        myGunHit = gunHit;
        Instantiate(objectToSpawn, gunHit.raycastHit.point, Quaternion.LookRotation(gunHit.raycastHit.normal));
        Debug.LogError(gunHit.raycastHit.point);
        
        myRigidBody.AddForceAtPosition(gunHit.origin * bulletSpeed, gunHit.raycastHit.point);
    }

}
