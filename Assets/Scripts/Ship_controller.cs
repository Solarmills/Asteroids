using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_controller : MonoBehaviour
{

    [SerializeField] private GameObject Fire_point;
    [SerializeField] private Projectile Projectile;
    [SerializeField] private Gameplay_manager Manager;
    [SerializeField] private AudioClip ShootSound;
    private bool Input_Locked = false;
    private SpriteRenderer m_Renderer;
    private AudioSource m_Source;
    private bool CanCheck= false;

    void Start()
    {
        m_Source = GetComponent<AudioSource>();
        m_Renderer = GetComponentInChildren<SpriteRenderer>();
        //This needed to prevent lose screen on first frames
        StartCoroutine(DelayToCheck());
    }

    
    void Update()
    {
        if (Input_Locked) return;
        if (Input.GetButtonDown("Jump")) 
        {
            Shoot();
        }
        //Lose if go out of screen
        if (!m_Renderer.isVisible && CanCheck) 
        {
            Lose();
        }
    }

    //Movement by fixed timer
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

    //Simple shoot processing
    private void Shoot() { 
        m_Source.PlayOneShot(ShootSound);
        Instantiate(Projectile, Fire_point.transform.position, transform.rotation, null);
    }

    //OPerating lose by collisions with other objects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Asteroid>()) 
        {
            Lose();
        }
        if (collision.gameObject.GetComponent<Alien_Ship>()) {
            Destroy(collision.gameObject);
            Lose();
        }
    }

    //Simple stoper for player processes
    private void Lose() 
    {
        Input_Locked = true;
        Manager.Lose();
        CanCheck = false;
    }

    //Setting player to start position
    public void ResetGame()
    {
        StartCoroutine(DelayToCheck());
        Input_Locked = false;
        transform.position = new Vector3(0, 0, 1);
        transform.rotation = new Quaternion();
    }

    //This needed to prevent lose screen on first frames
    private IEnumerator DelayToCheck() {
        yield return new WaitForSeconds(1f);
        CanCheck = true;
    }
}
