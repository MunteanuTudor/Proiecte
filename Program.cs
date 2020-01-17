using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OpNumereMari
{

    class Program
    {

        static void Main(string[] args)
        {
            TextReader TxtR = new StreamReader(@"..\..\datetxt.txt");

            string numar = TxtR.ReadLine();
            int[] A = new int[numar.Length];
            StringToInt(A, numar);

            numar = TxtR.ReadLine();
            int[] B = new int[numar.Length];
            StringToInt(B, numar);

            Afisare(A);
            Afisare(B);
            
            string Op = TxtR.ReadLine();
            if (Op[0] == '+') { Console.Write("A + B = "); SumaAB(A, B); }            
            if (Op[0] == '-') { Console.Write("A - B ( A>=B )= "); DifAB(A, B); }
            if (Op[0] == '*') { Console.Write("A * B = "); ProdusAB(A, B); }                  

            Console.ReadKey();
        }

        private static void StringToInt(int[] V, string numar) //Done
        {
            int k = 0;
            for (int i = numar.Length - 1; i >= 0; i--)
                V[k++] = Convert.ToInt32(numar[i] - '0');
        }
        private static void Afisare(int[] V) //Done
        {
            bool ok = false;
            for (int i = 0; i < V.Length; i++)
                if (V[i] != 0)
                { ok = true; break; }
            if (ok == false)
            { Console.Write(V[0] + " "); return; }

            
                int k = V.Length - 1;
                while (V[k] == 0)
                    k--;
                for (int i = k; i >= 0; i--)
                    Console.Write(V[i]);
            

            Console.WriteLine();
        } 

        private static void ProdusABX(int[] A, int[] B) //done 
        {
            int[] C = new int[A.Length + B.Length + 2];
            int tr = 0;

            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < B.Length; i++)
            {
                tr = 0;
                for (int j = 0; j < A.Length; j++)
                {
                    tr = tr + A[j] * B[i];
                    C[j] += tr % 10;
                    tr /= 10;
                }
                if (tr != 0)
                    C[A.Length + i - 1] += tr % 10;

                for (int ll = 0; ll < C.Length; ll++)
                    Console.Write(C[ll]);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < C.Length; i++)
                Console.Write(C[i]);
            Console.WriteLine();
            Afisare(C);
        }

        private static void SumaABi(int[] X, int[] C, int ci) //Done
        {
            int tr = 0;
            for (int i = 0; i < X.Length; i++)
            {
                tr = C[ci+i] + X[i] + tr;
                C[ci+i] = tr % 10;
                tr = tr / 10;
            }

            if (tr != 0)
                C[C.Length - 1] = tr;
        }
        private static void ProdusAB(int[] A, int[] B) //Done
        {
            if ((A.Length == 1 && A[0] == 0) || (B.Length == 1 && B[0] == 0))
            { Console.Write("0"); return; }

            int[] C = new int[A.Length + B.Length + 1];
            int tr = 0;
            for (int i = 0; i < B.Length; i++)
            {
                int[] X = new int[Math.Max(A.Length, B.Length) + 1];
                tr = 0;
                for (int j = 0; j < A.Length; j++)
                {
                    tr = tr + A[j] * B[i];
                    X[j] = tr % 10;
                    tr /= 10;
                }
                if (tr != 0)
                    X[A.Length] += tr % 10;
                SumaABi(X, C, i);
            }
           Afisare(C);
        }

        private static void SumaAB(int[] A, int[] B) //Done
        {
            int[] C = new int[Math.Max(A.Length, B.Length) + 1];
            int tr = 0;
            for (int i = 0; i < Math.Min(A.Length, B.Length); i++)
            {
                tr = A[i] + B[i] + tr;
                C[i] = tr % 10;
                tr = tr / 10;
            }

            if (A.Length > B.Length)
                for (int i = B.Length; i < A.Length; i++)
                {
                    tr = A[i] + tr;
                    C[i] = tr % 10;
                    tr = tr / 10;
                }
            else
                for (int i = A.Length; i < B.Length; i++)
                {
                    tr = B[i] + tr;
                    C[i] = tr % 10;
                    tr = tr / 10;
                }

            if (tr != 0)
                C[C.Length - 1] = tr;
            Afisare(C);
        }

        private static void DifAB(int[] A, int[] B) //Done
        {
            int tr = 0;
            int[] C = new int[A.Length + B.Length + 1];
            for (int i = 0; i < A.Length && i<B.Length; i++)
                if (A[i] - B[i] >= 0)
                    C[i] = A[i] - B[i];
                else
                {
                    int pls=i+1;
                    while (A[pls] == 0)
                        A[pls++]=9;
                    A[pls] -= 1;
                    C[i] = 10 - B[i] + A[i];
                }
            if(B.Length!=A.Length)
                for (int i = B.Length ; i < A.Length; i++)
                    C[i] = A[i];

            Afisare(C);
                
            
        }
    }
}
