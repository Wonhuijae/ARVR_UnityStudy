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

    private float surviveTime;
    private bool isGameover; //private ���� ����
    private bool isStageclear;
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
        
    }

    public void EndGame()
    {
        isGameover = true;

        gameoverText.SetActive(true);

        int bestRecord = PlayerPrefs.GetInt("BestRecord");
        // PlayerPrefs���� bestRecord�� Ű�� �ϴ� value�� ������ bestRecord ������ ����

        if (currentStage > bestRecord)
        {
            bestRecord = currentStage;
            PlayerPrefs.SetInt("BestRecord", bestRecord);
        }

        recordText.text = "Best Record: " + bestRecord + " Stage";
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

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void GotoTitle()
    {
        SceneManager.LoadScene(0);
    }
}
