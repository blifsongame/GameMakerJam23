using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemainingEnemyCounter : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI textMesh;

    private int remain = -1;
    private ObjectiveManager objectiveManager;

	private void Start()
	{
		objectiveManager = FindObjectOfType<ObjectiveManager>();
		if(objectiveManager == null)
		{
			Debug.LogError("Failed to find ObjectiveManager");
		}
	}

	private void Update()
	{
		if (objectiveManager != null)
		{
			if (objectiveManager.RemainingEnemeies != remain)
			{
				remain = objectiveManager.RemainingEnemeies;

				if (remain <= 0)
				{
					textMesh.text = "Go to Goal";
				}
				else
				{
					textMesh.text = $"Remaining Enemies: {remain}";
				}
			}
		}
	}
}
