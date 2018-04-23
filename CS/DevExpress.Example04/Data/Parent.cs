using DevExpress.Mvvm;
using System.Collections.ObjectModel;

namespace DevExpress.Example04.Data {

    public class Toy : BindableBase {
        protected string _Name;
        public string Name {
            get { return this._Name; }
            set { this.SetProperty(ref this._Name, value, "Name"); }
        }

    }

    public class Child : BindableBase {
        
        protected string _Name;

        public string Name {
            get { return this._Name; }
            set { this.SetProperty(ref this._Name, value, "Name"); }
        }

        protected int _Age;
        public int Age {
            get { return this._Age; }
            set { this.SetProperty(ref this._Age, value, "Age"); }
        }

        protected bool _IsExpanded;

        public bool IsExpanded {
            get { return this._IsExpanded; }
            set { this.SetProperty(ref this._IsExpanded, value, "IsExpanded"); }
        }

        protected ObservableCollection<Toy> _Toys;

        public ObservableCollection<Toy> Toys {
            get {
                if(this._Toys == null) {
                    this._Toys = new ObservableCollection<Toy>();
                }

                return this._Toys;
            }
        }
    }
    
    public class Parent : Child {

        protected ObservableCollection<Child> _Children;

        public ObservableCollection<Child> Children {
            get {
                if(this._Children == null) {
                    this._Children = new ObservableCollection<Child>();
                }
                return this._Children;
            }
        }
    }
}
