using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {

        gameObject.SetActive(false);
        //transform.position = new Vector3(0.97f, 0, 1.232f);
        //transform.rotation = Quaternion.Euler(0, 90, 0);
    }
}
