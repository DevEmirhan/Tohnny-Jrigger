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
            _playerController.NextMove(destination.position,timeToReach);
            _playerController.CurrentAnimator(isTrigger, isTrue , animName);
            _playerController.TimeScaler(isSlow);
        }
    }
}
