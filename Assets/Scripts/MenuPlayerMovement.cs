using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuPlayerMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform lookingParts;
    // Start is called before the first frame update
    void Start()
    {
        player.DOJump(player.transform.position + Vector3.right * 4, 3,1, 1).SetLoops(-1,LoopType.Yoyo);
        player.DORotate(new Vector3(0,360,0), .5f, RotateMode.FastBeyond360).SetLoops(-1,LoopType.Restart).SetEase(Ease.Linear);
        lookingParts.DOLocalRotate(new Vector3(-45 ,0,0), 0.1f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
       // player.DOMove(player.transform.position + Vector3.up * 3, .5f).SetEase(Ease.OutSine).SetLoops(-1, LoopType.Yoyo);
        //player.DOMove(player.transform.position + Vector3.right * 3, 1).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
    }

}
