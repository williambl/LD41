using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] tetrominoes;
    public static GameManager manager;

    public GameObject deathCanvas;
    public UnityEngine.UI.Text scoreText;

    // Use this for initialization
    void Start () {
        manager = this;
        StartCoroutine(SpawnTetrominoes());
    }
	
    // Update is called once per frame
    void Update () {
    }

    public void Die () {
        StopAllCoroutines();
        PlayerController.playerController.isDead = true;
        deathCanvas.SetActive(true);
        scoreText.text = "You survived for " + Time.time + " seconds!";
    }

    public void Restart () {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    IEnumerator SpawnTetrominoes () {
        while (true){
            Instantiate(
                    tetrominoes[Random.Range(0, tetrominoes.Length)],
                    new Vector2(Random.Range(-6, 6), 17),
                    Quaternion.Euler(90, 0, 0));
            yield return new WaitForSeconds(5f);
        }
    }
}
