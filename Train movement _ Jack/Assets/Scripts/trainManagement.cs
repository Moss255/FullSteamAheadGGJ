using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainManagement : MonoBehaviour
{
    public GameObject carriage; // used to hold the carriage object

    public int carriageCount; // used to hold the number of carriage current in existence

    public float carriageSpacing;


    // Start is called before the first frame update
    void Start()
    {
        //carriageCount = 2; testing value
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && carriageCount < 5)
        //{

        //    // should be called when player successfully gets through 
        //    addNewCarriage();
        //}
    }

    public void addNewCarriage()
    {
        // Sets up spawning position for object and creates a carriage


        Vector3 carriagePosition = gameObject.transform.position + new Vector3(0, 0, carriageSpacing * carriageCount);

        Instantiate(carriage, carriagePosition, Quaternion.identity, gameObject.transform);

        carriageCount += 1;
    }
}
