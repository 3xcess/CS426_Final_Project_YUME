using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;
    public TMP_Text timerText;
    public TMP_Text healthText;
    public GameObject gameOverPanel;

    private float timer = 60f;
    private int health = 100;
    private bool isInDream;
    private float healthDecreaseTimer = 1f;

    private void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start(){
        UpdateUI();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        isInDream = scene.name == "Dreams";
    }

    private void Update(){
        if (isInDream){
            timer -= Time.deltaTime;
            if (timer <= 0){
                GameOver();
            }
        }
        else{
            healthDecreaseTimer -= Time.deltaTime;
            if (healthDecreaseTimer <= 0f){
                health -= 1;
                healthDecreaseTimer = 1f;
            }

            if (health <= 0){
                GameOver();
            }
        }

        UpdateUI();
    }

    private void UpdateUI(){
        timerText.text = "Time: " + Mathf.Max(0, (int)timer);
        healthText.text = "Health: " + Mathf.Max(0, health);
    }

    private void GameOver(){
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddToTimer(){
        timer += 5f;
    }

    public void AddToHealth(){
        health += 10;
    }

    public int getHealth(){
        return health;
    }
}
