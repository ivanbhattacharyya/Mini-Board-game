using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceNumber : MonoBehaviour
{
    public static int diceNumber;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = diceNumber.ToString();
    }
}