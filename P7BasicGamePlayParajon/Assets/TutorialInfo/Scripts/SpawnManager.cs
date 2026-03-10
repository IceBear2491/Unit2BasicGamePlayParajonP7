 using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    public float sideSpawnMinZ;
    public float sideSpawnMaxZ;
    public float sideSpawnX;
    public float topBound = 30;
    public float lowerBound = -30;
    public float sideBound = 30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
        else if (transform.position.x > sideBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
        else if (transform.position.x < -sideBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
    void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }
    void SpawnRightAnimal() 
    { 
      int animalIndex = Random.Range(0, animalPrefabs.Length); 
      Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ)); 
      Vector3 rotation = new Vector3(30, -90, 0);
      Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation)); 
    }
}

