using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SqliteEX : MonoBehaviour {



    void Start()
    {
		SqliteActSelect.Stage = new int[12];
		SqliteActSelect.Star1 = new int[12];
		SqliteActSelect.Star2 = new int[12];
		SqliteActSelect.Star3 = new int[12];

        string m_ConnectionString;
        string m_SQLiteFileName = "PnP.sqlite";
        string conn;
#if UNITY_EDITOR
        m_ConnectionString = "URI=file:" + Application.streamingAssetsPath + "/" + m_SQLiteFileName;
        //m_ConnectionString = "URI=file:" + Application.dataPath + "/" + m_SQLiteFileName;
#else
            // check if file exists in Application.persistentDataPath
            var filepath = string.Format("{0}/{1}", Application.persistentDataPath, m_SQLiteFileName);

            if (!File.Exists(filepath))
            {
                // if it doesn't ->
                // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
                WWW loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + m_SQLiteFileName);  // this is the path to your StreamingAssets in android
                loadDb.bytesDownloaded.ToString();
                while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
                // then save to Application.persistentDataPath
                File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                     var loadDb = Application.dataPath + "/Raw/" + m_SQLiteFileName;  // this is the path to your StreamingAssets in iOS
                    // then save to Application.persistentDataPath
                    File.Copy(loadDb, filepath);
#elif UNITY_WP8
                    var loadDb = Application.dataPath + "/StreamingAssets/" + m_SQLiteFileName;  // this is the path to your StreamingAssets in iOS
                    // then save to Application.persistentDataPath
                    File.Copy(loadDb, filepath);
#elif UNITY_WINRT
      var loadDb = Application.dataPath + "/StreamingAssets/" + m_SQLiteFileName;  // this is the path to your StreamingAssets in iOS
      // then save to Application.persistentDataPath
      File.Copy(loadDb, filepath);
#else
     var loadDb = Application.dataPath + "/StreamingAssets/" + m_SQLiteFileName;  // this is the path to your StreamingAssets in iOS
     // then save to Application.persistentDataPath
     File.Copy(loadDb, filepath);

#endif
            }

            m_ConnectionString = "URI=file:" + filepath;
#endif

        ///////////////////////////////////////////////////////////////////[DB Path]
        if (Application.platform == RuntimePlatform.Android) {
		conn = "URI=file:" + Application.persistentDataPath + "/PnP.sqlite"; //Path to databse on Android
		} else { conn = "URI=file:" + Application.streamingAssetsPath + "/PnP.sqlite"; } //Path to database Else
        ///////////////////////////////////////////////////////////////////[DB Path]

        
        ///////////////////////////////////////////////////////////////////[DB Connection]
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        ///////////////////////////////////////////////////////////////////[DB Connection]


        ///////////////////////////////////////////////////////////////////[DB Query]
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * " + "FROM DATA";
        dbcmd.CommandText = sqlQuery;
        ///////////////////////////////////////////////////////////////////[DB Query]

        ///////////////////////////////////////////////////////////////////[Data Read]
        IDataReader reader = dbcmd.ExecuteReader();

		int num = 0;

	    while (reader.Read())
	    {
		SqliteActSelect.Stage[num] = reader.GetInt32(0);
		SqliteActSelect.Star1[num] = reader.GetInt32(1);
		SqliteActSelect.Star2[num] = reader.GetInt32(2);
		SqliteActSelect.Star3[num] = reader.GetInt32(3);

			//Debug.Log("stageNum= " + Stage[num] + "  Star1 =" + Star1[num] + "  Star2 =" + Star2[num] + "  Star3 =" + Star3[num]);
			num++;
		}

		int Number1 = SqliteActSelect.Star1[0] + SqliteActSelect.Star1[1] + SqliteActSelect.Star1[2] + 
		SqliteActSelect.Star2[0] + SqliteActSelect.Star2[1] + SqliteActSelect.Star2[2] + 
		SqliteActSelect.Star3[0] + SqliteActSelect.Star3[1] + SqliteActSelect.Star3[2];
	if(Number1 == 9){
			Number1++;
	}
		int Number2 = SqliteActSelect.Star1[3] + SqliteActSelect.Star1[4] + SqliteActSelect.Star1[5] + 
		SqliteActSelect.Star2[3] + SqliteActSelect.Star2[4] + SqliteActSelect.Star2[5] + 
		SqliteActSelect.Star3[3] + SqliteActSelect.Star3[4] + SqliteActSelect.Star3[5];
	if(Number2 == 9){
		Number2++;
	}
		int Number3 = SqliteActSelect.Star1[6] + SqliteActSelect.Star1[7] + SqliteActSelect.Star1[8] + 
		SqliteActSelect.Star2[6] + SqliteActSelect.Star2[7] + SqliteActSelect.Star2[9] + 
		SqliteActSelect.Star3[6] + SqliteActSelect.Star3[7] + SqliteActSelect.Star3[9];
	if(Number3 == 9){
		Number3++;
	}
		int Number4 = SqliteActSelect.Star1[9] + SqliteActSelect.Star1[10] + SqliteActSelect.Star1[11] + 
		SqliteActSelect.Star2[9] + SqliteActSelect.Star2[10] + SqliteActSelect.Star2[11] + 
		SqliteActSelect.Star3[9] + SqliteActSelect.Star3[10] + SqliteActSelect.Star3[11];
	if(Number4 == 9){
		Number4++;
	}
		GameObject obj1 = GameObject.Find ("LobbyMenu/P L A Y/SelectChapter_Window/Chapter1/CountNum");
		obj1.GetComponent<InstantGuiTextArea> ().text = Number1.ToString();
		GameObject obj2 = GameObject.Find ("LobbyMenu/P L A Y/SelectChapter_Window/Chapter2/CountNum");
		obj2.GetComponent<InstantGuiTextArea> ().text = Number2.ToString();
		GameObject obj3 = GameObject.Find ("LobbyMenu/P L A Y/SelectChapter_Window/Chapter3/CountNum");
		obj3.GetComponent<InstantGuiTextArea> ().text = Number3.ToString();
		GameObject obj4 = GameObject.Find ("LobbyMenu/P L A Y/SelectChapter_Window/Chapter4/CountNum");
		obj4.GetComponent<InstantGuiTextArea> ().text = Number4.ToString();
	//////////////////////////////////////
	//chapter1
	//stage1
		if(SqliteActSelect.Star1[0] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_1/Star1/TextArea_mainTexture");
			star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star2[0] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_1/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star3[0] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_1/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage2
		if(SqliteActSelect.Star1[1] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_2/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star2[1] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_2/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star3[1] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_2/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage3
		if(SqliteActSelect.Star1[2] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_3/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star2[2] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_3/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star3[2] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_3/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//chapter2
	//stage1
		if(SqliteActSelect.Star1[3] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_1/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star2[3] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_1/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star3[3] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_1/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage2
		if(SqliteActSelect.Star1[4] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_2/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star2[4] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_2/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star3[4] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_2/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage3
		if(SqliteActSelect.Star1[5] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_3/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star2[5] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_3/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star3[5] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_3/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//chapter3
	//stage1
		if(SqliteActSelect.Star1[6] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_1/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star2[6] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_1/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star3[6] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_1/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage2
		if(SqliteActSelect.Star1[7] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_2/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star2[7] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_2/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star3[7] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_2/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage3
		if(SqliteActSelect.Star1[8] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_3/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star2[8] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_3/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star3[8] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_3/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//chapter4
	//stage1
		if(SqliteActSelect.Star1[9] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_1/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star2[9] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_1/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star3[9] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_1/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage2
		if(SqliteActSelect.Star1[10] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_2/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star2[10] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_2/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star3[10] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_2/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage3
		if(SqliteActSelect.Star1[11] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_3/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star2[11] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_3/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
		if(SqliteActSelect.Star3[11] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_3/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}

	//////////////////////////////////////

		///////////////////////////////////////////////////////////////////[Data Read]

        ///////////////////////////////////////////////////////////////////[DB Connection Close]
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        ///////////////////////////////////////////////////////////////////[DB Connection Close]

    }


}