using UnityEngine;

public class Block : MonoBehaviour {

    public GameObject coin;
    private PlayerMovement player;
    private bool isDead = false;

	void Start ()
    {
        player = FindObjectOfType<PlayerMovement>();
        BlockMovementManager.AddBlock(this);

        AddCoin();

        SpriteRenderer blockRend = GetComponent<SpriteRenderer>();
        blockRend.color = ColorScheme();
    }

    private void Update()
    {
        if (IsOffScreen())
        {
            //print("<color=red><b> " + name + "</b> was marked for destruction</color>");
            BlockMovementManager.blocks.Remove(this);
            Destroy(gameObject);
        }
        if(player != null)
            if (transform.position.x + transform.localScale.x / 2.0f < player.transform.position.x && !isDead)
            {
                StartCoroutine(ScoreManager.UpdateScore());
                isDead = true;
            }
    }

    public void Move(float speed)
    {
        if(this != null)
            transform.position -= new Vector3(speed, 0);
    }

    private bool IsOffScreen()
    {
        float offScreen = BlockSpawner.LEFT_EDGE - 1.0f - transform.localScale.x / 2.0f;
        return transform.position.x < offScreen;
    }

    Color ColorScheme()
    {
        switch (ColorSetter.selected)
        {
            case ColorSetter.NumOptions.COOL: return ColorRandomizer.RandomCold();
            case ColorSetter.NumOptions.WARM: return ColorRandomizer.RandomWarm();
            case ColorSetter.NumOptions.FABULOUS: return ColorRandomizer.RandomFabulous();
            case ColorSetter.NumOptions.LIGHT: return ColorRandomizer.RandomLight();
            case ColorSetter.NumOptions.DARK: return ColorRandomizer.RandomDark();
            case ColorSetter.NumOptions.RANDOM: return Random.ColorHSV();
            case ColorSetter.NumOptions.CLASSICBLACK: return Color.black;
            case ColorSetter.NumOptions.CLASSICWHITE: return ColorRandomizer.RandomGreyScale();
            default: return Random.ColorHSV();
        }          
    }

    private void AddCoin()
    {
        float xHalfScale = transform.localScale.x / 2;
        float yMin = transform.position.y + transform.localScale.y;

        GameObject tempCoin =  Instantiate(coin, Vector3.zero, Quaternion.identity) as GameObject;
        tempCoin.transform.position = new Vector3
            (Random.Range(transform.position.x - xHalfScale, transform.position.x + xHalfScale), Random.Range(yMin, 3));
        tempCoin.transform.parent = transform;
    }
}
