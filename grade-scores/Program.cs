using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections;

namespace grade_scores
{
    public class MyOutput
    {
        public static void Legend()
        {
            Console.WriteLine("Legend: {0}is error, {1}is Infomation, {2}is Exception.", s_strError, s_strInfo, s_strException);
        }

        public static void GotError(String  str)
        {
            GotError(str, "");
        }

        public static void GotError(String  strFormat, params object[] arg)
        {
            Console.WriteLine(s_strError + strFormat, arg);
        }

        public static void GotInfo(String  str)
        {
            GotInfo(str, "");
        }

        public static void GotInfo(String  strFormat, params object[] arg)
        {
            Console.WriteLine(s_strInfo+ strFormat, arg);
        }

        public static void GotException(String  str)
        {
            GotException(str, "");
        }

        public static void GotException(String  strFormat, params object[] arg)
        {
            Console.WriteLine(s_strException+ strFormat, arg);
        }

        protected static readonly String s_strError = "!: ";
        protected static readonly String s_strInfo = ">: ";
        protected static readonly String s_strException = "?: ";
    }

    public class MyStudent : IComparable
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public int Score { get; set; }

        public MyStudent(String strName, String strSurname, int nScore)
        {
            Name = strName;
            Surname = strSurname;
            Score = nScore;
        }

