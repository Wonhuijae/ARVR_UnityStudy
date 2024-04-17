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

}
