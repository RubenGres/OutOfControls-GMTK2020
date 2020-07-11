using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLimit : Dictionary<string, int>
{
    private static Dictionary<int, ControlLimit> levelLimit = null;

    public static ControlLimit getLevelLimit(int level)
    {
        if(levelLimit == null)
        {
            levelLimit = new Dictionary<int, ControlLimit>();

            //test level
            addLevel(0, 99, 99, 99);

            addLevel(1, 0, 0, 1);
            addLevel(2, 1, 0, 1);
            addLevel(3, 1, 0, 1);
            addLevel(4, 2, 1, 1);
        }

        return levelLimit[level];
    }

    private static void addLevel(int level, int up, int left, int right)
    {
        ControlLimit limit = new ControlLimit();
        limit.Add("up", up);
        limit.Add("left", left);
        limit.Add("right", right);
        levelLimit.Add(level, limit);
    }
}
