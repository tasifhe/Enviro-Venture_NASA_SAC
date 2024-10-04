using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
  public TMP_InputField nameInput;

  public void LoadScene()
  {
    SceneManager.LoadScene("Main");
  }
}
