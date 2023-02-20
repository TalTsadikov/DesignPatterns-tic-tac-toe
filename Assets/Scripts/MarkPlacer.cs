using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MarkPlacer 
{
    static List<Box> boxes;

    public static void  SetAsMarked(Sprite sprite, Mark mark, Color color, Box box)
    {
        box.isMarked = true;
        box.mark = mark;
        box.spriteRenderer.color = color;
        box.spriteRenderer.sprite = sprite;

        if (boxes == null)
        {
            boxes = new List<Box>();
        }
        boxes.Add(box);
    }

    public static void RemoveBox(int index)
    {
        for (int i = 0; i < boxes.Count; i++)
        {
            if (boxes[i].index == index)
            {
                boxes[i].isMarked = false;
                boxes[i].mark = Mark.None;
                boxes[i].spriteRenderer.color = Color.white;
                boxes[i].spriteRenderer.sprite = null;
            }
        }
    }
}
