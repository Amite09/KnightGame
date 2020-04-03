using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

   public class HealthBarGUI : MonoBehaviour {
     public static int num;
     public GameObject[] playerIcons = new GameObject[4];
     public Vector2[] playerIconPositions = new Vector2[4];
     public GameObject shurikenIcon;
     public Vector2[] shurikenIconPositions = new Vector2[4];
     public GameObject lifeIcon;
     public Vector2[] lifeIconPositions = new Vector2[12];
     public float[] barDisplay = new float[4]; //current progress
     public int[] shurikenCount = new int[4];
     public int [] livesCount = new int[4];
     public Vector2[] pos = new Vector2[4];
     public Vector2 size;
     public Texture2D emptyTex;
     public Texture2D fullTex;
     public GUIStyle numFont;

     void Awake() {
        num = NumberOfPlayers.num;
        fullTex = new Texture2D(200,30);
        InitStyles();
     }

     void Start() { 
        for(int i = 0; i < num; i++){
            Instantiate(playerIcons[i],playerIconPositions[i], Quaternion.identity);
            //Instantiate(shurikenIcon,shurikenIconPositions[i], Quaternion.identity);
            // Instantiate(lifeIcon, lifeIconPositions[i], Quaternion.identity);
            // Instantiate(lifeIcon, lifeIconPositions[i + 4], Quaternion.identity);
            // Instantiate(lifeIcon, lifeIconPositions[i + 8], Quaternion.identity);


        }



     }

     void OnGUI() {
        for(int i = 0; i < num ; i++){            
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
            barDisplay[j] = HealthBar.health[j];
            shurikenCount[j] = ShurikenCounter.shurikenCount[j];
            livesCount[j] = PlayerLives.livesCount[j];
        }
     }
 }