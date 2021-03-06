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
    // Start is called before the first frame update
    void Start()
    {
        m_Source = GetComponent<AudioSource>();
        m_Renderer = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(DelayToCheck());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input_Locked) return;
        if (Input.GetButtonDown("Jump")) 
        {
            Shoot();
        }
        if (!m_Renderer.isVisible && CanCheck) 
        {
            Lose();
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
        m_Source.PlayOneShot(ShootSound);
        Instantiate(Projectile, Fire_point.transform.position, transform.rotation, null);
    }

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

    private void Lose() 
    {
        Input_Locked = true;
        Manager.Lose();
        CanCheck = false;
    }

    public void Reset()
    {
        StartCoroutine(DelayToCheck());
        Input_Locked = false;
        transform.position = new Vector3(0, 0, 1);
        transform.rotation = new Quaternion();
    }

    private IEnumerator DelayToCheck() {
        yield return new WaitForSeconds(1f);
        CanCheck = true;
    }
}
