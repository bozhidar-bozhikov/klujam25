using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Bet> bets;

    private PhysicsBall ball;

    [SerializeField]
    private int availableChips;
    [SerializeField]
    private int requiredChips;
    [SerializeField]
    private int chipValueSelected = 0;

    private void Awake()
    {
        ball = FindObjectOfType<PhysicsBall>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball.Launch();
        }
    }

    public struct Bet
    {
        public BET_TYPE bet;
        public int[] elligibleNumbers;

        public Bet(BET_TYPE bet, int[] elligibleNumbers)
        {
            this.bet = bet;
            this.elligibleNumbers = elligibleNumbers;
        }
    }

    public int GetBetPayout(BET_TYPE bet)
    {
        switch (bet)
        {
            case BET_TYPE.STRAIGHTUP: return 35;
            case BET_TYPE.SPLIT: return 17;
            case BET_TYPE.STREET: return 11;
            case BET_TYPE.CORNER: return 8;
            case BET_TYPE.LINE: return 5;
            case BET_TYPE.DOZEN: return 2;
            case BET_TYPE.RED:
            case BET_TYPE.BLACK:
            case BET_TYPE.EVEN:
            case BET_TYPE.ODD:
            case BET_TYPE.HIGH:
            case BET_TYPE.LOW: return 1;
            default: return 0;
        }
    }

    public void MakeBet(BET_TYPE bet)
    {

    }

    public enum BET_TYPE
    {
        STRAIGHTUP, SPLIT, STREET, CORNER, LINE, //inside bets
        DOZEN, RED, BLACK, EVEN, ODD, HIGH, LOW, //outside bets
        NONE
    }

    public void SelectChipValue(int value)
    {
        if (availableChips >= value)
        {
            chipValueSelected = value;
        }
    }
}