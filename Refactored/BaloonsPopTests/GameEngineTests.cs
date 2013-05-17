using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaloonsPop;
using System.IO;
using System.Text;

namespace BaloonsPopTests
{
    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void GameEngineTestInput()
        {


            StreamWriter writer = new StreamWriter("..\\..\\out.txt");
            StreamReader reader = new StreamReader("..\\..\\in.txt");
            
            Console.SetOut(writer);
            Console.SetIn(reader);

            GameEngine engine = new GameEngine();
            engine.Run();

            reader = new StreamReader("..\\..\\out.txt");
            StringBuilder result = new StringBuilder();

            string line;
            do
            {
                line = reader.ReadLine();
                result.AppendLine(line);
            }
            while (line != null);
             
            writer.Close();
            reader.Close();



            Assert.AreEqual(result.ToString(), line);

        }
    }
}
