using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform porjectileSpawn;

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
}
