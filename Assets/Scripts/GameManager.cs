using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int xScoreNum = 0;
    public int oScoreNum = 0;
    public static GameManager _instance;
    public bool gameOver = false;
    public Mark mark;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Gamemanager is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);

        mark = Mark.X;
    }
}
