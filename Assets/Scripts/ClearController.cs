using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //on~: ���� ȣ��x, ��Ȳ�� ������ �ڵ����� ȣ�� 
    {
        //Colider Ÿ��: �浹�� �ٸ� ��ü�� ����
        if (other.tag == "Player")
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.ClearGame();
        }
    }
}
