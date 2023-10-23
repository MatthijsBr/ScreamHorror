using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodePuzzle : MonoBehaviour
{
    [SerializeField] string correctCode;
    [SerializeField] Puzzle puzzle;
    [SerializeField] TextMeshProUGUI inputScreen;
    string currentCode = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (KeyCode i = KeyCode.Alpha0; i <= KeyCode.Alpha9; i++)
            if (Input.GetKeyDown(i))
                PutIn((int)(i - 48));

        if (Input.GetButtonDown("Interact"))
            Check();
    }

    public void PutIn(int number)
    {
        currentCode += number.ToString();

        inputScreen.text += "*";
    }

    public void Check()
    {
        if (currentCode == correctCode)
        {
            puzzle.PuzzleFinished(true);
        }
        else
        {
            // Play incorrect sound

            currentCode = "";
            inputScreen.text = "";
        }
    }
}
