using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations.Rigging;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;
    public bool isCheckPointReached = false;
    public Transform startBox;
    private bool isActivated = false;
    [SerializeField]
    private float firstDestTime;
   
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if((GameManager.Instance.gameState == GameState.Play) && !isActivated)
        {
            isActivated = true;
            NextMove(startBox.position , firstDestTime );
            CurrentAnimator(false, true, "Run");
            TimeScaler(false);
        }
        
    }

    public void NextMove(Vector3 endValue, float duration)
    {
        transform.DOMove(endValue,duration).SetEase(Ease.Linear);
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
    
    public void TimeScaler(bool isSlow)
    {
        if (isSlow)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Shoot()
    {
        

    }

    
}

