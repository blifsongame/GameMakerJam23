using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapDragHandler : MonoBehaviour
{

	[SerializeField]
	private Tilemap tilemap;

	[SerializeField]
	private Camera mainCamera;

    private Vector3 dragOffset;

	private void Update()
	{

		// TODO: Change the input type. Will trackpad work?
		// Not sure if thing confused
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
			Vector3Int cellPos = tilemap.WorldToCell(mouseWorldPos);
			TileBase clickedTile = tilemap.GetTile(cellPos);

			if (clickedTile != null)
			{
				dragOffset = mouseWorldPos - tilemap.GetCellCenterWorld(cellPos);
			}
			else
			{
				Debug.LogWarning("");
			}

			if (Input.GetMouseButton(0) && dragOffset != Vector3.zero)
			{
				//Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
				Vector3Int cellPosNew = tilemap.WorldToCell(mouseWorldPos - dragOffset);
				tilemap.SetTile(cellPos, tilemap.GetTile(cellPosNew));
			}

			if (Input.GetMouseButtonUp(0))
			{
				dragOffset = Vector3.zero;
			}
		}
	}
}
