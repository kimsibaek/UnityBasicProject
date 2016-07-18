using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SqliteEX : MonoBehaviour {


	public static int[] Stage;
	public static int[] Star1;
	public static int[] Star2;
	public static int[] Star3;

    void Start()
    {
		Stage = new int[12];
		Star1 = new int[12];
		Star2 = new int[12];
		Star3 = new int[12];

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
			Stage[num] = reader.GetInt32(0);
			Star1[num] = reader.GetInt32(1);
			Star2[num] = reader.GetInt32(2);
			Star3[num] = reader.GetInt32(3);

			//Debug.Log("stageNum= " + Stage[num] + "  Star1 =" + Star1[num] + "  Star2 =" + Star2[num] + "  Star3 =" + Star3[num]);
			num++;
		}

		int Number1 = Star1[0] + Star1[1] + Star1[2] + Star2[0] + Star2[1] + Star2[2] + Star3[0] + Star3[1] + Star3[2];
	if(Number1 == 9){
			Number1++;
	}
		int Number2 = Star1[3] + Star1[4] + Star1[5] + Star2[3] + Star2[4] + Star2[5] + Star3[3] + Star3[4] + Star3[5];
	if(Number2 == 9){
		Number2++;
	}
		int Number3 = Star1[6] + Star1[7] + Star1[8] + Star2[6] + Star2[7] + Star2[9] + Star3[6] + Star3[7] + Star3[9];
	if(Number3 == 9){
		Number3++;
	}
		int Number4 = Star1[9] + Star1[10] + Star1[11] + Star2[9] + Star2[10] + Star2[11] + Star3[9] + Star3[10] + Star3[11];
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
	if(Star1[0] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_1/Star1/TextArea_mainTexture");
			star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star2[0] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_1/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star3[0] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_1/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage2
	if(Star1[1] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_2/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star2[1] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_2/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star3[1] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_2/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage3
	if(Star1[2] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_3/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star2[2] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_3/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star3[2] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter1_Window/Stage_3/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//chapter2
	//stage1
	if(Star1[3] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_1/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star2[3] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_1/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star3[3] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_1/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage2
	if(Star1[4] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_2/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star2[4] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_2/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star3[4] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_2/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage3
	if(Star1[5] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_3/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star2[5] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_3/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star3[5] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter2_Window/Stage_3/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//chapter3
	//stage1
	if(Star1[6] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_1/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star2[6] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_1/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star3[6] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_1/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage2
	if(Star1[7] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_2/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star2[7] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_2/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star3[7] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_2/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage3
	if(Star1[8] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_3/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star2[8] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_3/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star3[8] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter3_Window/Stage_3/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//chapter4
	//stage1
	if(Star1[9] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_1/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star2[9] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_1/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star3[9] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_1/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage2
	if(Star1[10] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_2/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star2[10] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_2/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star3[10] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_2/Star3/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	//stage3
	if(Star1[11] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_3/Star1/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star2[11] == 1){
		GameObject star1 = GameObject.Find ("LobbyMenu/P L A Y/Chapter4_Window/Stage_3/Star2/TextArea_mainTexture");
		star1.GetComponent<GUITexture> ().color = new Color (255, 255, 255);
	}
	if(Star3[11] == 1){
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