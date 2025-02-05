using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallScale : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Time;
    [SerializeField] private int StartTime;
    [SerializeField] private GameManager gameManager;
    void Start()
    {
        StartCoroutine(StartTimes());
    }

    IEnumerator StartTimes()
    {
        Time.text = StartTime.ToString();
        while (true)
        {

            yield return new WaitForSeconds(1f);
            StartTime--;
            Time.text = StartTime.ToString();

            if (StartTime == 0)
            {
                gameObject.SetActive(false);
                break;
            }
           
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        //gameManager.BallScale();       
    }
}
