using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static int layer = 0;
    public static bool lose;
    public static bool pause;
    public static bool prepare;
    private int score = 0;
    private int dificult = 0;
    private int enemyCount = 0;
    private int counter = 0;
    private int maxCounter = 100;
    private int life = 3;
    private int blockColor;
    [SerializeField]
    private Image[] lifeImage;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject[] tapers;
    [SerializeField]
    private Color[] colors;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject gameOver;


    void OnEnable()
    {
        layer = 0;
        score = 0;
        life = 3;
        dificult = 3;
        maxCounter = 100;
        lose = false;
		pause = false;
        prepare = true;
        counter = 0;
        foreach(Image c in lifeImage)
        {

            c.color = colors[9];
        }
    }

    public void SumScore(int value)
    {
		if (!lose && !pause)
        {
            score += value;
            enemyCount++;
            if (score.Equals(10))
                dificult = 5;
            if (score.Equals(20))
				maxCounter = 60;
			if (score.Equals(40))
				maxCounter = 40;
			if (score.Equals(60))
				maxCounter = 30;
        }
    }
	public void ChangePause()
	{
		pause = !pause;
	}
    void FixedUpdate()
    {
        if (!lose && !pause)
        {
            scoreText.text = score.ToString();
            if (counter < maxCounter)
            {
                counter++;
            }
            else
            {
                SpawnEnemy();
                counter = 0;
                if (maxCounter > 10)
                    maxCounter -= maxCounter / 100;
            }
        }
    }


    public void LoseLife()
    {
        if (life > 0)
        {
            life--;
            lifeImage[life].color = colors[8];
            Handheld.Vibrate();
            if(life <= 0)
            {
                gameOver.SetActive(true);
                lose = true;
                ShowAd();
            }
        }
    }
    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
    public void SpawnTaper(int color)
    {
		if (!lose && !pause)
        {
            if (color <= 5 && prepare)
            {
                int n = UnityEngine.Random.Range(0, tapers.Length);
                GameObject taper = (GameObject)Instantiate(tapers[n]);
                taper.GetComponent<SpriteRenderer>().color = colors[color];
                taper.GetComponent<SpriteRenderer>().sortingOrder = layer;
                taper.name = color.ToString();
                blockColor = color;
                layer++;
                prepare = false;
            }
            else
            {
                // especial
            }
        }
    }
    public Color GetColor(int color)
    {
        return colors[color];
    }
    public void SpawnEnemy()
    {
        int n = UnityEngine.Random.Range(0, dificult);
        while(n.Equals(blockColor))
            n = UnityEngine.Random.Range(0, dificult + 1);
        Vector2 position = new Vector2(UnityEngine.Random.Range(-2.5f, 2.5f), UnityEngine.Random.Range(3.2f, -4.3f));
        GameObject enemy = (GameObject)Instantiate(this.enemy, position, this.enemy.transform.rotation);
        enemy.GetComponent<SpriteRenderer>().color = colors[n];
        enemy.GetComponent<EnemyBehaviour>().gameController = this;
        enemy.name = n.ToString();        
    }
    public void SpawnEnemy(int n, Vector2 position)
    {
        GameObject enemy = (GameObject)Instantiate(this.enemy, position, this.enemy.transform.rotation);
        enemy.GetComponent<SpriteRenderer>().color = GetColor(n);
        enemy.GetComponent<EnemyBehaviour>().gameController = this;
        enemy.name = n.ToString();
    }
}
