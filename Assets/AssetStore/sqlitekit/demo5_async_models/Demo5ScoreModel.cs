using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// this model reflect table "scores" from demo5.db
//
// CREATE TABLE scores(
//  id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
//  name VARCHAR(256),
//  level VARCHAR(256),
//  score FLOAT
// );"


public class Demo5ScoreModel
{
    public int id;
    public string name;
    public string level;
    public float score;
}
