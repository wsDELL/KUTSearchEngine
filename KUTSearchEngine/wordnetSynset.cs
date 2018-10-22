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
        private WordNetEngine wordnet;

        public WordnetSynset()
        {
            
        }


        public void CreateWordnetEngine()
        {
            directory = Directory.GetCurrentDirectory();
            wordnet.LoadFromDirectory(directory);
        }
        public string[] GetSynnetList(string word)
        {
            var synSetList = wordnet.GetSynSets(word);
            int listNumber = synSetList.Count;
            List<string> result = synSetList[0].Words;
            for (int i = 1; i < synSetList.Count; i++)
            {
                result = result.Union(synSetList[i].Words).ToList<string>();
            }
            string[] words = result.ToArray();
            return words;
        }
    }
}