        public int CompareTo(object obj)
        {
            if (obj is MyStudent)
            {
                if (Score != ((MyStudent)obj).Score)
                {
                    return -Score.CompareTo(((MyStudent)obj).Score);
                }
                else
                {
                    if (Surname != ((MyStudent)obj).Surname)
                        return -String.Compare(Surname, ((MyStudent)obj).Surname, true);
                        //return -Surname.CompareTo(((MyStudent)obj).Surname);
                    else
                        return -String.Compare(Name, ((MyStudent)obj).Name, true);
                        //return -Name.CompareTo(((MyStudent)obj).Name);
                }
            }

            return 0;
        }
    }

    public class MyFile
    {
        public MyFile()
        {
            m_strPath = "";
        }

        public MyFile(String strPath)
        {
            m_strPath = strPath;
        }

        public bool Work(String strPath)
        {
            m_strPath = strPath;
            return Work();
        }
        
        public bool Work()
        {
            if (!File.Exists(m_strPath))
            {
                MyOutput.GotError("The input file does not exist.");
                return false;
            }

            ArrayList alStudent = new ArrayList();
            Encoding encoding = GetFileEncodeType();

            try
            {
                StreamReader sr = new StreamReader(m_strPath, encoding);
                String strLine = "";
                int nLineNumber = 1;

                while ((strLine = sr.ReadLine()) != null)
                {
                    MyStudent student = CheckLine(strLine, nLineNumber++);
                    if (student != null)
                        alStudent.Add(student);
                }
                sr.Close();

                alStudent.Sort();
                Print(alStudent);

                String strOutputPath = Path.GetDirectoryName(m_strPath) + "\\" +
                    Path.GetFileNameWithoutExtension(m_strPath) + "-graded.txt";// +Path.GetExtension(m_strPath);
                MyOutput.GotInfo("The output file path is {0}", strOutputPath);
                if (File.Exists(strOutputPath))
                {
                    MyOutput.GotInfo("The output file already exists. Do you wish to overwrite [y/n]?");
                    try
                    {
                        if (Console.ReadKey(true).Key.ToString().ToLower() != "y")
                        {
                            MyOutput.GotInfo("Output is canceled.");
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        MyOutput.GotException(e.Message);
                        MyOutput.GotInfo("Are you running unit test?");
                    }
                }

                FileStream fs = new FileStream(strOutputPath, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, encoding);
                foreach (MyStudent student in alStudent)
                    sw.WriteLine("{0}, {1}, {2}", student.Name, student.Surname, student.Score);
                sw.Flush();
                sw.Close();
                fs.Close();
                MyOutput.GotInfo("Finished: created {0}.", Path.GetFileName(strOutputPath));
            }
            catch (Exception e)
            {
                MyOutput.GotException(e.Message);
                return false;
            }

            return true;
        }

        protected System.Text.Encoding GetFileEncodeType()
        {
            if (m_strPath.Length > 3)
            {
                try
                {
                    FileStream fs = new FileStream(m_strPath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] buffer = br.ReadBytes(2);
                    br.Close();

                    if (buffer[0] >= 0xEF)
                    {
                        if (buffer[0] == 0xEF && buffer[1] == 0xBB)
                        {
                            MyOutput.GotInfo("The encoding is UTF8.");
                            return System.Text.Encoding.UTF8;
                        }
                        else if (buffer[0] == 0xFE && buffer[1] == 0xFF)
                        {
                            MyOutput.GotInfo("The encoding is BigEndianUnicode.");
                            return System.Text.Encoding.BigEndianUnicode;
                        }
                        else if (buffer[0] == 0xFF && buffer[1] == 0xFE)
                        {
                            MyOutput.GotInfo("The encoding is Unicode.");
                            return System.Text.Encoding.Unicode;
                        }
                    }

                    MyOutput.GotInfo("The encoding is ASCII.");
                    return System.Text.Encoding.Default;
                }
                catch (Exception e)
                {
                    MyOutput.GotException(e.ToString ());
                    MyOutput.GotInfo("Perhaps the input file is empty or does not contain valid data.");
                }
            }

            return Encoding.Default;
        }

        protected void Print(ArrayList al)
        {
            int i = 0;
            MyOutput.GotInfo("Results:");
            foreach (Object obj in al)
            {
                i++;
                if (obj is MyStudent)
                    MyOutput.GotInfo("{0,20}, {1,20}, {2,5}", ((MyStudent)obj).Name, ((MyStudent)obj).Surname, ((MyStudent)obj).Score);
                else
                    MyOutput.GotError("An invalid data was found in Print() at position {0}", i);
            }
        }

        //public MyStudent Public_CheckLine(String strLine, int nLineNumber)
        //{
        //    return CheckLine(strLine, nLineNumber);
        //}

        protected MyStudent CheckLine(String strLine, int nLineNumber)
        {
            MyOutput.GotInfo("Read #'{0}': {1}", nLineNumber, strLine);

            if (nLineNumber <= 0)
            {
                MyOutput.GotError("Got invalid line number: {1}", nLineNumber, strLine);
                return null;
            }

            if (strLine.Length < 6)
            {
                MyOutput.GotError("Got invalid data (length < 6) at #'{0}': {1}", nLineNumber, strLine);
                return null;
            }

            String[] arrLine = strLine.Split(',');
            if (arrLine.Length != 3)
            {
                MyOutput.GotError("Got invalid data (column count != 3) at #'{0}': {1}", nLineNumber, strLine);
                return null;
            }
            for (int i = 0; i < 3; i++)
                arrLine[i] = arrLine[i].Trim();

            if (!s_rgName.IsMatch(arrLine[0]))
            {
                MyOutput.GotError("Got invalid Name at #'{0}': {1}", nLineNumber, strLine);
                return null;
            }

            if (!s_rgSurname.IsMatch(arrLine[1]))
            {
                MyOutput.GotError("Got invalid Surname at #'{0}': {1}", nLineNumber, strLine);
                return null;
            }

            int nScore = 0;
            bool bValidScore = s_rgScore.IsMatch(arrLine[2]);
            if (bValidScore)
            {
                if (int.TryParse(arrLine[2], out nScore))
                {
                    if (nScore < 0 || nScore > 100) // double check
                        bValidScore = false;
                }
                else
                {
                    bValidScore = false;
                }
            }
            if (!bValidScore)
            {
                MyOutput.GotError("Got invalid Score at #'{0}': {1}", nLineNumber, strLine);
                return null;
            }

            return new MyStudent(arrLine[0], arrLine[1], nScore);
        }

        protected String m_strPath;
        static readonly Regex s_rgName = new Regex(@"^[A-Za-z ]+$");
        static readonly Regex s_rgSurname = new Regex(@"^[A-Za-z]+$");
        static readonly Regex s_rgScore = new Regex(@"^(([1-9]\d?)|(100)|(0))$");
    }

    class Program
    {
        static void Main(String [] args)
        {
            MyOutput.Legend();

            if (args.Length != 1)
            {
                MyOutput.GotError("To use this program, run from command line and enter 1 full file path as argument.\n" +
                    "For example:\ngrade-scores c:\\names.txt");
            }
            else
            {
                MyOutput.GotInfo("The input file path is {0}", args[0]);
                MyFile oMyFile = new MyFile(args[0]);
                oMyFile.Work();
            }

            try
            {
                MyOutput.GotInfo("Enter any key to exit.");
                Console.ReadKey(true);
            }
            catch (Exception e)
            {
                MyOutput.GotException(e.Message);
                MyOutput.GotInfo("Are you running unit test?");
            }
        }
    }
}
