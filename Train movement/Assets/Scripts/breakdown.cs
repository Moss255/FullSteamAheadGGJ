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
    public float health;
    public int currentItemRequired;
    public List<int> possibleItemsRequired;
    public float degradeSpeed;

    public Colour carriageColour;


    

    //UI variables
    public SpriteRenderer carriageCall1;

    //Image lists
    public List<Sprite> beachImageList;

    // Start is called before the first frame update
    void Start()
    {
        selectNewItem();

        // Selects item required (Is Random)

        //possibleItemsRequired = SearchItemLoaded();

        //currentItemRequired = possibleItemsRequired[0];
    }
    // Update is called once per frame
    void Update()
    {

        ////Health
        ///Reduction
        if (health > 0)
        {
            health -= degradeSpeed;
        }


        //Debug
        if (Input.GetKeyDown(KeyCode.O))
        {

            selectNewItem();

        }


        ////UI
        ///Sets UI to show current item above carriage
        //Beach ball
        if(currentItemRequired == possibleItemsRequired[0])
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
                health = 200f;

                //Chooses new item
                selectNewItem();
            }
        }

        ///Player collides with carriage while player is holding item
        if (itemToCheck.CompareTag("Player"))
        {
            if (!itemToCheck.GetComponent<playerMovementScript>().followPlayer)
            {
                if (currentItemRequired == itemToCheck.GetComponent<playerMovementScript>().itemHeld.GetComponent<itemInfo>().ID)
                {
                    Destroy(itemToCheck.GetComponent<playerMovementScript>().itemHeld);
                    health = 200f;

                    //Chooses new item
                    selectNewItem();
                }
            }
        }
    }
}
