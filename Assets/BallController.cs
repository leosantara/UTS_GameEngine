using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force;
    int scoreMerah;
    int scorePutih;
    Text scoreUIMerah;
    Text scoreUIPutih;
    Text scoreUIMerah2;
    Text scoreUIPutih2;
    GameObject panelSelesai;
    Text Winner;

    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        scoreMerah = 0;
        scorePutih = 0;
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0,2).normalized;
        rigid.AddForce(arah*force);
        scoreUIMerah = GameObject.Find("SkoreMerah").GetComponent<Text>();
        scoreUIPutih = GameObject.Find("SkorePutih").GetComponent<Text>();
        scoreUIMerah2 = GameObject.Find("SkoreMerah2").GetComponent<Text>();
        scoreUIPutih2 = GameObject.Find("SkorePutih2").GetComponent<Text>();
        panelSelesai = GameObject.Find("Selesai");
        panelSelesai.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void TampilkanScore(){
        Debug.Log("Score Merah: "+ scoreMerah + " Score Putih: "+ scorePutih);
        scoreUIMerah.text= scoreMerah + "";
        scoreUIPutih.text= scorePutih + "";
        scoreUIMerah2.text= scoreMerah + "";
        scoreUIPutih2.text= scorePutih + "";
    }

    void OnCollisionEnter2D (Collision2D coll){
        if(coll.gameObject.name == "GoalAtas"){
            scorePutih += 1;
            TampilkanScore();
            if (scorePutih == 5)
            {
                panelSelesai.SetActive(true);
                Winner = GameObject.Find("Info").GetComponent<Text>();
                Winner.text = "Player Merah Menang";
                Destroy (gameObject);
                return;
            }
            ResetBola();    
            Vector2 arah = new Vector2(0,2).normalized;
            rigid.AddForce(arah * force);        
        }        
        if(coll.gameObject.name == "GoalBawah"){
            scoreMerah += 1;
            TampilkanScore();
            if (scoreMerah == 5)
            {
                panelSelesai.SetActive(true);
                Winner = GameObject.Find("Info").GetComponent<Text>();
                Winner.text = "Player Putih Menang";
                Destroy (gameObject);
                return;
            }
            ResetBola();
            Vector2 arah = new Vector2(0,-2).normalized;
            rigid.AddForce(arah * force);
            
        }
        if (coll.gameObject.name == "Pemukul1" || coll.gameObject.name == "Pemukul2")
        {
            float sudut = (transform.position.x - coll.transform.position.x) *5f;
            Vector2 arah = new Vector2(sudut, rigid.velocity.y).normalized;
            rigid.velocity = new Vector2(0,0);
            rigid.AddForce(arah*force*2);
        }
    }

    void ResetBola(){
        transform.localPosition = new Vector2(0,0);
        rigid.velocity = new Vector2(0,0);
    }
}
