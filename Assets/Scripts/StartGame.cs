using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] string _firstLevel;
    
    public void LoadLevel()
    {
        SceneManager.LoadScene(_firstLevel);
    }
}
