using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCdata data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話者名稱")]
    public Text textName;
    public bool playerInArea;
    [Header("對話間隔")]
    public float interval = 0.2f;

    ///private void start()
    ///{
    ///    StartCoroutine(Test());

    ///}

    ///private IEnumerator Test()
    ///{
    ///    print("hello");
    ///    yield return new WaitForSeconds(1.5f);
    ///    print("hellooooooooooooooo");

    ///}
    public enum NPCState
    {
        First, Missioning, Finish
    }
    public NPCState state = NPCState.First;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "SantaClaus")
        {
            playerInArea = true;
            StartCoroutine(Dialog()); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "SantaClaus")
        {
            playerInArea = false;
            StopDialog();
        }
    }
    /// <summary>
    /// 停止對話
    /// </summary>
     private void StopDialog()
    {
        { 
            dialog.SetActive(false);   ///關閉對話框
            StopAllCoroutines();       ///停止所有協成
        }
            }
    /// <summary>
    ///開始對話
    /// </summary>
  
    private IEnumerator Dialog()
    {
        /// print(data.dialougA);
        /// print(data.dialougA[0])

        ///for  (int  i  =  0;  i  < 10;   i++)
        //		{
        // print("迴圈:"+i);
        dialog.SetActive(true);
        textContent.text = "";
        textName.text = name;


        string dialogString = data.dialogB;

        switch (state)
        {
            case NPCState.First:
                dialogString = data.dialogA;
                break;
            case NPCState.Missioning:
                dialogString = data.dialogB;
                break;
            case NPCState.Finish:
                dialogString = data.dialogC;
                break;
           
        }

        for (int i = 0; i <data.dialogA.Length; i++)
        {
            textContent.text += data.dialogA[i] + "";
             ///   print(data.dialougA[i]);

            yield return new WaitForSeconds(interval);
            }
    }




}
