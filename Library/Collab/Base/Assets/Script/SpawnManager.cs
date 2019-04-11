using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   // [SerializeField]
   // private GameObject playerSquirrel;
    [SerializeField]
    private GameObject[] foodPrefabs;
    [SerializeField]
    private GameMaster gameMaster;

    // Start is called before the first frame update
   

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartSpawn()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();

        if (gameMaster != null)
        {
            StartCoroutine(FoodSpawnRoutine());
        }
    }
    private IEnumerator FoodSpawnRoutine()
    {
        while (gameMaster.IsGameOn())
        {
            int randomIndex =Random.Range(0,4);
            float randomX = Random.Range(-2.0f, 2.0f);
            Instantiate(foodPrefabs[randomIndex], new Vector3(randomX, 5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
