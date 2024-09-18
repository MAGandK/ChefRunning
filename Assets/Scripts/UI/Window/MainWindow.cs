using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainWindow : WindowBace
{
    [SerializeField]
    private Slider progressBar;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform levelEnd;
    [SerializeField]
    private float _offsetZ;
    [SerializeField]
    public TextMeshProUGUI _scoreText;
    [SerializeField]
    public GameObject _tabText;

    private int _coinCount = 0;
    private float startDistance;
    private float endDistance;
    private Vector3 _endPositionOffset;

    public override WindowType Type
    {
        get
        {
            return WindowType.MainWindow;
        }
    }

    private void OnEnable()
    {
        ObstacleInteraction.Interaction += ShowText;
        Joystick.Click += JoystickClick;
    }

    private void Update()
    {
        _endPositionOffset = new Vector3(0, 0, _offsetZ);
        endDistance = Vector3.Distance(player.position, levelEnd.position - _endPositionOffset);
        float progress = 1f - (endDistance / startDistance);
        progressBar.value = progress;
    }
    private void Start()
    {
        _tabText.SetActive(false);
        _endPositionOffset = new Vector3(0, 0, _offsetZ);
        startDistance = Vector3.Distance(player.position, levelEnd.position - _endPositionOffset);
        endDistance = 0f;
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

    private void JoystickClick()
    {
        if (_tabText.activeSelf)
        {
            _tabText.SetActive(false);
        }
    }
    private void OnDisable()
    {
        ObstacleInteraction.Interaction -= ShowText;
        Joystick.Click -= JoystickClick;
    }
}
