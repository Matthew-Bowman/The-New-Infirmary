using UnityEngine;

public class Resources : MonoBehaviour
{
    // DECLARE variables
    public int wood = 0;
    public int stone = 0;


    // DECLARE getters
    public int Wood
    {
        get { return wood; }
    }

    public int Stone
    {
        get { return stone; }
    }

    public void Collected(Resource type)
    {
        // INCREMENT gathered resource:
        switch (type)
        {
            case Resource.Wood:
                wood++;
                break;
            case Resource.Stone:
                stone++;
                break;
        }
    }
}