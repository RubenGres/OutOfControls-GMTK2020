using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLimit
{
    private static Dictionary<int, ControlLimit> levelLimit = null;
    public static ControlLimit currentControlLimit;

    public int up;
    public int left;
    public int right;

    public ControlLimit(int up, int left, int right)
    {
        this.up = up;
        this.left = left;
        this.right = right;
    }

    public static ControlLimit getLevelLimit(int level)
    {
        if(levelLimit == null)
        {
            levelLimit = new Dictionary<int, ControlLimit>();

            //test level
            addLevel(0, 5, 5, 5);

            addLevel(1, 0, 0, 1);
            addLevel(2, 1, 0, 1);
            addLevel(3, 1, 0, 1);
            addLevel(4, 2, 1, 1);
            addLevel(5, 4, 1, 2);
            addLevel(6, 1, 0, 1);
            addLevel(7, 2, 1, 2);
            addLevel(8, 4, 1, 1);
            addLevel(9, 5, 1, 2);
            addLevel(10, 3, 1, 2);
        }

        ControlLimit levelLim = levelLimit[level];
        currentControlLimit = new ControlLimit(levelLim.up, levelLim.left, levelLim.right);
        return currentControlLimit;
    }

    private static void addLevel(int level, int up, int left, int right)
    {
        ControlLimit limit = new ControlLimit(up, left, right);
        levelLimit.Add(level, limit);
    }
}
