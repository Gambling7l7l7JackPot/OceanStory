namespace OceanStory
{
    // 콘솔에서 현재 커서 아래에 메시지 출력
    internal class SystemMessage
    {
        public string message = "";
        public SystemMessage() { }

        public void SetMessage(string message)
        {
            this.message = message + "\n";
        }

        public void PrintMessage()
        {
            int currentCursor = Console.GetCursorPosition().Top;
            Console.SetCursorPosition(0, currentCursor + 4);
            Console.Write(message);
           Console.SetCursorPosition(0, currentCursor);
            message = "";
        }
    }
}
