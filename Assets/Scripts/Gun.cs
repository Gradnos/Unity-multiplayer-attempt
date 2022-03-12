using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Gun :  MonoBehaviour
{
    [SerializeField] Transform porjectileSpawn;

    public float damage;
    public float msBetweenShots;



    float nextShotTime;

    Vector3 point;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(porjectileSpawn.position, point, Color.blue);
    }

    public void SetRayPoint(Vector3 _point)
    {
        point = _point;
    }


    public void Shoot(Transform hitTransform, Vector3 shotStartPoint, Vector3 hitPoint)
    {
        
        if(Time.time > nextShotTime)
        {
            print("shot");
            nextShotTime = Time.time + msBetweenShots/1000f;

            if(hitTransform != null)
            {
                IDamagable damagableObject = hitTransform.GetComponent<IDamagable>();
                if (damagableObject != null)
                {
                    damagableObject.TakeHit(damage, hitPoint, (hitPoint-shotStartPoint).normalized);
                }
            }
        }

         
    }
}
