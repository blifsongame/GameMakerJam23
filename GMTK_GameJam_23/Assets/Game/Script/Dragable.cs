using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
	private RectTransform rectTransform;
	private Image image;

	public void OnBeginDrag(PointerEventData eventData)
	{
		image.color = new Color32(255, 255, 255, 170);
	}

	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		image.color = new Color32(255, 255, 255, 255);
	}

	private void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		image = GetComponent<Image>();
	}
}
