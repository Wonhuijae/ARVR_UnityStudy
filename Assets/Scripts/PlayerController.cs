using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour //: (�θ� Ŭ���� �̸�) -> ���
{
    public Rigidbody playerRigidbody;
    public float speed = 8f; //float Ÿ�� ����, C#������ ���ִ� ���� ǥ��   

    public int playerHP = 3;

    // Start is called before the first frame update
    void Start() //ó�� �� �� ����
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() //�� �����Ӹ��� ����
    {
        //Axis: ��, ����/������ �Է� ����
        float xInput = Input.GetAxis("Horizontal"); //����(�¿� ����Ű) �Է�
        float zInput = Input.GetAxis("Vertical"); //����(���� ����Ű) �Է�

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //������ ǥ���ϴ� Ŭ����
        Vector3 newVel = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVel;
        //velocity: ������ٵ��� ��� ����(������Ƽ), �ּҷ� ���� ���޹���, ���� �־ �������.

        /* ���۰� ����(���� �ڵ�)
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
        }*/
    }

    public void Die()
    {
        //gameObject: ��ũ��Ʈ�� �Ҽӵ� ������Ʈ, ���� ���� �ʿ� ����
        gameObject.SetActive(false);

        GameManager gm = FindObjectOfType<GameManager>();
        gm.EndGame();
    }
}