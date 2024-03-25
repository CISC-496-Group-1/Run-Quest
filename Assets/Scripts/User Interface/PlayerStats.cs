using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using CI.QuickSave;
using UnityEngine.Networking;
using System;
using Newtonsoft.Json;

public class PlayerStats : MonoBehaviour
{
    public static int strength;
    public static int defense;
    public static int magicDamage;
    public static int speed;

    public Text text;

    public QuickSaveReader reader;
    public QuickSaveWriter writer;

    public LogScript log;

    private PlayerMovement playerMove;

    void Start()
    {
        if (!QuickSaveReader.RootExists("Stats"))
        {
            writer = QuickSaveWriter.Create("Stats");
            writer.Write("Strength", 1);
            writer.Write("Defense", 1);
            writer.Write("Magic Damage", 1);
            writer.Write("Speed", 1);
            writer.Commit();
        }
        
        writer = QuickSaveWriter.Create("Stats");
        reader = QuickSaveReader.Create("Stats");

        strength = reader.Read<int>("Strength");
        defense = reader.Read<int>("Defense");
        magicDamage = reader.Read<int>("Magic Damage");
        speed = reader.Read<int>("Speed");

        playerMove = GetComponent<PlayerMovement>();

        log = GetComponent<LogScript>();

        UpdatePlayerStats();

    }

    public void addStrength(int amountToAdd)
    {
        strength += amountToAdd;
         writer.Write("Strength", strength);
         writer.Commit();

    }

    public void addDefense(int amountToAdd)
    {
        defense += amountToAdd;
        writer.Write("Defense", defense);
        writer.Commit();
        UpdatePlayerStats();
    }

    public void addMagicDamage(int amountToAdd)
    {
        magicDamage += amountToAdd;
        writer.Write("Magic Damage", magicDamage);
        writer.Commit();
        UpdatePlayerStats();
    }

    public void addSpeed(int amountToAdd)
    {
        speed += amountToAdd;
        writer.Write("Speed", speed);
        writer.Commit();
        UpdatePlayerStats();
    }

    public void GenerateStats(int min, int max)
    {
        addStrength(UnityEngine.Random.Range(min, max));
        addDefense(UnityEngine.Random.Range(min, max));
        addMagicDamage(UnityEngine.Random.Range(min, max));
        addSpeed(UnityEngine.Random.Range(min, max));
    }

    public void UpdatePlayerStats()
    {
        text.text = "Strength: " + strength + "\nDefence: " + defense + "\nMagic Damage: " + magicDamage + "\nSpeed: " + speed;
    }
    public IEnumerator GetLogs(string token)
    {
        using (UnityWebRequest response = UnityWebRequest.Get("https://www.strava.com/api/v3/athlete/activities?per_page=30"))
        {
            response.SetRequestHeader("accept", "application/json");
            response.SetRequestHeader("authorization", "Bearer " + token);

            yield return response.SendWebRequest();

            if (response.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error getting logs");
            }
            else
            {
                Debug.Log(response.downloadHandler.text);

                List<Activity> activities = JsonConvert.DeserializeObject<List<Activity>>(response.downloadHandler.text);
                Debug.Log(activities);

                foreach (Activity a in activities)
                {
                    log.CreateNewLog(a);
                    playerMove.AddDistance((float) a.distance / 100);
                    addStrength((int)a.distance / 100);
                    addSpeed((int)a.max_speed);
                    addDefense((int)a.moving_time / 100);
                    addMagicDamage((int)a.average_speed);
                }
            }
        }
    }
}


public class AthleteId
{
    public int id { get; set; }
    public int resource_state { get; set; }
}

public class Map
{
    public string id { get; set; }
    public string summary_polyline { get; set; }
    public int resource_state { get; set; }
}

public class Activity
{
    public int resource_state { get; set; }
    public AthleteId athlete { get; set; }
    public string name { get; set; }
    public double distance { get; set; }
    public int moving_time { get; set; }
    public int elapsed_time { get; set; }
    public double total_elevation_gain { get; set; }
    public string type { get; set; }
    public string sport_type { get; set; }
    public long id { get; set; }
    public DateTime start_date { get; set; }
    public DateTime start_date_local { get; set; }
    public string timezone { get; set; }
    public double utc_offset { get; set; }
    public object location_city { get; set; }
    public object location_state { get; set; }
    public object location_country { get; set; }
    public int achievement_count { get; set; }
    public int kudos_count { get; set; }
    public int comment_count { get; set; }
    public int athlete_count { get; set; }
    public int photo_count { get; set; }
    public Map map { get; set; }
    public bool trainer { get; set; }
    public bool commute { get; set; }
    public bool manual { get; set; }
    public bool @private { get; set; }
    public string visibility { get; set; }
    public bool flagged { get; set; }
    public object gear_id { get; set; }
    public List<object> start_latlng { get; set; }
    public List<object> end_latlng { get; set; }
    public double average_speed { get; set; }
    public double max_speed { get; set; }
    public bool has_heartrate { get; set; }
    public bool heartrate_opt_out { get; set; }
    public bool display_hide_heartrate_option { get; set; }
    public double elev_high { get; set; }
    public double elev_low { get; set; }
    public long upload_id { get; set; }
    public string upload_id_str { get; set; }
    public string external_id { get; set; }
    public bool from_accepted_tag { get; set; }
    public int pr_count { get; set; }
    public int total_photo_count { get; set; }
    public bool has_kudoed { get; set; }
}

