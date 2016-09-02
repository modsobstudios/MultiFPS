using UnityEngine;
using System.Collections.Generic;

public class gameManager : MonoBehaviour
{

    public static gameManager instance;

    public MatchSettings matchSettings;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one game manager exists in the scene.");
        }
        else
            instance = this;
    }

    #region Player Tracking

    private static Dictionary<string, Player> players = new Dictionary<string, Player>();

    public static void regPlayer(string _netID, Player _player)
    {
        string playerID = "Player " + _netID;
        players.Add(playerID, _player);
        _player.transform.name = playerID;
    }

    public static void unregPlayer(string _id)
    {
        players.Remove(_id);
    }

    public static Player getPlayer(string _id)
    {
        return players[_id];
    }

    //void OnGUI()
    //{
    //    GUILayout.BeginArea(new Rect(200, 200, 200, 500));
    //    GUILayout.BeginVertical();

    //    foreach(string _p in players.Keys)
    //    {
    //        GUILayout.Label(_p + " - " + players[_p].transform.name);
    //    }

    //    GUILayout.EndVertical();
    //    GUILayout.EndArea();
    //}
    #endregion

}
