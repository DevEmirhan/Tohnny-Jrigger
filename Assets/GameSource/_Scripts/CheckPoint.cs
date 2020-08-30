using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private ParticleSystem greenParticle;
    private PlayerController playerController;
    void Start()
    {
        greenParticle = GetComponentInChildren<ParticleSystem>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        playerController.isCheckPointReached = true;
        greenParticle.Play();
    }
}
