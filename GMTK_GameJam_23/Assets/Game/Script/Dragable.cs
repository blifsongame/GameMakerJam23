using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	// TODO: Have check if drag is allowed


	public void OnBeginDrag(PointerEventData eventData)
	{
		Debug.Log("On Begin Drag");
	}

	public void OnDrag(PointerEventData eventData)
	{
		Debug.Log("On Drag");
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("On End Drag");
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("On Pointer Down");
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
