
using System;
using System.Collections.Generic;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary contains:
///
/// (x,y) : [left, right, up, down]
///
/// If a direction is false, there is a wall in that direction.
/// If a direction is true, movement is allowed.
///
/// If movement is blocked, an InvalidOperationException is thrown.
/// Otherwise, the current coordinates are updated.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Moves left if the path is open.
    /// </summary>
    public void MoveLeft()
    {
        Move(0, -1, 0);
    }

    /// <summary>
    /// Moves right if the path is open.
    /// </summary>
    public void MoveRight()
    {
        Move(1, 1, 0);
    }

    /// <summary>
    /// Moves up if the path is open.
    /// </summary>
    public void MoveUp()
    {
        Move(2, 0, -1);
    }

    /// <summary>
    /// Moves down if the path is open.
    /// </summary>
    public void MoveDown()
    {
        Move(3, 0, 1);
    }

    /// <summary>
    /// Checks whether movement is allowed and updates the coordinates.
    /// </summary>
    private void Move(int direction, int changeX, int changeY)
    {
        var currentPosition = (_currX, _currY);

        if (!_mazeMap[currentPosition][direction])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX += changeX;
        _currY += changeY;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
