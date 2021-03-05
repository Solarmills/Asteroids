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
        transform.Translate(Vector3.up*.1f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.GetComponent<Asteroid>())
        {
            Debug.Log("w/ asteroid");
            collision.gameObject.GetComponent<Asteroid>().Break();
            Destroy(gameObject);
        }
    }
}
