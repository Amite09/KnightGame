using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{

    public void PlayGame(){
        
        Helper.chosenMap = (System.DateTime.Now.Millisecond % Helper.maps.GetLength(0));
        Debug.Log(Helper.chosenMap);

        switch (EventSystem.current.currentSelectedGameObject.name){
            case "2P":
                Helper.numOfPlayers = 2;
                break;
            case "3P":
                Helper.numOfPlayers = 3;
                break; 
            case "4P":
                Helper.numOfPlayers = 4;
                break;          
        } 

        SceneManager.LoadScene("Map" + Helper.chosenMap);

    }


    public void QuitGame() {
        Application.Quit();
    }

}
