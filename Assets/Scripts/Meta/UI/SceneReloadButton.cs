using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Meta.UI
{
    [RequireComponent(typeof(Button))]
    public class SceneReloadButton : MonoBehaviour
    {
        private void Awake()
        {
            Button button = GetComponent<Button>();
        
            button.onClick.AddListener(ReloadScene);
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
