using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSequence : MonoBehaviour
{
    private PlayerController playerController;
    private List<GameObject> particles = new List<GameObject>();
    public GameObject cam1;
    public GameObject cam2;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        foreach(GameObject ps in GameObject.FindGameObjectsWithTag("FinishParticle"))
        {
            particles.Add(ps);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
        if(other.gameObject.tag == "Player")
        {
            playerController.playerAnim.SetBool("Dance", true);
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].GetComponent<ParticleSystem>().Play();
            }
        }
        StartCoroutine("WinSequenceCo");
    }
    IEnumerator WinSequenceCo()
    {
        yield return new WaitForSeconds(3f);
        GameManager.Instance.gameState = GameState.Win;
    }
}
