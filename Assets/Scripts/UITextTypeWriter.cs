using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading.Tasks;

public class UITextTypeWriter : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public float delayToStart;
    static public float delayBetweenChars = 0.05f;
    static public float delayAfterPunctuation = 0.5f;
    
    private float originDelayBetweenChars;
    private bool lastCharPunctuation = false;
    private char charComma;
    private char charPeriod;

    [HideInInspector]
    public string fulltext;
    private string currentText = "";
    private int c = 0;

    //private bool yielding = false;

    void Awake()
    {
        originDelayBetweenChars = delayBetweenChars;

        charComma = Convert.ToChar(44);
        charPeriod = Convert.ToChar(46);
    }

    //Update text and start typewriter effect
    public void ChangeText(string textContent, float delayBetweenChars = 0f)
    {
        textField.text = ""; //clean textField content
        c = 0; // make sure forloop in coroutine starts at the right ID
        StopAllCoroutines(); // fix for coroutine accelerating when interrupted, other instances of PlayText() were actually still running...
        //StopCoroutine(PlayText()); //stop Coroutime if exist
        fulltext = textContent;
        Invoke("Start_PlayText", delayBetweenChars); //Invoke effect
    }

    void Start_PlayText()
    {
        StartCoroutine(PlayText());
    }

    IEnumerator PlayText()
    {
        for (c = 0; c < fulltext.Length; c++)
        {
            if (lastCharPunctuation)  //If previous character was a comma/period, pause typing
            {
                yield return new WaitForSeconds(delayAfterPunctuation);
                lastCharPunctuation = false;
            }

            if (c == charComma || c == charPeriod)
            {
                lastCharPunctuation = true;
            }

            currentText = fulltext.Substring(0, c);
            textField.text = currentText;
            yield return new WaitForSeconds(delayBetweenChars);
        }
    }
}
