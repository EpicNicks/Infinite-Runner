using UnityEngine;

public class Done_BGScroller : MonoBehaviour
{
    //Tile size z: 10
    //scroll speed: 5
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}