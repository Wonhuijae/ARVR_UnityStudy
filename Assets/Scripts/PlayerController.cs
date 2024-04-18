using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerController : MonoBehaviour //: (�θ� Ŭ���� �̸�) -> ���
{
    public Rigidbody playerRigidbody;
    public float speed = 8f; //float Ÿ�� ����, C#������ ���ִ� ���� ǥ��   

    public VariableJoystick joy;

    public int playerHP = 3;

    public Slider HPSlider;
    int maxHealth;
    int curHealth;

    public GameObject effect;

    public AudioClip sound1;
    public AudioClip sound2;

    public AudioSource audioS;

    // Start is called before the first frame update
    void Start() //ó�� �� �� ����
    {
        playerRigidbody = GetComponent<Rigidbody>();
        maxHealth = playerHP;
        curHealth = playerHP;
        checkHP();
    }

    // Update is called once per frame
    void Update() //�� �����Ӹ��� ����
    {
        //Axis: ��, ����/������ �Է� ����

  
        //float xInput = Input.GetAxis("Horizontal"); //����(�¿� ����Ű) �Է�
        //float zInput = Input.GetAxis("Vertical"); //����(���� ����Ű) �Է�

        float xInput = joy.Horizontal;
        float zInput = joy.Vertical;

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
        GameObject am = GameObject.Find("AudioManager");
        am.GetComponent<AudioManager>().PlayerDie();
        gm.EndGame();
    }

    private void OnTriggerEnter(Collider other) //on~: ���� ȣ��x, ��Ȳ�� ������ �ڵ����� ȣ�� 
    {
        //Colider Ÿ��: �浹�� �ٸ� ��ü�� ����
        if (other.tag == "bullet")
        {
            audioS.PlayOneShot(sound1);
            Instantiate(effect, transform.position, Quaternion.identity);

            /*��ũ��Ʈ ���ϵ� ������Ʈ�̴�. ������Ʈ�� �����ͼ� pc��� ������ ����
            PlayerController pc = other.GetComponent<PlayerController>();
            pc�� ��ȿ�� �������� Ȯ��. valid cheak, ��ȿ�� üũ
            if (pc != null)
            {*/
            curHealth--;
            checkHP();

            if (curHealth == 0)
            {
                audioS.PlayOneShot(sound2);

                Die();
            }
            
        }
    }

    public void checkHP()
    {

        if (HPSlider != null)
        {
            HPSlider.value = (float)curHealth / maxHealth;
        }
    }

    public void HPreset()
    {
        curHealth = 3;
    }
}