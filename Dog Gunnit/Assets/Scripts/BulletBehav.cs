using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehav : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().Damage(25);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Dog House"))
        {
            Destroy(gameObject);
        }
    }
}
