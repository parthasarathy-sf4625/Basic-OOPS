using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Threading.Tasks;

namespace SyncfusionLibrary
{
    public class BookDetails
    {
        /*Properties:
1.	BookID (Auto Increment - BID1000)
2.	BookName
3.	AuthorName
4.	BookCount
*/      
        //Fields
        private static int s_bookID = 1000; // Auto- increment ID

        //Properties

        public string BookID{get;} //Auto- Propperty
        public string BookName{get;set;}
        public string AuthorName{get;set;}
        public int BookCount {get;set;}

        //Constructor
        public BookDetails(string bookName,string authorName,int bookCount)
        {
            BookID = "BID"+(++s_bookID);
            BookName = bookName;
            BookCount = bookCount;
            AuthorName =authorName;
            
        }
    }
}