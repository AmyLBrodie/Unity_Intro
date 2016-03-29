using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour {

    public Text winnerText;

	// Use this for initialization
	void Start () {
	    if (RedSpiderSpawner.killedSpiders == RedSpiderSpawner.totalSpiders)
        {
            winnerText.text = "Green Fairy Wins!";
            winnerText.color = Color.green;
        }
        else if (GreenSpiderSpawner.killedSpiders == GreenSpiderSpawner.totalSpiders)
        {
            winnerText.text = "Red Fairy Wins!";
            winnerText.color = Color.red;
        }

        RedSpiderSpawner.killedSpiders = 0;
        RedSpiderSpawner.totalSpiders = 3;
        GreenSpiderSpawner.killedSpiders = 0;
        GreenSpiderSpawner.totalSpiders = 3;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
