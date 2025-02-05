using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource BallSound;

    public void OnTriggerEnter(Collider other)
    {
        BallSound.Play();
        if (other.CompareTag("GameWin"))
        {
            gameManager.GameWin();
        }

        else if (other.CompareTag("GameOver"))
        {
            gameManager.GameOver();

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        BallSound.Play();
    }

}
