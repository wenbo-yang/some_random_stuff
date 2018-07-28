using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 212 
// 211 can use dfs
namespace TrieTreeSearch
{
    class Program
    {
        class Trie
        {
            class TrieNode
            {
                public TrieNode()
                {
                    children = new TrieNode[26];
                    is_word = false;
                }
                public bool is_word;
                public TrieNode[] children;
            }

            private TrieNode root;

            /** Initialize your data structure here. */
            public Trie()
            {
                root = new TrieNode();
            }

            /** Inserts a word into the trie. */
            public void insert(String word)
            {
                TrieNode p = root;
                for (int i = 0; i < word.Length; i++)
                {
                    int index = (int)(word[i] - 'a');
                    if (p.children[index] == null)
                        p.children[index] = new TrieNode();
                    p = p.children[index];
                }
                p.is_word = true;
            }

            /** Returns if the word is in the trie. */
            public bool search(String word)
            {
                TrieNode node = find(word);
                return node != null && node.is_word;
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool startsWith(String prefix)
            {
                TrieNode node = find(prefix);
                return node != null;
            }

            private TrieNode find(String prefix)
            {
                TrieNode p = root;
                for (int i = 0; i < prefix.Length; i++)
                {
                    int index = (int)(prefix[i] - 'a');
                    if (p.children[index] == null) return null;
                    p = p.children[index];
                }
                return p;
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
