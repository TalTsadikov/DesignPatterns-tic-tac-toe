using UnityEngine ;
using UnityEngine.UI ;
using UnityEngine.SceneManagement ;
using System.Collections.Generic;

public class WinUI : MonoBehaviour 
{
   [SerializeField] private GameObject uiCanvas;
   [SerializeField] private Text uiWinnerText;
   [SerializeField] private Text xScoreText;
   [SerializeField] private Text oScoreText;
   [SerializeField] private Button uiRestartButton;

   [SerializeField] private Board board;

   private void Start() 
   {
      //uiRestartButton.onClick.AddListener (() => SceneManager.LoadScene (0));
      uiRestartButton.onClick.AddListener (() => ClearBoard());
      board.OnWinAction += OnWinEvent;

      uiCanvas.SetActive (false);
    }
    private void Update()
    {
        if (GameManager._instance.gameOver == true)
        {
            oScoreText.text = $"O wins: {GameManager._instance.oScoreNum}";
            xScoreText.text = $"X wins: {GameManager._instance.xScoreNum}";
        }
    }
    private void OnWinEvent(Mark mark, Color color) 
    {
      uiWinnerText.text = (mark == Mark.None) ? "Nobody Wins" : mark.ToString () + " Wins.";
      uiWinnerText.color = color;
      GameManager._instance.gameOver = true;

      uiCanvas.SetActive(true);
    }

   private void OnDestroy() 
   {
      uiRestartButton.onClick.RemoveAllListeners ();
      board.OnWinAction -= OnWinEvent;
   }

    private void ClearBoard()
    {
        Board originalGameObject = board;
        List<GameObject> boxes = new List<GameObject>();

        for (int i = 0; i < originalGameObject.transform.childCount; i++)
        {
            GameObject child = originalGameObject.transform.GetChild(i).gameObject;
            boxes.Add(child);

            foreach(var item in boxes)
            {
                Box box = item.GetComponent<Box>();
                box.isMarked = false;
                box.mark = Mark.None;
                box.spriteRenderer.color = Color.white;
                box.spriteRenderer.sprite = null;
            }
        }

        uiCanvas.SetActive(false);
    }
}
