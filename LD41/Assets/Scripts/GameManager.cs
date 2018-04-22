using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] tetrominoes;
    public static GameManager manager;

    public GameObject deathCanvas;

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
        //TODO: Show score on death canvas
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
