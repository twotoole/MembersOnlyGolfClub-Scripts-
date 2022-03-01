using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Golfer : MonoBehaviour
{
    public int age;
    public int weight;
    public float PoliticalCompass;

    public Text displayAge;
    public Text displayWeight;
    

    void OnAwake()
    {
        age = Random.Range(40, 70);
        weight = Random.Range(180, 300);
        PoliticalCompass = Random.Range(-50, 50);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
