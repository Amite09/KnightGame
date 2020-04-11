using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

   public class HealthBarUI : MonoBehaviour {
     public static int num;
     public Texture2D[] playerIcons = new Texture2D[4];
     public Vector2[] playerIconPositions = new Vector2[4];
     public GameObject shurikenIcon;
     public Vector2[] shurikenIconPositions = new Vector2[4];
     public float[] barDisplay = new float[4]; //current progress
     public int[] shurikenCount = new int[4];
     public int [] livesCount = new int[4];
     public Vector2[] pos = new Vector2[4];
     public Vector2 size;
     public Texture2D emptyTex;
     public Texture2D fullTex;
     public GUIStyle numFont;

     void Awake() {
        fullTex = new Texture2D(200,30);
        InitStyles();
     }

     void Start() { 
        num = Helper.numOfPlayers;
        getPositions();
     }


     void OnGUI() {
        for(int i = 0; i < num ; i++){  

            GUI.DrawTexture(new Rect(pos[i].x + size.x/3, pos[i].y - 50, playerIcons[i].width/2, playerIcons[i].height/2), playerIcons[i]);

            //draw the background
            GUI.BeginGroup(new Rect(pos[i].x, pos[i].y, size.x, size.y));
                GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
            
                //draw the filled-in part:
                GUI.BeginGroup(new Rect(0,0, size.x * barDisplay[i], size.y));
                        GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
                GUI.EndGroup();
            GUI.EndGroup();
            //GUI.Label(new Rect(pos[i].x + 80, pos[i].y + 30, size.x, size.y), shurikenCount[i].ToString(), numFont);
            GUI.Label(new Rect(pos[i].x + 60, pos[i].y + 20, size.x, size.y), livesCount[i].ToString(), numFont);

        }
     }

    void InitStyles(){
        for (int y = 0; y < fullTex.height; ++y){
            for (int x = 0; x < fullTex.width; ++x){
                Color color = new Color(0.9528302f, 0.3442279f, 0.3011303f);
                fullTex.SetPixel(x, y, color);
            }
        }
        fullTex.Apply();
    }

     void Update() {
        for(int j = 0; j < num; j++){
            barDisplay[j] = Helper.health[j];
            shurikenCount[j] = Helper.shurikenCount[j];
            livesCount[j] = Helper.livesCount[j];
        }
     }

    void getPositions(){
        pos[1] = new Vector2(Screen.width - pos[0].x - size.x, pos[0].y);
        pos[2] = new Vector2(pos[0].x,Screen.height - pos[0].y - size.y);
        pos[3] = new Vector2(Screen.width - pos[0].x - size.x,Screen.height - pos[0].y - size.y);
    }
    }
