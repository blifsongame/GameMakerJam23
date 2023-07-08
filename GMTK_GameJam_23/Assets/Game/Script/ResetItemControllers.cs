using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetItemControllers : MonoBehaviour
{
    private LevelEditorManager editor;
    private PlayModeManager playModeManager;

    // Start is called before the first frame update
    void Start()
    {
        editor = GameObject.FindGameObjectWithTag("LevelEditorManager").GetComponent<LevelEditorManager>();
        playModeManager = PlayModeManager.Instance;
    }

    public void ButtonClicked()
	{
        if (playModeManager.playmode == PlayModeManager.PlayMode.BuildMode)
		{
            editor.ResetAllSpawnedItems();
        }
        
	}
}
