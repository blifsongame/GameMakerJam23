using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedItem : MonoBehaviour
{
    public int ID;
    private LevelEditorManager editor;
    private PlayModeManager playModeManager;

    // Start is called before the first frame update
    void Start()
    {
        editor = GameObject.FindGameObjectWithTag("LevelEditorManager").GetComponent<LevelEditorManager>();
        playModeManager = PlayModeManager.Instance;
    }

	private void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(1) && playModeManager.playmode == PlayModeManager.PlayModeState.BuildMode)
		{
            DestroyAndUpdateEditor();
        }
	}

    public void DestroyAndUpdateEditor()
	{
        Destroy(this.gameObject);
        editor.ItemButtons[ID].quantity++;
        editor.ItemButtons[ID].quantityText.text = editor.ItemButtons[ID].quantity.ToString();
    }
}
