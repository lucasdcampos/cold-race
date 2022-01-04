using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordManager : MonoBehaviour
{

    public Discord.Discord discord;
    public string details;
    public string state;
    public long id;

    // Start is called before the first frame update
    void Start()
    {
        id = 924839115713814578;

        discord = new Discord.Discord(id, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Details = details,
            State = state,
            Timestamps =
            {
                 Start = 5,
             },

            Assets =
            {
                LargeImage = "banner",

            }
        };



        activityManager.UpdateActivity(activity, (res) => {
            if (res == Discord.Result.Ok)
                Debug.Log("Discord Status Set");
            else
                Debug.LogError("Discord Status failed");
        });

    }


    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
    }
}
