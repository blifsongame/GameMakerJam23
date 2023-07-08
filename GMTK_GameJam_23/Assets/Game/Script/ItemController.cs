using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemController : MonoBehaviour
{
    public int ID;
    public int quantity;
    public TextMeshProUGUI quantityText;
    public bool Clicked = false;
    private LevelEditorManager editor;
    private PlayModeManager playModeManager;

    private int maxQuantity;

	private void Awake()
	{
        maxQuantity = quantity;
	}

	void Start()
    {
        quantityText.text = quantity.ToString();
        editor = GameObject.FindGameObjectWithTag("LevelEditorManager").GetComponent<LevelEditorManager>();
        playModeManager = PlayModeManager.Instance;
    }

    public void ButtonClicked()
	{
        if (playModeManager.playmode == PlayModeManager.PlayModeState.BuildMode && quantity > 0)
		{
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            Vector2 snappedPosition = new Vector2(Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.y));
            Instantiate(editor.ItemImages[ID], new Vector3(snappedPosition.x, snappedPosition.y, 0f), Quaternion.identity);

            Clicked = true;
            quantity--;
            quantityText.text = quantity.ToString();
            editor.CurrentButtonPressed = ID;
        }
	}

    public void ResetQuantity()
	{
        quantity = maxQuantity;
        quantityText.text = quantity.ToString();
    }

}
