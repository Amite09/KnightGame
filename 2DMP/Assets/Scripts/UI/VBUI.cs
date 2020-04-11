using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VBUI : MonoBehaviour
{

    public int[] score = new int[2];
    public Vector2[] pos = new Vector2[2];
    public Vector2 size;
    public GUIStyle numFont;

    // Start is called before the first frame update
    void Start()
    {
        getPositions();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    void OnGUI() {
        for(int i = 0; i < 2 ; i++){  
            GUI.Label(new Rect(pos[i].x + 60, pos[i].y + 20, size.x, size.y), score[i].ToString(), numFont);
        }
     }

    void getPositions(){
        pos[0] = new Vector2(Screen.width * 0.25f, Screen.height * 0.9f);
        pos[1] = new Vector2(Screen.width * 0.75f, Screen.height * 0.9f);
    }

    void UpdateScore(){
        score[0] = Helper.LeftSidePoints;
        score[1] = Helper.RightSidePoints;
    }


}
