using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpeningText : MonoBehaviour
{

    [SerializeField] private TextWriter textWriter;
    [SerializeField] private TextMeshProUGUI messageText;
    private string textToWrite;
    private float writeSpeed = 0.1f;

    private void Awake()
    {
        textToWrite = messageText.text;
    }

    void Start()
    {
        textWriter.AddWriter(messageText, textToWrite , writeSpeed);
    }
}
