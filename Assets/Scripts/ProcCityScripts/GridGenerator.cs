using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GridGenerator
{
    int canvasWidth;
    int canvasHeight;
    int minBlockSize;

    public GridGenerator(int canvasWidth = 100, int canvasHeight = 100, int minBlockSize = 50, int rectLineScale = 1)
    {
        this.canvasWidth = canvasWidth;
        this.canvasHeight = canvasHeight;
        this.minBlockSize = minBlockSize + rectLineScale;
    }

    public List<Rect> Generate()
    {
        List<Rect> todoAreas = new List<Rect>();
        List<Rect> doneAreas = new List<Rect>();

        todoAreas.Add(new Rect(0, 0, canvasWidth, canvasHeight));

        while (todoAreas.Count > 0)
        {
            Rect currentBlock = todoAreas[0];
            todoAreas.RemoveAt(0);

            if (currentBlock.width >= currentBlock.height)
            {
                if (currentBlock.width > minBlockSize * 2f && currentBlock.height >= minBlockSize)
                {
                    //Vertical split
                    float oldWidth = currentBlock.width;

                    Rect left = new Rect(currentBlock.x, currentBlock.y, Random.Range(minBlockSize, currentBlock.width - minBlockSize), currentBlock.height);
                    Rect right = new Rect(left.xMax, left.y, oldWidth - left.width, left.height);

                    todoAreas.Add(left);
                    todoAreas.Add(right);
                }
                else
                {
                    doneAreas.Add(currentBlock);
                }
            }
            else if (currentBlock.width >= minBlockSize && currentBlock.height >= minBlockSize * 2f)
            {
                //Horizontal split
                float oldHeight = currentBlock.height;

                Rect top = new Rect(currentBlock.x, currentBlock.y, currentBlock.width, Random.Range(minBlockSize, currentBlock.height - minBlockSize));
                Rect bottom = new Rect(currentBlock.x, top.yMax, currentBlock.width, oldHeight - top.height);

                todoAreas.Add(top);
                todoAreas.Add(bottom);
            }
            else
            {
                doneAreas.Add(currentBlock);
            }
        }
        return doneAreas;
    }
}
