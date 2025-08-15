using System.Collections.Generic;
using UnityEngine;

public class BlockMovementManager : MonoBehaviour {

    public static float speed;
    public float difficulty;
    public static List<Block> blocks = new List<Block>();

    private float secondsElapsed = 0;

    private void Start()
    {
        speed = 0;
    }

    void Update () {
        if (!Pause.isPaused)
        {
            secondsElapsed += Time.deltaTime;
        }

        if (speed < 20f)
        {
            IncreaseSpeed();
        }

        foreach (Block b in blocks)
        {
            if(!Pause.isPaused)
                b.Move(speed * Time.deltaTime);
        }
	}

    void IncreaseSpeed()
    {
        speed = (secondsElapsed / 20 + 10);
    }

    public static void AddBlock(Block b)
    {
        blocks.Add(b);
        //print("<color=green><b>" + b.name + "</b>  added to block list</color>");
    }
}
