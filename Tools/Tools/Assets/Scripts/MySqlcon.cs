using UnityEngine;
using System.Collections;
using System.Text;
using MySql.Data.MySqlClient;
using System;


public class MySqlcon : MonoBehaviour {

    public string POST = "";
    public string HOST = "";
    public string userID = "root";
    public string password = "bitnami";
    public bool connect = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if ( connect )
        {
            connect = false;

            StringBuilder sb = new StringBuilder();
            sb.Append("Server=").Append(HOST).Append(";Uid=").Append(userID).Append(";Password=").Append(password);
            try
            {
                Debug.Log(sb);
                MySqlConnection conn = new MySqlConnection(sb.ToString());
                conn.Open();
                Debug.Log("Connected");
            }
            catch (Exception ex)
            {

                Debug.Log(ex.Message);
            }
        }

	}
}
