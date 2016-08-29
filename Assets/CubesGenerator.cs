using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Threading;

public class CubesGenerator : MonoBehaviour {
    GameObject[][] Cubes=new GameObject[][] { new GameObject[3], new GameObject[3], new GameObject[3] };
    int cx, cy;
    bool step = false;
    GameObject[] prevCubes = null;
    private GameObject prevCube;
    Coin coin;
	public GameObject timeoutSlider;

	Slider slider;    


    void loop()
    {
		Invoke ("loop", slider.value);

        if (!step)
        {
            if (prevCubes != null)
            {

                paintColor(prevCubes, Color.red);
            }
            prevCubes = Cubes[cx];
            paintColor(prevCubes, Color.green);
            cx++;
            if (cx == Cubes.Length)
            {
                cx = 0;
            }
            return;
        }
        if (prevCube != null)
        {
            paintColor(prevCube, Color.red);
            
        }
        prevCube = Cubes[cx][cy];
        paintColor(prevCube, Color.green);
        
        cy++;
        if (cy == Cubes[cx].Length)
        {
            cy = 0;
        }

    }
    // Use this for initialization
	void Start () {
        coin = GameObject.Find("Coin").GetComponent<Coin>();

        reset();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject cube = Cubes[2-j][i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<Rigidbody>();
                cube.GetComponent<MeshRenderer>().material.color = Color.red;
                
                cube.transform.position = new Vector3((i)*7.5f-7.5f, 1f, (j)*7.5f-7.5f);
                cube.transform.localScale = new Vector3(3, 3, 3);
            }
        }
		slider = timeoutSlider.GetComponent<Slider> ();
		loop ();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space)||(Input.GetKeyUp(KeyCode.Mouse0)&& !EventSystem.current.IsPointerOverGameObject()))
        {
            
            int x, y;
            x = cx;
            y = cy;


            if (x == -1)
            {
                x = Cubes.Length - 1;
            }
            y = y - 1;
            if (y == -1)
            {
                y = Cubes[x].Length-1;
            }

            if (!step)
            {
                step = true;
                paintColor(prevCubes, Color.red);
                cx = x-1;
                if (cx == -1)
                {
                    cx = Cubes.Length - 1;
                }
                return;
            }
           int [] coinCorrds = (new int[] {x ,  y });
            GameObject selected = Cubes[x][y];
            selected.GetComponent<MeshRenderer>().material.color = Color.yellow;
            coin.selected(coinCorrds);
            reset();
            
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
			Exit (); 
		}
        if (Input.GetKeyUp(KeyCode.F5))
        {
            coin.resetScore();
        }

    }
    void paintColor(GameObject obj, Color color)
    {
        obj.GetComponent<MeshRenderer>().material.color = color;
    }
    void paintColor(GameObject[] objs, Color color)
    {
        foreach(GameObject obj in objs)
        {
            paintColor(obj, color);
        }
    }
    void reset() {
        cx = cy = 0;
        step = false;
    }
	public void Exit ()
	{
		Application.Quit();

	}
}
