using UnityEngine;
using System.Collections;

public class FadeController : MonoBehaviour {

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject game;
    [SerializeField]
	private GameObject gameOver;
	[SerializeField]
	private GameObject pause;
    [SerializeField]
    private GameController controller;
    public bool goGame;
    private bool done;


    void OnEnable()
    {
        done = false;
    }

    void FixedUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Finished") && !done)
        {
            if (goGame)
            {
                menu.SetActive(false);
				game.SetActive(true);
				pause.SetActive(false);
                gameOver.SetActive(false);
                controller.enabled = false;               
            }
            else
            {
                menu.SetActive(true);
                game.SetActive(false);
				pause.SetActive(false);
				gameOver.SetActive(false);
                controller.enabled = false;
            }

            GameObject[] other = GameObject.FindGameObjectsWithTag("Taper");
            foreach (GameObject i in other)
            {
                Destroy(i);
            }
            other = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject i in other)
            {
                Destroy(i);
            }
            done = true;
        }

    }
    void LateUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Finished") && goGame)
        {
            controller.enabled = true;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("fin"))
        {
            this.gameObject.SetActive(false);

        }
    }
}
