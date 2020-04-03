using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{

    public void PlayGame(){
        
        Maps.chosenMap = (System.DateTime.Now.Millisecond % Maps.maps.GetLength(0));
        Debug.Log(Maps.chosenMap);

        switch (EventSystem.current.currentSelectedGameObject.name){
            case "2P":
                NumberOfPlayers.num = 2;
                break;
            case "3P":
                NumberOfPlayers.num = 3;
                break; 
            case "4P":
                NumberOfPlayers.num = 4;
                break;          
        } 

        SceneManager.LoadScene("Map" + Maps.chosenMap);

    }


    public void QuitGame() {
        Application.Quit();
    }

}
