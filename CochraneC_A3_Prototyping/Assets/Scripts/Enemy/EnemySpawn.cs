using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemySpawnPoint;
    private GameObject currentSpawnPoint;
    public GameObject enemyPrefab;
    public GameManager gameManager;
    private List<GameObject> spawnLocation;

    void Start(){

    }
    void Update(){
        if(gameManager.triggerSound == true){
            gameManager.triggerSound = false;
            for(int i = 0; i < gameManager.difficultyLevel; i++){
                FloorOneSpawn();
            }
        }
    }
    void FloorOneSpawn(){
        int randomNum = Random.Range(0, enemySpawnPoint.Length);
        currentSpawnPoint = enemySpawnPoint[randomNum];
        var enemy = Instantiate(enemyPrefab, currentSpawnPoint.transform.position, currentSpawnPoint.transform.rotation); 
    }
}
