using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public void LoadScene(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}
