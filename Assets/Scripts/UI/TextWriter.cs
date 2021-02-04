using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWriter : MonoBehaviour
{

    private TextMeshProUGUI uiText;
    private string textToWrite;
    private int characterIndex;
    private float timePerCharacter;
    private float timer;

    public void AddWriter(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        characterIndex = 0;
    }

    void Update()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                //Speed up with mouse press
                if (Input.GetMouseButton(0))
                {
                    timePerCharacter = 0.02f;
                }
                else
                {
                    timePerCharacter = 0.1f;
                }
                timer += timePerCharacter;
                characterIndex++;
                uiText.text = textToWrite.Substring(0, characterIndex);

                if (characterIndex >= textToWrite.Length)
                {
                    uiText = null;
                    return;
                }
            }
        }
    }
}
