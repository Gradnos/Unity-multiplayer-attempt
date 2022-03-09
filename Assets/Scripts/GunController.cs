using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Camera mainCam;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            RaycastHit hit;
            Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
            
            if(Physics.Raycast(ray, out hit))
            {
                print("hit");
                Debug.DrawLine(mainCam.transform.position, hit.point, Color.red);
            }
            else
            {
                Debug.DrawLine(mainCam.transform.position, mainCam.transform.position + mainCam.transform.forward * 100, Color.green);
            }
        
    }
}
