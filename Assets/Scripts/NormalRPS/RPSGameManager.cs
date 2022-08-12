using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSGameManager : MonoBehaviour
{
    [Header("Left Objects")]
    public GameObject leftHand;
    List<RPSButton> leftButtons = new List<RPSButton>();

    [Header("Right Objects")]
    public GameObject rightHand;
    List<RPSButton> rightButtons = new List<RPSButton>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    RPSButton RightButtonPressed()
    {
        foreach (RPSButton button in rightButtons)
            if (button.IsPressed()) return button;
        return new RPSButton();
    }
}
