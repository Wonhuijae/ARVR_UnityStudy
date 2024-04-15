using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;
    public GameObject door;

    private float surviveTime;
    private bool isGameover; //private 생략 가능
    private bool isStageclear;
    private int isSlimedie = 0;
    static int currentStage = 1;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
        isStageclear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover && !isStageclear)
        {
            surviveTime += Time.deltaTime; //시간 누적. Time.deltaTime: 프레임과 프레임 사이에 걸린 시간
            timeText.text = "Time: " + (int)surviveTime;
            //문자열, +: 문자열을 이어줌, int 캐스팅: surviveTime이 float형이기 때문에 소수점 버림
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    public void Slimedie()
    {
        isSlimedie--;
        if(isSlimedie == 0)
        {
            door.GetComponent<DoorController>().Open();
        }
    }

    public void EndGame()
    {
        isGameover = true;

        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");
        // PlayerPrefs에서 BestTime을 키로 하는 value를 가져와 bestTime 변수에 저장

        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }

    public void ClearGame()
    {
        isStageclear = true;
        currentStage++;
        //print(currentStage);

        if (currentStage == 4)
        {
            SceneManager.LoadScene(currentStage);
        }
        else if (GameObject.FindWithTag("BulletSP")==null)
        { 
           SceneManager.LoadScene(currentStage, LoadSceneMode.Single);
           isStageclear=false;
        }
    }
}
