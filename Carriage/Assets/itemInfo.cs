using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemInfo : MonoBehaviour
{
    public int ID;

    // Start is called before the first frame update
    void Start()
    {
        ID = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
