using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemInfo : MonoBehaviour
{
    public int ID;

    public bool isCollected;

    // Start is called before the first frame update
    void Start()
    {
        ID = Random.Range(1, 5);

        isCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollected)
        {
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isCollected = true;
        }
    }
}
