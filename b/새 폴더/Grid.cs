using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    // Start is called before the first frame update

    private int width;
    private int height;
    private float cellsize;
    private int[,] gridArray;

    public Grid(int width,int height,float cellsize)
    {
        this.width = width;
        this.height = height;
        this.cellsize = cellsize;
        
        gridArray = new int[width, height];

        
        for(int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                
            }
        }

    }
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellsize;
    }
    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / cellsize);
        y = Mathf.FloorToInt(worldPosition.y / cellsize);
    }
    public void SetValue(int x, int y, int value)
    {
        if(x >=0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
        }
    }
    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }
}
