using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public void ChooseCharacter(int index)
    {
        PlayerPrefs.SetInt("SelectedCharacter", index);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Training");
    }

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
