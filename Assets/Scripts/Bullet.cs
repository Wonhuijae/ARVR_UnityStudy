using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour //Ŭ���� �̸�->�빮��
{
    public float speed = 8f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        //��ũ��Ʈ�� ���� �Ҽ��� ���ӿ�����Ʈ�� transform ������Ʈ
        //forward: ������ �̵�
        //velocity: �ڱ��߽� ��ǥ
        //return rotation * Vector3.forward;

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
