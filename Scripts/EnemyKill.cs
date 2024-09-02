using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyKill : MonoBehaviour
{
    Text killText;
    int kill;

    public int Kill
    {
        get
        {
            return this.kill;            
        }
        set
        {
            this.kill = value;
            UpdateKillText();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        killText = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void UpdateKillText()
    {
        string killed = string.Format("{0:000}",kill);
        killText.text = killed;
        
    }
}
