using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainWindow : WindowBase
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private Transform levelEnd;
    [SerializeField] private float _offsetZ;
    [SerializeField] public TextMeshProUGUI _scoreText;
    [SerializeField] public GameObject _tabText;
    [SerializeField] public GameObject _hammerText;

    private int _coinCount = 0;
    private float startDistance;
    private float endDistance;
    private Vector3 _endPositionOffset;
    private Player _player;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }

    public override WindowType Type
    {
        get { return WindowType.MainWindow; }
    }

    private void OnEnable()
    {
        ObstacleInteraction.Interaction += ShowText;
        ObstacleInteraction.InteractionWithHammer += ShowTextHammer;
        Player.IsPlayerHit += HideText;
        ObstacleInteraction.ExitInteractionWithHammer += HideText;
        ObstacleInteraction.ExitInteraction += HideText;
    }

    private void Start()
    {
        _tabText.SetActive(false);
        _hammerText.SetActive(false);
        _endPositionOffset = new Vector3(0, 0, _offsetZ);

        if (_player != null)
        {
            startDistance = Vector3.Distance(_player.transform.position, levelEnd.position - _endPositionOffset);
        }
        else
        {
            return;
        }

        endDistance = 0f;
    }

    private void Update()
    {
        _endPositionOffset = new Vector3(0, 0, _offsetZ);
        endDistance = Vector3.Distance(_player.transform.position, levelEnd.position - _endPositionOffset);
        float progress = 1f - (endDistance / startDistance);
        progressBar.value = progress;
    }

    public void OnCoinCollected()
    {
        _coinCount++;
        _scoreText.text = _coinCount.ToString();
    }

    private void ShowText()
    {
        _tabText.SetActive(true);
    }

    private void ShowTextHammer()
    {
        _hammerText.SetActive(true);
    }

    private void HideText()
    {
        _tabText.SetActive(false);
        _hammerText.SetActive(false);
    }

    private void OnDisable()
    {
        ObstacleInteraction.Interaction -= ShowText;
        ObstacleInteraction.InteractionWithHammer -= ShowTextHammer;
        Player.IsPlayerHit -= HideText;
        ObstacleInteraction.ExitInteractionWithHammer -= HideText;
        ObstacleInteraction.ExitInteraction -= HideText;
    }
}