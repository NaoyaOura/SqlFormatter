using System;
using System.Linq;
using System.Text;

namespace SqlFormatter.Tools
{
    public class TabTool
    {
	    private readonly int DEFAULT_TAB_WIDTH = 4;
    	private int _tabWidth;

    	public TabTool()
    	{
    	    _tabWidth = DEFAULT_TAB_WIDTH;
    	}

	    public TabTool(int tabWidth) {
		    _tabWidth = tabWidth;
	    }


        /// <summary>
        /// タブでスペースが作成されるようにsizeを決定する
        /// example)
        ///     [hoge]  -> [hoge    ]
        ///     [hoge$] -> [hoge$   ]
        ///     [hogeho]-> [hogeho  ]
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string Pad(string param)
        {
            int size = param.Length / _tabWidth + (param.Length % _tabWidth == 0 ? 1 : 0);
            return Pad(param,size);
        }

        /// <summary>
        /// tabWidth タブ幅
        /// </summary>
        /// <param name="param"></param>
        /// <param name="size">_tabWithの倍数に満たない場合は切り捨てる</param>
        /// <returns></returns>
        public string Pad(string param, int size)
        {
            size -= size%_tabWidth;
            string expand = Tab2Space(param);
            if (expand.Length >= size)
            {
                // 埋めが不要な場合は半角スペースを追加
                return param + " ";
            }
            int delta = (size - expand.Length);
            int tabCnt = delta / _tabWidth + (delta % _tabWidth > 0 ? 1 : 0);

            string pad = string.Join("", Enumerable.Repeat("\t", tabCnt));
            return param + pad;
        }

        /// <summary>
        /// タブ→スペースに変換
        /// </summary>
        /// <param name="line">テキスト</param>
        /// <returns>スペース変換済みテキスト</returns>
        public string Tab2Space(string line)
        {
            if (line.IndexOf("\t", StringComparison.Ordinal) < 0)
            {
                return line;
            }

            int cur = 0;
            StringBuilder result = new StringBuilder(line.Length);
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (c == '\t')
                {
                    int surplus = _tabWidth - (cur % _tabWidth);
                    for (int j = 0; j < surplus; j++)
                    {
                        result.Append(" ");
                        cur++;
                    }
                }
                else
                {
                    result.Append(c);
                    cur++;
                }
            }
            return result.ToString();
        }
    }
}