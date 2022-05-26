using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nxt : MonoBehaviour
{ public Button []button=new Button[3*3];
    public Text[] txt = new Text[10];
    private string[] giver = new string[10];
    private bool chance = false;  //false for human player and true for easy AI
    private sbyte y = 0;
    public GameObject boad,turncanger;
    nxt() {
        char m = 'a';
        for (int i = 1; i < giver.Length; i++) {
            giver[i] = giver[i] + m;m++;
        }
    }
    void Start()
    {
      
        boad.SetActive(false);turncanger.SetActive(chance);
    }
    public void restart() {
        SceneManager.LoadSceneAsync(1);
    }
        void Update()
    {
        if (chance) { turncanger.SetActive(true); int change = Random.Range(0, 8); }
        else { turncanger.SetActive(false); }
        
    }
    void LateUpdate() {txt[9].text = check(y);}
    public void r1c1b()
    {
        giver[0] = check(y);
        txt[0].text =giver[0];
        button[0].enabled = false; y++;
    }
    public void r1c2b()
    {
        giver[1] = check(y);
        txt[1].text = giver[1];
        button[1].enabled = false; y++;
    }
    public void r1c3b()
    {
        giver[2] = check(y);
        txt[2].text = giver[2];
        button[2].enabled = false;
        y++;
    }
    public void r2c1b()
    {

        giver[3] = check(y);
        txt[3].text = giver[3];
        button[3].enabled = false;
        y++;
    }
    public void r2c2b()
    {

        giver[4] = check(y);
        txt[4].text = giver[4];
        button[4].enabled = false; y++;
    }
    public void r2c3b()
    {
        giver[5] = check(y);
        txt[5].text = giver[5];
        button[5].enabled = false; y++;
    }
    public void r3c1b()
    {

        giver[6] = check(y);
        txt[6].text = giver[6];
        button[6].enabled = false; y++;

    }
    public void r3c2b()
    {

        giver[7] = check(y);
        txt[7].text = giver[7];
        button[7].enabled = false; y++;
    }
    public void r3c3b()
    {
        button[8].enabled = false; giver[8] = check(y);
        txt[8].text = giver[8]; y++;
    }
    private void enablerd(string i)
    {/*
        h.SetActive(true); if (l) { winer.text = i; }
        else { winer.text = i + " Wins!"; }
    */}
    static string check(sbyte s)
    {
        if (0 == s % 2)
        {
            return "X";
        }
        else { return "O"; }
    }
}
