using System;
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
using Syn.WordNet;


namespace KUTSearchEngine
{
    class LuceneAdvancedSearchApplication: DefaultSimilarity
    {
        public static Lucene.Net.Store.Directory luceneIndexDirectory;
        Lucene.Net.Analysis.Analyzer analyzer;
        Lucene.Net.Index.IndexWriter writer;
        IndexSearcher searcher;
        MultiFieldQueryParser parser;
        Similarity similarity;
        WordnetSynset wordnetSynset =new WordnetSynset();

        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;

        public LuceneAdvancedSearchApplication()
        {
            luceneIndexDirectory = null;
            writer = null;
            //analyzer = new Lucene.Net.Analysis.SimpleAnalyzer();
            //analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(VERSION);
            analyzer = new Lucene.Net.Analysis.Snowball.SnowballAnalyzer(VERSION, "English");           
            similarity = new Newsimilarity();

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
            writer.SetSimilarity (similarity);
        }

        /// <summary>
        /// Indexes a given string into the index
        /// </summary>
        /// <param name="text">The text to index</param>
        public void IndexText(string[] text)
        {
            Lucene.Net.Documents.Document doc = new Document();
            Field id = new Field("id", text[0], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_OFFSETS);
            doc.Add(id);
            Field title = new Field("title", text[1], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_OFFSETS);
            doc.Add(title);
            Field author = new Field("author", text[2], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_OFFSETS);
            doc.Add(author);
            Field bibliographic = new Field("bibliographic", text[3], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_OFFSETS);
            doc.Add(bibliographic);
            Field abstractContent = new Field("abstract", text[4], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_OFFSETS);
            doc.Add(abstractContent);
            Field firstSentence = new Field("firstSentence", text[5], Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_OFFSETS);
            doc.Add(firstSentence);
            title.Boost=2.0f;
            author.Boost = 2.0f;
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


        public void createParser(string [] fileChoice)
        {
            string[] array = new string[] { "title", "author", "bibliographic", "abstract" };
            parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_30, array, analyzer);
        }

        /// <summary>
        /// Input information need and transform as query object.
        /// </summary>
        /// <param name="querytext">The text to search the index</param>
        public Query InfoParser(string infoNeed)
        {
            infoNeed = infoNeed.ToLower();
            Query query = parser.Parse(infoNeed);
            return query;
        }
        /// <summary>
        /// Search the query and return the result
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public TopDocs SearchText(Query query)
        {
            TopDocs results = searcher.Search(query, 1400);
            searcher.Similarity = similarity;
            return results;
        }
        /// <summary>
        /// Create a thesaurus dictionary for storing the synonym of query
        /// </summary>
        /// <param name="infoqueryExpansionTerms"></param>
        /// <returns></returns>
        public Dictionary<string, string[]> CreateThesaurus(string[] infoqueryExpansionTerms)
        {
            Dictionary<string, string[]> thesaurus = new Dictionary<string, string[]>();
            wordnetSynset.CreateWordnetEngine();

            foreach (string word in infoqueryExpansionTerms)
            {
                string[] wordExansion= wordnetSynset.GetSynnetList(word);
                if (thesaurus.ContainsKey(word) == true)
                {
                    continue;
                }
                else { thesaurus.Add(word, wordExansion); }
                
            }

           

            return thesaurus;
        }
        /// <summary>
        /// Expands the query with terms in the thesaurus
        /// </summary>
        /// <param name="thesaurus">A thesaurus of stems and associated terms</param>
        /// <param name="query">a query to stem</param>
        /// <returns>the query expanded with words that share the stem</returns>
        public string GetExpandedQuery(Dictionary<string, string[]> thesaurus, string[] queryExpansionTerms)
        {
            string expandedQuery = "";
            foreach(string queryTerm in queryExpansionTerms)
            {
                if (thesaurus.ContainsKey(queryTerm))
                {
                    string[] array = thesaurus[queryTerm];
                    foreach (string a in array)
                    {
                        expandedQuery += " " + a;
                    }
                }
            }
           
            return expandedQuery;
        }
        /// <summary>
        /// Expands the query with terms in the thesaurus but weights the original term the highest
        /// </summary>
        /// <param name="thesausus"></param>
        /// <param name="queryExpansionTerms"></param>
        /// <returns></returns>
        public string GetWeightedExpandedQuery(Dictionary<string, string[]> thesausus, string[] queryExpansionTerms)
        {
            string expandedQuery = "";
            foreach (string query in queryExpansionTerms)
            {
                if (thesausus.ContainsKey(query))
                {
                    bool first = true;
                    string[] array = thesausus[query];
                    foreach (string a in array)
                    {
                        expandedQuery += " " + a;
                        if (first)
                        {
                            expandedQuery += "^5";
                            first = false;
                        }
                    }
                }

            }
         
            return expandedQuery;
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


    }
}