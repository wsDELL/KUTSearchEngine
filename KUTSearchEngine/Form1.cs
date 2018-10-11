using System;
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
        internal List<string[]> fileContent = new List<string[]>();
        internal string indexPath = "";
        internal LuceneAdvancedSearchApplication myLuceneApp = new LuceneAdvancedSearchApplication();
        internal DataTable dataTable = new DataTable();
        internal PageDivded pageDivded = new PageDivded();
        internal int selectedItemIndex = 0;
        private string infoNeed="";
        

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
            
            pageDivded.ClearUpDataTable();
            pageDivded.DtSource.Columns.Clear();
            infoNeed = InfoNeedInput.Text;

            DialogResult result1 = MessageBox.Show("Invalid input!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if(result1==DialogResult.OK)
            {
                
                InfoNeedInput.Clear();
                return;
            }
            
            myLuceneApp.CreateSearcher();
         
            Lucene.Net.Search.Query query = myLuceneApp.InfoParser(infoNeed);
            string queryText = query.ToString();
            queryText = queryText.Replace("abstract:","");
            queryDisplay.Text = queryText;
            Lucene.Net.Search.TopDocs result = myLuceneApp.SearchText(query);
            

            int rank = 0;

            pageDivded.DtSource.Columns.Add("list");
            /*
                pageDivded.DtSource.Columns.Add("rank");
                pageDivded.DtSource.Columns.Add("title");
                pageDivded.DtSource.Columns.Add("author");
                pageDivded.DtSource.Columns.Add("bibliographic");
                pageDivded.DtSource.Columns.Add("firstSentence");
            */

            foreach (Lucene.Net.Search.ScoreDoc scoreDoc in result.ScoreDocs)
            {
                rank++;
                Lucene.Net.Documents.Document doc =myLuceneApp.GetSearcher.Doc(scoreDoc.Doc);
                string title = "Title: "+doc.Get("title").ToString();
                string author = "Author: "+ doc.Get("author").ToString();
                string bbibliographic = "Bibliographic: " + doc.Get("bibliographic").ToString();
                string textAbstract = doc.Get("firstSentence").ToString();

                string row = title +"\n"+ author+"\n" + bbibliographic+"\n" + textAbstract;
                //string[] row = { title, author, bbibliographic, textAbstract };
               
                pageDivded.DtSource.Rows.Add(row);
                /*
                pageDivded.DtSource.Rows.Add(author);
                pageDivded.DtSource.Rows.Add(bbibliographic);
                pageDivded.DtSource.Rows.Add(textAbstract);
                pageDivded.DtSource.Rows.Add(" ");
                */
            }
            if (pageDivded.DtSource.Rows.Count <= 0)
            {
                MessageBox.Show("No result", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pageDivded.DividedPage();
            dataGridView1.DataSource = pageDivded.LoadPage();
            
            dataGridView1.Show();
            myLuceneApp.CleanUpSearcher();

            DataGridViewLinkColumn column = new DataGridViewLinkColumn();
            column.Name= "Link"; 
            column.UseColumnTextForLinkValue = true;
            column.Text = "Read"; 
            column.LinkBehavior = LinkBehavior.HoverUnderline;
            column.TrackVisitedState = true; 
            dataGridView1.Columns.Add(column);

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            myLuceneApp.CreateSearcher();
            Lucene.Net.Search.Query query = myLuceneApp.InfoParser(infoNeed);
            Lucene.Net.Search.TopDocs result = myLuceneApp.SearchText(query);

            int index = pageDivded.currentPage-1;
            
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Link")
            {
                textBox1.Clear();
                selectedItemIndex = index * 10 + e.RowIndex;
                Lucene.Net.Documents.Document documents = myLuceneApp.GetSearcher.Doc(result.ScoreDocs[selectedItemIndex].Doc);
                string abstractText = documents.Get("abstract").ToString();
                textBox1.Text =abstractText;
                DataGridViewLinkCell cell = (DataGridViewLinkCell)dataGridView1[e.ColumnIndex, e.RowIndex];
                cell.LinkVisited = true;
            }
            myLuceneApp.CleanUpSearcher();

        }

        private void bindingNavigatorSeparator_Click(object sender, EventArgs e)
        {

        }

        private void firstPage_Click_1(object sender, EventArgs e)
        {
            pageDivded.currentPage = 1;
            dataGridView1.DataSource=pageDivded.LoadPage();
        }

        private void nextPage_Click_1(object sender, EventArgs e)
        {
            pageDivded.currentPage++;
            dataGridView1.DataSource= pageDivded.LoadPage();
        }

        private void previousPage_Click_1(object sender, EventArgs e)
        {
            pageDivded.currentPage--;
            dataGridView1.DataSource= pageDivded.LoadPage();
        }

        private void lastPage_Click_1(object sender, EventArgs e)
        {
            pageDivded.currentPage = pageDivded.pageCount;
            dataGridView1.DataSource= pageDivded.LoadPage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //StartForm startForm = new StartForm(this);
            //startForm.ShowDialog();
            //this.Hide();

            this.Enabled = false;
            StartForm f = new StartForm(this);
            f.Show();
            f.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);

        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            
            
        }
        

    }

}
