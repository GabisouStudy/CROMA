using UnityEngine;
using System.Collections;

public class TaperBehaviour : StateMachineBehaviour {
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        GameObject[] other = GameObject.FindGameObjectsWithTag("Taper");
        foreach (GameObject i in other)
        {
            Destroy(i);
        }
        GameController.prepare = true;
        animator.gameObject.tag = "Taper";
    }

}
