using TMPro;
using UnityEngine;

namespace UI.Window
{
    public class GameWindowView : AbstractWindowView
    {
        [SerializeField] public TextMeshProUGUI _scoreText;

        public void RefreshScore(int score)
        {
            _scoreText.SetText(score.ToString());
        }
    }
}