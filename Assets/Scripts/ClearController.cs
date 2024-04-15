using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //on~: 수동 호출x, 상황이 맞으면 자동으로 호출 
    {
        //Colider 타입: 충돌된 다른 객체의 정보
        if (other.tag == "Player")
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.ClearGame();
        }
    }
}
