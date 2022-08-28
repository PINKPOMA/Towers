using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(LoadGameScene);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void OnClickExitButton()
    {
        Application.Quit(0);
        UnityEditor.EditorApplication.isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
