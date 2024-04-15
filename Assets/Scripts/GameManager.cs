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
    private bool isGameover; //private ���� ����
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
            surviveTime += Time.deltaTime; //�ð� ����. Time.deltaTime: �����Ӱ� ������ ���̿� �ɸ� �ð�
            timeText.text = "Time: " + (int)surviveTime;
            //���ڿ�, +: ���ڿ��� �̾���, int ĳ����: surviveTime�� float���̱� ������ �Ҽ��� ����
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
        // PlayerPrefs���� BestTime�� Ű�� �ϴ� value�� ������ bestTime ������ ����

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
