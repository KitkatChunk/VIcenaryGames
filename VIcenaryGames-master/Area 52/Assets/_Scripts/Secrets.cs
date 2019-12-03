using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Secrets : MonoBehaviour
{
    public Button levelSelect;
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        levelSelect.interactable = false;
        levelText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            levelSelect.interactable = true;
            levelText.text = "Level Select";
        }
    }
}
