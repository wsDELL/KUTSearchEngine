﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis; // for Analyser
using Lucene.Net.Documents; // for Document and Field
using Lucene.Net.Index; //for Index Writer
using Lucene.Net.Store; //for Directory
using Lucene.Net.Search; // for IndexSearcher
using Lucene.Net.QueryParsers;  // for QueryParser
using Lucene.Net.Analysis.Snowball; // for snowball analyser 

namespace KUTSearchEngine
{
    class LuceneAdvancedSearchApplication
    {
        Lucene.Net.Store.Directory luceneIndexDirectory;
        Lucene.Net.Analysis.Analyzer analyzer;
        Lucene.Net.Index.IndexWriter writer;
        IndexSearcher searcher;
        QueryParser parser;
       
        

        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;
        const string TEXT_FN = "abstract";


        public LuceneAdvancedSearchApplication()
        {
            luceneIndexDirectory = null;
            writer = null;
            //analyzer = new Lucene.Net.Analysis.SimpleAnalyzer();
            analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(VERSION);
            //analyzer = new Lucene.Net.Analysis.Snowball.SnowballAnalyzer(VERSION, "English");
            parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, TEXT_FN, analyzer);

        }
        /// <summary>
        /// Creates the index at a given path
        /// </summary>
        /// <param name="indexPath">The pathname to create the index</param>
        public void CreateIndex(string indexPath)
        {

            luceneIndexDirectory = Lucene.Net.Store.FSDirectory.Open(indexPath);
            IndexWriter.MaxFieldLength mfl = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);
            writer = new Lucene.Net.Index.IndexWriter(luceneIndexDirectory, analyzer, true, mfl);
        }

        /// <summary>
        /// Indexes a given string into the index
        /// </summary>
        /// <param name="text">The text to index</param>
        public void IndexText(string[] text)
        {
            Lucene.Net.Documents.Document doc = new Document();



            doc.Add(new Field("id", text[0], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES));
            doc.Add(new Field("title", text[1], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES));
            doc.Add(new Field("author", text[2], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES));
            doc.Add(new Field("bibliographic", text[3], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES));
            doc.Add(new Field("abstract", text[4], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES));
            doc.Add(new Field("firstSentence", text[5], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES)); 
            writer.AddDocument(doc);
        }

        /// <summary>
        /// Flushes the buffer and closes the index
        /// </summary>
        public void CleanUpIndexer()
        {
            writer.Optimize();
            writer.Flush(true, true, true);
            writer.Dispose();
        }


        /// <summary>
        /// Creates the searcher object
        /// </summary>
        public void CreateSearcher()
        {
            searcher = new IndexSearcher(luceneIndexDirectory);
        }

        /// <summary>
        /// Searches the index for the querytext
        /// </summary>
        /// <param name="querytext">The text to search the index</param>
        public Query InfoParser(string infoNeed)
        {
            
            infoNeed = infoNeed.ToLower();
            Query query = parser.Parse(infoNeed);
            return query;
        }

        public TopDocs SearchText(Query query)
        {


            TopDocs results = searcher.Search(query, 1400);

            return results;


        }

        public void DisplayOneResult(TopDocs results, Query query)
        {

            System.Console.WriteLine("Number of results is " + results.TotalHits);
            int rank = 0;
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                rank++;
                Lucene.Net.Documents.Document doc = searcher.Doc(scoreDoc.Doc);
                string myFieldValue = doc.Get(TEXT_FN).ToString();
                Console.WriteLine("Rank: " + rank + " text: " + myFieldValue + " Score: " + scoreDoc.Score + " Doc-id: " + scoreDoc.Doc);
                Explanation explanation = searcher.Explain(query, scoreDoc.Doc);
                Console.WriteLine(explanation.ToString());

            }

        }

        public Searcher GetSearcher 
        {
            get
            {
                return searcher;
            }
        }

        /// <summary>
        /// Closes the index after searching
        /// </summary>
        public void CleanUpSearcher()
        {
            searcher.Dispose();
        }
        /*
        public Directory LuceneIndexDirectory
        {
            get
            {
                return luceneIndexDirectory;
            }
            set
            {
                luceneIndexDirectory = value;
            }
        }

        static void Main(string[] args)
        {

            System.Console.WriteLine("Hello Lucene.Net");

            LuceneApplication myLuceneApp = new LuceneApplication();
            string indexPath = @"C:\Lucene\MyIndex";
            LuceneApplication luceneApplication = new LuceneApplication();
            luceneApplication.OpenIndex(indexPath);

            luceneApplication.CreateAnalyser();
            luceneApplication.CreateWriter();

            string text = "The Daily Star";
            luceneApplication.IndexText(text);
            luceneApplication.CleanUp();





            System.Console.ReadLine();
        }
        */
    }
}