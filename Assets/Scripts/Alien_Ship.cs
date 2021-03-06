using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_Ship : MonoBehaviour
{
    public Gameplay_manager manager;
    public Ship_controller player;

    //Rotate and move alien to player
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
