﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace KUTSearchEngine
{
    public partial class Form1 : Form
    {
        private List<string[]> fileContent = new List<string[]>();
        private string indexPath = "";
        private LuceneAdvancedSearchApplication myLuceneApp = new LuceneAdvancedSearchApplication();
        private DataTable dataTable = new DataTable();
        private PageDivded pageDivded = new PageDivded();
    
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
         
            
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BroweButton1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] file = directoryInfo.GetFiles();

            foreach (FileInfo info in file)
            {

                
                if (info.Extension.ToLower() == ".txt")
                {
                    string content = File.ReadAllText(info.FullName);
                    string[] delimter = { ".T", ".I", ".A", ".B", ".W" };
                    string[] contents = content.Split(delimter,StringSplitOptions.None);
                    string[] newList = new string[6];
                    Array.Copy(contents, 1, newList, 0, 5);
                    for (int i = 0; i < contents.Length-1; i++)
                    {
                       
                        contents[i] = contents[i].Replace("\n", "").Replace("\r", " ");
                        

                    }
                    newList[newList.Length-2] = newList[newList.Length-2].Replace(newList[1],"");
                    string[] splitAbstract = newList[newList.Length - 2].Split('.');
                    newList[newList.Length - 1] = splitAbstract[0] + ".";
                    fileContent.Add(newList);
                }
            }

            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void IndexBroweButton1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog();
            indexPath = folderBrowserDialog2.SelectedPath;
           
            myLuceneApp.CreateIndex(indexPath);
            int docID = 0;
            string reminder = "";
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            foreach (string[] s in fileContent)
            {

                reminder+="Adding doc " + docID + ". to Index\n";
                myLuceneApp.IndexText(s);
                docID++;
            }
            stopwatch.Stop();

            TimeSpan timeSpan = stopwatch.Elapsed;
            double time=timeSpan.Milliseconds;
            label2.Text = time+"ms";
            label3.Text="All documents added.";
            myLuceneApp.CleanUpIndexer();
        }



        private void InfoNeedInput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            resultDisplaylistBox.Items.Clear();
            
            string infoNeed = InfoNeedInput.Text;

            
            
            if (infoNeed=="")
            {
                MessageBox.Show("Invalid input!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                InfoNeedInput.Clear();
                return;
            }
            
            myLuceneApp.CreateSearcher();
         
            Lucene.Net.Search.Query query = myLuceneApp.InfoParser(infoNeed);
            queryDisplay.Text = query.ToString();
            Lucene.Net.Search.TopDocs result= myLuceneApp.SearchText(query);
            
            resultDisplaylistBox.Text += result.MaxScore;
            resultDisplaylistBox.Items.Add( "Number of results is " + result.TotalHits);
            int rank = 0;
            pageDivded.DtSource.Clear();
            //CreateDataTable();
            
            pageDivded.DtSource.Columns.Add("title");
            pageDivded.DtSource.Columns.Add("author");
            pageDivded.DtSource.Columns.Add("bibliographic");
            pageDivded.DtSource.Columns.Add("firstSentence");

            /*
            dataGridView1.Columns.Add("title","title");
            dataGridView1.Columns.Add("author", "author");
            dataGridView1.Columns.Add("bibliographic", "bibliographic");
            dataGridView1.Columns.Add("firstSentence", "first sentence");
            */
            foreach (Lucene.Net.Search.ScoreDoc scoreDoc in result.ScoreDocs)
            {
                rank++;
                Lucene.Net.Documents.Document doc =myLuceneApp.GetSearcher.Doc(scoreDoc.Doc);
                string title = doc.Get("title").ToString();
                string author = doc.Get("author").ToString();
                string bbibliographic = doc.Get("bibliographic").ToString();
                string textAbstract = doc.Get("firstSentence").ToString();
                resultDisplaylistBox.Items.Add(scoreDoc);
                string[] row = { title, author, bbibliographic, textAbstract };

                pageDivded.DtSource.Rows.Add(row);
                
                /*
                resultDisplaylistBox.Items.Add("title:" + title.Replace(".",""));

                resultDisplaylistBox.Items.Add("author: " + author.Substring(0,author.Length-1));
                resultDisplaylistBox.Items.Add("bbibliographic:" + bbibliographic.Substring(0,bbibliographic.Length-1));
                resultDisplaylistBox.Items.Add( textAbstract);
                resultDisplaylistBox.Items.Add("\n\n");
                //Lucene.Net.Search. Explanation explanation = myLuceneApp.Searcher.Explain(query, scoreDoc.Doc);
                //resultDisplay.Text+= explanation.ToString();
                //" text: " + myFieldValue +
                */
            }
            pageDivded.DividedPage();
            dataGridView1.data

            myLuceneApp.CleanUpSearcher();

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void resultDisplaylistBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingNavigatorSeparator_Click(object sender, EventArgs e)
        {

        }

        private void CreateDataTable()
        {
            dataTable.Columns.Add("title");
            dataTable.Columns.Add("author");
            dataTable.Columns.Add("bibliographic");
            dataTable.Columns.Add("firstSentence");
        }

        private void LoadPag()
        {

        }

        private void firstPage_Click(object sender, EventArgs e)
        {
            pageDivded.currentPage = 1;
            pageDivded.LoadPage();
        }

        private void nextPage_Click(object sender, EventArgs e)
        {
            pageDivded.currentPage++;
            pageDivded.LoadPage();
        }

        private void previousPage_Click(object sender, EventArgs e)
        {
            pageDivded.currentPage--;
            pageDivded.LoadPage();

        }

        private void lastPage_Click(object sender, EventArgs e)
        {
            pageDivded.currentPage = pageDivded.pageCount;
            pageDivded.LoadPage();
        }
    }

}
