using UnityEngine;
using UnityEngine.UI;
using System.Collections; 
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour//, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private Image sprite;
    [SerializeField]
    private int myKey;
    private Button button;
    private bool used;

	private static List<int> totalKey = new List<int>();
    private static bool press;


    void Start()
    {
        used = false;
		sprite.color = gameController.GetColor(myKey);
		List<int> totalKey = new List<int>();
    }
    /*public void OnTouchDown(PointerEventData eventData)
    {
        Down();
    }
	public void OnTouchEnter(PointerEventData eventData)
    {
        Enter();
    }
    public void OnTouchUp(PointerEventData eventData)
    {
        Up();
    }*/
    public void Enter()
    {
        if (this.enabled)
		{
			totalKey.Add(myKey); 
			if(totalKey.Count > 2)
				totalKey.RemoveAt(0);
        }
    }
    public void Up()
    {
        if (this.enabled)
		{
			int i = 0;
			if(totalKey.Count >= 2)
			{
				i = totalKey[0] + totalKey[1] + 2;
			}
			else
			{
				i = totalKey[0];
			}
            gameController.SpawnTaper(i);
			totalKey.Clear();
            press = false;
            used = false;
        }
    }
}