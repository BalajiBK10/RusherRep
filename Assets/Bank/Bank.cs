using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
   [SerializeField] int startingBalance= 150;
   [SerializeField] int currentBalance;
   [SerializeField] TextMeshProUGUI displayBalance;
   public int CurrentBalance {get{return currentBalance;}}
   
    void Awake() 
   {
     currentBalance = startingBalance;
     UpadateDisplay();
   }
   
   public void Deposit(int amount)
   {
     currentBalance += Mathf.Abs(amount);
     UpadateDisplay();
   }
    public void WithDraw(int amount)
   {
     currentBalance -= Mathf.Abs(amount);
     UpadateDisplay();
     if(currentBalance < 0)
     {
       ReLoadScene();
     }
   }
   void UpadateDisplay()
   {
     displayBalance.text = "gold: " + currentBalance;
   }
   void ReLoadScene()
   {
      Scene currentScene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(currentScene.buildIndex);
   }
}
