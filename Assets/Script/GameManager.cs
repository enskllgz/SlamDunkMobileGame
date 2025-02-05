using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Platform;
    private Vector3 baslangıcboyutu;
    [SerializeField] private GameObject Ball;
    [SerializeField] private GameObject BallScales;
    [SerializeField] private GameObject[] BallScaleCreate;
    [SerializeField] private Image[] MıssıonPıcture;
    [SerializeField] private Sprite MıssıonOkeySprite;
    [SerializeField] private int MıssıonBall;
    [SerializeField] private AudioSource[] Sesler;
    [SerializeField] private GameObject[] Paneller;
    int BallNumber;
    float FingerPozX;

    void Start()
    {
        //Time.timeScale = 0;
        baslangıcboyutu = new Vector3(0.5f, 0.5f, 0.5f);

        for (int i = 0; i < MıssıonBall; i++)
        {
            MıssıonPıcture[i].gameObject.SetActive(true);
        }

        Invoke("BallScaleCreates", 3f);
    }

    private void BallScaleCreates()
    {
        int randomNumber = Random.Range(0, BallScaleCreate.Length - 1);
        
        BallScales.transform.position = BallScaleCreate[randomNumber].transform.position;
        BallScales.SetActive(true);      
        StartCoroutine(EskiHalineDön());
    }

     IEnumerator EskiHalineDön()
    {
        yield return new WaitForSeconds(8f);
        // Topun boyutunu eski haline döndür
        Ball.transform.localScale = baslangıcboyutu;
    }

    void Update()
    {

        if (Time.timeScale != 0)
        {
            if (Input.touchCount>0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 TouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        FingerPozX = TouchPosition.x - Platform.transform.position.x;
                        break;

                    case TouchPhase.Moved:
                        if (TouchPosition.x - FingerPozX > - 1.00 && TouchPosition.x - FingerPozX < 1.00)
                        {
                            Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(TouchPosition.x - FingerPozX, Platform.transform.position.y, Platform.transform.position.z), 5f);
                        }
                        break;
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Platform.transform.position.x > -0.90)
                    Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x - .3f, Platform.transform.position.y, Platform.transform.position.z), .050f);
            }

            else if (Input.GetKey(KeyCode.RightArrow))
           {
                if (Platform.transform.position.x < +0.90)
                    Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x + .3f, Platform.transform.position.y, Platform.transform.position.z), .050f);
            }
        }

        
       
    }
    public void GameWin()
    {
        BallNumber++;
        MıssıonPıcture[BallNumber - 1].sprite = MıssıonOkeySprite;
        Sesler[1].Play();
        if (BallNumber == MıssıonBall)
        {
            Win();
        }
        /*if (BallNumber == 1)
        {
            BallScaleCreates();
        }*/
    }

    public void GameOver()
    {
        Sesler[3].Play();
        Paneller[2].SetActive(true);
        Time.timeScale = 0;
        //Debug.Log("Kaybettin");
    }
    void Win()
    {
        //Debug.Log("Kazandın");
        Sesler[2].Play();
        Paneller[1].SetActive(true);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        Time.timeScale = 0;
    }

    public void BallScale()
    {
        Sesler[0].Play();
        Ball.transform.localScale = new Vector3(1f, 1f, 1f);      
    }
    public void Buttons(string Deger)                                                                                                                                                                                                                                  

    {
        switch (Deger)
        {
            case "Pause":
                Time.timeScale = 0;
                Paneller[0].SetActive(true);
                break;
            case "Resume":
                Time.timeScale = 1;
                Paneller[0].SetActive(false);
                break;
            case "TryAgain":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;               
                break;
            case "Next":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Time.timeScale = 1;
                break;
            case "Menu":
                SceneManager.LoadScene(0);      
                break;
            case "Quit":
                Application.Quit();
                break;
        }
    }
    
}