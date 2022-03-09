using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : LivingEntity
{
    [SerializeField] Transform playerPartsToHide;
    [SerializeField] Transform drawOnTopObjects;

    protected override void Start()
    {
        base.Start();
        if(isLocalPlayer)
        {
        transform.tag = "LocalPlayer";
        AskToHidePlayerParts();
        DrawOnTopClient(drawOnTopObjects);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }


    [Command]
    void AskToHidePlayerParts()
    {
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

    void DrawOnTopClient(Transform objects)
    {
        GameObject currentObject;
        int childCount = objects.childCount;
        for(int i = 0; i < childCount; i++)
        {
            currentObject = objects.GetChild(i).gameObject;
            if (currentObject != null)
            {
                currentObject.layer = LayerMask.NameToLayer("OnTop");
                if (currentObject.transform.childCount > 0 )
                {
                   DrawOnTopClient(currentObject.transform);
                }
            }
        }  
    }

    
}
