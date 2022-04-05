using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characterList;
    private int index;
    
    
    
    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        
        characterList = new GameObject[transform.childCount];

        //fill the array with our models 
        for(int i = 0; i < transform.childCount; i++)
            characterList[i] = transform.GetChild(i).gameObject;

        //we toggle off their renderer 
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }
        //we toggle on the selected character
        if (characterList[index])
        {
            characterList[index].SetActive(true);   
        }
    }
    

    public void ToggleLeft()
    {
        //toggle off the current model
        characterList[index].SetActive(false);


        index--;
        if(index < 0) 
            index = characterList.Length -1;

        //toggle on the new model
        characterList[index].SetActive(true);

    }

    public void ToggleRight()
    {
        //toggle off the current model
        characterList[index].SetActive(false);


        index++;
        if (index == characterList.Length)
            index = 0;

        //toggle on the new model
        characterList[index].SetActive(true);

    }

    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("game");
    }

}
