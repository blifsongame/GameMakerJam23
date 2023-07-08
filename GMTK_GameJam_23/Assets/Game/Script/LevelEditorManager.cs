using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorManager : MonoBehaviour
{
    public ItemController[] ItemButtons;
    public GameObject[] ItemPrefabs;
	public GameObject[] ItemImages;
    public int CurrentButtonPressed;

	private List<SpawnedItem> allSpawnedItems = new();

	private void Update()
	{
		Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

		if(Input.GetMouseButtonDown(0) && ItemButtons[CurrentButtonPressed].Clicked)
		{
			ItemButtons[CurrentButtonPressed].Clicked = false;
			var spawnedObj = Instantiate(ItemPrefabs[CurrentButtonPressed], new Vector3(worldPosition.x, worldPosition.y, 0f), Quaternion.identity);

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
			allSpawnedItems[i].DestroyAndUpdateEditor();
		}
		allSpawnedItems.Clear();
	}


}
