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
    
    public GameObject door;

    int spCnt;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] sp = GameObject.FindGameObjectsWithTag("BulletSP");
        spCnt = sp.Length;

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
        spCnt--;
        if(spCnt==0)
        {
            door.GetComponent<DoorController>().Open();
            GameObject am = GameObject.Find("AudioManager");
            am.GetComponent<AudioManager>().DoorOpen();
        }
    }

    public void EndGame()
    {
        isGameover = true;
        int currentStage = SceneManager.GetActiveScene().buildIndex;
        gameoverText.SetActive(true);

        int bestRecord = PlayerPrefs.GetInt("BestRecord");
        // PlayerPrefs���� bestRecord�� Ű�� �ϴ� value�� ������ bestRecord ������ ����

        if (currentStage > bestRecord)
        {
            bestRecord = currentStage;
            PlayerPrefs.SetInt("BestRecord", bestRecord);
        }

        if (bestRecord == 4)
        {
            recordText.text = "Best Record: CLEAR!";
        }
        else
        {
            recordText.text = "Best Record: " + bestRecord + " Stage";
        }
    }

    public void ClearGame()
    {
        isStageclear = true;
        int currentStage = SceneManager.GetActiveScene().buildIndex;
        currentStage++;
       
        FindObjectOfType<PlayerController>().HPreset();

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

    public void Exit()
    {
        Application.Quit();
    }
}
