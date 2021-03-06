using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Define projectile lifetime
        Destroy(gameObject, 5f);
    }

    //Move projectile b fixed timer, for avoid FPS-based issues
    private void FixedUpdate()
    {
        transform.Translate(Vector3.up*.2f);
    }

    //Operate projectile hit 
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
