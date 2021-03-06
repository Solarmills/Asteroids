using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up*.2f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.GetComponent<Asteroid>())
        {
            collision.gameObject.GetComponent<Asteroid>().Break();
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<Alien_Ship>()) {
            collision.gameObject.GetComponent<Alien_Ship>().Hitted();
        }
    }
}
