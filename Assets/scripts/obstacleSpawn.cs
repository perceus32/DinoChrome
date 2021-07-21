using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{
    public GameObject[] prefabs;
    public float xVel, startDelay, repeatDelay;
    public int random;
    public GameObject spawnManager;
    private GameObject child;
    public bool isGameOver=false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generate", startDelay, repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;
        //Debug.Log(isGameOver);
        GameObject MovingChild;
        for (int i = 0; i<transform.childCount;  i++){
            MovingChild = transform.GetChild(i).gameObject;
            MoveObstacle(MovingChild);
            if (MovingChild.transform.position.x < -20)
            {
                Destroy(MovingChild);
            }
            
        }        
        
    }
    void Generate()
    {
        random = Random.Range(0, 3);
        child = Instantiate(prefabs[random], spawnManager.transform.position, Quaternion.identity);
        child.transform.parent = spawnManager.transform;
        
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isGameOver = true;
        }
    }*/


    void MoveObstacle(GameObject child)
    {
        child.transform.position += Vector3.left * xVel * Time.deltaTime; 
    }
    public void GameOver()
    {
        isGameOver = true;
        //FindObjectOfType<dino>().GameOver();
    }

}
