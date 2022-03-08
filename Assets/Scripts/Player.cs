using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : LivingEntity
{
    [SerializeField] Transform playerPartsToHide;

    protected override void Start()
    {
        base.Start();
        if(isLocalPlayer)
        {
        AskHidePlayerParts();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [Command]
    void AskHidePlayerParts()
    {
        print("asked");
        HidePlayerParts();
    }

    [TargetRpc]
    void HidePlayerParts()
    {
        print ("hidden");
        MeshRenderer mr;
        int childCount = playerPartsToHide.childCount;
        for(int i = 0; i < childCount; i++)
        {
            mr = playerPartsToHide.GetChild(i).GetComponent<MeshRenderer>();
            if (mr != null)
            {
                mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
        }  
    }
}
