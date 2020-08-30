using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScenario : MonoBehaviour
{
    private PlayerController _playerController;

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


    public List<EnemyController> enemies = new List<EnemyController>();



    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
     

    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _playerController.playerAnim.speed = 1f;
            _playerController.laserAim.GetComponent<MeshRenderer>().enabled = false;
            _playerController.NextMove(destination.position,timeToReach);
            _playerController.CurrentAnimator(isTrigger, isTrue , animName);
            if (isContainShoot)
            {
                
                foreach(EnemyController enemy in enemies)
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
