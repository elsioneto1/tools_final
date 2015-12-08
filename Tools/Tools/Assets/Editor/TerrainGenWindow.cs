using UnityEngine;
using UnityEditor;
using System.Collections;

public class TerrainGenWindow : EditorWindow {

    [MenuItem("Window/ Terrain Generator")]
    public static void ShowWindow()
    {
        GetWindow(typeof(TerrainGenWindow));
    }


    public int Seed;
    public Vector2 TerrainSize = new Vector2(500,500);
    public Terrain theTerrain;


    public float[] cornerheights = new float[4];
    public string[] cornerNames = { "TL", "TR", "BR", "BL"};
    private bool m_cornerVis;

    void OnGUI()
    {

        theTerrain = EditorGUILayout.ObjectField("Terrain", theTerrain, typeof(Terrain)) as Terrain;

        Seed = EditorGUILayout.IntField("Seed",Seed);
        TerrainSize = EditorGUILayout.Vector2Field("Terrain Size (Units)", TerrainSize);

        if (m_cornerVis)
        {
            m_cornerVis = EditorGUILayout.Foldout(m_cornerVis, "Corners");
            for (int i = 0; i < cornerheights.Length; i++)
            {
                cornerheights[i] = EditorGUILayout.FloatField(cornerNames[i], cornerheights[i]);
            }
        }
        else
        {
            string info = "";
            info += "Corners  ";// TL=" + cornerheights[0].ToString() + "/ TR=" + cornerheights[1].ToString() + "/ BR=" + cornerheights[2].ToString() + "/ BL=" + cornerheights[3].ToString();
            for (int i = 0; i < cornerheights.Length; i++)
            {
                info += " /";
                info += cornerNames[i];
                info += "=";
                info += cornerheights[i].ToString();

            }
            m_cornerVis = EditorGUILayout.Foldout(m_cornerVis, info);
        }

        if ( GUILayout.Button("Generate"))
        {
            Debug.Log("Generate a world!");


            if( theTerrain == null)
            {
                return;
            }
            TerrainData tdata = theTerrain.terrainData;
            float [,] heights = tdata.GetHeights(0,0,513,513);
            for (int y=0; y < 513; y++)
            {
                for (int x = 0; x < 513; x++)
                {
                    heights[y, x] = Random.Range(0.0f, 1.0f);
                }
            }

            tdata.SetHeights(0,0,heights);

        }

    }

}
