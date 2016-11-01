using UnityEngine;
using System.Collections;

public class Quest {

    private string request;
    private int value;
    private bool complete;

    public Quest(string request, int value)
    {
        this.request = request; 
        this.value = value;
        complete = false;
    }

    public void TestComplete(int test)
    {
        if (test > value)
            complete = true;
        else
            return;
    }
}
