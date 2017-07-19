using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Task
{
    class Program
    {
        struct City
        {
            public string Name;
            public int Area;
            public int Population;
        }

        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            string[] splitedStrs = new string[0];
            City[] inputCity;
            string tmp = string.Empty; ;

            for (int i = 0, j = 0; i < inputString.Length; i++)
            {
                if (inputString[i] != ';')
                {
                    tmp += inputString[i];
                }
                else
                {
                    string[] tmpArr = new string[splitedStrs.Length + 1];
                    for (int k = 0; k < splitedStrs.Length; k++)
                    {
                        tmpArr[k] = splitedStrs[k]; 
                    }
                    splitedStrs = tmpArr;
                    splitedStrs[j++] = tmp;
                    tmp = string.Empty;
                }

            }


            inputCity = new City[splitedStrs.Length];
            string nameTmpStr;
            string areaTmpStr;
            string populTmpStr;
            for (int i = 0, j = 0, k = 0; i < inputCity.Length; i++)
            {
                nameTmpStr = string.Empty;
                for (j = 0; j < splitedStrs[i].Length; j++)
                {
                    if (splitedStrs[i][j] != '=')
                    {
                        nameTmpStr += splitedStrs[i][j];
                    }
                    else
                    {
                        inputCity[i].Name = nameTmpStr;
                        break;
                    }
                }

                populTmpStr = string.Empty;
                for (k = j + 1; k < splitedStrs[i].Length; k++)
                {
                    if (splitedStrs[i][k] != ',')
                    {
                        populTmpStr += splitedStrs[i][k];
                    }
                    else
                    {
                        inputCity[i].Population = int.Parse(populTmpStr);
                        break;
                    }
                }

                areaTmpStr = string.Empty;
                for (int l = k + 1; l < splitedStrs[i].Length; l++)
                {
                    areaTmpStr += splitedStrs[i][l];
                }
                inputCity[i].Area = int.Parse(areaTmpStr);
            }

            for (int i = 0; i < inputCity.Length; i++)
            {
                double density = (double)inputCity[i].Population / inputCity[i].Area;
                Console.WriteLine("Density:" + inputCity[i].Name);
                Console.WriteLine(density);
            }

            int maxNameLength = 0;
            int maxPopul = 0;
            for (int i = 0; i < inputCity.Length; i++)
            {
                if (inputCity[i].Population > maxPopul)
                    maxPopul = inputCity[i].Population;
            }

            for (int i = 0; i < inputCity.Length; i++)
            {
                if (inputCity[i].Name.Length > maxNameLength)
                    maxNameLength = inputCity[i].Name.Length;
            }

            for (int i = 0; i < inputCity.Length; i++)
            {
                if (inputCity[i].Population == maxPopul)
                    Console.WriteLine("Most Populated City : " + inputCity[i].Name);
                if(inputCity[i].Name.Length == maxNameLength)
                    Console.WriteLine("Largest name lenght City: " + inputCity[i].Name);

            }
        }
    }
}
