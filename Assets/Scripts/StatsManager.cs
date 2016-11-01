using UnityEngine;
using System.Collections;

public class StatsManager : MonoBehaviour {


    public void SaveTotalSH(int score, int hit)
    {
        PlayerPrefs.SetInt("TotalScore", score);
        PlayerPrefs.SetInt("TotalHit", hit);
    }
    public void SaveSpecificHit(int yellow, int red, int blue)
    {
        PlayerPrefs.SetInt("YellowHit", yellow);
        PlayerPrefs.SetInt("RedHit", red);
        PlayerPrefs.SetInt("BlueHit", blue);
    }
    public void SaveMixedHit(int green, int orange, int purple)
    {
        PlayerPrefs.SetInt("GreenHit", green);
        PlayerPrefs.SetInt("OrangeHit", orange);
        PlayerPrefs.SetInt("PurpleHit", purple);
    }
    public void SaveSpecialUses(int special)
    {
        PlayerPrefs.SetInt("SpecialUses", special);
    }

}
