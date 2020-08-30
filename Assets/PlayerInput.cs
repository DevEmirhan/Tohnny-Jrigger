using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //private ParticleSystem shootFx;
    void Start()
    {
        //shootFx = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("I saw an enemy");
            if (Input.GetMouseButtonDown(0))
            {
                other.GetComponent<EnemyController>().EnemyDead();
                //shootFx.Play();
            }
        }
    }
}
