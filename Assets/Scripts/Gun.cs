using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.VFX;

public class Gun :  MonoBehaviour
{
    [SerializeField] public Transform porjectileSpawn;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] VisualEffect muzzleFlash; 
    
    
    
    public float damage;
    public float msBetweenShots;


    float nextShotTime;

    Vector3 point;
    List <Color> cols = new List<Color>();
    void Start()
    {
    cols.Add(Color.red);
    cols.Add(Color.red);
        
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

            muzzleFlash.Play();

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



    IEnumerator ServerDestroyIn(GameObject destroyable, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(destroyable);
    }
}
