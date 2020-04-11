using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class Menu : MonoBehaviour
{

    public void PlayGame(){
        


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

        if(transform.Find("switchButton").Find("value").GetComponent<TextMeshProUGUI>().text == "ON"){
            Helper.chosenMap = (System.DateTime.Now.Millisecond % Helper.VBmaps.GetLength(0));
            SceneManager.LoadScene("VBMap" + Helper.chosenMap);
        } else {
            Helper.chosenMap = (System.DateTime.Now.Millisecond % Helper.maps.GetLength(0));
            SceneManager.LoadScene("Map" + Helper.chosenMap);
        }

    }

    public void SwitchVB(){
        string text = transform.Find("switchButton").Find("value").GetComponent<TextMeshProUGUI>().text;
        transform.Find("switchButton").Find("value").GetComponent<TextMeshProUGUI>().text = (text == "OFF" ? "ON" : "OFF");
    }


    public void QuitGame() {
        Application.Quit();
    }

}
