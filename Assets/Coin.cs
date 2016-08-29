using UnityEngine;
using System.Collections;
using System;

public class Coin : MonoBehaviour {
    int[] currentCoords = new int[2] { 0, 0};
   
	// Use this for initialization
	void Start () {
        randomPosition();
      
	}
    Score score;
    // Update is called once per frame
    void Update () {
        transform.Rotate(Vector3.left);
        score = GameObject.Find("Score").GetComponent<Score>();

    }
    public void hide()
    {
        GetComponent<Renderer>().enabled = false;
    }
    public void show()
    {
        GetComponent<Renderer>().enabled = true;
    }
    public void resetScore()
    {
		
        score.reset();
	}
    void moveToPosition (int[] currentCoords)
    {
        int z = 2-currentCoords[0];
        int x = currentCoords[1];

        transform.position = new Vector3((x) * 7.5f - 7.5f, transform.position.y, (z) * 7.5f - 7.5f);

    }

    public void randomPosition()
    {
        show();
        int[] prev = new int[] { currentCoords[0], currentCoords[1] };
        while (prev[0] == currentCoords[0] && prev[1] == currentCoords[1])
        {
            currentCoords[0] = UnityEngine.Random.Range(0, 3);
            currentCoords[1] = UnityEngine.Random.Range(0, 3);
        }
        moveToPosition(currentCoords);
    }
    public void selected(int[] coords) {
        if (coords[0]==currentCoords[0]&&coords[1]==currentCoords[1])
        {

            Debug.Log("Selected");
            randomPosition();
            score.up();
            return;
        }
        Debug.Log("Don't selected");

    }

}
