using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private int size;
    private Vector3 Translation_Direction;
    [SerializeField] private GameObject Sprite_Container;

    // Start is called before the first frame update
    void Start()
    {
        size = Random.Range(0, 2);
        ReSize();
        Destroy(gameObject, 10f);
        Sprite_Container.transform.Rotate(0,0,Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Translation_Direction);
    }

    public void Break()
    {
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

    private void ReSize() {
        switch (size)
        {
            case 0: transform.localScale = new Vector3(.3f, .3f, .3f); break;
            case 1: transform.localScale = new Vector3(.6f, .6f, .6f); break;
            case 2: transform.localScale = new Vector3(1f, 1f, 1f); break;
            default: transform.localScale = new Vector3(1f, 1f, 1f); break;
        }
    }

    public void Set_Move_Direction(Vector3 Direction) {
        Translation_Direction = Direction;
    }
}
