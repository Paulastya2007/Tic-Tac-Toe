using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class main : MonoBehaviour
{
    sbyte y = 1;
    public Button r1c1,r1c2,r1c3,r2c1,r2c2,r2c3,r3c1,r3c2,r3c3;
    public Text r1c1T, turner, r1c2T, r1c3T, r2c1T, r2c2T, r2c3T, r3c1T, r3c2T, r3c3T,winer;
    private string[] car=new string[9];
    private bool l = false;
    public GameObject h;
    main()
    {  char p = 'A';
        for (int i = 0; i < car.Length; i++) {
          car[i]=p+car[i];
            ++p;
        }
       
    }
    void Start() {
        h.SetActive(false);
    }
public void Restart(){
        SceneManager.LoadScene("SampleScene");
}
    void LateUpdate()
    {
        if (y % 2 == 0) { turner.text = check(y); } else { turner.text = check(y); }
    }
    void Update() {
       
            if (car[0].Equals(car[3]) && car[3].Equals(car[6]))      { enablerd(car[0]); }
            else if (car[4].Equals(car[1]) && car[4].Equals(car[7])) { enablerd(car[7]); }
            else if (car[2].Equals(car[5]) && car[5].Equals(car[8])) { enablerd(car[8]); }
            else if (car[0].Equals(car[1]) && car[1].Equals(car[2])) { enablerd(car[2]); }
            else if (car[3].Equals(car[4]) && car[5].Equals(car[4])) { enablerd(car[4]); }
            else if (car[8].Equals(car[7]) && car[7].Equals(car[6])) { enablerd(car[6]); }
            else if (car[0].Equals(car[4]) && car[4].Equals(car[4*2])) { enablerd(car[4*2]); }
            else if (car[2].Equals(car[4]) && car[2*2].Equals(car[2*3])) { enablerd(car[3*2]); }
            else if(y==10){
            enablerd(" Draw! "); 
            l = true; }
    }
    static string check(sbyte s) {
         if (0 ==s % 2)
        {
            return "X";
        }
        else { return "O"; }}
    public void r1c1b() {
        
        car[0] = check(y); 
        r1c1T.text = car[0]; 
        r1c1.enabled = false; y++;
    }
    public void r1c2b()
    {
        
        car[1] = check(y); r1c2T.text = car[1];
        r1c2.enabled = false; y++;
    }
    public void r1c3b()
    {
        car[2] = check(y);
        r1c3T.text =car[2];
        r1c3.enabled = false;
        y++;
    }
    public void r2c1b()
    {
       
        car[3] = check(y);
        r2c1T.text = car[3];
        r2c1.enabled = false;
        y++;
    }
    public void r2c2b()
    {
       
        car[4] = check(y);
        r2c2T.text = car[4];
        r2c2.enabled = false; y++;
    }
    public void r2c3b()
    {car[5]=check(y); 
        r2c3T.text = car[5];
        r2c3.enabled = false; y++;
    }
    public void r3c1b()
    {
       
        car[6] = check(y);
        r3c1T.text = car[6];
        r3c1.enabled = false; y++;

    }
    public void r3c2b()
    {
       
        car[7] = check(y);
         r3c2T.text = car[7];
        r3c2.enabled = false; y++;
    }
    public void r3c3b()
    {
        r3c3.enabled = false;car[8]=check(y);
        r3c3T.text = car[8]; y++;
    }
    private void enablerd(string i) {
        h.SetActive(true); if (l) { winer.text = i; }
        else { winer.text = i + " Wins!"; }
    }
}