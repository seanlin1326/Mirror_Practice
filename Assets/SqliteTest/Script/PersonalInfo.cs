using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System;
using Unity.VisualScripting;
namespace SqliteTest.Database.Data
{
    public class PersonalInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Guid AccountGuid { get; set; }
        /// <summary>
        /// 性別 男性=1 女性=2
        /// </summary>
        public int GenderId {  get; set; } 

        public string PlayerName {  get; set; }

        public override string ToString()
        {
            return string.Format("[Person: Id={0}, AccountGuid={1},  GenderId={2}, PlayerName={3}]", Id, AccountGuid, GenderId, PlayerName);
        }
    }
}