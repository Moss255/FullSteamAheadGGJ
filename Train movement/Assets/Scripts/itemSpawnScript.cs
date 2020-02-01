using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawnScript : MonoBehaviour
{
    ///General variables
    public GameObject itemTemplate;

    public GameObject train;

    public Transform trainTransform;


    public float itemSpawnTimer;

    public float timeToSpawn;


    public float obstacleSpawnTimer;
    public float obstacleTimeToSpawn;


    ///Lists
    //Item names
    public List<string> beachItems;

    //Item meshes
    public List<Mesh> beachMeshes;

    //Item materials
    public List<Material> beachMaterials;

    //Obstacle list
    public List<GameObject> beachObstacles;


    // Start is called before the first frame update
    void Start()
    {

        trainTransform = train.transform;

    }

    // Update is called once per frame
    void Update()
    {
        ////Item spawn
        ///Timer increase every frame
        itemSpawnTimer += Time.deltaTime;

        ///Item spawning
        if(itemSpawnTimer >= timeToSpawn)
        {
            //Spawns item
            var spawnedItem = Instantiate(itemTemplate, new Vector3(trainTransform.position.x + Random.Range(4f, 15f), 1.5f, trainTransform.position.z + Random.Range(-5f, 5f)), transform.rotation);

            var itemInfo = Random.Range(0, beachItems.Count);

            //Changes item name
            spawnedItem.name = beachItems[itemInfo];
            spawnedItem.GetComponent<itemInfo>().itemName = spawnedItem.name;

            //Changes item mesh and material
            spawnedItem.GetComponent<MeshFilter>().mesh = beachMeshes[itemInfo];
            spawnedItem.GetComponent<MeshRenderer>().material = beachMaterials[itemInfo];


            //Destroys item
            Destroy(spawnedItem, 15);

            //Reset timer
            itemSpawnTimer = 0;


            
        }


        ////Obstacle spawn
        ///Timer increase
        obstacleSpawnTimer += Time.deltaTime;

        ///Item spawning
        if (obstacleSpawnTimer >= obstacleTimeToSpawn)
        {
            


            //Spawns obstacles
            var obstacle = Instantiate(beachObstacles[Random.Range(0, beachObstacles.Count)], new Vector3(trainTransform.position.x + Random.Range(4f, 15f), 0.5f, trainTransform.position.z + Random.Range(-25f, -15f)), transform.rotation);

            obstacleSpawnTimer = 0f;

            Destroy(obstacle, 25);


        }


    }
}
