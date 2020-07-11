using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLimit
{
    private static Dictionary<int, ControlLimit> levelLimit = null;

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
            addLevel(0, 1, 1, 1);

            addLevel(1, 0, 0, 1);
            addLevel(2, 1, 0, 1);
            addLevel(3, 1, 0, 1);
            addLevel(4, 2, 1, 1);
        }

        ControlLimit levelLim = levelLimit[level];
        return new ControlLimit(levelLim.up, levelLim.left, levelLim.right);
    }

    private static void addLevel(int level, int up, int left, int right)
    {
        ControlLimit limit = new ControlLimit(up, left, right);
        levelLimit.Add(level, limit);
    }
}
