using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorManager : MonoBehaviour
{
    public ItemController[] ItemButtons;
    public GameObject[] ItemPrefabs;
	public GameObject[] ItemImages;
    public int CurrentButtonPressed;
	public AudioClip buildSFX;

	private List<SpawnedItem> allSpawnedItems = new();

	private PlayModeManager playModeManager;

	private AudioSource audioSource;



	private void Start()
	{
		playModeManager = PlayModeManager.Instance;
		audioSource = gameObject.GetComponent<AudioSource>();
		if (audioSource == null)
			audioSource = gameObject.AddComponent<AudioSource>();
	}

	private void Update()
	{
		if (playModeManager.playmode != PlayModeManager.PlayModeState.BuildMode)
		{
			return;
		}

		Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

		// Snap
		Vector2 snappedPosition = new Vector2(Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.y));

		if(Input.GetMouseButtonDown(0) && ItemButtons[CurrentButtonPressed].Clicked)
		{
			ItemButtons[CurrentButtonPressed].Clicked = false;
			var spawnedObj = Instantiate(ItemPrefabs[CurrentButtonPressed], new Vector3(snappedPosition.x, snappedPosition.y, 0f), Quaternion.identity);

			audioSource.PlayOneShot(buildSFX);
			var spawnedItem = spawnedObj.GetComponent<SpawnedItem>();
			if (spawnedItem == null)
			{
				Debug.LogError($"{nameof(LevelEditorManager)} item spawned without {nameof(SpawnedItem)} component.");
			}
			else
			{
				allSpawnedItems.Add(spawnedItem);
			}
			Destroy(GameObject.FindGameObjectWithTag("ItemImage"));
		}
	}

	public void ResetAllSpawnedItems()
	{
		for (int i = 0; i < allSpawnedItems.Count; i++)
		{
			//if (allSpawnedItems[i].gameObject.transfo)
			allSpawnedItems[i].DestroyAndUpdateEditor();
		}
		allSpawnedItems.Clear();
	}


}
