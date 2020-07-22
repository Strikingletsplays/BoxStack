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
    private TMP_InputField Name;
    [SerializeField]
    private TextMeshProUGUI TopScore;
    [SerializeField]
    private TextMeshProUGUI TopScoreName;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<GameScript>().getScore();
        savePath = Application.persistentDataPath + "/boxstack.ss";
    }

    public void SaveData()
    {
        
        Save save = new Save();
        {
            save.SavedScore = (int)score;
            save.SavedName = Name.text;
        };

        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }
        Debug.Log("Score saved!");
    }
    public void LoadData()
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
        }
        else
        {
            Debug.LogWarning("Safe file dosen't exist");
        }
    }
}
