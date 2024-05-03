using OceanStory.Characters;
using System.Diagnostics;
using System.Text.Json;

namespace OceanStory
{
    internal class SaveManager
    {
        public void Save(string fileName)
        {
            string directory = ".\\..\\..\\..\\sav";
            string filePath = directory + "\\" + fileName;
            string saveInfo;
            saveInfo = JsonSerializer.Serialize(Program.Character);
            saveInfo += ("\n" + JsonSerializer.Serialize(Program.Inventory));
            saveInfo += ("\n" + JsonSerializer.Serialize(Program.QuestManager));

            try
            {
                DirectoryInfo di = new DirectoryInfo(directory);
                if (!di.Exists)
                    di.Create();
                FileInfo fi = new FileInfo(filePath);
                if (fi.Exists)
                {
                    fi.Delete();
                    StreamWriter sw = new StreamWriter(filePath);
                    sw.WriteLine(saveInfo);
                    sw.Close();
                    Program.SystemMessage.SetMessage("동일한 이름의 저장 파일이 있어 덮어쓰기 하였습니다.");
                }
                else
                {
                    StreamWriter sw = new StreamWriter(filePath);
                    sw.WriteLine(saveInfo);
                    sw.Close();
                    Program.SystemMessage.SetMessage("저장했습니다.");
                }
            }
            catch (Exception e)
            {
                Program.SystemMessage.SetMessage("저장에 실패했습니다. " + e.Message);
            }
        }

        public bool Load(string fileName)
        {
            string directory = ".\\..\\..\\..\\sav";
            string filePath = directory + "\\" + fileName;
            string characterInfo, inventoryInfo, questInfo;
            DirectoryInfo di = new DirectoryInfo(directory);
            FileInfo fi = new FileInfo(filePath);
            try
            {
                if (!(di.Exists && fi.Exists))
                {
                    Program.SystemMessage.SetMessage("그런 이름의 저장 파일이 존재하지 않습니다.");
                    return false;
                }
                else
                {
                    StreamReader sr = new StreamReader(filePath);
                    characterInfo = sr.ReadLine();
                    inventoryInfo = sr.ReadLine();
                    questInfo = sr.ReadLine();
                    sr.Close();
                    Program.Character = JsonSerializer.Deserialize<Character>(characterInfo);
                    Program.Inventory = JsonSerializer.Deserialize<Inventory>(inventoryInfo);
                    Program.QuestManager = JsonSerializer.Deserialize<QuestManager>(questInfo);
                    Program.SystemMessage.SetMessage($"{fileName} 파일 불러오기에 성공했습니다.");
                    return true;
                }
            }
            catch (Exception e)
            {
                Program.SystemMessage.SetMessage("불러오기에 실패했습니다. " + e.Message);
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
