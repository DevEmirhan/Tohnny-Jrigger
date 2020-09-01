using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyController : MonoBehaviour
{
    private PlayerController playerController;
    public Animator enemyAnim;

    public GameObject enemyAnimated;
    public GameObject enemyRagdoll;
    public bool isAlive = true;
    public Rig Rigweight;
    public GameObject shootFx;
    public GameObject BloodFx;

    public bool InShootZone = false;
    public GameObject targetPoint;
    public float ShootTime = 1f;
    public float endTime = 1.5f;
    public bool isGunFired = false;
    void Start()
    {
        enemyAnim = GetComponentInChildren<Animator>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InShootZone)
        {
            targetPoint.transform.position = playerController.transform.position;
            if (!isGunFired)
            {
                isGunFired = true;
                StartCoroutine("ShootSequence");
            }


        }
    }
    public void ShootPlayer()
    {
        if (isAlive)
        {
            
            
            shootFx.GetComponent<ParticleSystem>().Play();
            playerController.PlayerDead();
            
        }
    }

     
            
    
            
            
    public void EnemyDead()
    {
        isAlive = false;
        GetComponent<BoxCollider>().isTrigger = true;
        playerController.CopyTransformData(enemyAnimated.transform, enemyRagdoll.transform);
        BloodFx.GetComponent<ParticleSystem>().Play();
        enemyRagdoll.SetActive(true);
        enemyAnimated.SetActive(false);
       
    }
    IEnumerator ShootSequence()
    {
        yield return new WaitForSeconds(ShootTime);
        ShootPlayer();
       

      
        yield return new WaitForSeconds(endTime);
        if (isAlive)
        {
         GameManager.Instance.gameState = GameState.Lose;
        } 
        
    }
 

}
