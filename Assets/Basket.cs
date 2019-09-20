using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
        //find a ref. to the ScoreCounter GO
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;
        // the camera's z position set how far to push the mouse in 3d
        mousePos2D.z = -Camera.main.transform.position.z;
        //convert the point from 2d screen space into 3d game world space
        Vector3 mousePos3d = Camera.main.ScreenToWorldPoint(mousePos2D);
        //move the x position of this basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3d.x;
        this.transform.position = pos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //find out what hit this basket
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
        }
        //parse the test of the scoreGT into an int
        int score = int.Parse(scoreGT.text);
        //add points 
        score += 100;
        scoreGT.text = score.ToString();
        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
