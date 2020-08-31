using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject[] bullets;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reload()
    {
        for (int i = 0; i < playerController.bulletAmount; i++)
        {
            bullets[i].SetActive(true);
        }
    }
    public void AmmoReduce()
    {
        int currentNumber = playerController.bulletAmount;
        bullets[currentNumber].SetActive(false);
    }
}
