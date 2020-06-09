using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

namespace CSVFileHandler
{
    public class CSVFileHandler : MonoBehaviour
    {

        TextAsset wordDatabase;
        private UITextTypeWriter typeWriter;

        [HideInInspector]
        public List<string> verbCap, adjective, verb, verb2, orientation, direction, moonPhase, technology, bucketlistProphecy, bucketlistFront1, bucketlistMid1, attempt, outcome, time, storage, pause, planet;

        private void Start()
        {
            typeWriter = (UITextTypeWriter)FindObjectOfType<UITextTypeWriter>();
            ReadData();
            typeWriter.ChangeText(BuildSentence(), typeWriter.delayToStart);
        }
        private void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                typeWriter.ChangeText(BuildSentence(), typeWriter.delayToStart);
            }
        }

        public void WhenYouClick()
        {
            typeWriter.ChangeText(BuildSentence(), typeWriter.delayToStart);
        }
        
        public void ReadData()
        {
            //load file in memory
            TextAsset wordDatabase = Resources.Load<TextAsset>("wordDatabase");

            string[] data = wordDatabase.text.Split(new char[] { '\n' });

            // go through all the lines but not the last empty one
            for (int i = 1; i < data.Length - 1; i++)
            {
                string[] row = data[i].Split(new char[] { ',' });

                if (row[0] != null)
                {
                    if (row[0] != "") verbCap.Add(row[0]); 
                    if (row[1] != "") adjective.Add(row[1]); 
                    if (row[2] != "") verb.Add(row[2]);
                    if (row[3] != "") verb2.Add(row[3]);
                    if (row[4] != "") orientation.Add(row[4]);
                    if (row[5] != "") direction.Add(row[5]);
                    if (row[6] != "") moonPhase.Add(row[6]);
                    if (row[7] != "") technology.Add(row[7]);
                    if (row[8] != "") bucketlistProphecy.Add(row[8]);
                    if (row[9] != "") bucketlistFront1.Add(row[9]);
                    if (row[10] != "") bucketlistMid1.Add(row[10]);
                    if (row[11] != "") attempt.Add(row[11]);
                    if (row[12] != "") outcome.Add(row[12]);
                    if (row[13] != "") time.Add(row[13]);
                    if (row[14] != "") storage.Add(row[14]);
                    if (row[15] != "") pause.Add(row[16]);
                    if (row[16] != "") planet.Add(row[16]);
                }
            }
            //DEBUG
            /*
            foreach(var verbCap in verbCap)
            {
                Debug.Log(verbCap);
            }
            */
        }

        public string BuildSentence()
        {

            #region// RANDOM NUMBER GENERATION
            int num1 = UnityEngine.Random.Range(2, 10);
            int num2 = UnityEngine.Random.Range(1000, 10000);
            int num3 = UnityEngine.Random.Range(5000, 50000);
            int num4 = UnityEngine.Random.Range(3000, 10000);
            int numDegree = UnityEngine.Random.Range(0, 360);
            int num5 = UnityEngine.Random.Range(2, 20);
            #endregion

            /*
             * TO ADD NEW VERSIONS OF PART 1, 2 or 3 you just have to write. part1.Add(); and write a string inside the brackets
             * Then to use it, you need to do: part1[ID] wher ID is an int of your choosing from 0 to the max number of items in your list
            */

            #region// PART 1
            List<string> part1 = new List<string>();
            part1.Add(          verbCap[UnityEngine.Random.Range(0, verbCap.Count)] + "ing ID #" + num2 + "..."              );
            part1.Add(          "TEST" + verbCap[UnityEngine.Random.Range(0, verbCap.Count)] + "ing ID #" + num2 + "..."     );
            #endregion

            #region// PART 2
            List<string> part2 = new List<string>();
            part2.Add(          num4 + storage[UnityEngine.Random.Range(0, storage.Count)] + " " + 
                                verb[UnityEngine.Random.Range(0, verb2.Count)] + "ed. " + num3 + " " +
                                outcome[UnityEngine.Random.Range(0, outcome.Count)] + " " +
                                verb2[UnityEngine.Random.Range(0, verb.Count)] + "ed \n" + "\n" + ""
                     );
            part2.Add(          "TEST" + num4 + storage[UnityEngine.Random.Range(0, storage.Count)] + " " +
                                verb[UnityEngine.Random.Range(0, verb2.Count)] + "ed. " + num3 + " " +
                                outcome[UnityEngine.Random.Range(0, outcome.Count)] + " " +
                                verb2[UnityEngine.Random.Range(0, verb.Count)] + "ed \n" + "\n" + ""
                     );
            part2.Add(          "TEST132" + num4 + storage[UnityEngine.Random.Range(0, storage.Count)] + " " +
                                verb[UnityEngine.Random.Range(0, verb2.Count)] + "ed. " + num3 + " " +
                                outcome[UnityEngine.Random.Range(0, outcome.Count)] + " " +
                                verb2[UnityEngine.Random.Range(0, verb.Count)] + "ed \n" + "\n" + ""
                     );
            part2.Add("NEW TEST 1");
            part2.Add("NEW TEST 2");
            part2.Add("NEW TEST 3");
            part2.Add("NEW TEST 4");
            #endregion

            #region// PART3
            List<string> part3 = new List<string>();
            part3.Add(          "A " + adjective[UnityEngine.Random.Range(0, adjective.Count)] + " " + 
                                technology[UnityEngine.Random.Range(0, technology.Count)] + " is " +
                                verb[UnityEngine.Random.Range(0, verb2.Count)] + "ing " +
                                "under " /*change by rdm preposition list*/+ " the " +
                                direction[UnityEngine.Random.Range(0, direction.Count)] + "ern " +
                                planet[UnityEngine.Random.Range(0, planet.Count)] + "."
                       );
            #endregion

            #region//unused wordtypes
            /*
            adjective[UnityEngine.Random.Range(0, adjective.Count)] + " " +
            verb2[UnityEngine.Random.Range(0, verb2.Count)] + " " +
            orientation[UnityEngine.Random.Range(0, orientation.Count)] + " " +
            moonPhase[UnityEngine.Random.Range(0, moonPhase.Count)] + " " +
            bucketlistProphecy[UnityEngine.Random.Range(0, bucketlistProphecy.Count)] + " " +
            bucketlistFront1[UnityEngine.Random.Range(0, bucketlistFront1.Count)] + " " +
            bucketlistMid1[UnityEngine.Random.Range(0, bucketlistMid1.Count)] + " " +
            attempt[UnityEngine.Random.Range(0, attempt.Count)] + " " +
            time[UnityEngine.Random.Range(0, time.Count)] + " " +
            pause[UnityEngine.Random.Range(0, pause.Count)] + " " +
            planet[UnityEngine.Random.Range(0, planet.Count)] + ".";
            */
            #endregion

            string mySentence = part1[UnityEngine.Random.Range(0, part1.Count)] + "\n" + "\n" +
                                part2[UnityEngine.Random.Range(0, part2.Count)] + "\n" + "\n" +
                                part3[UnityEngine.Random.Range(0, part3.Count)];
            return mySentence;
        }
    }
}