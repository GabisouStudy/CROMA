using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonBlackCall : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField]
	private ButtonController button;


    public void OnPointerEnter(PointerEventData eventData)
    {
        button.Enter();
	}
	public void OnPointerDown(PointerEventData eventData)
	{
	}
    public void OnPointerUp(PointerEventData eventData)
    {
		button.Up();
    }
}
