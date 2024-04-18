using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    private static AudioManager s_Instance = null;

    public AudioClip doorOpen;
    public AudioClip playerDie;

    public AudioSource audioSo;
    
    // Start is called before the first frame update
    void Start()
    {
        if (s_Instance)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        s_Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name=="End")
        {
            gameObject.SetActive(false);    
        }
    }

    public void DoorOpen()
    {
        audioSo.PlayOneShot(doorOpen);
    }

    public void PlayerDie()
    {
        audioSo.PlayOneShot(playerDie);
    }
}
