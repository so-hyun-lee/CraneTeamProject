//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Firebase.Auth;
//using TMPro;
//using UnityEngine.SceneManagement;
//using System;

//public class FirebaseLogin : MonoBehaviour
//{
//    private FirebaseAuth auth;

//    public TMP_InputField email;
//    public TMP_InputField password;


//    // Start is called before the first frame update
//    void Start()
//    {
//        auth = FirebaseAuth.DefaultInstance;
//    }

//    public void Create()
//    {
//        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task =>
//        {
//            if (task.IsFaulted)
//            {
//                Debug.Log("���� ���� ����");
//                return;
//            }
//            if (task.IsCanceled)
//            {
//                Debug.Log("���� ���� ��ҵ�");
//                return;
//            }

//            FirebaseUser newUser = task.Result.User;
//            Debug.Log("���� ���� ����");
//        });

//    }
//    public async void Login()
//    {
//        try
//        {
//            await auth.SignInWithEmailAndPasswordAsync(email.text, password.text);
//            Debug.Log("�α��� ����");
//            SceneManager.LoadScene("SampleScene");
//        }
//        catch (Exception ex)
//        {
//            Debug.Log("�α��� ����: " + ex.Message);
//        }
//    }
//    //public void Login()
//    //{
//    //    auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task =>
//    //    {
//    //        if (task.IsFaulted)
//    //        {
//    //            Debug.Log("�α��� ����");
//    //            return;
//    //        }
//    //        if (task.IsCanceled)
//    //        {
//    //            Debug.Log("�α��� ��ҵ�");
//    //            return;
//    //        }
//    //        else
//    //        {
//    //            Debug.Log("�α��� ����");
//    //            SceneManager.LoadScene("SampleScene");
//    //        }

//    //    });
//    //}

//    //public void Logout()
//    //{
//    //    auth.SignOut();
//    //    Debug.Log("�α׾ƿ�");
//    //}

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
