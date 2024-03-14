using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject gameOption;
    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    public void OpenOption() //�ɼ� ����
    {
        gameOption.SetActive(true);
        Time.timeScale = 0;
    }
    //public void RestartGame() //�����
    //{
    //    Time.timeScale = 1.0f;
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}
    public void CloseOption() //continue
    {
        gameOption.SetActive(false);
        Time.timeScale = 1;
    }
    public void QuitGame() //quit
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Esc Ű�� ������ �� ȣ���� �Լ� ����
            OpenOption();
        }
    }
}
