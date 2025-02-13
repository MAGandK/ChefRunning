using TMPro;
using UnityEngine;

namespace UI.Window.MainWindow
{
    public class MainWindowView : AbstractWindowView
    {
        [SerializeField] public TextMeshProUGUI _scoreText;
        
        public void RefreshScore(int score)
        {
            _scoreText.SetText(score.ToString());
        }
    }
}