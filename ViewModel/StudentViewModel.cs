using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Student> Students { get; set; }

        public RelayCommand AddStudentCommand { get; set; }
        public RelayCommand RemoveStudentCommand { get; set; }

        public StudentViewModel()
        {
            Students = new ObservableCollection<Student>();
            CurrentStudent = new Student();

            AddStudentCommand = new RelayCommand(AddStudent);
            RemoveStudentCommand = new RelayCommand(RemoveStudent);
        }

        public Student CurrentStudent
        {
            get
            {
                return _student;
            }
            set
            {
                _student = value;
                OnPropertyChanged(nameof(CurrentStudent));
            }
        }
        public Student _student { get; set; }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RemoveStudent()
        {
            Students.Remove(CurrentStudent);
            CurrentStudent = new Student();
        }

        private void AddStudent()
        {
            CurrentStudent = new Student();
            Students.Add(CurrentStudent);
        }
    }
}
