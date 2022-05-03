using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public static SpawnManager Instance { get; private set; }

    public GameObject enemyPrefab;
    public float spawnTimer = 2f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartSpawn()
    {
        InvokeRepeating("SpawnEnemy",0f, spawnTimer);
    }
    //Encargado de generar el enemigo
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
       
    }
    //Detener la generación de enemigos
    public void StopSpawn()
    {
        CancelInvoke("SpawnEnemy");
    }
}
