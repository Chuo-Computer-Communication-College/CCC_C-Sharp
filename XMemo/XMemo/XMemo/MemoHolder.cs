using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMemo
{
    public class MemoHolder
    {
        public static MemoHolder Current
        {
            get;
        } = new MemoHolder();

        public Memo Memo
        {
            get;
            set;
        }
    }
}
