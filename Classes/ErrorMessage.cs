using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRent.Classes
{
    public class ErrorMessage
    {
        public DateTime DateError { get; set; }
        public Exception Message { get; set; }
        public string Source { get; set; }
        public ErrorMessage(DateTime DateError,Exception ErrorMessage,string Source) 
        {
            this.DateError = DateError;
            this.Message = ErrorMessage;
            this.Source = Source;
        }
        public static void ShowLastError(MainWindow mainWindow)
        {
            var SortedList = mainWindow.Errors.OrderBy(si => si.DateError).ToList();
            if (SortedList.Count != 0) MessageBox.Show(SortedList[SortedList.Count-1].Message.Message.ToString() +" "+ SortedList[SortedList.Count - 1].DateError.ToString(), SortedList[SortedList.Count - 1].Source);
            else MessageBox.Show("За последнее время не было ошибок");
        }
    }
}
