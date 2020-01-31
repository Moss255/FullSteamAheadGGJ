using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-30, 0, 0));
        }
        
    }
}
