using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Animal"))
        {
            gameManager.AddScore(50);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
