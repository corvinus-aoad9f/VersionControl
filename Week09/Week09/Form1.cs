using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Week09.Entities;
using System.IO;

namespace Week09
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        Random rng = new Random(1234);
        List<string> lista = new List<string>();
        public Form1()
        {
            
            BirthProbabilities = ReadBirth(@"d:\Users\Peter\Downloads\születés.csv");
            DeathProbabilities = ReadDeath(@"d:\Users\Peter\Downloads\halál.csv");
            
            InitializeComponent();
            
        }

        private void Simulator()
        {
            endYearNum.Enabled = false;
            for (int year = 2005; year <= endYearNum.Value; year++)
            {

                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();
                lista.Add(
                    string.Format("Szimulációs év:{0}\n\t Fiúk:{1}\n\t Lányok:{2}\n", year, nbrOfMales, nbrOfFemales));
                DisplayText();
            }
        }

        private void SimStep(int year, Person person)
        {
            //Ha halott akkor kihagyjuk, ugrunk a ciklus következő lépésére
            if (!person.IsAlive) return;

            // Letároljuk az életkort, hogy ne kelljen mindenhol újraszámolni
            byte age = (byte)(year - person.BirthYear);

            // Halál kezelése
            // Halálozási valószínűség kikeresése
            double pDeath = (from x in DeathProbabilities
                             where x.Gender == person.Gender && x.Age == age
                             select x.P).FirstOrDefault();
            // Meghal a személy?
            if (rng.NextDouble() <= pDeath)
                person.IsAlive = false;

            //Születés kezelése - csak az élő nők szülnek
            if (person.IsAlive && person.Gender == Gender.Female)
            {
                //Szülési valószínűség kikeresése
                double pBirth = (from x in BirthProbabilities
                                 where x.Age == age
                                 select x.P).FirstOrDefault();
                //Születik gyermek?
                if (rng.NextDouble() <= pBirth)
                {
                    Person újszülött = new Person();
                    újszülött.BirthYear = year;
                    újszülött.NbrOfChildren = 0;
                    újszülött.Gender = (Gender)(rng.Next(1, 3));
                    Population.Add(újszülött);
                }
            }
        }
        public List<DeathProbability> ReadDeath(string csvpath)
        {
            List<DeathProbability> death = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    death.Add(new DeathProbability()
                    {
                        Age = int.Parse(line[1]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        P = double.Parse(line[2])
                    });
                }
            }

            return death;

        }

        public List<BirthProbability> ReadBirth(string csvpath)
        {
            List<BirthProbability> birth = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birth.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NbrOfChildren = int.Parse(line[1]),
                        P = double.Parse(line[2])
                    });
                }
            }

            return birth;
        }

        public List<Person> ReadPerson(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }

        private void startBut_Click(object sender, EventArgs e)
        {
            resultText.Clear();
            Simulator();
            DisplayText();
        }

        private void DisplayText()
        {
            for (int i = 0; i < lista.Count; i++)
            {
                resultText.Text += lista[i];
            }
        }

        private void browseBut_Click(object sender, EventArgs e)
        {
            using (openFileDialog1)
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "*CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Population = ReadPerson(openFileDialog1.FileName);
                    personText.Text = openFileDialog1.FileName;
                }

            }
            
            startBut.Enabled = true;

        }
    }
}
