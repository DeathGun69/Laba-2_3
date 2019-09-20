using System;
using System.IO;
using System.Collections.Generic;

namespace laba2_3
{
    class Program
    {
        public static List<string[]> num_array = new List<string[]>();
        static void Matrix (int n, int m)
        {
            int[,] num = new int[n, m];
            for(int i=0; i<n; i++){
                for(int j=0; j<m; j++){
                    num[i,j] = Convert.ToInt32(num_array[i][j]);
                    Console.Write(num[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nТранспонированная матрица:");

            for(int i=0; i<n; i++){
                for(int j=0; j<i; j++){
                    int result = num[i,j];
                    num[i,j] = num[j,i];
                    num[j,i] = result;
                }
            }
            
            for(int i=0; i<n; i++){
                for(int j=0; j<m; j++){
                    Console.Write(num[i,j] + " ");
                }
                Console.WriteLine();
            }  
        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\ADMIN\Documents\sergey\KPO\laba2_3\matr.txt";
            string line;
            int n = 0;
            int m = 0;


            if(File.Exists(path)){
                StreamReader stread = new StreamReader(path, System.Text.Encoding.Default);
                
                try {
                    Console.WriteLine();
                    Console.WriteLine("Файл: {0}", Path.GetFileName(path));
                    Console.WriteLine();

                    using (stread){
                        Console.WriteLine("Исходная матрица:");
                        while ((line = stread.ReadLine()) != null)
                        {
                            num_array.Add(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                        }
                    }
                    foreach (var mass_1 in num_array){
                        foreach (var mass_2 in mass_1){
                            n = num_array.Count;
                            m = mass_1.Length;
                            if (n != m) {
                                Console.WriteLine("Ошибка! Задана не квадратная матрица.");
                                stread.Close();
                                Environment.Exit(0);
                            }
                        }
                    }

                    Matrix(n, m);
                    
                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                    } finally {
                        try {
                            stread.Close();
                        } catch (Exception ex) {
                            Console.WriteLine(ex.Message);
                        }
                    }
            } else {
                Console.WriteLine("Файла {0} не существует.", Path.GetFileName(path));
            }    
        }
    }
}
