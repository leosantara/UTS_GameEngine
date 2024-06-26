using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    public int force;
    Rigidbody2D rigid;
    int scoreP1;
    int scoreP2;

    public TextMeshProUGUI scoreUIP1;
    public TextMeshProUGUI scoreUIP2;
    public TextMeshProUGUI scoreUIP3;
    public TextMeshProUGUI scoreUIP4;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);
        scoreP1 = 0;
        scoreP2 = 0;
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D (Collision2D coll){
        if (coll.gameObject.name == "TepiKanan")
        {
            scoreP1 += 1;
            TampilkanScore();
            ResetBall();
            Vector2 arah = new Vector2 (2, 0).normalized;
            rigid.AddForce (arah * force);
        }
        if (coll.gameObject.name == "TepiKiri")
        {
            scoreP2 += 1;
            TampilkanScore();
            ResetBall();
            Vector2 arah = new Vector2 (-2, 0).normalized;
            rigid.AddForce (arah * force);
        }
        if (coll.gameObject.name == "Pemukul1" || coll.gameObject.name == "Pemukul2")
        {
            float sudut = (transform.position.y - coll.transform.position.y)*5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah*force*2);
        }
    }

    void ResetBall (){
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }

    void TampilkanScore(){
        Debug.Log("Score P1: "+scoreP1+" Score P2: "+scoreP2);
        scoreUIP1.text = scoreP2+"";
        scoreUIP2.text = scoreP1+"";
        scoreUIP3.text = scoreP2 + "";
        scoreUIP4.text = scoreP1 + "";

        if (scoreP2 == 5)
        {
            SceneManager.LoadScene("RedWin");
            scoreP1 = 0;
            scoreP2 = 0;
        }
        if (scoreP1 == 5)
        {
            SceneManager.LoadScene("BiruWin");
            scoreP1 = 0;
            scoreP2 = 0;
        }
    }
}
