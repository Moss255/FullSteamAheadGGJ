using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakdown : MonoBehaviour
{
    public float health;
    public int currentItemRequired;
    public List<int> possibleItemsRequired;
    public float degradeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Selects item required (Is Random)

        //possibleItemsRequired = SearchItemLoaded();

        //currentItemRequired = possibleItemsRequired[0];
    }
    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            health -= degradeSpeed;
        }


        if (health <= 0 && currentItemRequired == 0)
        {
            selectNewItem();
        }
    }

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

    private void selectNewItem()
    {
        possibleItemsRequired = SearchItemLoaded();

        currentItemRequired = possibleItemsRequired[Random.Range(0, possibleItemsRequired.Count)];
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject itemToCheck = collision.collider.gameObject;
            
        if (itemToCheck.CompareTag("Item"))
        {
            if (currentItemRequired == itemToCheck.GetComponent<itemInfo>().ID)
            {
                Destroy(itemToCheck);
                health = 200f;
            }
        }
    }
}
