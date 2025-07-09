public class PlayerStatsModel
{
    private const string MAX_SCORE_KEY = "max_score";

    public int MaxScore
    {
        get => UnityEngine.PlayerPrefs.GetInt(MAX_SCORE_KEY, 0);
        set
        {
            if (value > MaxScore)
                UnityEngine.PlayerPrefs.SetInt(MAX_SCORE_KEY, value);
        }
    }
}