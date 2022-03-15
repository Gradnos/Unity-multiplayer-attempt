using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GunController : NetworkBehaviour
{
    [SerializeField] Camera mainCam;

    Gun currentGun;

    void Start()
    {
        currentGun = GetComponentInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {



            RaycastHit hit;
            Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
            
            if(Physics.Raycast(ray, out hit))
            {
                //print("hit");
                Debug.DrawLine(mainCam.transform.position, hit.point, Color.red);
                currentGun.SetRayPoint(hit.point);
            }
            else
            {
                Debug.DrawLine(mainCam.transform.position, mainCam.transform.position + mainCam.transform.forward * 100, Color.green);
                currentGun.SetRayPoint(mainCam.transform.position + mainCam.transform.forward * 100);
            }
        if(isLocalPlayer)
        {
            if(Input.GetMouseButton(0))
            {
                Vector3 hitpoint;
                Vector3 normal;
                //print("shoot");
                if(hit.transform == null)
                {
                    hitpoint = mainCam.transform.position + mainCam.transform.forward * 100;
                    normal = Vector3.zero;
                }
                else
                {
                    hitpoint = hit.point;
                    normal = hit.normal;
                }
                AskShoot(hit.transform,currentGun.porjectileSpawn.position ,hitpoint, normal);
            }
        }
        
    }
    
    [Command]
    void AskShoot(Transform hitTransform, Vector3 shotStartPoint, Vector3 hitPoint, Vector3 normal)
    {
        Shoot(hitTransform,shotStartPoint,hitPoint, normal);
    }
    
    [ClientRpc]
    void Shoot(Transform hitTransform, Vector3 shotStartPoint, Vector3 hitPoint, Vector3 normal)
    {
        currentGun.Shoot(hitTransform,shotStartPoint,hitPoint, normal);
    }
}


