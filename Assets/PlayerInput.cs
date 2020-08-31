using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public ParticleSystem shootFx;
    private PlayerController playerController;
    private AmmoUI ammoUI;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        ammoUI = FindObjectOfType<AmmoUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.playerAnim.speed < 1f)
        {
             if (Input.GetMouseButtonDown(0))
            {
                if(playerController.bulletAmount > 0)
                {
                    shootFx.Play();
                    playerController.bulletAmount--;
                    ammoUI.AmmoReduce();

                }
               
                
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("I saw an enemy");
            if (Input.GetMouseButtonDown(0))
            {
                if (other.GetComponent<EnemyController>().isAlive && playerController.bulletAmount > 0)
                {
                other.GetComponent<EnemyController>().EnemyDead();
                }

                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("I missed an enemy");
            other.gameObject.GetComponent<EnemyController>().ShootPlayer();
        }
    }
    
}
