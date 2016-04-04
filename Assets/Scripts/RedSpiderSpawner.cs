using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RedSpiderSpawner : MonoBehaviour {

    public GameObject spider;
    public static int totalSpiders = 3;
    public static int killedSpiders = 0;
    public Text Score;

    // Use this for initialization
    void Start () {
	
	}
    
    //spawns spiders when game starts
    void OnEnable()
    {
        Instantiate(spider);
        Instantiate(spider);
        Instantiate(spider);
        // updates score for green fairy
        if (Score != null)
        {
            Score.text = "Red Spiders: " + killedSpiders + "/" + totalSpiders;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
