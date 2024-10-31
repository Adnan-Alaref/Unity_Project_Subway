using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameOver,gameStarted=false;
    public GameObject gamePanel,start_game_play,Go;
    public static string user_name;
    public InputField name=null;
    public Text result,Max_Score,Time_Taken_text;
    void Start()
    {   
        //Time.timeScale=0;
        gameOver=false;
        Time.timeScale=1;
    }
    bool e=true;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(name.text);
        
        if (gameOver)
        {
            gameStarted=false;
            if(e==true)
            {
                e=false;
                run_file();
            }
            result.text=controller_.score.ToString();
            Time.timeScale=0;
            gamePanel.SetActive(true);
        } 
    }
    public void verifying()
    {
        gameStarted=true;
        e=true;        
        user_name=name.text;
        start_game_play.SetActive(false);
        Time.timeScale=1;
        Go.SetActive(true);
    }
    void run_file()
    {
        string line;
        StreamReader sr = new StreamReader("C:\\file.txt");
        line = sr.ReadLine();
        List<string> lines = new List<string>();
        while (line != null)
        {
            lines.Add(line);
            line = sr.ReadLine();
        }
        //close the file
        sr.Close();/**/
        bool found=false;
        StreamWriter sw = new StreamWriter("C:\\file.txt");
        for(int i=0;i<lines.Count;i++){
            string[]str=lines[i].Split(' ');
            if(str[0].CompareTo(PlayerManager.user_name)==0)
            {
                int mx1=controller_.score;
                int mx2=Convert.ToInt32(str[1]);
                if(mx1<mx2)mx1=mx2;
                Max_Score.text=mx1.ToString();
                Time_Taken_text.text=(controller_.Time_taken/60).ToString("F2");
                sw.WriteLine(user_name+" "+mx1);
                found=true;
            }
            else sw.WriteLine(lines[i]);
        }
        if(found==false)
        {
            Max_Score.text=controller_.score.ToString();
            sw.WriteLine(user_name+" "+controller_.score);
            Time_Taken_text.text = (controller_.Time_taken / 60).ToString("F2");
        }
        sw.Close();
        
    }
}
