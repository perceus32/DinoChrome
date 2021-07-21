using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class score : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Show()
    {
        canvas.SetActive(true);
    }
    public void GameOver()
    {
        Show();
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
