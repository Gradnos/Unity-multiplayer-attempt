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
                //print("shoot");
                AskShoot(hit.transform,currentGun.transform.position,hit.point);
            }
        }
        
    }
    
    [Command]
    void AskShoot(Transform hitTransform, Vector3 shotStartPoint, Vector3 hitPoint)
    {
        Shoot(hitTransform,shotStartPoint,hitPoint);
    }
    
    [ClientRpc]
    void Shoot(Transform hitTransform, Vector3 shotStartPoint, Vector3 hitPoint)
    {
        currentGun.Shoot(hitTransform,shotStartPoint,hitPoint);
    }
}


