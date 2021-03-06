using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private int size;
    private Vector3 Translation_Direction;
    //Make sprite holder for cut relations betwen movement and visual
    [SerializeField] private GameObject Sprite_Container;
    public Gameplay_manager manager;

    void Start()
    {
        //Randomize asteroid size
        size = Random.Range(0, 3);
        ReSize();
        //Set lifetime
        Destroy(gameObject, 10f);
        //Randopm ratation for better look
        Sprite_Container.transform.Rotate(0,0,Random.Range(0, 360));
    }

    //Move by fixed timer
    void FixedUpdate()
    {
        transform.Translate(Translation_Direction);
    }

    //Operates when asteroid getting hit
    public void Break()
    {
        //Increace score
        manager.AddScore(100);
        //Destroy if already small, in other cases reduce size
        if (size == 0)
        {
            Destroy(gameObject);
        }
        else {
            size--;
            ReSize();
            int Angle = Random.Range(0, 360);
            float _x = Mathf.Cos(Angle);
            float _y = Mathf.Sin(Angle);
            Translation_Direction += new Vector3(_x, _y, 1f)*.005f;
        }
    }

    //Set scale based on size
    private void ReSize() 
    {
        switch (size)
        {
            case 0: transform.localScale = new Vector3(.3f, .3f, .3f); break;
            case 1: transform.localScale = new Vector3(.6f, .6f, .6f); break;
            case 2: transform.localScale = new Vector3(1f, 1f, 1f); break;
            default: transform.localScale = new Vector3(1f, 1f, 1f); break;
        }
    }

    //Just common setter
    public void Set_Move_Direction(Vector3 Direction) 
    {
        Translation_Direction = Direction;
    }
}
