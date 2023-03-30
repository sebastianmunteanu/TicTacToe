using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace XsiOv2.Entities
{   

    internal class Camp
    {
        int rowNumber;
        int columnNumber;
        string content; // -1 0 1 

        public Camp (int rowNumber, int columnNumber, string content)
        {
            this.rowNumber = rowNumber;
            this.columnNumber = columnNumber;
            this.content = content;
        } 
        
        public Camp ()
        {

        }

        public string GetContent ()
        {
            return this.content;
        }

        public Camp GetCamp()
        {
            return this;
        }

        public void SetContent (string content)
        {
            this.content = content;
        }

        public int GetRow()
        {
            return rowNumber;
        }

        public int GetColumn()
        {
            return columnNumber;
        }
    }
}
