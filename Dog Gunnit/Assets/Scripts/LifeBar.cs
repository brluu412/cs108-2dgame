using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        int health = player.GetComponent<Health>().health;
        if(health <= 40){
            Destroy(GameObject.Find("Bone 5"));
        }
        if(health <= 30){
            Destroy(GameObject.Find("Bone 4"));
        }
        if(health <= 20){
            Destroy(GameObject.Find("Bone 3"));
        }
        if(health <= 10){
            Destroy(GameObject.Find("Bone 2"));
        }
        if(health == 0){
            Destroy(GameObject.Find("Bone 1"));
        }
    }
}
