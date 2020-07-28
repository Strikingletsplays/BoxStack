using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(GameScript))]
public class SaveScript : MonoBehaviour
{
    private float score;
    private string savePath;

    //GUI
    [SerializeField]
    private TMP_InputField CurrentName;
    [SerializeField]
    private TextMeshProUGUI TopScore;
    [SerializeField]
    private TextMeshProUGUI TopScoreName;

    // Start is called before the first frame update
    void Start()
    {
        savePath = Application.persistentDataPath + "/boxstack.ss";
    }
    public void SaveData()
    {
        score = GetComponent<GameScript>().getScore();
        Save save = new Save();
        {
            save.SavedScore = (int)score;
            save.SavedName = CurrentName.text;
        };

        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }
        Debug.Log("Score saved!");
        LoadData();
    }
    public Save LoadData()
    {
        if (File.Exists(savePath))
        {
            Save save;

            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }

            //load data to leaderboard...
            TopScore.text = save.SavedScore.ToString();
            TopScoreName.text = save.SavedName;
            return save;
        }
        else
        {
            Debug.LogWarning("Safe file dosen't exist");
            return null;
        }
    }
}
