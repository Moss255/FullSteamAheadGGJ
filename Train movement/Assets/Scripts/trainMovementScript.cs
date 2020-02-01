using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainMovementScript : MonoBehaviour
{

    //General variables
    public GameObject train;

    //Movement variables
    public float trainSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ////Continous movement
        ///Forward movement
        train.transform.position += new Vector3(0, 0, -trainSpeed * Time.deltaTime);


        
    }
}
