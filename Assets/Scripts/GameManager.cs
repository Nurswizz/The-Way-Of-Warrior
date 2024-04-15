using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject lose;
    public GameObject pl;
    private Player player;
    public List<GameObject> enemies;
    public GameObject razboinik, knight;
    private void Start()
    {
        player = pl.GetComponent<Player>();
        Time.timeScale = 1;
        lose.SetActive(false);
        
    }
    private void Update()
    {
        if (player.getHp() <= 0)
        {
            lose.SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKey(KeyCode.R))
                SceneManager.LoadScene("SampleScene");
        }
        int count = 0;
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null)
                count++;
            
        }

        if (count == enemies.Count)
        {
            for (int i = 0; i < 12; i++)
            {
                enemies[i] = Instantiate(knight, new Vector2(Random.Range(-20, 20), 20), Quaternion.identity);
            }
            for (int i = 0; i < 4; i++)
            {
                enemies[i + 12] = Instantiate(razboinik, new Vector2(Random.Range(-20, 20), 20), Quaternion.identity);
            }
        }
    }


}
