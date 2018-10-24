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
using System.Windows;
using System.Runtime.InteropServices;



namespace KUTSearchEngine
{
    public partial class Form1 : Form
    {
        private List<string[]> fileContent = new List<string[]>();
        private string indexPath = "";
        private string path = "";
        private LuceneAdvancedSearchApplication myLuceneApp = new LuceneAdvancedSearchApplication();
        private DataTable dataTable = new DataTable();
        private PageDivded pageDivded = new PageDivded();
        private int selectedItemIndex = 0;
        private string infoNeed = "";
        private List<string> file = new List<string>();
        private Dictionary<string, string[]> thesaurus = new Dictionary<string, string[]>();
        private string wordnetPath;

        public Form1()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Gain the path of source collection. divide every files in collection by delimeter and store in list
        /// </summary>
        /// <param name="collectionPath"></param>
        public void SourceCollectionPath(string collectionPath)
        {
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
        /// <summary>
        /// make sure thep position where the index will be created and then create the index. 
        /// Also calculate the total time of creating index
        /// </summary>
        /// <param name="selectedIndexPath"></param>
        public void IndexBrowse(string selectedIndexPath)
        {

            indexPath = selectedIndexPath;
            myLuceneApp.CreateIndex(indexPath);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            foreach (var s in fileContent)
            {
                myLuceneApp.IndexText(s);
            }
            stopwatch.Stop();

            TimeSpan timeSpan = stopwatch.Elapsed;
            double time = timeSpan.TotalSeconds;
            time = Math.Round(time, 4);
            toolStripStatusLabel1.Text ="Indexing time: "+ time + " s";
            label3.Text = "All documents added.";
            myLuceneApp.CleanUpIndexer();
        }

        /// <summary>
        /// Deal with the information need as suitable query
        /// search the processed query 
        /// display the result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            CleanResult();
            infoNeed = InfoNeedInput.Text;
            Stopwatch stopwatch = new Stopwatch();

            if (infoNeed == "")
            {
                MessageBox.Show("Invalid input!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InfoNeedInput.Clear();
                return;
            }


            file.Add("abstract");
            if (checkBox2.Checked)
            {
                file.Add("title");
            }
            if (checkBox3.Checked)
            {
                file.Add("author");
            }


            string[] fileChoice = file.ToArray();
            myLuceneApp.createParser(fileChoice);

            myLuceneApp.CreateSearcher();
            if (checkBox1.Checked)
            {
                infoNeed = infoNeed.Replace("\"", "");
                infoNeed = "\"" + infoNeed + "\"";
            }

            string expandedQueryItems = "";
            OptionOfQeryExpansionAndWeighterQueries(expandedQueryItems);


            stopwatch.Start();
            Lucene.Net.Search.Query query = myLuceneApp.InfoParser(infoNeed);
            string queryText = query.ToString();
            textBox2.Text = queryText;
            Lucene.Net.Search.TopDocs result = myLuceneApp.SearchText(query);
            stopwatch.Stop();

            TimeSpan timeSpan = stopwatch.Elapsed;
            double time = timeSpan.TotalSeconds;

            time = Math.Round(time, 4);
            toolStripStatusLabel2.Text = "Searching time: "+time.ToString() + "s";
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
            label6.Text = pageDivded.PageNumber();
            myLuceneApp.CleanUpSearcher();

        }
        /// <summary>
        /// display the abstract of results in a new window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            }
            myLuceneApp.CleanUpSearcher();

            AbstractView abstractView = new AbstractView();
            abstractView.ShowDialog();

        }
        /// <summary>
        /// show the result record in the first page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void firstPage_Click_1(object sender, EventArgs e)
        {
            pageDivded.currentPage = 1;
            dataGridView1.DataSource = pageDivded.LoadPage();
            label6.Text = pageDivded.PageNumber();
        }
        /// <summary>
        /// show the result record in next page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextPage_Click_1(object sender, EventArgs e)
        {
            pageDivded.currentPage++;
            dataGridView1.DataSource = pageDivded.LoadPage();
            label6.Text = pageDivded.PageNumber();
        }
        /// <summary>
        /// show the result record in previous page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousPage_Click_1(object sender, EventArgs e)
        {
            pageDivded.currentPage--;
            dataGridView1.DataSource = pageDivded.LoadPage();
            label6.Text = pageDivded.PageNumber();
        }
        /// <summary>
        /// show the result record in the last page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lastPage_Click_1(object sender, EventArgs e)
        {
            pageDivded.currentPage = pageDivded.pageCount;
            dataGridView1.DataSource = pageDivded.LoadPage();
            label6.Text = pageDivded.PageNumber();
        }

