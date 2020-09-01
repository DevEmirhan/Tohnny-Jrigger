using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScenario : MonoBehaviour
{
    private PlayerController _playerController;
    private AmmoUI ammoUI;
    

    [Space(5)] [Header("Move Properties")][Space(5)]
    [SerializeField]
    private Transform destination;
    [SerializeField]
    private float timeToReach;
    [SerializeField]
    private bool isContainShoot;

    [Space(5)] [Header("Animation Properties")][Space(5)]
    [SerializeField]
    private bool isTrigger;
    [SerializeField]
    private bool isTrue;
    [SerializeField]
    private string animName;
    [Space(5)] [Header("Time Properties")] [Space(5)]
    [SerializeField]
    private bool isSlow;
    [SerializeField]
    private float slowAmount = 0.5f;
    [SerializeField]
    private int desiredBulletForZone = 6;
    


    public List<EnemyController> enemies = new List<EnemyController>();



    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        ammoUI = FindObjectOfType<AmmoUI>();


    }

    // Update is called once per frame
    void Update()
    {
     if(_playerController.isAlive == false)
        {
            _playerController.playerAnim.speed = 1f;
            foreach (EnemyController enemy in enemies)
            {
                enemy.enemyAnim.speed = 1f;
                enemy.GetComponent<Collider>().isTrigger = true;
                enemy.enemyAnim.SetBool("PlayerLose", true);
                enemy.Rigweight.weight = 0f;

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (ammoUI.gameObject.activeInHierarchy)
            {
            ammoUI.gameObject.SetActive(false);
            }

            _playerController.playerAnim.speed = 1f;
            _playerController.bulletAmount = desiredBulletForZone;
            _playerController.laserAim.GetComponent<MeshRenderer>().enabled = false;
            _playerController.NextMove(destination.position,timeToReach);
            _playerController.CurrentAnimator(isTrigger, isTrue , animName);
            if (isContainShoot)
            {
                ammoUI.gameObject.SetActive(true);
                ammoUI.Reload();
                foreach (EnemyController enemy in enemies)
                {
                    enemy.enemyAnim.speed = slowAmount;
                    enemy.InShootZone = true;
                    enemy.enemyAnim.SetBool("ShootTime", true);
                    
                }
                _playerController.laserAim.GetComponent<MeshRenderer>().enabled = true;
            }
            if (isSlow)
            {
                _playerController.playerAnim.speed = slowAmount;
            }
        }
    }
 
}
