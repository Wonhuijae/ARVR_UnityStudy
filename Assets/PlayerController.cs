using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour //: (부모 클래스 이름) -> 상속
{
    public Rigidbody playerRigidbody;
    public float speed = 8f; //float 타입 강조, C#에서는 해주는 것이 표준   

    // Start is called before the first frame update
    void Start() //처음 한 번 실행
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() //매 프레임마다 실행
    {
        //Axis: 축, 수평/수직축 입력 감지
        float xInput = Input.GetAxis("Horizontal"); //수평(좌우 방향키) 입력
        float zInput = Input.GetAxis("Vertical"); //수직(상하 방향키) 입력

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //방향을 표시하는 클래스
        Vector3 newVel = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVel;
        //velocity: 리지드바디의 멤버 변수(프로퍼티), 주소로 값을 전달받음, 직접 넣어도 상관없음.

        /* 조작감 개선(이전 코드)
        //AddForce: 힘 주기
        //Input: 입력 감지
        //GetKey: 키보드 입력 감지, 누르고 있으면 계속 감지, *GetKeyDown: 누른 순간만 감지
        //UpArrow: 위쪽 화살표

        // speed 방향 힘 주기, z방향
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }

        if(Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        // speed 방향 힘 주기, x방향
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
             playerRigidbody.AddForce(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }*/
    }

    public void Die()
    {
        //gameObject: 스크립트가 소속된 오브젝트, 따로 선언 필요 없음
        gameObject.SetActive(false);
    }
}