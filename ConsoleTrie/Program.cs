using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public class Trie
        {
            static readonly int Alphabet_size = 26;

            public class Trienode
            {
                public Trienode[] children = new Trienode[Alphabet_size];
                public bool isendofword;

                public Trienode()
                {
                    isendofword = false;
                    for (int i = 0; i < Alphabet_size; i++)
                    {
                        children[i] = null;
                    }

                }
            };

            static Trienode root;

            static void Insert(string key)
            {
                int level;
                int length = key.Length;
                int index;

                Trienode node = root;

                for (level = 0; level < length; level++)
                {
                    index = key[level] - 'a';
                    if (node.children[index] == null)
                    {
                        node.children[index] = new Trienode();
                    }

                    node = node.children[index];

                }
                node.isendofword = true;
            }

            public static List<string> Search(string key)
            {
                List<string> names = new List<string>();
                int index;
                Trienode node = root;

                for (int i = 0; i < key.Length; i++)
                {
                    index = key[i] - 'a';
                    if (node.children[index] == null)
                    {
                        return names;
                    }
                    else
                    {
                        node = node.children[index];
                    }
                }

                if (node.isendofword)
                {
                    names.Add(key);
                }

                Findtextwords(node, key, names);
                return names;
            }

            static void Findtextwords(Trienode node, string key, List<string> names)
            {
                char[] chars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                for (int i = 0; i < 26; i++)
                {
                    if (node.children[i] != null)
                    {
                        string newKey = key + chars[i];
                        if (node.children[i].isendofword)
                        {
                            names.Add(newKey);
                        }
                        Findtextwords(node.children[i], newKey, names);
                    }
                }
            }

            public static void Main()
            {
                string[] keys = { "mark", "markus", "marcel", "marcello", "david", "davian" };

                root = new Trienode();
                int i;
                for (i = 0; i < keys.Length; i++)
                {
                    Insert(keys[i]);
                }

                string keyword = Console.ReadLine();
                var names = Search(keyword);

                foreach (var item in names)
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();

            }
        }
    }
}