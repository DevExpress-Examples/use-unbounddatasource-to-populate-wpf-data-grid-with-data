using System.Collections.ObjectModel;
using System.Windows;

namespace UnboundSource {
    public partial class MainWindow : Window {

        MyViewModel vm;

        public MainWindow() {
            vm = new MyViewModel();
            InitializeComponent();
        }

        private void UnboundDataSource_ValueNeeded(object sender, DevExpress.Data.UnboundSourceValueNeededEventArgs e) {
            var ind = e.RowIndex;
            if (e.PropertyName == "UnboundFirstName") {
                e.Value = vm.ListPerson[ind].FirstName;
            }
            if (e.PropertyName == "UnboundAge") {
                e.Value = vm.ListPerson[ind].Age;
            }
            if (e.PropertyName == "UnboundGroup") {
                e.Value = vm.ListPerson[ind].Group;
            }
        }

        private void UnboundDataSource_ValuePushed(object sender, DevExpress.Data.UnboundSourceValuePushedEventArgs e) {
            var ind = e.RowIndex;
            if (e.PropertyName == "UnboundFirstName") {
                vm.ListPerson[ind].FirstName = (string)e.Value;
            }
            if (e.PropertyName == "UnboundAge") {
                vm.ListPerson[ind].Age = (int)e.Value;
            }
            if (e.PropertyName == "UnboundGroup") {
                vm.ListPerson[ind].Group = (bool)e.Value;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            unboundDataSource1.SetRowCount(10);
        }
    }

    public class MyViewModel {
        public MyViewModel() {
            CreateList();
        }
        void CreateList() {
            ListPerson = new ObservableCollection<Person>();

            for (int i = 0; i < 50; i++) {
                Person p = new Person(i);
                ListPerson.Add(p);
            }
        }
        public ObservableCollection<Person> ListPerson { get; set; }
    }

    public class Person {
        public Person(int i) {
            FirstName = "FirstName" + i;
            LastName = "LastName" + i;
            Age = i * 10;
            Group = i % 2 == 0;
        }

        public int Age { get; set; }
        public string FirstName { get; set; }
        public object Group { get; set; }
        public string LastName { get; set; }
    }
}
