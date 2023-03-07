using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaygunController : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        float angle = Mathf.Atan2(transform.position.y - mousePos.y, transform.position.x - mousePos.x) * Mathf.Rad2Deg - 180;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetMouseButtonDown(0)) {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.position.x - mousePos.x, transform.position.y - mousePos.y).normalized * projectileSpeed * -1;
        }
    }
}
