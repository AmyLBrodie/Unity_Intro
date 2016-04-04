using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GreenSpiderSpawner : MonoBehaviour {

    public GameObject spider;
    public static int totalSpiders = 3;
    public static int killedSpiders = 0;
    public Text Score;

	// Use this for initialization
    // spawns spiders at start of game
	void Start () {
        Instantiate(spider);
        Instantiate(spider);
        Instantiate(spider);
        // updates score for red fairy
        if (Score != null)
        {
            Score.text = "Green Spiders: " + killedSpiders + "/" + totalSpiders;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
