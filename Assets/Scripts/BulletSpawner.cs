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
        //<>타입의 컴포넌트를 가진 게임오브젝트를 찾는 메서드, 플레이어 위치 추적
    }
     
    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        //최종적으로 총알을 만든 이후 지난 시간, 흐른 시간이 누적되어 기록됨
        transform.LookAt(target);

        if (timeAfterSpawn > spawnRate)
        {
            timeAfterSpawn = 0f; //스폰 누적시간 리셋
            //탄환 오브젝트 생성, 탄환 생성기의 위치와 회전정보로 생성
            GameObject bullet = Instantiate(prefab, transform.position, transform.rotation);
            //생성된 탄환 오브젝트를 target방향으로 회전, 회전값을 수정하는 메서드
            bullet.transform.LookAt(target); // 한 번만 LookAt()
            //생성 주기 재할당
            spawnRate = Random.Range(rateMin, rateMax);
        }
    }
}