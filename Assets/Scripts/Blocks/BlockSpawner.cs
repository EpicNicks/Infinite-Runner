using UnityEngine;
using UnityEngine.UI;
public class BlockSpawner : MonoBehaviour {
    /// <summary>
    /// Edges of screen:
    /// Left: -7.5
    /// Right: 7.5
    /// Top: 5
    /// Bottom: -5
    /// </summary>
    public GameObject blockPrefab;
    public const float LEFT_EDGE = -7.5f;
    public const float RIGHT_EDGE = 7.5f;
    public const float TOP_EDGE = 5.0f;
    public const float BOTTOM_EDGE = -5.0f;
    private int totalBlockCount = 0;

	
	void Update ()
    {
        SpawnBlock();
	}
    
    void SpawnBlock()
        //TODO: check why this if never runs in spaceFromSpawn and array
    {
        // f(x) = -0.5194286*x + 2.92   (half of transform + offset
        float spaceFromSpawn = BlockMovementManager.blocks[BlockMovementManager.blocks.Count - 1].transform.localScale.x * -0.5f + 2;

        if(BlockMovementManager.blocks[BlockMovementManager.blocks.Count - 1].transform.position.x < spaceFromSpawn)
        {
            totalBlockCount++;
            GameObject block = Instantiate(blockPrefab, new Vector3(), Quaternion.identity) as GameObject;
            block.name = "Block" + totalBlockCount;
            block.transform.localScale = new Vector3(Random.Range(5, 10), Random.Range(1, 3));
            block.transform.position = new Vector3(RIGHT_EDGE + block.transform.localScale.x / 2.0f, -Random.Range(1.0f, 3.75f));

        ///TODO
        ///Set random parameters relative to previous block in list
        }
    }
}
