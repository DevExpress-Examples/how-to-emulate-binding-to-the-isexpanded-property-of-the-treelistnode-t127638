using System;
using System.Collections.Generic;

namespace DevExpress.Example04.Data {
    public static class DataHelper {

        public static Random r = new Random();

        public static List<Parent> GetParents(int amount) {
            List<Parent> result = new List<Parent>();
            int i = 0;
            while(i < amount) {
                var parent = new Parent() { Name = _Names[r.Next(100)], Age = r.Next(30) + 30 };
                int childrenCount = r.Next(10) + 3;
                int j = 0;
                while(j < childrenCount) {
                    var child = new Child() { Name = _Names[r.Next(100)], Age = r.Next(15) + 4 };
                    int toysCount = r.Next(15) + 2;
                    int q = 0;
                    while(q < toysCount) {
                        child.Toys.Add(new Toy() { Name = _Names[r.Next(100)] });
                        ++q;
                    }

                    parent.Children.Add(child);
                    ++j;
                }

                result.Add(parent);
                ++i;
            }

            return result;
        }

        #region Names

        private static string[] _Names = new string[]{
            "Carla Abbott",
            "Carolyn Sosa",
            "Jared England",
            "Mannix Padilla",
            "Tanek Molina",
            "Skyler Tillman",
            "Jescie Shepard",
            "TaShya Barlow",
            "Georgia Bond",
            "Keane Wynn",
            "Rylee Shaw",
            "Susan Hardy",
            "Zane Park",
            "Fay Levy",
            "Emily Lee",
            "Kerry Bowen",
            "Quinn Carson",
            "Macaulay Camacho",
            "Judith Farley",
            "Kendall Poole",
            "Macy Klein",
            "Jackson Hays",
            "Maxwell Meadows",
            "Kenyon Calhoun",
            "Hammett Murphy",
            "Thor Carr",
            "Ahmed Rowland",
            "Clark Atkinson",
            "Lunea Warner",
            "Elijah Phillips",
            "Minerva Crane",
            "Merrill Delgado",
            "Derek Manning",
            "Kyla Hoffman",
            "Emi Steele",
            "Clark Miller",
            "Darius Riley",
            "Brittany Trujillo",
            "Vernon Compton",
            "Ora Bright",
            "Whoopi Hopkins",
            "Russell Dennis",
            "Colt Whitehead",
            "Fiona English",
            "Delilah Spears",
            "Chantale Savage",
            "Kimberley Cortez",
            "Buckminster Grant",
            "Lucian Bryant",
            "Veda Dunlap",
            "Laurel Cotton",
            "Willa Roach",
            "William Delacruz",
            "Sonya Sampson",
            "Xena Burt",
            "Tarik Conrad",
            "Cullen Henson",
            "Brian Joyce",
            "Quyn Benton",
            "Fallon Edwards",
            "Neville Sutton",
            "Slade Gould",
            "Thaddeus Little",
            "Wyoming Wood",
            "Kiona Moon",
            "Erasmus Holden",
            "Portia Cross",
            "Kennan Calderon",
            "Karen Dillard",
            "Francis Jacobson",
            "Simon Bailey",
            "Zephr Jimenez",
            "Sonia Holloway",
            "Ramona Hardy",
            "Sawyer Orr",
            "Tara Ramirez",
            "Anne Hutchinson",
            "Blake Baldwin",
            "Leigh Odonnell",
            "Quail Mccormick",
            "Zachery Bean",
            "Jasmine Benjamin",
            "Kerry Guy",
            "Lance Bowers",
            "Otto Bates",
            "Dara Bowen",
            "Geraldine Simon",
            "Thaddeus Cook",
            "Lara Todd",
            "Samson Kirk",
            "William Franks",
            "Laura Burt",
            "Riley Shaw",
            "Kaitlin Reeves",
            "Linda Strickland",
            "Yetta Brown",
            "Daryl Lopez",
            "Yen Marquez",
            "Alika May",
            "Jennifer Pickett"
        };

        #endregion Names

    }
}




































































































