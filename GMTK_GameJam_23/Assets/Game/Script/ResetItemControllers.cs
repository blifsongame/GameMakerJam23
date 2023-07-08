using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetItemControllers : MonoBehaviour
{
    private LevelEditorManager editor;

    // Start is called before the first frame update
    void Start()
    {
        editor = GameObject.FindGameObjectWithTag("LevelEditorManager").GetComponent<LevelEditorManager>();
    }

    public void ButtonClicked()
	{
        editor.ResetAllSpawnedItems();
	}
}
