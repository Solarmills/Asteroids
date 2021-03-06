using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_Ship : MonoBehaviour
{
    public Gameplay_manager manager;
    public Ship_controller player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        float NewZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, NewZ - 90);
        transform.Translate(direction*.05f);
    }

    public void Hitted() 
    {
        manager.AddScore(300);
        Destroy(gameObject);
    }
}
