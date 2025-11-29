using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Layout
{
    public Pocket[] pockets;

    private int initialPockets = 24;
    private readonly static COLOR[] standardColors = { COLOR.GREEN, COLOR.RED, COLOR.BLACK, COLOR.RED, COLOR.BLACK, COLOR.RED, COLOR.BLACK, COLOR.RED, COLOR.BLACK, COLOR.RED, COLOR.BLACK, COLOR.BLACK, COLOR.RED, COLOR.BLACK, COLOR.RED, COLOR.BLACK, COLOR.RED, COLOR.BLACK, COLOR.RED, COLOR.RED, COLOR.BLACK, COLOR.RED, COLOR.BLACK, COLOR.RED, COLOR.BLACK, COLOR.RED, COLOR.BLACK, COLOR.RED, COLOR.BLACK, COLOR.BLACK, COLOR.RED, COLOR.BLACK, COLOR.RED, COLOR.BLACK, COLOR.RED, COLOR.BLACK, COLOR.RED };
    private readonly static int[] standardLayout = { 0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26 };

    public Layout()
    {
        pockets = new Pocket[37];
        CreateLayout();
    }

    private void CreateLayout()
    {
        pockets[0] = new Pocket(); //always add the zero

        for (int i = 1; i < initialPockets - 1; i++)
        {
            int rand;
            do
            {
                rand = Random.Range(1, 37);
            } while (pockets[rand] != null);
            pockets[rand] = new Pocket(standardLayout[rand], standardColors[rand]);
        }

        for (int i = 0; i < 37; i++)
        {
            if (pockets[i] == null)
            {
                pockets[i] = new Pocket(-1, COLOR.GRAY);
            }
        }
    }

    public Pocket GetPocket(int index) { return pockets[index]; }
    public void SetPocket(int index, Pocket pocket) { pockets[index] = pocket; }
}

public class Pocket
{
    public SpriteRenderer sprite;
    public TextMeshPro text;

    int number;
    COLOR color;

    public Pocket(int number, COLOR color)
    {
        this.number = number;
        this.color = color;
    }

    public Pocket()
    {
        number = 0;
        color = COLOR.GREEN;
    }


    public void SetUI(SpriteRenderer sprite, TextMeshPro text)
    {
        this.sprite = sprite;
        this.text = text;

        this.sprite.color = GetColor();
        this.text.text = number.ToString();

        if (color == COLOR.GRAY) this.text.text = "";
    }

    public bool isEven()
    {
        if (number == 0) return false;
        return number % 2 == 0;
    }

    public bool isOdd()
    {
        if (number == 0) return false;
        return number % 2 == 1;
    }

    public bool isFirstThird() { return number >= 1 && number <= 12; }

    public bool isSecondThird() { return number >= 13 && number <= 24; }

    public bool isThirdThird() { return number >= 25 && number <= 36; }

    public bool isFirstHalf() { return number >= 1 && number <= 18; }
    public bool isSecondHalf() { return number >= 19 && number <= 36; }

    public bool isRed() { return color == COLOR.RED; }
    public bool isBlack() { return color == COLOR.BLACK; }
    public bool isZero() { return color == COLOR.GREEN || number == 0; }

    public Color GetColor()
    {
        switch (color)
        {
            case COLOR.RED: return Color.red;
            case COLOR.GREEN: return Color.green;
            case COLOR.BLACK: return Color.black;
            case COLOR.GRAY: return Color.gray;
            default: return Color.white;
        }
    }
}

public enum COLOR
{
    GREEN, RED, BLACK, GRAY
};