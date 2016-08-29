using UnityEngine;
using System.Collections;
using System;

public class Score : MonoBehaviour {
    TextMesh textMesh;
    public int score = 0;
	// Use this for initialization
	void Start () {
        textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        textMesh.text = "Счет: "+score;
	}

	public void up()
    {
        score++;
		Hashtable ht = new Hashtable();
		ht.Add ("score", score);
		AppMetrica.Instance.ReportEvent ("up score", ht);

    }

	public void reset()
    {
        score = 0;
		AppMetrica.Instance.ReportEvent ("reset score");

    }
}
