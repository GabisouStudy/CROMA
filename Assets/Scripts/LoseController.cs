using UnityEngine;
using System.Collections;

public class LoseController : MonoBehaviour {
    
    [SerializeField]
    private GameController gameController;

    public void LoseLife()
    {
        gameController.LoseLife();
    }
}
