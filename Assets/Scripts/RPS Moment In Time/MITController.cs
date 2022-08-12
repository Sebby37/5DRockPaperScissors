using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HandStates
{
    Rock,
    Paper,
    Scissors
}

public enum Players
{
    Left,
    Right
}

public class MITController : MonoBehaviour
{
    [Header("Game Information")]
    public bool gameOver = false;

    public HandStates? leftHandState = null;
    public HandStates? rightHandState = null;

    public Players? currentPlayer = Players.Right;
    public Players? wonPlayer = null;

    public int leftHandSprites = 4;
    public int rightHandSprites = 3;

    [Header("Hand references")]
    public Animator handAnimator;
    public Image leftHand;
    public Image rightHand;

    [Header("Hands")]
    // The list will contain the following: (0: rock, 1: paper, 2: scissors)
    public List<Sprite> hand1 = new List<Sprite>();
    public List<Sprite> hand2 = new List<Sprite>();
    public List<Sprite> hand3 = new List<Sprite>();
    public List<Sprite> hand4 = new List<Sprite>();
    public List<Sprite> hand5 = new List<Sprite>();
    public List<Sprite> hand6 = new List<Sprite>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Checking if both players have played their move and evaluating the win if so
        if (leftHandState != null && rightHandState != null && !gameOver)
        {
            gameOver = true;
            wonPlayer = EvaluateWin(leftHandState, rightHandState);
            handAnimator.SetTrigger("Throw Move");
        }
    }

    // Function to evaluate which player won
    public static Players? EvaluateWin(HandStates? _leftHand, HandStates? _rightHand)
    {
        // Returning null if neither wom
        if (_leftHand == _rightHand) return null;

        // Checking if the left player won
        if (_leftHand == HandStates.Rock && _rightHand == HandStates.Scissors) return Players.Left;
        if (_leftHand == HandStates.Scissors && _rightHand == HandStates.Paper) return Players.Left;
        if (_leftHand == HandStates.Paper && _rightHand == HandStates.Rock) return Players.Left;

        // Checking if the right player won
        if (_rightHand == HandStates.Rock && _leftHand == HandStates.Scissors) return Players.Right;
        if (_rightHand == HandStates.Scissors && _leftHand == HandStates.Paper) return Players.Right;
        if (_rightHand == HandStates.Paper && _leftHand == HandStates.Rock) return Players.Right;

        // Returning null if none of the above conditions are met
        return null;
    }

    // Function to set the current player and change the turn. The sprite of the previous player's turn is set to rock so their move is not known
    public void SetCurrentPlayer(Players? newPlayer)
    {
        if (currentPlayer != null) 
        {
            Image handImage = (currentPlayer == Players.Left ? leftHand : rightHand);
            handImage.sprite = hand3[0];
        }

        currentPlayer = newPlayer;
    }

    // Function to get the list of hands from an integer/player
    List<Sprite> GetHandSprites(int handInt)
    {
        switch (handInt)
        {
            case 1: return hand1;
            case 2: return hand2;
            case 3: return hand3;
            case 4: return hand4;
            case 5: return hand5;
            case 6: return hand6;
            default: return hand1;
        }
    }

    List<Sprite> GetHandSprites(Players player)
    {
        return GetHandSprites(player == Players.Left ? leftHandSprites : rightHandSprites);
    }

    List<Sprite> GetHandSprites(Players? player)
    {
        return GetHandSprites(player == Players.Left ? leftHandSprites : rightHandSprites);
    }

    // Function to get the move index from a HandState
    int GetMoveIndex(HandStates move)
    {
        switch (move)
        {
            case HandStates.Rock: return 0;
            case HandStates.Paper: return 1;
            case HandStates.Scissors: return 2;
            default: return 0;
        }
    }

    // Functions for selecting a move
    public void PlayRock()
    {
        PlayMove(HandStates.Rock);
    }

    public void PlayPaper()
    {
        PlayMove(HandStates.Paper);
    }

    public void PlayScissors()
    {
        PlayMove(HandStates.Scissors);
    }

    // Function to play a move
    // This function will set the sprite of the current player's hand, set it's move and switch to the next player
    void PlayMove(HandStates move)
    {
        List<Sprite> handSprites = GetHandSprites(currentPlayer);

        
    }
}
