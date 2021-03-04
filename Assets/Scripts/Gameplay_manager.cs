using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_manager : MonoBehaviour
{
    [SerializeField] private GameObject Button_Group;
    // Start is called before the first frame update
    void Start()
    {
        Button_Group.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
