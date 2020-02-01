using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Colour
{
    red,
    blue,
    green,
    purple
}
public class breakdown : MonoBehaviour
{



    //Health variables
    public float health;

    public float maxHealth;

    public List<Material> carriageHealthMaterials;

    public GameObject carriageVisuals;

    



    public int currentItemRequired;
    public List<int> possibleItemsRequired;
    public float degradeSpeed;

    public Colour carriageColour;


    //Train variables
    public GameObject train;

    public float carriagePos;


    

    //UI variables
    public SpriteRenderer carriageCall1;

    //Image lists
    public List<Sprite> beachImageList;

    // Start is called before the first frame update
    void Start()
    {
        selectNewItem();


        train = GameObject.Find("train");

        carriagePos = train.GetComponent<trainManagement>().carriageSpacing * train.GetComponent<trainManagement>().carriageCount;

        // Selects item required (Is Random)

        //possibleItemsRequired = SearchItemLoaded();

        //currentItemRequired = possibleItemsRequired[0];
    }
    // Update is called once per frame
    void Update()
    {

        //Carriage placement
        gameObject.transform.position = train.transform.position + new Vector3(0, -1, carriagePos);

        ////Health
        ///Reduction
        if (health > 0)
        {
            health -= degradeSpeed;
        }


        if(health >= maxHealth / 4)
        {

            foreach(Transform child in carriageVisuals.transform)
            {
                if(child.GetComponent<MeshRenderer>() != null)
                {

                    child.GetComponent<MeshRenderer>().material = carriageHealthMaterials[0];

                }


            }

            

        }

        else if (health < maxHealth / 4)
        {

            foreach (Transform child in carriageVisuals.transform)
            {
                if (child.GetComponent<MeshRenderer>() != null)
                {

                    child.GetComponent<MeshRenderer>().material = carriageHealthMaterials[1];

                }


            }


        }


        ////Debug
        //if (Input.GetKeyDown(KeyCode.O))
        //{

        //    selectNewItem();

        //}




        ////UI
        ///Sets UI to show current item above carriage
        //Beach ball
        if (currentItemRequired == possibleItemsRequired[0])
        {

            carriageCall1.sprite = beachImageList[0];

        }

        //Bucket
        else if (currentItemRequired == possibleItemsRequired[1])
        {

            carriageCall1.sprite = beachImageList[1];

        }

        //Sunglasses
        else if (currentItemRequired == possibleItemsRequired[2])
        {

            carriageCall1.sprite = beachImageList[2];

        }
    }

    
    ////Classes and lists
    private List<int> SearchItemLoaded()
    {

        //// Look for items that are currently loaded and adds them to a list.
        List<int> returnItems = new List<int>();

        GameObject[] possibleItems = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject item in possibleItems)
        {
            print(item.GetComponent<itemInfo>().ID);
            returnItems.Add(item.GetComponent<itemInfo>().ID);
        }

        return returnItems;
    }

    ///Chooses a new item
    private void selectNewItem()
    {
        

        currentItemRequired = possibleItemsRequired[Random.Range(0, possibleItemsRequired.Count)];
    }



    ////Collisions
    public void OnCollisionEnter(Collision collision)
    {
        GameObject itemToCheck = collision.collider.gameObject;
        
        ////Healing
        ///Item collides with carriage
        if (itemToCheck.CompareTag("Item"))
        {
            if (currentItemRequired == itemToCheck.GetComponent<itemInfo>().ID)
            {
                Destroy(itemToCheck);
                health = maxHealth;

                //Chooses new item
                selectNewItem();
            }
        }

       
        ///Player collides with carriage while player is holding item
        if (collision.gameObject.tag == "Player")
        {
           

            print(collision.gameObject.GetComponent<playerMovementScript>().itemHeld.GetComponent<itemInfo>().ID);

            print(currentItemRequired);

            if (currentItemRequired == collision.gameObject.GetComponent<playerMovementScript>().itemHeld.GetComponent<itemInfo>().ID)
            {
                

                Destroy(itemToCheck.GetComponent<playerMovementScript>().itemHeld);
                health = maxHealth;

                //Chooses new item
                selectNewItem();
            }
        }
    }
}
