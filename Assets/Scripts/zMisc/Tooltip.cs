using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class Tooltip : MonoBehaviour {

    public float additionalOffsetX, additionalOffsetY;
    private Vector3 offset = new Vector3(-100, 0);
    public string toolTip;
    private Text toolTipText;
    public GameObject toolTipBox;
    GameObject curToolTipBox;

	public void SpawnToolTip () {
        if (curToolTipBox == null)
        {
            curToolTipBox = gameObject; // In first scene, make us the singleton.
        }
        else if (curToolTipBox != gameObject)
            Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.

        curToolTipBox = Instantiate(toolTipBox, FindAnyObjectByType<Canvas>().transform);
        curToolTipBox.transform.position = Input.mousePosition;
        toolTipText = curToolTipBox.GetComponentInChildren<Text>();
        toolTipText.text = toolTip;
	}

    public void DespawnToolTip()
    {
        Destroy(curToolTipBox);
    }

    private void Update()
    {
        if (curToolTipBox != null)
            curToolTipBox.transform.position = Input.mousePosition + offset + new Vector3(additionalOffsetX, additionalOffsetY);
    }
}
