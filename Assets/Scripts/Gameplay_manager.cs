using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameplay_manager : MonoBehaviour
{
    [SerializeField] private GameObject ButtonGroup;
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Asteroid AsteroidPrefab;
    [SerializeField] private Alien_Ship AlienPrefab;
    [SerializeField] private GameObject Ship;
    [SerializeField] private Text Score;
    private int i_Score;
    public bool Playable = true;
    private float Edge;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        ButtonGroup.SetActive(false);
        Edge = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)).magnitude;
        StartCoroutine(Spawn());
    }

    //Simple spawn for asteroids and aliens
    private IEnumerator Spawn() 
    {
        while (Playable)
        {
            yield return new WaitForSeconds(Random.Range(.3f, 2f));
            int Angle = Random.Range(0, 360);
            float Spawn_X = Mathf.Cos(Angle) * Edge;
            float Spawn_Y = Mathf.Sin(Angle) * Edge;
            Vector3 Direction = new Vector3(Spawn_X, Spawn_Y, 1f);
            if (Random.Range(0, 100) < 10)
            {
                Alien_Ship SpawnedShip = Instantiate(AlienPrefab, Direction, new Quaternion());
                SpawnedShip.player = Ship.GetComponent<Ship_controller>();
                SpawnedShip.manager = this;
            }
            else
            {
                Asteroid Spawnedasteroid = Instantiate(AsteroidPrefab, Direction, new Quaternion());
                Angle = Random.Range(0, 360);
                float _x = Mathf.Cos(Angle);
                float _y = Mathf.Sin(Angle);
                Direction = -Direction + new Vector3(_x, _y, 1f);
                Spawnedasteroid.Set_Move_Direction(Direction.normalized*.05f);
                Spawnedasteroid.manager = this;
            }
        }
        
    }

    public void Lose() 
    {
        StopAllCoroutines();
        Playable = false;
        ButtonGroup.SetActive(true);
    }

    public void Reset()
    {
        ClearScore();
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(new Vector2(0, 0), Edge)) {
            if (collider.gameObject.GetComponent<Asteroid>() || collider.gameObject.GetComponent<Alien_Ship>()) Destroy(collider.gameObject);
        }
        Playable = true;
        ButtonGroup.SetActive(false);
        Ship.GetComponent<Ship_controller>().ResetGame();
        StartCoroutine(Spawn());
    }

    public void Exit()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void AddScore(int GainedScore)
    {
        i_Score += GainedScore;
        Score.text = i_Score.ToString();
    }

    private void ClearScore() 
    {
        i_Score = 0;
        Score.text = "0";
    }
}
