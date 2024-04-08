using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float rateMin = 0.5f;
    public float rateMax = 3f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    
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

        if (timeAfterSpawn > spawnRate)
        {
            timeAfterSpawn = 0f; //���� �����ð� ����
            //źȯ ������Ʈ ����, źȯ �������� ��ġ�� ȸ�������� ����
            GameObject bullet = Instantiate(prefab, transform.position, transform.rotation);
            //������ źȯ ������Ʈ�� target�������� ȸ��, ȸ������ �����ϴ� �޼���
            bullet.transform.LookAt(target); // �� ���� LookAt()
            //���� �ֱ� ���Ҵ�
            spawnRate = Random.Range(rateMin, rateMax);
        }
    }
}