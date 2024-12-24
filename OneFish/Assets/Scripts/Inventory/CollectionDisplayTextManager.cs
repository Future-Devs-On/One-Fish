using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionDisplayTextManager : MonoBehaviour
{
    
    public Text textElement;

    public void DisplayText(string textValue)
    {
        textElement.text = textValue;
    }
}
