using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrilliumTest.Extensions
{
    public static class IListExtensions
    {
        /// <summary>
        /// This assumes there is an index k such that predicate(source[i]) = false for i < k and
        /// predicate(source[i]) = true for i >= k.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int IndexForFirstTrue<T>(this IList<T> source, Func<T, bool> predicate)
        {
            int min = 0, max = source.Count - 1, diff = max - min;
            while (diff > 0)
            {
                var mid = min + diff / 2;

                if (predicate(source[mid]))
                    max = mid;
                else
                    min = mid + 1;

                diff = max - min;
            }

            return source.Count > 0 && predicate(source[min]) ? min : -1;
        }

        /// <summary>
        /// This assumes the vertices are labeled from 0 to n - 1 in the adjacency matrix.
        /// </summary>
        /// <param name="adj"></param>
        /// <returns></returns>
        public static List<int> TopologicalSort(this IList<IList<int>> adj)
        {
            var NumOfVertices = adj.Count;
            var InDegrees = new int[NumOfVertices];
            var Result = new List<int>();

            for (int u = 0; u < NumOfVertices; u++)
            {
                foreach (int itr in adj[u])
                    InDegrees[itr]++;
            }

            var TopLevelNodes = new Queue<int>();
            for (int i = 0; i < NumOfVertices; i++)
                if (InDegrees[i] == 0)
                    TopLevelNodes.Enqueue(i);

            while (TopLevelNodes.Count > 0)
            {
                int u = TopLevelNodes.Dequeue();
                Result.Add(u);

                foreach (var itr in adj[u])
                {
                    if (--InDegrees[itr] == 0)
                        TopLevelNodes.Enqueue(itr);
                }
            }

            return Result;
        }
    }
}
