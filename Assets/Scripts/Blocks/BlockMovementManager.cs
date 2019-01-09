using System.Collections.Generic;
using UnityEngine;

public class BlockMovementManager : MonoBehaviour {

    public static float speed;
    public float difficulty;
    public static List<Block> blocks = new List<Block>();

    private void Start()
    {
        speed = 0;
    }

    void Update () {
        if (speed < 0.2f)
        {
            IncreaseSpeed();
        }

        foreach (Block b in blocks)
        {
            if(!Pause.isPaused)
                b.Move(speed);
        }
	}

    void IncreaseSpeed()
    {
        speed = (Time.timeSinceLevelLoad / 10 + 1) / 10;
    }

    public static void AddBlock(Block b)
    {
        blocks.Add(b);
        //print("<color=green><b>" + b.name + "</b>  added to block list</color>");
    }
}
