using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager
{
    private const string PROGRESS_KEY = "Progress";

    public static UserProgressData Progress;

    public static void Load()
    {
        // Cek apa ada data yg tersimpan sbg PROGRESS_KEY
        if (!PlayerPrefs.HasKey(PROGRESS_KEY))
        {
            // Jika tak ada, maka buat baru
            Progress = new UserProgressData();
            Save();
        }
        else
        {
            // Jika ada, maka timpa progress dg sebelumnya
            string json = PlayerPrefs.GetString (PROGRESS_KEY);
            Progress = JsonUtility.FromJson<UserProgressData> (json);
        }
    }

    public static void Save()
    {
        string json = JsonUtility.ToJson (Progress);
        PlayerPrefs.SetString (PROGRESS_KEY, json);
    }

    public static bool HasResources(int index)
    {
        return index + 1 <= Progress.ResourcesLevels.Count;
    }


    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
