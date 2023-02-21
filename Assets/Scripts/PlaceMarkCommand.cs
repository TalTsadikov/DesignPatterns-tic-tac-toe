using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMarkCommand : ICommand
{
    Mark mark;
    Color color;
    Box box;
    Sprite sprite;

    public PlaceMarkCommand(Mark mark, Color color, Box box, Sprite sprite)
    {
        this.mark = mark;
        this.color = color;
        this.box = box;
        this.sprite = sprite;
    }

    public void Execute()
    {
        MarkPlacer.SetAsMarked(sprite, mark, color, box);
    }

    public void Undo()
    {
        MarkPlacer.RemoveBox(box.index);
        // GameManager._instance.mark = (mark == Mark.X) ? Mark.O : Mark.X;
        MarkPlacer.SwitchPlayer(mark);
    }
}
