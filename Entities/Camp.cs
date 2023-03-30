namespace XsiOv2.Entities
{

    internal class Camp
    {
        int rowNumber;
        int columnNumber;
        int content; // 0 1 2 

        public Camp (int rowNumber, int columnNumber, int content)
        {
            this.rowNumber = rowNumber;
            this.columnNumber = columnNumber;
            this.content = content;
        } 
        
        public Camp ()
        {

        }

        public int GetContent ()
        {
            return this.content;
        }

        public Camp GetCamp()
        {
            return this;
        }

        public void SetContent (int content)
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
