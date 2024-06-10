using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.Networking;

static class MyDataBase
{
    private const string fileName = "CardDB.bytes";
    private static string DBPath;
    private static SqliteConnection connection;
    private static SqliteCommand command;
    static MyDataBase()
    {
        DBPath = GetDatabasePath();
    }

    private static string GetDatabasePath()
    {
#if UNITY_EDITOR
        string filePath = Path.Combine(Application.dataPath, fileName);
        if(!File.Exists(filePath)) UnpackDatabase(filePath);
        return filePath;

#elif UNITY_STANDALONE
        string filePath = Path.Combine(Application.dataPath, fileName);
        if(!File.Exists(filePath)) UnpackDatabase(filePath);
        return filePath;
#elif UNITY_ANDROID
    string filePath = Path.Combine(Application.persistentDataPath, fileName);
    if(!File.Exists(filePath)) UnpackDatabase(filePath);
    return filePath;

#endif

    }

    private static void UnpackDatabase(string toPath)
{
    string fromPath = Path.Combine(Application.streamingAssetsPath, fileName);

    UnityWebRequest reader = new UnityWebRequest(fromPath);
        reader.downloadHandler = new DownloadHandlerBuffer();
       while (!reader.isDone) { }

    File.WriteAllBytes(toPath, reader.downloadHandler.data);
}
    private static void OpenConnection()
    {
        connection = new SqliteConnection("Data Source=" + DBPath);
        command = new SqliteCommand(connection);
        connection.Open();
    }

 
    public static void CloseConnection()
    {
        connection.Close();
        command.Dispose();
    }


    public static void ExecuteQueryWithoutAnswer(string query)
    {
        OpenConnection();
        command.CommandText = query;
        command.ExecuteNonQuery();
        CloseConnection();
    }
    


public static string ExecuteQueryWithAnswer(string query)
    {
        OpenConnection();
        command.CommandText = query;
        var answer = command.ExecuteScalar();
        CloseConnection();

        if (answer != null) return answer.ToString();
        else return null;
    }

  
    public static DataTable GetTable(string query)
    {
        OpenConnection();

        SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection);

        DataSet DS = new DataSet();
        adapter.Fill(DS);
        adapter.Dispose();

        CloseConnection();

        return DS.Tables[0];
    }
}