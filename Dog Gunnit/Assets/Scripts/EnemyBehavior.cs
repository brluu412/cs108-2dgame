using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private EnemyData data;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        SetEnemyValues();  
    }

    // Update is called once per frame
    void Update()
    {
        Swarm();
    }

    void FixedUpdate()
    {
       
    }

    private void SetEnemyValues(){
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    

    private void Swarm(){
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.CompareTag("Player")){
            if(collider.gameObject.GetComponent<Health>() != null){
                collider.gameObject.GetComponent<Health>().Damage(damage);
                this.GetComponent<Health>().Damage(100);
            }

        }
    }

    
}
