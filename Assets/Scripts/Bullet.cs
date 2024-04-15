using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Bullet : MonoBehaviour //Ŭ���� �̸�->�빮��
{
    public float speed = 8f;
    Rigidbody rb;

    public Slider HPSlider;
    public int maxHealth = FindObjectOfType<PlayerController>().playerHP;
    public int curHealth;

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


    public void checkHP()
    {
        if (HPSlider != null)
        {
            HPSlider.value = curHealth / maxHealth;
        }
    }

    private void OnTriggerEnter(Collider other) //on~: ���� ȣ��x, ��Ȳ�� ������ �ڵ����� ȣ�� 
    {
        //Colider Ÿ��: �浹�� �ٸ� ��ü�� ����
        if (other.tag == "Player")
        {
            //��ũ��Ʈ ���ϵ� ������Ʈ�̴�. ������Ʈ�� �����ͼ� pc��� ������ ����
            PlayerController pc = other.GetComponent<PlayerController>();
            //pc�� ��ȿ�� �������� Ȯ��. valid cheak, ��ȿ�� üũ
            if (pc != null) 
            {
                curHealth--;


                if(curHealth == 0)
                {
                    pc.Die();
                }
            }
        }
    }
}
