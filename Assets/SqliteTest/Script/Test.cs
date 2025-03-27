using SqliteTest.Database.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SqliteTest
{
    public class Test : MonoBehaviour
    {
        const string databaseName = "testDatabase.db";
        DataCommandService dataCommandService;
        [SerializeField] private int testGender;
        [SerializeField] private string testPlayerName;
        // Start is called before the first frame update
        void Start()
        {
            dataCommandService = new DataCommandService(databaseName);
            UpdatePersonalInfoByDefault();
        }
        [EditorButton]
        private void UpdatePersonalInfo()
        {
            dataCommandService.UpdatePersonalInto(testGender, testPlayerName);
        }
        private void UpdatePersonalInfoByDefault()
        {
            PersonalInfo defaultData = new PersonalInfo()
            {
                AccountGuid = Guid.NewGuid(),
                GenderId = 1,
                PlayerName = "¹w³]¦WºÙ"
            };
            dataCommandService.SetPersonalIntoIfNoData(defaultData);
        }

        
    }
}