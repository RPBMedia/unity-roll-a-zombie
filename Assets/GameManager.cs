using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private int selectedZombiePosition = 0;
    public GameObject selectedZombie;
    public List<GameObject> zombies;
    public Vector3 selecedSize;
    public Vector3 defaultSize;
    public Text scoreText;
    private int score = 0;

	// Use this for initialization
	void Start () {
        SelectZombie(selectedZombie);
        scoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown ("left")) {
            GetZombieLeft();
        }
        if (Input.GetKeyDown("right")) {
            GetZombieRight();
        }
        if (Input.GetKeyDown("up")) {
            PushZombieUp();
        }

    }

    void GetZombieLeft()
    {
        if (selectedZombiePosition == 0)
        {
            SelectZombie(zombies[3]);
            selectedZombiePosition = 3;
        }
        else
        {
            selectedZombiePosition--;
            SelectZombie(zombies[selectedZombiePosition]);
        }
    }

    void GetZombieRight()
    {
        if (selectedZombiePosition == 3)
        {
            SelectZombie(zombies[0]);
            selectedZombiePosition = 0;
        }
        else
        {
            selectedZombiePosition++;
            SelectZombie(zombies[selectedZombiePosition]);
        }
    }

    void SelectZombie(GameObject newZombie)
    {
        selectedZombie.transform.localScale = defaultSize;
        selectedZombie = newZombie;
        newZombie.transform.localScale = selecedSize;
    }

    void PushZombieUp()
    {
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, 10, ForceMode.Impulse);
    }

    public void AddScorePoint()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
