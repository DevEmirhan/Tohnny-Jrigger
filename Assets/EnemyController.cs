using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private PlayerController playerController;
    public Animator enemyAnim;
    public bool isAlive = true;
    public bool InShootZone = false;
    public GameObject targetPoint;
    public float ShootTime = 1f;
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
            //Bullet Particle
            //Bullet Shoot as Pool Object
            playerController.isAlive = false;
            GameManager.Instance.gameState = GameState.Lose;
        }
    }
    IEnumerator ShootSequence()
    {
        yield return new WaitForSeconds(ShootTime);
        ShootPlayer();
    }

}
