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
        SpellChecker.Net.Search.Spell.SpellChecker spellChecker;

        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;
        public LuceneAdvancedSearchApplication()
        {
            luceneIndexDirectory = null;
            writer = null;
            //analyzer = new Lucene.Net.Analysis.SimpleAnalyzer();
            analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(VERSION);
            //analyzer = new Lucene.Net.Analysis.Snowball.SnowballAnalyzer(VERSION, "English");           
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

        public void CreateSpellChecker()
        {
            spellChecker = new SpellChecker.Net.Search.Spell.SpellChecker(luceneIndexDirectory);
        }

        public void createParser(string [] fileChoice)
        {
            parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_30, fileChoice, analyzer);
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
            searcher.Similarity = similarity;
            return results;
        }

        public SpellChecker SpellChecker()
        {

        }

        public Dictionary<string, string[]> CreateThesaurus(string[] infoqueryExpansionTerms)
        {
            Dictionary<string, string[]> thesaurus = new Dictionary<string, string[]>();
            wordnetSynset.CreateWordnetEngine();

            foreach (string word in infoqueryExpansionTerms)
            {
                string[] wordExansion= wordnetSynset.GetSynnetList(word);
                thesaurus.Add(word, wordExansion);
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

        public SpellChecker GetSpellChecker
        {
            get
            {
                return spellChecker;
            }
        }
    }
}