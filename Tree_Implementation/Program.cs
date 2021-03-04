using System;
using System.Collections.Generic;
using Tree_Implementation.PreMadelibrary;

namespace Tree_Implementation
{
    class Program
    {



        static void Main(string[] args)
        {

            //Start the outermost List
            string fullString = "<ul>";
            

            IList<Category> listOfNodes = GetListofNodes();

            IList<Category> toplevelCategories = TreeUtility.TreeHelper.ConvertToForest(listOfNodes);

            //end the outerMost list
            fullString += "<ul/>";

            
            Console.WriteLine("end here ");
        }

        private static List<Category> GetListofNodes()
        {
            var sourceCategories = GetCategoryList();

            List<Category> categories = new List<Category>();

            foreach (var sourceCategory in sourceCategories)
            {
                //Category c = new Category();
                //c.Id = sourceCategory.Id;
                //c.CategoryName = sourceCategory.CategoryName;
                if (sourceCategory.ParentCategoryId != null)
                {
                    sourceCategory.Parent = new Category();
                    sourceCategory.Parent.Id = sourceCategory.ParentCategoryId.Value;
                }
                //categories.Add(c);

            }

            return sourceCategories;
        }

        public static List<Category> GetCategoryList()
        {
            var result = new List<Category>
            {
                new Category{ Id=1 ,  CategoryName = "Devices", ParentCategoryId =null},
                new Category{ Id=2 ,  CategoryName = "Housing", ParentCategoryId =null},

                new Category{ Id=3 ,  CategoryName = "Furniture", ParentCategoryId =2},
                new Category{ Id=4 ,  CategoryName = "Fixture", ParentCategoryId =2},
                new Category{ Id=5 ,  CategoryName = "Building Material", ParentCategoryId =2},

                new Category{ Id=6 ,  CategoryName = "Learning Material", ParentCategoryId =null},
                new Category{ Id=7 ,  CategoryName = "Books", ParentCategoryId =6},
                new Category{ Id=8 ,  CategoryName = "Supplies", ParentCategoryId =6},
                new Category{ Id=9 ,  CategoryName = "Food & Waste", ParentCategoryId =null},






            };

            return result;

        }
    }
}
