using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations.Rigging;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public GameObject laserAim;
    public Animator playerAnim;

    public GameObject playerRagdoll;
    public GameObject playerAnimated;
    public bool isAlive = true;
    public int bulletAmount = 6;
   
    public bool isCheckPointReached = false;
    public Transform startBox;
    //public Transform checkPointStart;

    private AmmoUI ammoUI;
    private bool isActivated = false;
    [SerializeField]
    private float firstDestTime;
    
   
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        ammoUI = FindObjectOfType<AmmoUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if((GameManager.Instance.gameState == GameState.Play) && !isActivated)
        {
            isActivated = true;
            NextMove(startBox.position , firstDestTime );
            CurrentAnimator(false, true, "Run");
            ammoUI.gameObject.SetActive(false);

          
        }
      
        
    }

    public void NextMove(Vector3 endValue, float duration)
    {
        transform.DOMove(endValue,duration).SetEase(Ease.Linear).SetId("NextDest");
    }

    public void CurrentAnimator( bool isTrigger , bool isTrue ,  string animName)
    {
        if (isTrigger)
        {
            playerAnim.SetTrigger(animName);
        }
        else
        {
            playerAnim.SetBool(animName, isTrue);
        }
    }
    

    public void Shoot()
    {
        

    }
    public void PlayerDead()
    {
        isAlive = false;
        GetComponent<BoxCollider>().isTrigger = true;
        CopyTransformData(playerAnimated.transform, playerRagdoll.transform);
        playerRagdoll.SetActive(true);
        playerAnimated.SetActive(false);
        DOTween.Kill("NextDest");
       

    }
    public void CopyTransformData (Transform sourceTransform, Transform destinationTransform)
    {
        if(sourceTransform.childCount != destinationTransform.childCount)
        {
            Debug.LogWarning("Invalid transform copy! They need to match at hierarchy.");
            return;
        }
        for (int i = 0; i < sourceTransform.childCount; i++)
        {
            
            var source = sourceTransform.GetChild(i);
            var destination = destinationTransform.GetChild(i);
            destination.position = source.position;
            destination.rotation = source.rotation;

            CopyTransformData(source, destination);   
        }
    }
    
}

