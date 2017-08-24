using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [SerializeField]
    GameObject Player;
    [SerializeField]
    List<GameObject> Enemies = new List<GameObject>();
    [SerializeField]
    List<GameObject> UIs = new List<GameObject>();
    [SerializeField]
    List<GameObject> WINs = new List<GameObject>();
    [SerializeField]
    List<GameObject> LOSEs = new List<GameObject>();
    bool IsPlaying,GameOvered;
    void Start ()
    {
        Time.timeScale = 0;
        IsPlaying = false;
        UIs.ForEach(go => go.SetActive(true));
	}
	void Update ()
    {
        if(Input.GetAxisRaw("Jump") > 0 && !IsPlaying)
        {
            UIs.ForEach(go => go.SetActive(false));
            Time.timeScale = 1;
            IsPlaying = true;
        }
        if(GameOvered && Input.GetAxisRaw("Jump") > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void Check()
    {
        if (Enemies.Where(go => go.activeInHierarchy).Count() == 0)
        {
            WINs.ForEach(go => go.SetActive(true));
            GameOver();
        }
        if (!Player.activeInHierarchy)
        {
            LOSEs.ForEach(go => go.SetActive(true));
            GameOver();
        }
    }
    void GameOver()
    {
        Time.timeScale = 0;
        GameOvered = true;
    }
}
