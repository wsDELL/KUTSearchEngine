using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Syn.WordNet;

namespace KUTSearchEngine
{
    class WordnetSynset
    {

        private string directory;
        private WordNetEngine wordnet=new WordNetEngine();

        public WordnetSynset()
        {
            
        }

        /// <summary>
        /// create a wordnet engine 
        /// </summary>
        public void CreateWordnetEngine()
        {
            directory = GlobalData.wordnetDBPath;
            wordnet.LoadFromDirectory(directory);
        }

        /// <summary>
        /// Get the synonym set of the input word
        /// </summary>
        /// <param name="word">The word which is used for search its synonym</param>
        /// <returns> return all synonyms of the parameter "word" in an array </returns>
        public string[] GetSynnetList(string word)
        {
            var synSetList = wordnet.GetSynSets(word);
            int listNumber = synSetList.Count;
            string[] words = new[] { "" };
            if (listNumber ==0)
            {
                words[0] = word;
                return words;
            }
            else
            {
                List<string> result = synSetList[0].Words;
                for (int i = 1; i < synSetList.Count; i++)
                {
                    result = result.Union(synSetList[i].Words).ToList<string>();
                }
                words = result.ToArray();
                return words;

            }
           
        }
    }
}
