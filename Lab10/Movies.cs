using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10
{
    class Movies
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private Genre catagory;
        public Genre Catagory
        {
            get { return catagory; }
            set { catagory = value; }
        }
        public Movies(string title, Genre catagory)
        {
            Title = title;
            Catagory = catagory;
        }
    }
}
