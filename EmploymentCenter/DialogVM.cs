using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;

namespace EmploymentCenter
{
    internal class DialogVM : INotifyPropertyChanged
    {
        private ComboBoxItem selectedTag;
        private string testList;

        public ComboBoxItem SelectedTag
        {
            get => selectedTag;
            set { selectedTag = value;
                ChangeText(selectedTag.Tag as string);
            
            }
        }

        private void ChangeText(string index)
        {
            switch (index)
            {  
                //"О занятости граждан"
                case "1":
                    TestList = "Это не противоречащая законодательству деятельность граждан, связанная с удовлетворением их " +
                        "личных и общественных потребностей и приносящая им заработок, трудовой доход.";
                    break;

                    //"О занятых гражданах"
                case "2":
                    TestList = "Занятыми считаются граждане: работающие по трудовому договору на условиях" +
                        " полного либо неполного рабочего времени, а также имеющие иную оплачиваемую работу";
                    break;

                //"Подходящая и неподходящая работа"
                case "3":
                    TestList = "Гражданам принадлежит исключительное право распоряжаться своими способностями к производительному, творческому труду. " +
                        "Принуждение к труду в какой-либо форме не допускается.";
                    break;

                
                case "4":
                    TestList = "Встать на биржу — значит получить статус безработного. Безработным платят " +
                        "пособие, помогают искать работу, освоить бесплатно новую специальность или запустить свой бизнес.";
                    break;

                case "5":
                    TestList = "В 2021 году максимальное пособие по безработице составит 12 130 Р. Деньги выплачиваются, если в течение 11 дней " +
                        "безработный не находит подходящее рабочее место.";
                    break;
                case "6":
                    TestList = "Если 2 раза отказаться от подходящей работы в течение 10 дней после регистрации в целях" +
                        " поиска подходящей работы, то человек не будет признан безработным.  ";
                    break;
            }
        }

        public string TestList { get => testList; set { testList = value; SignalChanged(); } }
       
        protected void SignalChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public DialogVM()
        {
            
        }

    }
    /*public class Tag
    {
        public string Label { get; internal set; }
        public bool Value { get; internal set; }
    }*/
}