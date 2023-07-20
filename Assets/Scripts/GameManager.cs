using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameState currentGameState;

    [Space(5)]
    [Header("BALL")]
    [SerializeField] private Transform ballStartPosition;
    [SerializeField] private GameObject ball;
    [SerializeField] private float ballSpeed = 5f;

    [Space(10)]
    [SerializeField] private Transform bricks;
    [SerializeField] private ParticleSystem particleSystem;

    [HideInInspector] public int score;
    
    [HideInInspector] public int currentLive;
    private readonly int maxLive = 3;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(ResetBallPositionRoutine());
        currentLive = maxLive;
        currentGameState = GameState.Started;
    }

    private void Update()
    {
        HandleGameState();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UIManager.Instance.UpdateScoreText();
        CheckBricks();
    }

    public void DecreaseLive()
    {
        currentLive--;
        UIManager.Instance.UpdateLiveText();

        if (currentLive <= 0)
        {
            currentGameState = GameState.Lost;
        }

        StartCoroutine(ResetBallPositionRoutine());
    }

    /// <summary>
    /// Check 'bricks' gameobject to get the number of bricks that are alive.
    /// </summary>
    private void CheckBricks()
    {
        if (bricks.childCount == 0)
        {
            currentGameState = GameState.Won;
            UIManager.Instance.ActivateGameStateText("GAME WON");
            Time.timeScale = 0;
        }
    }

    private IEnumerator ResetBallPositionRoutine()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.transform.position = ballStartPosition.position;
        yield return new WaitForSeconds(1.5f);
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.up * ballSpeed;
    }

    public void PlayParticleSystem(Vector3 position)
    {
        particleSystem.transform.position = position;
        particleSystem.Play();
    }

    private void HandleGameState()
    {
        switch (currentGameState)
        {
            case GameState.Started:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    currentGameState = GameState.Paused;
                    UIManager.Instance.ActivateGameStateText("PAUSED");
                    Time.timeScale = 0;
                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
            
            case GameState.Paused:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Time.timeScale = 1;
                    currentGameState = GameState.Started;
                    UIManager.Instance.DeactivateGameStateText();
                }
                break;
            
            case GameState.Lost:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            
            case GameState.Won:
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
            
            default:
                break;
        }
    }
}

public enum GameState
{
    Started,
    Paused,
    Lost,
    Won
}
