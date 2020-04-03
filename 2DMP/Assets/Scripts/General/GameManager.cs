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

    }
    // Start is called before the first frame update
    void Start()
    {
        Players[0] = Instantiate (Players[0], PlayersPositions[0], Quaternion.identity);
        Players[1] = Instantiate (Players[1], PlayersPositions[1], Quaternion.identity);
        if (NumberOfPlayers.num >= 3)
        {
            Players[2] = Instantiate (Players[2], PlayersPositions[2], Quaternion.identity);
        }
        if (NumberOfPlayers.num == 4)
        {
            Players[3] = Instantiate (Players[3], PlayersPositions[3], Quaternion.identity);
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        updatePlayers();
        checkAlive();
        checkIfWon();
    }

    void updatePlayers(){
        for(int i = 0; i < NumberOfPlayers.num; i++){
            HealthBar.health[i] = Players[i].GetComponent<Knight>().hp / Players[i].GetComponent<Knight>().maxHP;
            ShurikenCounter.shurikenCount[i] = Players[i].GetComponent<Knight>().shurikens;
            PlayerLives.livesCount[i] = Players[i].GetComponent<Knight>().lives;
        }
    }

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

    IEnumerator switchMap(float timer){
        Maps.chosenMap = (System.DateTime.Now.Millisecond % Maps.maps.GetLength(0));
        Debug.Log("The winner is: " + winner);
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene("Map" + Maps.chosenMap);
    }

    void checkAlive(){
        for(int i = 0; i < NumberOfPlayers.num; i++){
            if (!Players[i].GetComponent<Knight>().isAlive && Players[i].GetComponent<Knight>().j == 0 && Players[i].GetComponent<Knight>().lives > 0){
                Players[i].GetComponent<Knight>().j = 1;
                StartCoroutine(Resurrect(Players[i].GetComponent<Knight>(), i));
            }
        }


    }

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
