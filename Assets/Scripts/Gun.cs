using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.VFX;

public class Gun :  MonoBehaviour
{
    [SerializeField] public Transform porjectileSpawn;
    [SerializeField] VisualEffect muzzleFlash; 
    [SerializeField] VisualEffect bulletImpact;
    
    
    
    public float damage;
    public float msBetweenShots;


    GameObject mainCam;

    float nextShotTime;

    Vector3 point;
    List <Color> cols = new List<Color>();
    void Start()
    {
        cols.Add(Color.red);
        cols.Add(Color.red);
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        
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



    


    public void Shoot(Transform hitTransform, Vector3 shotStartPoint, Vector3 hitPoint, Vector3 normal)
    {
        
        if(Time.time > nextShotTime)
        {
            print("shot");
            nextShotTime = Time.time + msBetweenShots/1000f;

            muzzleFlash.Play();
            AudioManager.Instance.playAtAudioSource("GunShot_01", mainCam.GetComponent<AudioSource>());
            if(hitTransform != null)
            {
                print("prebop");
                IDamagable damagableObject = hitTransform.GetComponent<IDamagable>();
                if (damagableObject != null)
                {   
                    damagableObject.TakeHit(damage, hitPoint, (hitPoint-shotStartPoint).normalized);
                    
                }
                else
                {
                    print("boop");
                    VisualEffect impact = Instantiate(bulletImpact, hitPoint, Quaternion.LookRotation(normal));
                    impact.Play();
                    GameObject.Destroy(impact,10f);
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
