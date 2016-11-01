using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonGameOver : MonoBehaviour, IPointerDownHandler
{

    [SerializeField]
    private bool restart;
    [SerializeField]
    private GameObject fade;
    public void OnPointerDown(PointerEventData eventData)
    {
        if(restart)
        {
            fade.GetComponent<FadeController>().goGame = true;
            fade.SetActive(true);
        }
        else
        {
            fade.GetComponent<FadeController>().goGame = false;
            fade.SetActive(true);
        }
    }

    
}
