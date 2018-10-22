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
        internal string path = "";
        internal LuceneAdvancedSearchApplication myLuceneApp = new LuceneAdvancedSearchApplication();
        internal DataTable dataTable = new DataTable();
        internal PageDivded pageDivded = new PageDivded();
        internal int selectedItemIndex = 0;
        private string infoNeed = "";
        


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

     

        public void SourceCollectionPath(string collectionPath)
        {
            //folderBrowserDialog1.ShowDialog();
            //folderBrowserDialog1.SelectedPath;
            path = collectionPath;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] file = directoryInfo.GetFiles();

            foreach (FileInfo info in file)
            {


                if (info.Extension.ToLower() == ".txt")
                {
                    string content = File.ReadAllText(info.FullName);
                    string[] delimter = { ".T", ".I", ".A", ".B", ".W" };
                    string[] contents = content.Split(delimter, StringSplitOptions.None);
                    string[] newList = new string[6];
                    Array.Copy(contents, 1, newList, 0, 5);
                    for (int i = 0; i < contents.Length - 1; i++)
                    {

                        contents[i] = contents[i].Replace("\n", "").Replace("\r", " ");


                    }
                    newList[newList.Length - 2] = newList[newList.Length - 2].Replace(newList[1], "");
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

        public void IndexBrowse(string selectedIndexPath)
        {
            //folderBrowserDialog2.ShowDialog();
            indexPath = selectedIndexPath;//folderBrowserDialog2.SelectedPath;

            myLuceneApp.CreateIndex(indexPath);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            foreach (var s in fileContent)
            {


                myLuceneApp.IndexText(s);

            }
            stopwatch.Stop();

            TimeSpan timeSpan = stopwatch.Elapsed;
            double time = timeSpan.Milliseconds;
            label2.Text = time + "ms";
            label3.Text = "All documents added.";
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
            dataGridView1.Columns.Clear();
            infoNeed = InfoNeedInput.Text;

            if (infoNeed == "")
            {
                MessageBox.Show("Invalid input!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InfoNeedInput.Clear();
                return;
            }

            myLuceneApp.CreateSearcher();
            if (checkBox1.Checked)
            {
                infoNeed = infoNeed.Replace("\"", "");
                infoNeed = "\"" + infoNeed + "\"";
            }
            Lucene.Net.Search.Query query = myLuceneApp.InfoParser(infoNeed);
            string queryText = query.ToString();
            queryText = queryText.Replace("abstract:", "");
            textBox2.Text =infoNeed+ queryText;
            Lucene.Net.Search.TopDocs result = myLuceneApp.SearchText(query);


            int rank = 0;

            pageDivded.DtSource.Columns.Add("list");

            foreach (Lucene.Net.Search.ScoreDoc scoreDoc in result.ScoreDocs)
            {
                rank++;
                Lucene.Net.Documents.Document doc = myLuceneApp.GetSearcher.Doc(scoreDoc.Doc);
                string title = "Title: " + doc.Get("title").ToString();
                string author = "Author: " + doc.Get("author").ToString();
                string bbibliographic = "Bibliographic: " + doc.Get("bibliographic").ToString();
                string textAbstract = doc.Get("firstSentence").ToString();

                string row = title + "\r\n" + author + "\r\n" + bbibliographic + "\r\n" + textAbstract;

                pageDivded.DtSource.Rows.Add(row);
            }
            if (pageDivded.DtSource.Rows.Count <= 0)
            {
                MessageBox.Show("No result", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pageDivded.DividedPage();
            dataGridView1.DataSource = pageDivded.LoadPage();
            dataGridView1.Columns["list"].FillWeight = 240;
            dataGridView1.Show();
            label6.Text = pageDivded.IntotalPage();
            myLuceneApp.CleanUpSearcher();
            /*
            DataGridViewLinkColumn column = new DataGridViewLinkColumn();
            column.Name = "Link";
            column.UseColumnTextForLinkValue = true;
            column.Text = "Read";
            column.LinkBehavior = LinkBehavior.HoverUnderline;
            column.TrackVisitedState = true;
            dataGridView1.Columns.Add(column);
            */
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

            int index = pageDivded.currentPage - 1;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "list")
            {
                
                selectedItemIndex = index * 10 + e.RowIndex;
                Lucene.Net.Documents.Document documents = myLuceneApp.GetSearcher.Doc(result.ScoreDocs[selectedItemIndex].Doc);
                string abstractText = documents.Get("abstract").ToString();
                GlobalData.abstractContent = abstractText;
                //DataGridViewLinkCell cell = (DataGridViewLinkCell)dataGridView1[e.ColumnIndex, e.RowIndex];
                //cell.LinkVisited = true;
            }
            myLuceneApp.CleanUpSearcher();

            AbstractView abstractView = new AbstractView();
            abstractView.ShowDialog();

        }

        private void bindingNavigatorSeparator_Click(object sender, EventArgs e)
        {

        }

        private void firstPage_Click_1(object sender, EventArgs e)
        {
            pageDivded.currentPage = 1;
            dataGridView1.DataSource = pageDivded.LoadPage();
            label6.Text = pageDivded.PageNumber();
        }

        private void nextPage_Click_1(object sender, EventArgs e)
        {
            pageDivded.currentPage++;
            dataGridView1.DataSource = pageDivded.LoadPage();
            label6.Text = pageDivded.PageNumber();
        }

        private void previousPage_Click_1(object sender, EventArgs e)
        {
            pageDivded.currentPage--;
            dataGridView1.DataSource = pageDivded.LoadPage();
            label6.Text = pageDivded.PageNumber();
        }

        private void lastPage_Click_1(object sender, EventArgs e)
        {
            pageDivded.currentPage = pageDivded.pageCount;
            dataGridView1.DataSource = pageDivded.LoadPage();
            label6.Text = pageDivded.PageNumber();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            indexPath = @"C:\Users\25091\Documents\647\project\test10";
            path = @"C:\Users\25091\Documents\647\project\crandocs";




            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] file = directoryInfo.GetFiles();

            foreach (FileInfo info in file)
            {


                if (info.Extension.ToLower() == ".txt")
                {
                    string content = File.ReadAllText(info.FullName);
                    string[] delimter = { ".T", ".I", ".A", ".B", ".W" };
                    string[] contents = content.Split(delimter, StringSplitOptions.None);
                    string[] newList = new string[6];
                    Array.Copy(contents, 1, newList, 0, 5);
                    for (int i = 0; i < contents.Length - 1; i++)
                    {

                        contents[i] = contents[i].Replace("\n", "").Replace("\r", " ");


                    }
                    newList[newList.Length - 2] = newList[newList.Length - 2].Replace(newList[1], "");
                    string[] splitAbstract = newList[newList.Length - 2].Split('.');
                    newList[newList.Length - 1] = splitAbstract[0] + ".";
                    fileContent.Add(newList);
                }
            }
            myLuceneApp.CreateIndex(indexPath);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            foreach (string[] s in fileContent)
            {

               
                myLuceneApp.IndexText(s);

            }
            stopwatch.Stop();

            TimeSpan timeSpan = stopwatch.Elapsed;
            double time = timeSpan.Milliseconds;
            label2.Text = time + "ms";
            label3.Text = "All documents added.";
            myLuceneApp.CleanUpIndexer();






            //StartForm startForm = new StartForm(this);
            //startForm.ShowDialog();
            //this.Hide();
            /*
            this.Enabled = false;
            StartForm f = new StartForm();
            f.Show();
            f.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            */
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {


        }

        private void saveResultButton_Click(object sender, EventArgs e)
        {


        }

        private void saveResultButton_Click_1(object sender, EventArgs e)
        {

        }

        private void saveResultButton_Click_2(object sender, EventArgs e)
        {
            Stream stream;
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter =
                "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            myLuceneApp.CreateSearcher();
            Lucene.Net.Search.Query query = myLuceneApp.InfoParser(infoNeed);
            Lucene.Net.Search.TopDocs result = myLuceneApp.SearchText(query);
            string path = "";
            string oneLine = "";
            int rank = 0;
            string topicID = textBox3.Text;
            //SaveFileDialog save = new SaveFileDialog();


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                if (File.Exists(path))
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        foreach (Lucene.Net.Search.ScoreDoc scoreDoc in result.ScoreDocs)
                        {
                            rank++;
                            oneLine = topicID + "   " + "Q0" + "   " + rank + "   " + scoreDoc.Doc.ToString() + "   " + scoreDoc.Score.ToString() + "   " + "0123456798_0987654321_ourteam";
                            sw.WriteLine(oneLine);
                        }
                        sw.Flush();
                        sw.Close();
                    }
                }

                else if ((stream = saveFileDialog1.OpenFile()) != null)
                {
                    using (StreamWriter myWritter = new StreamWriter(stream))
                    {

                        foreach (Lucene.Net.Search.ScoreDoc scoreDoc in result.ScoreDocs)
                        {
                            rank++;
                            oneLine = topicID + "   " + "Q0" + "   " + rank + "   " + scoreDoc.Doc.ToString() + "   " + scoreDoc.Score.ToString() + "   " + "0123456798_0987654321_ourteam";
                            myWritter.WriteLine(oneLine);
                        }
                        myWritter.Flush();
                        myWritter.Close();

                    }
                }

            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void startIndex_Click(object sender, EventArgs e)
        {

        }
    }

}
