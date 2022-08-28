using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [SerializeField] private Button startButton;
    
    private void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(LoadTitleScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
