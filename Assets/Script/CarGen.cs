using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarGen : MonoBehaviour
{
    public GameObject[] prefabCars;
    public GameObject[] prefabcoin;
  
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("generateCar", 1f, 2f);
        InvokeRepeating("coingenrate", 3f, 5f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void generateCar()
    {
        int r = Random.Range(0, prefabCars.Length);
        Vector2 pos = new Vector2(Random.Range(-1.7f, 1.7f), transform.position.y);
        Instantiate(prefabCars[r], pos, Quaternion.identity);
    }
    void coingenrate()
    {
        int c = Random.Range(0, prefabcoin.Length);
        Vector2 pos = new Vector2(Random.Range(-1.7f, 1.7f), transform.position.y);
        Instantiate(prefabcoin[c], pos, Quaternion.identity); 
    }
}