        /// <summary>
        /// save result as txt file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveResultButton_Click_2(object sender, EventArgs e)
        {
            //set paramaeter of savefiledialog
            Stream stream;
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (infoNeed == "")
            {
                MessageBox.Show("Invalid input!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InfoNeedInput.Clear();
                return;
            }

            myLuceneApp.CreateSearcher();
            Lucene.Net.Search.Query query = myLuceneApp.InfoParser(infoNeed);
            Lucene.Net.Search.TopDocs result = myLuceneApp.SearchText(query);
            string query1 = query.ToString();
            string path = "";
            string oneLine = "";
            int rank = 0;
            string topicID = textBox3.Text;
            string gropunumber = "0123456798_0987654321_ourteam";


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                path = saveFileDialog1.FileName;
                if (File.Exists(path))
                {
                    using (StreamWriter myWritter1 = File.AppendText(path))
                    {

                        foreach (Lucene.Net.Search.ScoreDoc scoreDoc in result.ScoreDocs)
                        {
                            rank++;
                            oneLine = string.Format("{0}\tQ0{1,10}\t{2,5}\t{3,15}\t{4,38}", topicID, scoreDoc.Doc.ToString(), rank, scoreDoc.Score.ToString(), gropunumber);
                            myWritter1.WriteLine(oneLine);

                        }
                        myWritter1.Flush();
                        myWritter1.Close();
                    }
                }

                else if ((stream = saveFileDialog1.OpenFile()) != null)
                {
                    using (StreamWriter myWritter2 = new StreamWriter(stream))
                    {

                        foreach (Lucene.Net.Search.ScoreDoc scoreDoc in result.ScoreDocs)
                        {
                            rank++;
                            oneLine = string.Format("{0}\tQ0{1,10}\t{2,5}\t{3,15}\t{4,38}", topicID, scoreDoc.Doc.ToString(), rank, scoreDoc.Score.ToString(), gropunumber);
                            myWritter2.WriteLine(oneLine);
                        }
                        myWritter2.Flush();
                        myWritter2.Close();

                    }
                }

            }
        }
        /// <summary>
        /// clean data in result
        /// </summary>
        private void CleanResult()
        {
            pageDivded.ClearUpDataTable();
            pageDivded.DtSource.Columns.Clear();
            dataGridView1.Columns.Clear();
            file.Clear();
            thesaurus.Clear();

        }
        /// <summary>
        /// option of query expansion and weighted queries
        /// </summary>
        /// <param name="expandedQueryItems"></param>
        private void OptionOfQeryExpansionAndWeighterQueries(string expandedQueryItems)
        {
            wordnetPath = Directory.GetCurrentDirectory() + "\\dict";
            GlobalData.wordnetDBPath = wordnetPath;
            if (checkBox4.Checked)
            {
                string[] queryExpansionTerms = infoNeed.Split(' ');
                thesaurus = myLuceneApp.CreateThesaurus(queryExpansionTerms);
                expandedQueryItems = myLuceneApp.GetExpandedQuery(thesaurus, queryExpansionTerms);
                infoNeed = expandedQueryItems;
            }
            else if (checkBox5.Checked && checkBox4.Checked)
            {
                string[] queryExpansionTerms = infoNeed.Split(' ');
                thesaurus = myLuceneApp.CreateThesaurus(queryExpansionTerms);
                expandedQueryItems = myLuceneApp.GetWeightedExpandedQuery(thesaurus, queryExpansionTerms);
                infoNeed = expandedQueryItems;
            }
            else if (checkBox5.Checked)
            {
                MessageBox.Show("You only can choose ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

<<<<<<< HEAD
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
        public bool IsEnabled { get; set; }

        public void SpellCheckExample()
        {
            StackPanel myStackPanel = new StackPanel();

            //Create TextBox
            TextBox myTextBox = new TextBox();
            myTextBox.Width = 200;

            // Enable spellchecking on the TextBox.
            myTextBox.SpellCheck.IsEnabled = true;

            // Alternatively, the SetIsEnabled method could be used
            // to enable or disable spell checking like this:
            // SpellCheck.SetIsEnabled(myTextBox, true);

            myStackPanel.Children.Add(myTextBox);
            this.Content = myStackPanel;
        }

        private void InfoNeedInput_TextChanged_1(object sender, EventArgs e)
        {

        }
=======
>>>>>>> 85e5219737b5fc37d698660606800f828e5ed347
    }

}
