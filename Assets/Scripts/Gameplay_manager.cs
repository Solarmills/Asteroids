using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_manager : MonoBehaviour
{
    [SerializeField] private GameObject Button_Group;
    [SerializeField] private Camera Main_Camera;
    [SerializeField] private Asteroid Asteroid_Prefab;
    [SerializeField] private GameObject Ship;
    private bool Playable = true;
    private float Edge;
    // Start is called before the first frame update
    void Start()
    {
       // Button_Group.SetActive(false);
        Edge = Main_Camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)).magnitude;
        Debug.Log(Edge);
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn() {
        while (Playable)
        {
            yield return new WaitForSeconds(Random.Range(.3f, 2f));
            int Angle = Random.Range(0, 360);
            float Spawn_X = Mathf.Cos(Angle) * Edge;
            float Spawn_Y = Mathf.Sin(Angle) * Edge;
            Vector3 Direction = new Vector3(Spawn_X, Spawn_Y, 1f);
            Asteroid Spawned_asteroid = Instantiate(Asteroid_Prefab, Direction, new Quaternion());
            Angle = Random.Range(0, 360);
            float _x = Mathf.Cos(Angle);
            float _y = Mathf.Sin(Angle);
            Direction = -Direction + new Vector3(_x, _y, 1f);
            Spawned_asteroid.Set_Move_Direction(Direction.normalized*.01f);
        }
        
    }

    public void Lose() {
        StopAllCoroutines();
        Playable = false;
        Button_Group.SetActive(true);
    }

    public void Reset()
    {
        Playable = true;
        Button_Group.SetActive(false);
        Ship.GetComponent<Ship_controller>().Reset();
        StartCoroutine(Spawn());
    }

    public void Exit()
    {
        Application.Quit();
    }
}
