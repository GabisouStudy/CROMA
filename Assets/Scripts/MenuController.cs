using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private Image play;
    [SerializeField]
    private Image playIn;

    [SerializeField]
    private GameObject settings;
    [SerializeField]
    private GameObject more;

    [SerializeField]
    private GameObject taper;
    private int color;

    private Animator animSett;
    private Animator animMore;

    void OnEnable()
    {
        color = Random.Range(0, 3);
        play.color = gameController.GetColor(color);
        playIn.color = gameController.GetColor(color);
        animSett = settings.GetComponent<Animator>();
        animMore = more.GetComponent<Animator>();
    }

    public void Play()
    {
        taper.GetComponent<FadeController>().goGame = true;
        taper.GetComponent<SpriteRenderer>().color = gameController.GetColor(color);
        taper.SetActive(true);
    }
	void Update()
	{
		if (animSett.GetCurrentAnimatorStateInfo (0).IsName ("EntrySettings") ||
			animSett.GetCurrentAnimatorStateInfo (0).IsName ("ExitSettings")) 
		{
			animSett.SetBool ("enter", false);
			animSett.SetBool ("exit", false);
		}
		if (animMore.GetCurrentAnimatorStateInfo (0).IsName ("EntryMore") ||
		    animMore.GetCurrentAnimatorStateInfo (0).IsName ("ExitMore")) 
		{
			animMore.SetBool ("enter", false);
			animMore.SetBool ("exit", false);
		}
	}
    public void Settings(bool go)
    {
        if (go)
        {
            animSett.SetBool("enter", true);
            animSett.SetBool("exit", false);
        }
        else
        {
            animSett.SetBool("enter", false);
            animSett.SetBool("exit", true);
        }
    }

    public void More(bool go)
    {
        if (go)
        {
            animMore.SetBool("enter", true);
            animMore.SetBool("exit", false);
        }
        else
        {
            animMore.SetBool("enter", false);
            animMore.SetBool("exit", true);
        }
    }

}
