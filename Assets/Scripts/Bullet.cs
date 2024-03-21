using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour //클래스 이름->대문자
{
    public float speed = 8f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        //스크립트와 같은 소속의 게임오브젝트의 transform 컴포넌트
        //forward: 앞으로 이동
        //velocity: 자기중심 좌표
        //return rotation * Vector3.forward;

        Destroy(gameObject, 3f);
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
            //스크립트 파일도 컴포넌트이다. 컴포넌트를 가져와서 pc라는 변수에 저장
            PlayerController pc = other.GetComponent<PlayerController>();
            //pc가 유효한 변수인지 확인. valid cheak, 유효성 체크
            if (pc != null) 
            {
                pc.Die();
            }
        }
    }
}
