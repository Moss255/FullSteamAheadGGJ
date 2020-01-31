using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{
    //General variables
    public GameObject player;

    public GameObject itemHeld;


    //Movement variables
    public float playerSpeed;
 





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemHeld)
        {
            itemHeld.transform.position = player.transform.position + new Vector3(Input.GetAxis("Horizontal") * 2, 0, Input.GetAxis("Vertical") * 2);
        }

        player.transform.position += new Vector3(Input.GetAxis("Horizontal") * playerSpeed, 0, -Input.GetAxis("Vertical") * playerSpeed) * Time.deltaTime;

        ////Movement
        ///Up
        //if (Input.GetKey(KeyCode.W))
        //{

        //    //Moves player up on Z axis
        //    player.transform.position += new Vector3(0, 0, playerSpeed * Time.deltaTime);

        //}


        /////Down
        //else if (Input.GetKey(KeyCode.S))
        //{

        //    //Moves player down on Z axis
        //    player.transform.position += new Vector3(0, 0, -playerSpeed * Time.deltaTime);

        //}


        /////Left
        //if (Input.GetKey(KeyCode.A))
        //{

        //    //Moves player down on X axis
        //    player.transform.position += new Vector3(-playerSpeed * Time.deltaTime, 0, 0);

        //}


        /////Right
        //else if (Input.GetKey(KeyCode.D))
        //{

        //    //Moves player up on X axis
        //    player.transform.position += new Vector3(playerSpeed * Time.deltaTime, 0, 0);

        //}



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Item"))
        {
            collision.collider.GetComponent<itemInfo>().isCollected = true;
            itemHeld = collision.collider.gameObject;
        }
    }
}
