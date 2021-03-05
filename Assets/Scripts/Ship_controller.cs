using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_controller : MonoBehaviour
{

    [SerializeField] private GameObject Fire_point;
    [SerializeField] private Projectile Projectile;
    [SerializeField] private Gameplay_manager Manager;
    private bool Input_Locked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input_Locked) return;
        if (Input.GetButtonDown("Jump")) {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (Input_Locked) return;
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0, 0, Input.GetAxis("Horizontal")*3f);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(0, Input.GetAxis("Vertical") * .1f, 0);
        }
     
    }

    private void Shoot() {
        Instantiate(Projectile, Fire_point.transform.position, transform.rotation, null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Asteroid>()) {
            Input_Locked = true;
            Manager.Lose();
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(0, 0, 1);
        transform.Rotate(new Vector3(0, 0, 0));
    }

}
