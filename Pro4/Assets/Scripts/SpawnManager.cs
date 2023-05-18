using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{ 
   public GameObject [] enemyPrefab;
   public GameObject powerupPrefeb,player;
   public int enemyCount=0,index;
   int counter=1;
   float spownRange=9;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(1);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount=FindObjectsOfType<Enemy>().Length;
        
        if(enemyCount==0)
        {   counter++;
            SpawnEnemy(counter);
            spawnPowerup();
        }
       
    }
    void SpawnEnemy(int enemisToSpawn){
        for(int i=0 ; i<enemisToSpawn;i++)
        {  index= Random.Range(0,2);
            Instantiate(enemyPrefab[index],SpawnPosition(),enemyPrefab[index].transform.rotation);
        }
    }
    void spawnPowerup(){
     
        Instantiate(powerupPrefeb,SpawnPosition(),player.gameObject.transform.rotation);
    }
   
    Vector3 SpawnPosition(){
          float spownPosX=Random.Range(-spownRange,spownRange);
        float spownPosZ=Random.Range(-spownRange,spownRange);
        Vector3 spawnPosition=new Vector3(spownPosX,1,spownPosZ);
        return spawnPosition;
    }
    
}
