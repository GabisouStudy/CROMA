using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public GameController gameController;
    private float velX;
    private float velY;
    private Vector2 saveVel;

    void Start()
    {
        float angleRadians = Mathf.Atan2(0 - this.transform.position.y, 0 - this.transform.position.x);
        velX = Mathf.Cos(angleRadians);
        velY = Mathf.Sin(angleRadians);
    }

    void Update()
    {
		if (!GameController.pause) 
		{
			this.GetComponent<Rigidbody2D> ().WakeUp();
			this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (velX, velY));
		}
		else
		{
			this.GetComponent<Rigidbody2D> ().Sleep();
		}
    }

    public float GetAproxSpeed()
    {
        return (velX + velY) / 2; 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (int.Parse(this.gameObject.name) < 3 && int.Parse(other.gameObject.name) < 3 && other.gameObject.name != this.gameObject.name)
        {
            if (other.gameObject.GetComponent<EnemyBehaviour>().GetAproxSpeed() > this.GetAproxSpeed())
            {
                int temp = int.Parse(other.gameObject.name) + int.Parse(this.gameObject.name) + 2;
                gameController.SpawnEnemy(temp, this.transform.position);
            }
            Destroy(this.gameObject);
        }
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("PreTaper") && other.gameObject.name.Equals(this.gameObject.name))
        {
            gameController.SumScore(1);
            if (int.Parse(this.gameObject.name) > 2)
                gameController.SumScore(2);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag.Equals("Respawn"))
        {
            other.gameObject.GetComponent<LoseController>().LoseLife();
            Destroy(this.gameObject);
        }
    }
}
