using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BulletSpawner : MonoBehaviour
{
    public GameObject normalSlime;
    public GameObject rablitSlime;
    public GameObject vikingSlime;
    public GameObject catSlime;
    public GameObject leafSlime;

    public float rateMin = 0.5f;
    public float rateMax = 3f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    public int spawnCount = 10;


    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(rateMin, rateMax);
        target = FindObjectOfType<PlayerController>().transform;
        //<>Ÿ���� ������Ʈ�� ���� ���ӿ�����Ʈ�� ã�� �޼���, �÷��̾� ��ġ ����
    }
     
    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        //���������� �Ѿ��� ���� ���� ���� �ð�, �帥 �ð��� �����Ǿ� ��ϵ�
        transform.LookAt(target);
        int slime = Random.Range(1, 6);

        if (timeAfterSpawn > spawnRate)
        {
            timeAfterSpawn = 0f; //���� �����ð� ����
            //źȯ ������Ʈ ����, źȯ �������� ��ġ�� ȸ�������� ����
            switch (slime)
            {
                case 1:
                    makeBullet(normalSlime); break;

                case 2:
                    makeBullet(rablitSlime); break;
                case 3:
                    makeBullet(vikingSlime); break;
                case 4:
                    makeBullet(catSlime); break;
                case 5:
                    makeBullet(leafSlime); break;
            }
            spawnCount--;

            if (spawnCount == 0)
            {
                GameManager gm = FindObjectOfType<GameManager>();
                gm.Slimedie();
                gameObject.SetActive(false);
            }


        }
    }

    void makeBullet(GameObject slime)
    {
        GameObject bullet = Instantiate(slime, transform.position, transform.rotation);
        //������ źȯ ������Ʈ�� target�������� ȸ��, ȸ������ �����ϴ� �޼���
        bullet.transform.LookAt(target); // �� ���� LookAt()
                                         //���� �ֱ� ���Ҵ�
        spawnRate = Random.Range(rateMin, rateMax);
    }

}