using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VBGameManager : MonoBehaviour
{
    public GameObject[] Players = new GameObject[4];
    public Vector3[] PlayersPositions = new Vector3[4];
    public string winner;
    public bool gameOver = false;

    void Awake(){
        if (Helper.numOfPlayers == 0){
            Helper.numOfPlayers = 2;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitPlayers();      
    }

    // Update is called once per frame
    void Update()
    {
        checkIfWon();
    }

    //Checks if only one active player remained.
    void checkIfWon(){
        if(!gameOver){

        }

    }

    //Change to a random map after the game is over
    IEnumerator switchMap(float timer){
        Helper.chosenMap = (System.DateTime.Now.Millisecond % Helper.maps.GetLength(0));
        Debug.Log("The winner is: " + winner);
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene("VBMap" + Helper.chosenMap);
    }


    void InitPlayers(){
        for(int i = 0; i < Helper.numOfPlayers; i++){
            Players[i] = Instantiate (Players[i], PlayersPositions[i], Quaternion.identity);
        }
    }

}
