using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNunit
{
    class Program
    {
        public int CheckPuls()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "DateSenzori.txt");
            string pulsCitit;
            char[] constrPuls = new char[4];
            int k = 0;
            int i = 0;
            int nrPuls = 0;
            int avarieP = 0;
            char[] aux = new char[211];
            if (File.Exists(filename))
            {
                using (var streamReader = new StreamReader(filename))
                {
                    pulsCitit = streamReader.ReadToEnd();
                    aux = pulsCitit.ToCharArray();
                    for (int j = 0; j < aux.Length - 1; j++)
                    {
                        if (aux[j] == 'P')
                        {
                            nrPuls = 0;
                            k = j;
                            while (i != 3)
                            {
                                k++;
                                if (k == 11 || aux[k] == 'E')
                                {
                                    avarieP = 1;
                                    break;
                                }
                                if (aux[k] >= '0' && aux[k] <= '9')
                                {
                                    constrPuls[i] = aux[k];
                                    i++;
                                }
                            }
                            if (constrPuls.Length >= 2)
                            {
                                int iter = 0;
                                while (constrPuls[iter] != '\0')
                                    iter++;
                                if (iter == 2)
                                {
                                    nrPuls = (constrPuls[0] - '0') * 10 + (constrPuls[1] - '0');
                                }
                                else if (iter == 3)
                                {
                                    nrPuls = (constrPuls[0] - '0') * 100 + (constrPuls[1] - '0') * 10 + (constrPuls[2] - '0');
                                }
                                streamReader.Close();
                                return 1;
                            }
                            if (avarieP == 1)
                            {
                                streamReader.Close();
                                avarieP = 0;
                                return 0;
                            }
                            avarieP = 0;
                        }
                    }
                    if (k == 0)
                    {
                        streamReader.Close();
                    }
                    return 0;
                }
            }
            return 0;
        }


        static void Main(string[] args)
        {
        }
    }
}
