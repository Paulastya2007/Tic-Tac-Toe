using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nxt : MonoBehaviour
{ public Button []button=new Button[3*3];
    public Text[] txt = new Text[10];
    private string[] giver = new string[10];
    private bool l=false,chance = false;  //false for human player and true for easy AI
    private sbyte y = 0;
    public Text winer;
    public GameObject boad,turncanger;
        void Start()
    {
        char m = 'a';
        for (int i = 1; i < giver.Length; i++)
        {
            giver[i] = giver[i] + m; m++;
        }

        boad.SetActive(false);turncanger.SetActive(chance);
    }
    public void restart() {
        SceneManager.LoadScene(1);
    }
        void Update()
    {
        if (giver[0].Equals(giver[3]) && giver[3].Equals(giver[6])) { enablerd(giver[0]); }
        else if (giver[4].Equals(giver[1]) && giver[4].Equals(giver[7])) { enablerd(giver[7]); }
        else if (giver[2].Equals(giver[5]) && giver[5].Equals(giver[8])) { enablerd(giver[8]); }
        else if (giver[0].Equals(giver[1]) && giver[1].Equals(giver[2])) { enablerd(giver[2]); }
        else if (giver[3].Equals(giver[4]) && giver[5].Equals(giver[4])) { enablerd(giver[4]); }
        else if (giver[8].Equals(giver[7]) && giver[7].Equals(giver[6])) { enablerd(giver[6]); }
        else if (giver[0].Equals(giver[4]) && giver[4].Equals(giver[4 * 2])) { enablerd(giver[4 * 2]); }
        else if (giver[2].Equals(giver[4]) && giver[2 * 2].Equals(giver[2 * 3])) { enablerd(giver[3 * 2]); }
        else if (y == 10)
        {
            enablerd(" Draw! ");
            l = true;
        }
       
        
    }static int chan() {
        return Random.Range(0, 9);
    }
    void LateUpdate() {txt[9].text = check(y);
        if (Time.timeScale != 0)
        {
            if (chance)
            {
                turncanger.SetActive(true);

                while (chance)
                {
                    int m = chan();//get random nmber only once
                    if (giver[m].Equals("X") || giver[m].Equals("O"))
                    {
                        continue;
                    }
                    else
                    {
                        if (m == 0) { r1c1b(); }
                        else if (m == 1) { r1c2b(); }
                        else if (m == 2) { r1c3b(); }
                        else if (m == 3) { r2c1b(); }
                        else if (m == 4) { r2c2b(); }
                        else if (m == 5) { r2c3b(); }
                        else if (m == 6) { r3c1b(); }
                        else if (m == 7) { r3c2b(); } else if (m == 8) { r3c3b(); }
                        chance = false; break;
                    }
                }

            }
            else { turncanger.SetActive(false); }
        }
    }
    public void r1c1b()
    {
        giver[0] = check(y);
        txt[0].text =giver[0];
        button[0].enabled = false; y++;changer();
    }
    private void changer() { if (chance) { chance = false; } else { chance = true; } }
    public void r1c2b()
    {
        giver[1] = check(y);
        txt[1].text = giver[1];
        button[1].enabled = false; y++; changer();
    }
    public void r1c3b()
    {
        giver[2] = check(y);
        txt[2].text = giver[2];
        button[2].enabled = false; changer();
        y++;
    }
    public void r2c1b()
    {

        giver[3] = check(y);
        txt[3].text = giver[3];
        button[3].enabled = false; changer();
        y++;
    }
    public void r2c2b()
    {

        giver[4] = check(y);
        txt[4].text = giver[4];
        button[4].enabled = false; y++; changer();
    }
    public void r2c3b()
    {
        giver[5] = check(y);
        txt[5].text = giver[5];
        button[5].enabled = false; y++; changer();
    }
    public void r3c1b()
    {

        giver[6] = check(y);
        txt[6].text = giver[6];
        button[6].enabled = false; y++; changer();

    }
    public void r3c2b()
    {

        giver[7] = check(y);
        txt[7].text = giver[7];
        button[7].enabled = false; y++; changer();
    }
    public void r3c3b()
    {
        button[8].enabled = false; giver[8] = check(y); changer();
        txt[8].text = giver[8]; y++;
    }
    private void enablerd(string i)
    {
        Time.timeScale = 0;
        boad.SetActive(true); if (l) { winer.text = i; }
        else { winer.text = i + " Wins!"; }
    
    }
    static string check(sbyte s)
    {
        if (0 == s % 2)
        {
            return "X";
        }
        else { return "O"; }
    }
}
