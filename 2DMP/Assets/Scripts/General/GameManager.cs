using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] Players = new GameObject[4];
    public Vector3[] PlayersPositions = new Vector3[4];
    private int alivePlayers;
    public string winner;
    public bool gameOver = false;

    void Awake(){
        if (Helper.numOfPlayers == 0){
            Helper.numOfPlayers = 2;
        }
        Helper.livesCount = new int[Helper.numOfPlayers];
        Helper.shurikenCount = new int[Helper.numOfPlayers];
        Helper.health = new float[Helper.numOfPlayers];
    }
    // Start is called before the first frame update
    void Start()
    {
        InitPlayers();   
    }

    // Update is called once per frame
    void Update()
    {
        updatePlayers();
        checkAlive();
        checkIfWon();
    }


    void InitPlayers(){
        for(int i = 0; i < Helper.numOfPlayers; i++){
            Players[i] = Instantiate (Players[i], PlayersPositions[i], Quaternion.identity);
        }
    }


    //Updates the Health/Lives Count/# of shurikens each frame. 
    void updatePlayers(){
        for(int i = 0; i < Helper.numOfPlayers; i++){
            Helper.health[i] = Players[i].GetComponent<Knight>().hp / Players[i].GetComponent<Knight>().maxHP;
            Helper.shurikenCount[i] = Players[i].GetComponent<Knight>().shurikens;
            Helper.livesCount[i] = Players[i].GetComponent<Knight>().lives;
        }
    }

    //Checks if only one active player remained.
    void checkIfWon(){
        if(!gameOver){
            foreach(GameObject p in Players){
                if(p.activeInHierarchy && p.GetComponent<Knight>().lives > 0){
                    alivePlayers++;
                    winner = p.name.Remove(8);
                }
            }
            if(alivePlayers == 1){
                gameOver = true;
                StartCoroutine(switchMap(5f));
            } else {
                alivePlayers = 0;
            }
        }

    }

    //Change to a random map after the game is over
    IEnumerator switchMap(float timer){
        Helper.chosenMap = (System.DateTime.Now.Millisecond % Helper.maps.GetLength(0));
        Debug.Log("The winner is: " + winner);
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene("Map" + Helper.chosenMap);
    }

    //Sends a respawn command to a dead player if he has lives left    
    void checkAlive(){
        for(int i = 0; i < Helper.numOfPlayers; i++){
            if (!Players[i].GetComponent<Knight>().isAlive && Players[i].GetComponent<Knight>().j == 0 && Players[i].GetComponent<Knight>().lives > 0){
                Players[i].GetComponent<Knight>().j = 1;
                StartCoroutine(Resurrect(Players[i].GetComponent<Knight>(), i));
            }
        }
    }

    //Respawns the player
    IEnumerator Resurrect(Knight player, int index){
        yield return new WaitForSeconds(5f);
        player.gameObject.SetActive(true);
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.transform.Find("model").GetComponent<Animator>().Play("Idle");      
        player.transform.rotation = new Quaternion(0, 0, 0, 0);
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        player.transform.position = PlayersPositions[index];
        player.isAlive = true;
        player.hp = player.maxHP;
        player.j = 0;

    }

}
