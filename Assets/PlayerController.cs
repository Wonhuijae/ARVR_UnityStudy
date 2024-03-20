using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour //: (�θ� Ŭ���� �̸�) -> ���
{
    public Rigidbody playerRigidbody;
    public float speed = 8f; //float Ÿ�� ����, C#������ ���ִ� ���� ǥ��

    // Start is called before the first frame update
    void Start() //ó�� �� �� ����
    {
        
    }

    // Update is called once per frame
    void Update() //�� �����Ӹ��� ����
    {
        //AddForce: �� �ֱ�
        //Input: �Է� ����
        //GetKey: Ű���� �Է� ����, ������ ������ ��� ����, *GetKeyDown: ���� ������ ����
        //UpArrow: ���� ȭ��ǥ

        // speed ���� �� �ֱ�, z����
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }

        if(Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        // speed ���� �� �ֱ�, x����
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
             playerRigidbody.AddForce(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
    }
}
